using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Subs.Data;
using Subs.Business;
using Subs.Presentation;
using System.ServiceModel;
using System.ServiceModel.Description;
//using MIMS.Presentation;
//using MIMS.Data;
using System.Diagnostics;
using System.Net.Mail;
using MIMS.Test.ServiceReference2;
using MIMS.Test.ServiceReference1;

namespace MIMS.Test
{
    public partial class Form1 : Form
    {

        #region Objects
        private System.Timers.Timer gTimer = null;
        //private ServiceHost gServiceHost = null;

        #endregion

        void gTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                eventLog1.WriteEntry("gTimer.Interval is now = " + gTimer.Interval.ToString());

            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("Error in gTimerElapsed = " + ex.Message);
            }

        }

        public Form1()
        {
            InitializeComponent();
            string myConnectionString = "";


            myConnectionString = global::MIMS.Test.Properties.Settings.Default.ConnectionString;

            if (myConnectionString == "")
            {
                throw new Exception("No connection string has been set.");
            }
            else
            {
                Subs.Data.Settings Settings = new Subs.Data.Settings();
                Settings.ConnectionString = myConnectionString;
                //Settings.ProductFilter = myProductFilter;
                //Settings.Save();
                //Settings.Reload();
            }


            //Bootstrap.Factory = (Subs.Data.IFactory)new MIMS.Presentation.Factory();


            // Setup the event log

            //EventLogPermission eventLogPermission = new EventLogPermission(EventLogPermissionAccess.Write, ".");

            //eventLogPermission.Assert();

            //if (!System.Diagnostics.EventLog.SourceExists("MIMSSource"))
            //{
            //    System.Diagnostics.EventLog.CreateEventSource("MIMSSource", "MIMSLog");
            //}

            //this.eventLog1.Source = "MIMSSource";
            //this.eventLog1.Log = "MIMSLog";

            //gTimer = new System.Timers.Timer(30000);
            //gTimer.Elapsed += new System.Timers.ElapsedEventHandler(gTimerElapsed);
        }

        private bool SelectTab(Tabs Tab)
        {
            this.tabControl1.SelectedIndex = (int)Tab;
            return true;
        }

        public enum Tabs
        {
            Test = 0,
            Report = 1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerPicker lPicker = CustomerPicker.GetSingleton();
                lPicker.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void buttonGetIssueId_Click(object sender, EventArgs e)
        {
            int lIssueId = 0;
            try
            {
                {
                string lResult;

                if ((lResult = ProductData.GetIssueId(7, 48, out lIssueId) )!= "OK")
                    {
                        MessageBox.Show(lResult);
                        return;
                    }
                }
             
                MessageBox.Show(lIssueId.ToString());
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(typeof(WarningException) == ex.GetType() ? 3 : 1, ex.Message, this.ToString(), "buttonGetIssueId_Click", "");
                    MessageBox.Show(this.ToString() + " : " + "buttonGetIssueId_Click" + " : " + ex.Message);
                }
                else
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        private void buttonInvoice_Click(object sender, EventArgs e)
        {

            Subs.Invoice.Generator lMIMSInvoice = new Subs.Invoice.Generator(
            "Data Source=PKLMAGMIMS01;Initial Catalog=MIMS3;Integrated Security=True;Enlist=False;Pooling=True;Max Pool Size=10;Connect Timeout=30",
            @"c:\Subs");

            lMIMSInvoice.Start();

            MessageBox.Show("Done");

        }



        private void buttonDelivered_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LedgerData.Delivered(1942, 432).ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.Viewer1.RefreshReport();
        }

        private void buttonStatementDirect_Click(object sender, EventArgs e)
        {

            try
            {

                LedgerDoc2 lLedgerDoc = LedgerData.GetReportInfo(500);
                LedgerData.LoadByPayer(500, StatementTypes.Abridged, ref lLedgerDoc);

                // Link the report
                Viewer1.LocalReport.ReportPath = @"c:\CSharp2010\Subs2\MIMS.Statement\Statement3.rdlc";

                // Link the data
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "ReportInfo";
                reportDataSource1.Value = lLedgerDoc.ReportInfo;

                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource2.Name = "Transactions";
                reportDataSource2.Value = lLedgerDoc.Transactions;

                Viewer1.LocalReport.DataSources.Clear();
                Viewer1.LocalReport.DataSources.Add(reportDataSource1);
                Viewer1.LocalReport.DataSources.Add(reportDataSource2);

                // Display the report

                Viewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
                Viewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
                System.Drawing.Printing.Margins lMargins = new System.Drawing.Printing.Margins();
                lMargins.Right = 5;
                lMargins.Top = 5;
                lMargins.Left = 5;
                lMargins.Bottom = 5;
                System.Drawing.Printing.PageSettings lPrintPageSetting = new System.Drawing.Printing.PageSettings();

                lPrintPageSetting.Margins = lMargins;
                lPrintPageSetting.Landscape = true;

                Viewer1.SetPageSettings(lPrintPageSetting);
                Viewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                Viewer1.ShowDocumentMapButton = false;
                Viewer1.DocumentMapCollapsed = true;
                this.Viewer1.RefreshReport();
                SelectTab(Tabs.Report);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }

        }

        private void buttonStatementDirectBatch_Click(object sender, EventArgs e)
        {
            //string lConnectionString = "Data Source=it-rbk-078;Initial Catalog=MIMS3;Integrated Security=True;Enlist=False;Pooling=True;Max Pool Size=10;Connect Timeout=30";
            string lDirectoryPath = @"C:\Subs";
            //string lReportPath = @"C:\Development\Subs\Subs.Statement\MIMSStatement4.rdlc";

            Subs.Statement.Generator lStatement = new Subs.Statement.Generator(lDirectoryPath);
            if (lStatement.Start())
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void buttonCreditNoteDirect_Click(object sender, EventArgs e)
        {
            //MIMS.CreditNote.Generator lCreditNote = new CreditNote.Generator();
            //if (lCreditNote.Start())
            //{
            //    MessageBox.Show("Done");
            //}
            //else
            //{
            //    MessageBox.Show("Failed");
            //}
        }


        //private void buttonInvoice_Click_1(object sender, EventArgs e)
        //{
        //    ServiceReference1.ActivatorClient lActivator = new ServiceReference1.ActivatorClient();

        //    ServiceReference1.StartRequest lStartRequest = new ServiceReference1.StartRequest();
        //    lStartRequest.pJob = ServiceReference1.Jobs.MIMSInvoice;
        //    lStartRequest.pConnectionString = global::MIMS.Test.Properties.Settings.Default.ConnectionString;
        //    lStartRequest.pDirectoryPath = global::MIMS.Test.Properties.Settings.Default.DirectoryPath;
        //    //lStartRequest.pReportPath = global::MIMS.Test.Properties.Settings.Default.ReportPath + "\\MIMSVATInvoice.rdlc";
        //    lActivator.BeginStart(lStartRequest, null, null);
        //    MessageBox.Show("Statement batch job has been started asynchronously.");

        //}


        private void buttonGetCustomerInfo_Click(object sender, EventArgs e)
        {
            ActivatorClient lActivator = new ActivatorClient();

            GetCustomerInfoRequest lStartRequest = new GetCustomerInfoRequest();
            lStartRequest.CustomerId = 101465;

            GetCustomerInfoResponse lResponse = new GetCustomerInfoResponse();
            lResponse = lActivator.GetCustomerInfo(lStartRequest);

            MessageBox.Show(lResponse.GetCustomerInfoResult.Due.ToString());
        }

        private void buttonEMail_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient myClient = new SmtpClient();
                MailMessage myMessage = new MailMessage("ReitmannH@timesmedia.co.za", "ReitmannH@timesmedia.co.za");
                Attachment myAttachment = new Attachment("c:\\MIMS Data\\Hein.txt", System.Net.Mime.MediaTypeNames.Application.Pdf);
                myMessage.Attachments.Add(myAttachment);
                myMessage.Subject = "SUBS Tax Invoice";
                string myBody = "Dear Client\n\n";

                myMessage.Body = myBody;
                myClient.Host = "172.15.83.190";
                myClient.UseDefaultCredentials = true;
                myClient.Send(myMessage);
                MessageBox.Show("Done");
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }

        }

        private void buttonAllocatePayments_Click(object sender, EventArgs e)
        {
            //PaymentData.PaymentRecord gRecord = new PaymentData.PaymentRecord();

            //gRecord.CustomerId = 2953;
            //gRecord.Amount = 1000;
            //gRecord.PaymentMethod = 1;
            //gRecord.ReferenceTypeId = 5;

            //Subs.Presentation.PaymentAllocation2 lFormPaymentAllocation = new PaymentAllocation2(6339, -40, 1610481);
            //lFormPaymentAllocation.ShowDialog();
        }

        private void buttonPaidForProduct_Click(object sender, EventArgs e)
        {
            //Subs.Business.CustomerBiz lCustomerBiz = new Subs.Business.CustomerBiz();
            //MessageBox.Show(lCustomerBiz.PaidForProduct(101530, 32).ToString());
            //MessageBox.Show(lCustomerBiz.PaidForProduct(13878, 32).ToString());

            MessageBox.Show(CustomerBiz.PaidForProduct(3213, 32).ToString());
            MessageBox.Show(CustomerBiz.PaidForProduct(1324, 32).ToString());

        }

        private void ButtonCustomerData_Click(object sender, EventArgs e)
        {
            CustomerData3 lCustomerData = new CustomerData3(8760);
            MessageBox.Show(lCustomerData.Deliverable.ToString());
            MessageBox.Show(lCustomerData.Due.ToString());
        }

        private void GetCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ActivatorClient lActivator = new ActivatorClient();

                Subs.Presentation.ServiceReference1.CustomerInfo lCustomerInfo = new Subs.Presentation.ServiceReference1.CustomerInfo();


                GetCustomerInfoRequest lGetRequest = new GetCustomerInfoRequest();
                lGetRequest.CustomerId = 108244;

                GetCustomerInfoResponse lGetResponse = new GetCustomerInfoResponse();

                lGetResponse = lActivator.GetCustomerInfo(lGetRequest);

                lCustomerInfo = lGetResponse.GetCustomerInfoResult;

                MessageBox.Show(lCustomerInfo.FullName);
            }

             catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetCustomer_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

               MessageBox.Show(ex.Message);
            }
        }

        private void buttonPaidUntil_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Subs.Business.IssueBiz.PaidUntil(32, 108244).ToLongDateString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Renewal_Click(object sender, EventArgs e)
        {
            Subs.Data.RenewalDoc1.RenewalRecordDataTable myRenewal = new Subs.Data.RenewalDoc1.RenewalRecordDataTable();
            SqlConnection Connection = new SqlConnection();
            SqlDataAdapter Adaptor = new SqlDataAdapter();
            Connection.ConnectionString = Settings.ConnectionString;
    
 
            try
            {
                SqlCommand Command = new SqlCommand();
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "MIMSRenewalData001";
                SqlCommandBuilder.DeriveParameters(Command);
                Command.Parameters["@SubscriptionId"].Value = 172252;

                Adaptor.SelectCommand = Command;

                Adaptor.Fill(myRenewal);
            }
             catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Update", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }
        }

        private void buttonAutoriseCPDTest_Click(object sender, EventArgs e)
        {
            ActivatorClient lActivator = new ActivatorClient();

           
            MIMS.Test.ServiceReference2.AuthoriseCPDIssueRequest lRequest = new MIMS.Test.ServiceReference2.AuthoriseCPDIssueRequest();
            lRequest.CustomerId = 108244;
            lRequest.IssueId = 786;
          

            MIMS.Test.ServiceReference2.AuthoriseCPDIssueResponse lResponse = new MIMS.Test.ServiceReference2.AuthoriseCPDIssueResponse();

            lResponse = lActivator.AuthoriseCPDIssue(lRequest);

            bool lResult = lResponse.AuthoriseCPDIssueResult;

            MessageBox.Show(lResult.ToString());

        }

        private void Authorize_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(SubscriptionBiz.Authorize(1, 114948).Seats.ToString());

                MessageBox.Show(SubscriptionBiz.Authorize(1, 114948).Reason);

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Authorize_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

               MessageBox.Show(ex.Message);
            }

        }

        private void Authorizations_Click(object sender, EventArgs e)
        {
            try
            {
                //List<AuthorizationResult> lResult = new List<AuthorizationResult>();
                //lResult = SubscriptionBiz.Authorizations();

                //MessageBox.Show(lResult.Count.ToString());

                //MessageBox.Show(lResult[1].CustomerId.ToString());
              

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Authorizations_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }




        }

        private void TestWebService_Click(object sender, EventArgs e)
        {
            MIMS.Test.ServiceReference1.ServiceSoapClient lClient = new ServiceSoapClient();
            AuthorizationHeader lHeader = new AuthorizationHeader();
            lHeader.Source = "NJA";
            lHeader.Type = "MOBIMims";

            string lResult;

            lResult = lClient.Test(lHeader, 114948, 1);

            MessageBox.Show(lResult);

        }
    }
}
