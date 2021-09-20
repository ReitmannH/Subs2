using Subs.Data;
using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Subs.Presentation
{

    public partial class SubscriptionStatusPrintControl : UserControl
    {
        #region Global variables
       
        private readonly Subs.Data.SubscriptionDoc3TableAdapters.SubscriptionIssueTableAdapter lAdapterSubscriptionIssue
                    = new Subs.Data.SubscriptionDoc3TableAdapters.SubscriptionIssueTableAdapter();
        private readonly Subs.Data.LedgerDoc2TableAdapters.TransactionHistoryTableAdapter lAdaptorTransactionHistory =
                   new Subs.Data.LedgerDoc2TableAdapters.TransactionHistoryTableAdapter();
        private SubscriptionData3 gSubscriptionData;
        private readonly SubscriptionDoc3 gDataset = new SubscriptionDoc3();
        private readonly LedgerDoc2 gLedgerDoc = new LedgerDoc2();

        #endregion

        #region Construction
        public SubscriptionStatusPrintControl()
        {
            InitializeComponent();
            try
            {
                lAdapterSubscriptionIssue.AttachConnection();
                lAdaptorTransactionHistory.AttachConnection();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SubscriptionStatusDisplayControl", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }
        }

        private void Load(int pSubscriptionId)

        {
            try
            {


                // Populate Subscription

                gSubscriptionData = new SubscriptionData3(pSubscriptionId);
                Basic.DataContext = (object)gSubscriptionData;

                // Populate SubscriptionIssues

                lAdapterSubscriptionIssue.FillById(gDataset.SubscriptionIssue, pSubscriptionId, "BySubscription");
                Issues.DataContext = gDataset.SubscriptionIssue;

                // History

                lAdaptorTransactionHistory.FillBy(gLedgerDoc.TransactionHistory, pSubscriptionId);

                foreach (LedgerDoc2.TransactionHistoryRow lRow in gLedgerDoc.TransactionHistory)
                {
                    if (lRow.Operation == 22)
                    {
                        // this is a creditnote
                        lRow.CreditValue = -lRow.Value;
                    }
                }

                History.ItemsSource = gLedgerDoc.TransactionHistory;
                this.Refresh();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Load", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }

        }

        #endregion

        #region Properties - public

        public static readonly DependencyProperty SubscriptionIdProperty;

        static SubscriptionStatusPrintControl()
        {
            FrameworkPropertyMetadata lMetaData = new FrameworkPropertyMetadata(new PropertyChangedCallback(SubscriptionChanged));
            SubscriptionStatusPrintControl.SubscriptionIdProperty = DependencyProperty.Register("SubscriptionId", typeof(int), typeof(SubscriptionStatusPrintControl), lMetaData);
        }

        private static void SubscriptionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if ((int)e.NewValue == -1)
            {
                return;
            }

            SubscriptionStatusPrintControl lControl = (SubscriptionStatusPrintControl)o;
            lControl.Load((int)e.NewValue);
        }

        public int SubscriptionId
        {
            get
            {
                return (int)GetValue(SubscriptionStatusPrintControl.SubscriptionIdProperty);
            }

            set
            {
                SetValue(SubscriptionStatusPrintControl.SubscriptionIdProperty, value);
            }
        }

        #endregion

        #region Event handlers

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog lPrintDialog = new PrintDialog();
                lPrintDialog.UserPageRangeEnabled = true;

                if (lPrintDialog.ShowDialog() == true)
                {
                    lPrintDialog.PrintDocument(
                         ((IDocumentPaginatorSource)gFlowDocument).DocumentPaginator, "SubscriptionStatusDisplayControl");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Print_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);


            }
        }

        private string SendEmail(MemoryStream pStream)
        {
            try
            {
                CustomerData3 lCustomerData = new CustomerData3(gSubscriptionData.ReceiverId);


                SmtpClient myClient = new SmtpClient();
                MailMessage myMessage = new MailMessage("vandermerwer@timesmedia.co.za", lCustomerData.EmailAddress);
                Attachment myAttachment = new Attachment(pStream, "SubscriptionStatus.pdf", MediaTypeNames.Application.Pdf);
                myMessage.Attachments.Add(myAttachment);
                myMessage.Subject = "Status of subscription = " + gSubscriptionData.SubscriptionId.ToString();
                string myBody = "Dear Client\n\n"
 + "Attached herewith your subscription status.\n\n"
 + "We trust that this will improve the quality of our service and look forward to a long-lasting relationship with you.\n\n"
 + "Best\n\n"
 + "Riëtte van der Merwe\n"
 + "Subscription and Marketing Manager\n"
 + "Tel: (011) 280-5856\n"
 + "Fax: (086) 675 7910\n"
 + "E-mail: vandermerwer@tisoblackstar.co.za\n\n"
 + "Hill on Empire, 16 Empire Rd (cnr Hillside Rd), ParkTown, Johannesburg, 2193\n"
 + "P O Box 1746, Saxonworld, Johannesburg, 2132\n"
 + "www.mims.co.za";

                myMessage.Body = myBody;
                myClient.Host = Settings.EMailHostIp;
                myClient.UseDefaultCredentials = true;
                myClient.Send(myMessage);

                MessageBox.Show("Email has been sent successfully");
                return "OK";
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SendEmail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "Error sending Emial " + ex.Message;
            }
        }

        private void Email_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] lBuffer = FlowDocumentConverter.PdfConverter.ConvertDoc(gFlowDocument);

                using (MemoryStream lStream = new System.IO.MemoryStream(lBuffer, true))
                {

                    lStream.Write(lBuffer, 0, lBuffer.Length);
                    lStream.Position = 0;

                    {
                        string lResult;

                        if ((lResult = SendEmail(lStream)) != "OK")
                        {
                            MessageBox.Show(lResult);
                            return;
                        }
                    }
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "EMail Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
