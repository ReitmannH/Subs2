namespace MIMS.Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.buttonGetIssueId = new System.Windows.Forms.Button();
            this.buttonInvoiceDirect = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.buttonDelivered = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAutoriseCPDTest = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonPaidUntil = new System.Windows.Forms.Button();
            this.GetCustomer = new System.Windows.Forms.Button();
            this.ButtonCustomerData = new System.Windows.Forms.Button();
            this.buttonPaidForProduct = new System.Windows.Forms.Button();
            this.buttonAllocatePayments = new System.Windows.Forms.Button();
            this.buttonEMail = new System.Windows.Forms.Button();
            this.buttonGetCustomerInfo = new System.Windows.Forms.Button();
            this.buttonInvoice = new System.Windows.Forms.Button();
            this.buttonDeliveryAddress = new System.Windows.Forms.Button();
            this.buttonCreditNoteDirect = new System.Windows.Forms.Button();
            this.buttonStatementDirectBatch = new System.Windows.Forms.Button();
            this.buttonStatementDirect = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.Viewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "CustomerPicker";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonGetIssueId
            // 
            this.buttonGetIssueId.Location = new System.Drawing.Point(300, 6);
            this.buttonGetIssueId.Name = "buttonGetIssueId";
            this.buttonGetIssueId.Size = new System.Drawing.Size(75, 23);
            this.buttonGetIssueId.TabIndex = 2;
            this.buttonGetIssueId.Text = "GetIssueId";
            this.buttonGetIssueId.UseVisualStyleBackColor = true;
            this.buttonGetIssueId.Click += new System.EventHandler(this.buttonGetIssueId_Click);
            // 
            // buttonInvoiceDirect
            // 
            this.buttonInvoiceDirect.Location = new System.Drawing.Point(8, 93);
            this.buttonInvoiceDirect.Name = "buttonInvoiceDirect";
            this.buttonInvoiceDirect.Size = new System.Drawing.Size(164, 23);
            this.buttonInvoiceDirect.TabIndex = 3;
            this.buttonInvoiceDirect.Text = "Invoice direct";
            this.buttonInvoiceDirect.UseVisualStyleBackColor = true;
            this.buttonInvoiceDirect.Click += new System.EventHandler(this.buttonInvoice_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // buttonDelivered
            // 
            this.buttonDelivered.Location = new System.Drawing.Point(300, 35);
            this.buttonDelivered.Name = "buttonDelivered";
            this.buttonDelivered.Size = new System.Drawing.Size(75, 23);
            this.buttonDelivered.TabIndex = 7;
            this.buttonDelivered.Text = "Delivered";
            this.buttonDelivered.UseVisualStyleBackColor = true;
            this.buttonDelivered.Click += new System.EventHandler(this.buttonDelivered_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTest);
            this.tabControl1.Controls.Add(this.tabReport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1055, 723);
            this.tabControl1.TabIndex = 8;
            // 
            // tabTest
            // 
            this.tabTest.Controls.Add(this.button5);
            this.tabTest.Controls.Add(this.button4);
            this.tabTest.Controls.Add(this.button1);
            this.tabTest.Controls.Add(this.buttonAutoriseCPDTest);
            this.tabTest.Controls.Add(this.button3);
            this.tabTest.Controls.Add(this.buttonPaidUntil);
            this.tabTest.Controls.Add(this.GetCustomer);
            this.tabTest.Controls.Add(this.ButtonCustomerData);
            this.tabTest.Controls.Add(this.buttonPaidForProduct);
            this.tabTest.Controls.Add(this.buttonAllocatePayments);
            this.tabTest.Controls.Add(this.buttonEMail);
            this.tabTest.Controls.Add(this.buttonGetCustomerInfo);
            this.tabTest.Controls.Add(this.buttonInvoice);
            this.tabTest.Controls.Add(this.buttonDeliveryAddress);
            this.tabTest.Controls.Add(this.buttonCreditNoteDirect);
            this.tabTest.Controls.Add(this.buttonStatementDirectBatch);
            this.tabTest.Controls.Add(this.buttonStatementDirect);
            this.tabTest.Controls.Add(this.reportViewer1);
            this.tabTest.Controls.Add(this.buttonGetIssueId);
            this.tabTest.Controls.Add(this.buttonDelivered);
            this.tabTest.Controls.Add(this.buttonInvoiceDirect);
            this.tabTest.Controls.Add(this.button2);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(1047, 697);
            this.tabTest.TabIndex = 0;
            this.tabTest.Text = "Tests";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 423);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "Authorizations";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Authorizations_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Authorize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Authorize_Click);
            // 
            // buttonAutoriseCPDTest
            // 
            this.buttonAutoriseCPDTest.Location = new System.Drawing.Point(457, 130);
            this.buttonAutoriseCPDTest.Name = "buttonAutoriseCPDTest";
            this.buttonAutoriseCPDTest.Size = new System.Drawing.Size(189, 23);
            this.buttonAutoriseCPDTest.TabIndex = 23;
            this.buttonAutoriseCPDTest.Text = "Authorise CPD Test";
            this.buttonAutoriseCPDTest.UseVisualStyleBackColor = true;
            this.buttonAutoriseCPDTest.Click += new System.EventHandler(this.buttonAutoriseCPDTest_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(570, 273);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Renewal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Renewal_Click);
            // 
            // buttonPaidUntil
            // 
            this.buttonPaidUntil.Location = new System.Drawing.Point(420, 272);
            this.buttonPaidUntil.Name = "buttonPaidUntil";
            this.buttonPaidUntil.Size = new System.Drawing.Size(75, 23);
            this.buttonPaidUntil.TabIndex = 20;
            this.buttonPaidUntil.Text = "PaidUntil";
            this.buttonPaidUntil.UseVisualStyleBackColor = true;
            this.buttonPaidUntil.Click += new System.EventHandler(this.buttonPaidUntil_Click);
            // 
            // GetCustomer
            // 
            this.GetCustomer.Location = new System.Drawing.Point(457, 93);
            this.GetCustomer.Name = "GetCustomer";
            this.GetCustomer.Size = new System.Drawing.Size(189, 23);
            this.GetCustomer.TabIndex = 19;
            this.GetCustomer.Text = "GetCustomerInfo from service";
            this.GetCustomer.UseVisualStyleBackColor = true;
            this.GetCustomer.Click += new System.EventHandler(this.GetCustomer_Click);
            // 
            // ButtonCustomerData
            // 
            this.ButtonCustomerData.Location = new System.Drawing.Point(18, 324);
            this.ButtonCustomerData.Name = "ButtonCustomerData";
            this.ButtonCustomerData.Size = new System.Drawing.Size(162, 23);
            this.ButtonCustomerData.TabIndex = 18;
            this.ButtonCustomerData.Text = "CustomerData";
            this.ButtonCustomerData.UseVisualStyleBackColor = true;
            this.ButtonCustomerData.Click += new System.EventHandler(this.ButtonCustomerData_Click);
            // 
            // buttonPaidForProduct
            // 
            this.buttonPaidForProduct.Location = new System.Drawing.Point(241, 272);
            this.buttonPaidForProduct.Name = "buttonPaidForProduct";
            this.buttonPaidForProduct.Size = new System.Drawing.Size(115, 23);
            this.buttonPaidForProduct.TabIndex = 17;
            this.buttonPaidForProduct.Text = "PaidForProduct";
            this.buttonPaidForProduct.UseVisualStyleBackColor = true;
            this.buttonPaidForProduct.Click += new System.EventHandler(this.buttonPaidForProduct_Click);
            // 
            // buttonAllocatePayments
            // 
            this.buttonAllocatePayments.Location = new System.Drawing.Point(18, 273);
            this.buttonAllocatePayments.Name = "buttonAllocatePayments";
            this.buttonAllocatePayments.Size = new System.Drawing.Size(154, 23);
            this.buttonAllocatePayments.TabIndex = 16;
            this.buttonAllocatePayments.Text = "AllocatePayments";
            this.buttonAllocatePayments.UseVisualStyleBackColor = true;
            this.buttonAllocatePayments.Click += new System.EventHandler(this.buttonAllocatePayments_Click);
            // 
            // buttonEMail
            // 
            this.buttonEMail.Location = new System.Drawing.Point(9, 227);
            this.buttonEMail.Name = "buttonEMail";
            this.buttonEMail.Size = new System.Drawing.Size(75, 23);
            this.buttonEMail.TabIndex = 15;
            this.buttonEMail.Text = "TestEMail";
            this.buttonEMail.UseVisualStyleBackColor = true;
            this.buttonEMail.Click += new System.EventHandler(this.buttonEMail_Click);
            // 
            // buttonGetCustomerInfo
            // 
            this.buttonGetCustomerInfo.Location = new System.Drawing.Point(241, 179);
            this.buttonGetCustomerInfo.Name = "buttonGetCustomerInfo";
            this.buttonGetCustomerInfo.Size = new System.Drawing.Size(154, 23);
            this.buttonGetCustomerInfo.TabIndex = 14;
            this.buttonGetCustomerInfo.Text = "GetCustomerInfo";
            this.buttonGetCustomerInfo.UseVisualStyleBackColor = true;
            this.buttonGetCustomerInfo.Click += new System.EventHandler(this.buttonGetCustomerInfo_Click);
            // 
            // buttonInvoice
            // 
            this.buttonInvoice.Location = new System.Drawing.Point(241, 93);
            this.buttonInvoice.Name = "buttonInvoice";
            this.buttonInvoice.Size = new System.Drawing.Size(134, 23);
            this.buttonInvoice.TabIndex = 13;
            this.buttonInvoice.Text = "Invoice via service";
            this.buttonInvoice.UseVisualStyleBackColor = true;
            // 
            // buttonDeliveryAddress
            // 
            this.buttonDeliveryAddress.Location = new System.Drawing.Point(0, 0);
            this.buttonDeliveryAddress.Name = "buttonDeliveryAddress";
            this.buttonDeliveryAddress.Size = new System.Drawing.Size(75, 23);
            this.buttonDeliveryAddress.TabIndex = 22;
            // 
            // buttonCreditNoteDirect
            // 
            this.buttonCreditNoteDirect.Location = new System.Drawing.Point(9, 179);
            this.buttonCreditNoteDirect.Name = "buttonCreditNoteDirect";
            this.buttonCreditNoteDirect.Size = new System.Drawing.Size(163, 23);
            this.buttonCreditNoteDirect.TabIndex = 11;
            this.buttonCreditNoteDirect.Text = "CreditNoteDirect";
            this.buttonCreditNoteDirect.UseVisualStyleBackColor = true;
            this.buttonCreditNoteDirect.Click += new System.EventHandler(this.buttonCreditNoteDirect_Click);
            // 
            // buttonStatementDirectBatch
            // 
            this.buttonStatementDirectBatch.Location = new System.Drawing.Point(241, 131);
            this.buttonStatementDirectBatch.Name = "buttonStatementDirectBatch";
            this.buttonStatementDirectBatch.Size = new System.Drawing.Size(145, 23);
            this.buttonStatementDirectBatch.TabIndex = 10;
            this.buttonStatementDirectBatch.Text = "StatementDirectBatch";
            this.buttonStatementDirectBatch.UseVisualStyleBackColor = true;
            this.buttonStatementDirectBatch.Click += new System.EventHandler(this.buttonStatementDirectBatch_Click);
            // 
            // buttonStatementDirect
            // 
            this.buttonStatementDirect.Location = new System.Drawing.Point(8, 131);
            this.buttonStatementDirect.Name = "buttonStatementDirect";
            this.buttonStatementDirect.Size = new System.Drawing.Size(164, 23);
            this.buttonStatementDirect.TabIndex = 9;
            this.buttonStatementDirect.Text = "Statement direct";
            this.buttonStatementDirect.UseVisualStyleBackColor = true;
            this.buttonStatementDirect.Click += new System.EventHandler(this.buttonStatementDirect_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(588, 214);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(8, 8);
            this.reportViewer1.TabIndex = 8;
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.Viewer1);
            this.tabReport.Location = new System.Drawing.Point(4, 22);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1047, 697);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Report";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // Viewer1
            // 
            this.Viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer1.Location = new System.Drawing.Point(3, 3);
            this.Viewer1.Name = "Viewer1";
            this.Viewer1.Size = new System.Drawing.Size(1041, 691);
            this.Viewer1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(241, 324);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 23);
            this.button5.TabIndex = 26;
            this.button5.Text = "TestWebService";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.TestWebService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 723);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabTest.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonGetIssueId;
        private System.Windows.Forms.Button buttonInvoiceDirect;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Button buttonDelivered;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTest;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabReport;
        private Microsoft.Reporting.WinForms.ReportViewer Viewer1;
        private System.Windows.Forms.Button buttonStatementDirect;
        private System.Windows.Forms.Button buttonStatementDirectBatch;
        private System.Windows.Forms.Button buttonCreditNoteDirect;
        private System.Windows.Forms.Button buttonDeliveryAddress;
        private System.Windows.Forms.Button buttonInvoice;
        private System.Windows.Forms.Button buttonGetCustomerInfo;
        private System.Windows.Forms.Button buttonEMail;
        private System.Windows.Forms.Button buttonAllocatePayments;
        private System.Windows.Forms.Button buttonPaidForProduct;
        private System.Windows.Forms.Button ButtonCustomerData;
        private System.Windows.Forms.Button GetCustomer;
        private System.Windows.Forms.Button buttonPaidUntil;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAutoriseCPDTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

