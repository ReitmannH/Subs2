using Subs.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Subs.Presentation
{
    /// <summary>
    /// Interaction logic for InvoiceControl.xaml
    /// </summary>
    public partial class InvoiceControl : UserControl
    {
        private LedgerDoc2 gLedgerDoc = new LedgerDoc2();
        private CustomerData3 gCustomerData;
        private readonly MIMSDataContext gDataContext = new MIMSDataContext(Settings.ConnectionString);

        public InvoiceControl()
        {
            InitializeComponent();
        }

        public string LoadAndRenderInvoice(int pInvoiceId)
        {
            return Render(gDataContext.MIMS_InvoiceControl_LoadInvoice(pInvoiceId).ToList());
        }

        public string Render(List<Invoice> pInvoice)
        {
            string lStage = "Start";
            try
            {
                // Reportinfo

                {
                    string lResult;
                    gLedgerDoc.ReportInfo.Clear();
                    if ((lResult = LedgerData.GetReportInfo(pInvoice[0].PayerId, ref gLedgerDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return lResult;
                    }
                }

                if (gLedgerDoc.ReportInfo.Rows.Count == 0)
                {
                    return "No data found on this customer";
                }

                lStage = "Billing address";

                if (!gLedgerDoc.ReportInfo[0].IsLine1Null()) Line1.Content = gLedgerDoc.ReportInfo[0].Line1;
                if (!gLedgerDoc.ReportInfo[0].IsLine2Null()) Line2.Content = gLedgerDoc.ReportInfo[0].Line2;
                if (!gLedgerDoc.ReportInfo[0].IsLine3Null()) Line3.Content = gLedgerDoc.ReportInfo[0].Line3;
                if (!gLedgerDoc.ReportInfo[0].IsLine4Null()) Line4.Content = gLedgerDoc.ReportInfo[0].Line4;
                if (!gLedgerDoc.ReportInfo[0].IsLine5Null()) Line5.Content = gLedgerDoc.ReportInfo[0].Line5;
                if (!gLedgerDoc.ReportInfo[0].IsLine6Null()) Line6.Content = gLedgerDoc.ReportInfo[0].Line6;
                if (!gLedgerDoc.ReportInfo[0].IsLine7Null()) Line7.Content = gLedgerDoc.ReportInfo[0].Line7;
                if (!gLedgerDoc.ReportInfo[0].IsLine8Null()) Line8.Content = gLedgerDoc.ReportInfo[0].Line8;

                lStage = "Physical address";

                if (!gLedgerDoc.ReportInfo[0].IsPAddress1Null()) PLine1.Content = gLedgerDoc.ReportInfo[0].PAddress1;
                if (!gLedgerDoc.ReportInfo[0].IsPAddress2Null()) PLine2.Content = gLedgerDoc.ReportInfo[0].PAddress2;
                if (!gLedgerDoc.ReportInfo[0].IsPAddress3Null()) PLine3.Content = gLedgerDoc.ReportInfo[0].PAddress3;
                if (!gLedgerDoc.ReportInfo[0].IsPAddress4Null()) PLine4.Content = gLedgerDoc.ReportInfo[0].PAddress4;
                if (!gLedgerDoc.ReportInfo[0].IsPAddress5Null()) PLine5.Content = gLedgerDoc.ReportInfo[0].PAddress5;
                if (!gLedgerDoc.ReportInfo[0].IsPAddress6Null()) PLine6.Content = gLedgerDoc.ReportInfo[0].PAddress6;
                if (!gLedgerDoc.ReportInfo[0].IsPAddress7Null()) PLine7.Content = gLedgerDoc.ReportInfo[0].PAddress7;
                if (!gLedgerDoc.ReportInfo[0].IsPAddress8Null()) PLine8.Content = gLedgerDoc.ReportInfo[0].PAddress8;

                gCustomerData = new CustomerData3(pInvoice[0].PayerId);

                InvoiceNumber.Content = "INV" + pInvoice[0].InvoiceId;
                if (!gLedgerDoc.ReportInfo[0].IsPPhoneNumberNull()) PPhoneNumber.Content = gLedgerDoc.ReportInfo[0].PPhoneNumber;
                if (!gLedgerDoc.ReportInfo[0].IsPEmailNull()) PEmail.Content = gLedgerDoc.ReportInfo[0].PEmail;
                if (!gLedgerDoc.ReportInfo[0].IsPVATRegistrationNull()) PVatRegistration.Content = gLedgerDoc.ReportInfo[0].PVATRegistration;
                VendorNumber.Content = gCustomerData.VendorNumber;
                CompanyRegistrationNumber.Content = gCustomerData.CompanyRegistrationNumber;
                PayerId.Content = gLedgerDoc.ReportInfo[0].PayerId;
                InvoiceDate.Content = pInvoice[0].DateFrom.ToString("dd MMM yyyy");

                // Write Items
                lStage = "Items";
                Thickness lTextMargin = new Thickness(0, 0, 10, 0);
                //Thickness lRightMargin = new Thickness(0, 0, 0, 0);


                decimal lTotalExc = 0;
                decimal lTotalVat = 0;
                decimal lPayable = 0;

                foreach (Invoice lInvoice in pInvoice)
                {

                    SubscriptionData3 lSubscription = new SubscriptionData3(lInvoice.SubscriptionId);

                    OrderNo.Content = lSubscription.OrderNumber; // Assuming that you are going to end up with the last order number.

                    // Build a row
                    TableRow lTableRow = new TableRow();

                    Paragraph lSubIdParagraph = new Paragraph(new Run(lSubscription.SubscriptionId.ToString()));
                    lTableRow.Cells.Add(new TableCell(lSubIdParagraph));

                    lTableRow.Cells.Add(new TableCell(new Paragraph(new Run(lSubscription.ReceiverId.ToString())) { Margin = lTextMargin }));

                    lTableRow.Cells.Add(new TableCell(new Paragraph(new Run(lSubscription.ReceiverCompany)) { Margin = lTextMargin }));

                    lTableRow.Cells.Add(new TableCell(new Paragraph(new Run(ProductDataStatic.GetIssueDescription(lSubscription.StartIssue))) { Margin = lTextMargin }));

                    lTableRow.Cells.Add(new TableCell(new Paragraph(new Run(ProductDataStatic.GetIssueDescription(lSubscription.LastIssue)))));

                    Paragraph lDebitValueParagraph = new Paragraph(new Run(lSubscription.BaseRate.ToString("R ######0.00")));
                    lDebitValueParagraph.TextAlignment = TextAlignment.Right;
                    lTableRow.Cells.Add(new TableCell(lDebitValueParagraph));

                    decimal lDiscountedPrice = lSubscription.BaseRate * lSubscription.DiscountMultiplier;
                    decimal lDiscount = lSubscription.BaseRate - lDiscountedPrice;
                    Paragraph lDiscountParagraph = new Paragraph(new Run(lDiscount.ToString("R ######0.00")));
                    lDiscountParagraph.TextAlignment = TextAlignment.Right;
                     lTableRow.Cells.Add(new TableCell(lDiscountParagraph));

                    Paragraph lDeliveryParagraph = new Paragraph(new Run(lSubscription.DeliveryCost.ToString("R ######0.00")));
                    lDeliveryParagraph.TextAlignment = TextAlignment.Right;
                    lTableRow.Cells.Add(new TableCell(lDeliveryParagraph));

                    decimal lUnitPriceExc = lSubscription.UnitPrice - lSubscription.Vat;


                    Paragraph lUnitPriceParagraph = new Paragraph(new Run(lUnitPriceExc.ToString("R ######0.00")));
                    lUnitPriceParagraph.TextAlignment = TextAlignment.Right;
                    lTableRow.Cells.Add(new TableCell(lUnitPriceParagraph));

                    int lNumberOfUnits = lSubscription.UnitsPerIssue * lSubscription.NumberOfIssues;
                    Paragraph lUnitParagraph = new Paragraph(new Run(lSubscription.UnitsPerIssue.ToString() + " X " + lSubscription.NumberOfIssues.ToString()));
                    lUnitParagraph.TextAlignment = TextAlignment.Right;
                    lTableRow.Cells.Add(new TableCell(lUnitParagraph));

                    decimal lTotalPerSubExc = (lSubscription.UnitPrice - lSubscription.Vat) * lNumberOfUnits;
                    Paragraph lTotalParagraph = new Paragraph(new Run(lTotalPerSubExc.ToString("R #######0.00")));
                    lTotalParagraph.TextAlignment = TextAlignment.Right;
                     lTableRow.Cells.Add(new TableCell(lTotalParagraph));

                    // Calculate totals

                    lTotalExc = lTotalExc + lTotalPerSubExc;
                    lTotalVat = lTotalVat + (lSubscription.Vat * lNumberOfUnits);


                    // Add the row to the table
                    HistoryTable.RowGroups[1].Rows.Add(lTableRow);

                    // Add a creditnote row if it is appriopriate

                    if (lSubscription.CreditNoteValue < 0)
                    {
                        lTableRow = new TableRow();

                        Paragraph lCreditNoteParagraph = new Paragraph(new Run(lSubscription.CreditNoteName));
                        lTableRow.Cells.Add(new TableCell(lCreditNoteParagraph));
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTableRow.Cells.Add(new TableCell());
                        lTotalPerSubExc = lSubscription.CreditNoteValue * ((100 / (100 + lSubscription.VatPercentage)));
                        Paragraph lCNParagraph = new Paragraph(new Run(lTotalPerSubExc.ToString("R #######0.00")));
                        lCNParagraph.TextAlignment = TextAlignment.Right;
                        lTableRow.Cells.Add(new TableCell(lCNParagraph));
                        HistoryTable.RowGroups[1].Rows.Add(lTableRow);

                        lTotalExc = lTotalExc + lTotalPerSubExc;
                        lTotalVat = lTotalVat + (lSubscription.CreditNoteValue - lTotalPerSubExc);
                    }

                } // End of foreach loop

                // Add the totals                              

                // Calculate the credit

                decimal lDue = gCustomerData.Due;

                lPayable = lTotalExc + lTotalVat;

                TotalExc.Content = lTotalExc.ToString("R ######0.00");
                Vat.Content = lTotalVat.ToString("R ######0.00");

                Payable.Content = lPayable.ToString("R ######0.00");

                // Save to disk

                string lFileName = "INV_"
               + pInvoice[0].PayerId.ToString()
               + "_"
               + pInvoice[0].InvoiceId.ToString()
               + ".pdf";


                if (File.Exists(Settings.DirectoryPath + "\\" + lFileName))
                {
                    File.Delete(Settings.DirectoryPath + "\\" + lFileName);
                }

                byte[] lBuffer = FlowDocumentConverter.XpsConverter.ConverterDoc(this.gFlowDocument);
                MemoryStream lXpsStream = new MemoryStream(lBuffer);
                FileStream lPdfStream = File.OpenWrite(Settings.DirectoryPath + "\\" + lFileName);
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Render", lStage);
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "Failed on Load " + ex.Message;
            }
        }

    }
}
