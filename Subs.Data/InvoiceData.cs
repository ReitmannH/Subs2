using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Subs.Data
{


    public class InvoiceData
    {
        #region Globals and constructors

        [Serializable]
        public class InvoiceSubscription
        {
            public int SubscriptionId;
            public int TransactionId;
        }

        [Serializable]
        public class InvoiceDirective
        {
            public int PayerId;
            public int InvoiceId;
            public string EMailAddress;
            public List<InvoiceSubscription> Subscriptions;
        }

        private List<InvoiceRaw> gRawInvoices;
        private readonly List<InvoiceDirective> gInvoiceDirectives = new List<InvoiceDirective>();
        private static MIMSDataContext gMimsDataContext = new MIMSDataContext(Settings.ConnectionString);


        public InvoiceData(int pFromTransactionId)
        {
            // Load the raw data
            Generate(pFromTransactionId);
        }
        #endregion

        #region Public properties

        public int NumberOfRawElements
        {
            get { return gRawInvoices.Count; }
        }

        #endregion

        #region Batch operation

        public void Generate(int pFromTransactionId)
        {
            try
            {
                MIMSDataContext lContext = new MIMSDataContext(Settings.ConnectionString);
                gRawInvoices = lContext.MIMS_InvoiceData_Generate(pFromTransactionId).ToList();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Generate", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                throw ex;
            }
        }

        private InvoiceDirective InitialiseDirective(InvoiceRaw pInvoiceRaw)
        {

            InvoiceDirective lDirective = new InvoiceDirective()
            {
                InvoiceId = AdministrationData2.GetInvoiceId(),
                PayerId = pInvoiceRaw.PayerId,
                Subscriptions = new List<InvoiceSubscription>()
            };

            try
            {
                lDirective.Subscriptions.Add(new InvoiceSubscription() { SubscriptionId = pInvoiceRaw.SubscriptionId, TransactionId = pInvoiceRaw.TransactionId });
                return lDirective;
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "InitialiseDirective", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return lDirective;
            }
        }


        public void ConvertToDirectives()
        {
            try
            {
                if (NumberOfRawElements == 0)
                {
                    throw new Exception("Nothing to convert");
                }

                //Assign the invoice numbers

                int lCurrentPayerId = 0;
                int lLargestTransactionId = 0;
                InvoiceRaw lInvoiceRawArgument;
                InvoiceDirective lCurrentDirective = new InvoiceDirective();

                foreach (InvoiceRaw lInvoiceRaw in gRawInvoices)
                {
                    if (lInvoiceRaw.TransactionId > lLargestTransactionId) { lLargestTransactionId = lInvoiceRaw.TransactionId; }
                    lInvoiceRawArgument = lInvoiceRaw;

                    if (lCurrentPayerId == 0)
                    {
                        lCurrentDirective = InitialiseDirective(lInvoiceRawArgument);
                        lCurrentPayerId = lInvoiceRaw.PayerId;
                    }
                    else
                    {
                        if (lInvoiceRaw.PayerId != lCurrentPayerId)
                        {
                            // This is a new invoice, so persist the previous directive 
                            this.Add(lCurrentDirective);
                            this.Persist(lCurrentDirective);

                            // Initialise a new directive
                            lCurrentDirective = InitialiseDirective(lInvoiceRawArgument);
                            lCurrentPayerId = lInvoiceRaw.PayerId;
                        }
                        else
                        {
                            // Add a subscription to the current directive
                            lCurrentDirective.Subscriptions.Add(new InvoiceSubscription() { SubscriptionId = lInvoiceRaw.SubscriptionId, TransactionId = lInvoiceRaw.TransactionId });
                        }
                    }

                } // End of foreach loop - one loop per transaction


                //Keep track of the last transactionid

                if (!CounterData.SetValue("LastTransactionIdInvoice", lLargestTransactionId))
                {
                    return;
                }
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ConvertToDirective", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                throw ex;
            }

        }

        private void Add(InvoiceDirective pInvoiceDirective)
        {
            // Prepare for batch XML
            gInvoiceDirectives.Add(pInvoiceDirective);
        }



        public void WriteToXML(string pFilePath)
        {





        }


        public void ReadFromXML(string pFilePath)
        {

        }


        #endregion

        #region Single directive operations

        public static decimal ActiveSubscriptionsBefore(DateTime pDate, int pPayerId)
        {
            MIMS_InvoiceData_ActiveSubscriptionsBeforeResult lResult = (MIMS_InvoiceData_ActiveSubscriptionsBeforeResult)gMimsDataContext.MIMS_InvoiceData_ActiveSubscriptionsBefore(pDate, pPayerId).Single();
            return (int)lResult.Column1;
        }



        private void Persist(InvoiceDirective pDirective)
        {
            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = Settings.ConnectionString;
            SqlTransaction lTransaction;
            lConnection.Open();
            lTransaction = lConnection.BeginTransaction("Persist");

            try
            {
                XmlSerializer lSerializer = new XmlSerializer(typeof(InvoiceDirective));
                MemoryStream lMemoryStream = new MemoryStream();
                lSerializer.Serialize(lMemoryStream, pDirective);
                int lLengthOfMemoryStream = (int)lMemoryStream.Length;
                byte[] lByteArray = new byte[lLengthOfMemoryStream];
                lMemoryStream.Write(lByteArray, 0, (int)lMemoryStream.Length);
                if (!LedgerData.InvoiceDirective(ref lTransaction, pDirective.InvoiceId, lByteArray))
                {
                    lTransaction.Rollback("Persist");
                    throw new Exception("Error in persisting directive for invoice " + pDirective.InvoiceId.ToString());
                }

                // 2. Persist to SubscriptionTable

                decimal lInvoiceValue = 0;
                foreach (InvoiceSubscription lSubscription in pDirective.Subscriptions)
                {
                    SubscriptionData3 lSubscriptionData = new SubscriptionData3(lSubscription.SubscriptionId);
                    lSubscriptionData.InvoiceId = pDirective.InvoiceId;

                    if (!lSubscriptionData.UpdateInTransaction(ref lTransaction))
                    {
                        lTransaction.Rollback("Persist");
                        throw new Exception("Error in persisting directive for invoice " + pDirective.InvoiceId.ToString());
                    }

                    lInvoiceValue = lInvoiceValue + lSubscriptionData.UnitPrice * lSubscriptionData.UnitsPerIssue * lSubscriptionData.NumberOfIssues;
                }


                // 3.   Persist to Transactions table

                if (!LedgerData.Invoice(ref lTransaction, pDirective.PayerId, pDirective.InvoiceId, 0, lInvoiceValue))
                {

                    lTransaction.Rollback("Persist");
                    throw new Exception("Error in persisting directive for invoice " + pDirective.InvoiceId.ToString());
                }

                lTransaction.Commit();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Persist", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                throw ex;
            }
        }

        #endregion

    }
}
