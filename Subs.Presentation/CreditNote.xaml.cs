﻿using Subs.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Subs.Presentation
{
    public partial class CreditNote : Window
    {
        #region Globals
        private LedgerDoc2 gLedgerDoc = new LedgerDoc2();
        private CustomerData3 gCustomerData;
        private IEnumerable<MIMS_LedgerDoc_CreditNoteBatch_LoadResult> gListing;
        #endregion

        #region Window management

        public CreditNote()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var lContext = new MIMSDataContext(Settings.ConnectionString);
                var lCreditNotes = from lValues in lContext.MIMS_LedgerDoc_CreditNoteBatch_Load()
                                   select lValues;
                gListing = (IEnumerable<MIMS_LedgerDoc_CreditNoteBatch_LoadResult>)lCreditNotes.ToList<MIMS_LedgerDoc_CreditNoteBatch_LoadResult>();
                DataGridListing.ItemsSource = gListing;
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Window_Loaded", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DataGridListing.Height = this.ActualHeight - 100;
        }

        #endregion

        #region Select tab
        private void Click_Generate(object sender, RoutedEventArgs e)
        {

            MIMS_LedgerDoc_CreditNoteBatch_LoadResult lResult = (MIMS_LedgerDoc_CreditNoteBatch_LoadResult)DataGridListing.CurrentItem;
            Load(lResult);
            TabControl.SelectedIndex = 1;
        }
        public string Load(MIMS_LedgerDoc_CreditNoteBatch_LoadResult pDetail)
        {
            string lStage = "Start";
            try
            {
                // Reportinfo

                {
                    string lResult;
                    gLedgerDoc.ReportInfo.Clear();
                    if ((lResult = LedgerData.GetReportInfo(pDetail.PayerId, ref gLedgerDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return lResult;
                    }
                }

                if (gLedgerDoc.ReportInfo.Rows.Count == 0)
                {
                    return "No data found on this customer";
                }

                lStage = "PersonalData";

                if (!gLedgerDoc.ReportInfo[0].IsLine1Null()) Line1.Content = gLedgerDoc.ReportInfo[0].Line1;
                if (!gLedgerDoc.ReportInfo[0].IsLine2Null()) Line2.Content = gLedgerDoc.ReportInfo[0].Line2;
                if (!gLedgerDoc.ReportInfo[0].IsLine3Null()) Line3.Content = gLedgerDoc.ReportInfo[0].Line3;
                if (!gLedgerDoc.ReportInfo[0].IsLine4Null()) Line4.Content = gLedgerDoc.ReportInfo[0].Line4;
                if (!gLedgerDoc.ReportInfo[0].IsLine5Null()) Line5.Content = gLedgerDoc.ReportInfo[0].Line5;
                if (!gLedgerDoc.ReportInfo[0].IsLine6Null()) Line6.Content = gLedgerDoc.ReportInfo[0].Line6;
                if (!gLedgerDoc.ReportInfo[0].IsLine7Null()) Line7.Content = gLedgerDoc.ReportInfo[0].Line7;
                if (!gLedgerDoc.ReportInfo[0].IsLine8Null()) Line8.Content = gLedgerDoc.ReportInfo[0].Line8;

                gCustomerData = new CustomerData3(pDetail.PayerId);

                CreditNoteNumber.Content = pDetail.CreditnoteNumber;
                InvoiceNumber.Content = pDetail.InvoiceNumber;
                if (!gLedgerDoc.ReportInfo[0].IsPPhoneNumberNull()) PPhoneNumber.Content = gLedgerDoc.ReportInfo[0].PPhoneNumber;
                if (!gLedgerDoc.ReportInfo[0].IsPPhoneNumberNull()) PEmail.Content = gLedgerDoc.ReportInfo[0].PEmail;
                if (!gLedgerDoc.ReportInfo[0].IsPPhoneNumberNull()) PVatRegistration.Content = gLedgerDoc.ReportInfo[0].PVATRegistration;
                CreditNoteNumber.Content = pDetail.CreditnoteNumber;
                CompanyRegistrationNumber.Content = gCustomerData.CompanyRegistrationNumber;
                PayerId.Content = gLedgerDoc.ReportInfo[0].PayerId;
                CreditNoteDate.Content = DateTime.Now.ToString("dd MMM yyyy");


                // Creditnote specific information

                lStage = "Bind detail";

                Reason.Content = "The abovementioned invoice has been amended for the following reason: " + pDetail.Explanation;

                decimal lReduction = (decimal)(pDetail.UnitPrice * pDetail.UnitsLess);

                SubscriptionData3 lSubscriptionData = new SubscriptionData3((int)pDetail.SubscriptionId);

                Header0.Content = "Subscription";
                Content0.Content = lSubscriptionData.SubscriptionId.ToString();

                Header1.Content = "Order number";
                Content1.Content = lSubscriptionData.OrderNumber;

                Header2.Content = "Company";
                Content2.Content = lSubscriptionData.ReceiverCompany;

                Header3.Content = "Surname";
                Content3.Content = lSubscriptionData.ReceiverSurname;

                Header4.Content = "Product";
                Content4.Content = lSubscriptionData.ProductName;

                Header5.Content = "Price per unit";
                Content5.Content = lSubscriptionData.UnitPrice.ToString("R #######0.00");

                Header6.Content = "Number of units reduced";
                Content6.Content = pDetail.UnitsLess.ToString();

                Header7.Content = "Total reduction";
                Content7.Content = lReduction.ToString("R ###########0.00");


                if (File.Exists(Settings.DirectoryPath + "\\" + gCustomerData.CustomerId.ToString() + "_CreditNote.pdf"))
                {
                    File.Delete(Settings.DirectoryPath + "\\" + gCustomerData.CustomerId.ToString() + "_CreditNote.pdf");
                }

                byte[] lBuffer = FlowDocumentConverter.XpsConverter.ConverterDoc(this.gFlowDocument);
                MemoryStream lXpsStream = new MemoryStream(lBuffer);
                FileStream lPdfStream = File.OpenWrite(Settings.DirectoryPath + "\\" + gCustomerData.CustomerId.ToString() + "_CreditNote.pdf");
                PdfSharp.Xps.XpsConverter.Convert(lXpsStream, lPdfStream, false);
                lPdfStream.Position = 0;
                lPdfStream.Flush();
                lPdfStream.Close();

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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Load", lStage);
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "Failed on Load " + ex.Message;
            }
        }
        #endregion

        #region Display tab

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog lPrintDialog = new PrintDialog();
                lPrintDialog.UserPageRangeEnabled = true;
                lPrintDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;


                if (lPrintDialog.ShowDialog() == true)
                {
                    lPrintDialog.PrintDocument(
                         ((IDocumentPaginatorSource)gFlowDocument).DocumentPaginator, "Creditnote");
                }

                MessageBox.Show("Print job submitted");

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonPrint_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
            }
        }

        public static string SendEmailBatch(int pCustomerId)
        {
            try
            {
                CustomerData3 lCustomerData = new CustomerData3(pCustomerId);

                string lEmailAddress = lCustomerData.EmailAddress;
                if (lCustomerData.StatementEmail.Length > 3)
                {
                    lEmailAddress = lCustomerData.StatementEmail;
                }

                if (string.IsNullOrWhiteSpace(lEmailAddress))
                {
                    return "SendEmail failed: Customer " + lCustomerData.CustomerId.ToString() + " does not have an Email Address";
                }

                byte[] lBuffer = File.ReadAllBytes(Settings.DirectoryPath + "\\" + pCustomerId.ToString() + "_CreditNote.pdf");

                using (MemoryStream lStream = new System.IO.MemoryStream(lBuffer, true))
                {

                    lStream.Write(lBuffer, 0, lBuffer.Length);
                    lStream.Position = 0;

                    SmtpClient myClient = new SmtpClient();
                    MailMessage myMessage = new MailMessage("vandermerwer@mims.co.za", lEmailAddress);
                    //MailMessage myMessage = new MailMessage("vandermerwer@mims.co.za", "reitmannh@arena.africa");
                    Attachment myAttachment = new Attachment(lStream, "CreditNote.pdf", MediaTypeNames.Application.Pdf);
                    myMessage.Attachments.Add(myAttachment);
                    myMessage.Subject = "Credit note for customer " + pCustomerId.ToString();
                    string myBody = "Dear Client\n\n"
                     + "Attached herewith your credit note.\n\n"
                     + "We trust that this will improve the quality of our service and look forward to a long-lasting relationship with you.\n\n"
                     + "Best\n\n"
                     + "Riëtte van der Merwe\n"
                     + "Subscription and Marketing Manager\n"
                     + "Tel: (011) 280-5856\n"
                     + "Fax: (086) 675 7910\n"
                     + "E-mail: vandermerwer@mims.co.za\n\n"
                     + "Hill on Empire, 16 Empire Rd (cnr Hillside Rd), ParkTown, Johannesburg, 2193\n"
                     + "P O Box 1746, Saxonworld, Johannesburg, 2132\n"
                     + "www.mims.co.za";

                    myMessage.Body = myBody;
                    myClient.Host = Settings.EMailHostIp;
                    myClient.UseDefaultCredentials = true;
                    myClient.Send(myMessage);

                }

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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, "StatementControl", "SendEmailBatch", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "Error sending Email " + ex.Message + " Customer = " + pCustomerId.ToString();
            }
        }
        private void ButtonEmail_Click(object sender, RoutedEventArgs e)
        {
            {
                string lResult;

                if ((lResult = SendEmailBatch(gCustomerData.CustomerId)) != "OK")
                {
                    MessageBox.Show(lResult);
                    return;
                }
                else MessageBox.Show("Email successfully sent to " + gCustomerData.CustomerId.ToString());
            }

        }

        #endregion

    }
}
