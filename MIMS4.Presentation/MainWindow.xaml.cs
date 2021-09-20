using Subs.Data;
using Subs.Business;
using Subs4.Presentation;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MIMS4.Presentation
{
    public partial class MainWindow : Window
    {
        #region Globals

        //public Subs.Data.AdministrationData gAdministrationData;

        private readonly BackgroundWorker gBackgroundWorker;
        public static string gVersion;
        #endregion

        #region Constructor

        public MainWindow()
        {
            string lProductFilter = "";
            string lConnectionString = "";

            try
            {
                lConnectionString = global::MIMS4.Presentation.Properties.Settings.Default.ConnectionString;

                if (lConnectionString == "")
                {
                    throw new Exception("No connection string has been set.");
                }
                else
                {
                    Settings.ConnectionString = lConnectionString;
                    Settings.DirectoryPath = global::MIMS4.Presentation.Properties.Settings.Default.DirectoryPath;
                    Settings.EMailHostIp = global::MIMS4.Presentation.Properties.Settings.Default.EMailHostIp;
                    Settings.ProductFilter = lProductFilter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Setting " + ex.Message);
            }

            try
            {
                InitializeComponent();

                gBackgroundWorker = new BackgroundWorker();
                gBackgroundWorker.DoWork += new DoWorkEventHandler(workerThread_DoWork);
                gBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerThread_RunWorkerCompleted);
                gBackgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitializeComponent " + ex.Message);
            }


            try
            {
                // Initialise data objects
                ProductDataStatic.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initialize data objects " + ex.Message);
            }



            try
            {

                // Set the Status-strip
                string[] myStatusMessages;
                char[] charSeparators = new char[] { ';' };
                myStatusMessages = lConnectionString.Split(charSeparators, 10, StringSplitOptions.RemoveEmptyEntries);
                string myServer = "";
                string myDataBase = "";
                //string myVersion = "";
                foreach (string myMember in myStatusMessages)
                {
                    if (myMember.StartsWith("Data Source"))
                    {
                        myServer = myMember.Substring(12);
                    }

                    if (myMember.StartsWith("Initial Catalog"))
                    {
                        myDataBase = myMember.Substring(16);
                    }
                }

                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {

                    Settings.Version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }

                this.Title = "MIMS on " + myServer + " on database " + myDataBase + " Version " + Settings.Version;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Title " + ex.Message);
            }


            try
            {
                //*****
                string lUserName = (string)Environment.UserName.ToString().ToUpper();

                System.Collections.Specialized.StringCollection Authority4Users
                  = (System.Collections.Specialized.StringCollection)global::MIMS4.Presentation.Properties.Settings.Default.Authority4;

                System.Collections.Specialized.StringCollection Authority3Users
                    = (System.Collections.Specialized.StringCollection)global::MIMS4.Presentation.Properties.Settings.Default.Authority3;

                System.Collections.Specialized.StringCollection Authority2Users
                    = (System.Collections.Specialized.StringCollection)global::MIMS4.Presentation.Properties.Settings.Default.Authority2;


                if (Authority2Users.Contains(lUserName))
                {
                    Settings.Authority = 2;
                }

                if (Authority3Users.Contains(lUserName))
                {
                    Settings.Authority = 3;
                }

                if (Authority4Users.Contains(lUserName))
                {
                    Settings.Authority = 4;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Special priviledges " + ex.Message);
            }


            // Start DeliveryAddress so that it is ready when someone needs it.

            try
            {
                // I think this caused a problem. There must be a better way in WPF. See chapter 9.

                //gThread = new Thread(StartDeliveryAddress);
                //gThread.IsBackground = true;
                //gThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Starting DeliveryAddress in a thread." + ex.Message);
            }
        }

        private void workerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            // Prime the loading of the delivery addresses.
            DeliveryAddressDoc lPrompt = DeliveryAddressStatic.DeliveryAddresses;
        }

        private void workerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DeliveryAddressStatic.Loaded = true;
        }

        private void SetVisibility(object sender, RoutedEventArgs e)
        {
            FrameworkElement lFrameworkElement = (FrameworkElement)sender;

            if (string.IsNullOrWhiteSpace((string)lFrameworkElement.Tag))
            {
                // This event handler is dependent on the Tag property
                return;
            }

            if (Settings.Authority == 4 && ((string)lFrameworkElement.Tag == "AuthorityHighest"
                                         || (string)lFrameworkElement.Tag == "AuthorityHigh"
                                         || (string)lFrameworkElement.Tag == "AuthorityMedium"))
            {
                lFrameworkElement.Visibility = Visibility.Visible;
            }
            else
            {
                if (Settings.Authority == 3 && ((string)lFrameworkElement.Tag == "AuthorityHigh"
                                             || (string)lFrameworkElement.Tag == "AuthorityMedium"))
                {
                    lFrameworkElement.Visibility = Visibility.Visible;
                }
                else
                {
                    if (Settings.Authority == 2 && (string)lFrameworkElement.Tag == "AuthorityMedium")
                    {
                        lFrameworkElement.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lFrameworkElement.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        #endregion

        #region Administration

        private void Country_Click(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.AdministrationCountry lAdministration = new Subs4.Presentation.AdministrationCountry();
            lAdministration.Show();
        }

        private void Click_AdministrationProduct(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.AdministrationProduct frmProductAdministration = new Subs4.Presentation.AdministrationProduct();
            //frmProductAdministration.SelectTab(Subs.Presentation.AdministrationProduct.Tabs.Product);
            frmProductAdministration.ShowDialog();
        }

        //private void Click_CustomerTitle(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        AdministrationCustomer lWindow = new AdministrationCustomer();
        //        lWindow.SelectTab(AdministrationCustomer.Tabs.Title);
        //        lWindow.ShowDialog();
        //        AdministrationData2.Refresh(); // It seems important to do this here, becasue this triggers the refresh of the control as well.
        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Click_CompanyConsolidation", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);

        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void Click_CustomerClassification(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                Subs4.Presentation.ClassificationPicker Classification = new Subs4.Presentation.ClassificationPicker();
                Classification.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private void Click_CompanyConsolidation(object sender, RoutedEventArgs e)
        {
            try
            {
                AdministrationCompany lWindow = new AdministrationCompany();
                //lWindow.SelectTab(AdministrationCustomer.Tabs.Company);
                lWindow.ShowDialog();
                AdministrationData2.RefreshCompany(); // It seems important to do this here, becasue this triggers the refresh of the control as well.
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Click_CompanyConsolidation", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        private void Click_DeliveryCost(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.AdministrationCountry lAdministration = new Subs4.Presentation.AdministrationCountry();
            lAdministration.Show();
        }

        private void Click_PostCode(object sender, RoutedEventArgs e)
        {
            AdministrationPostCode lWindow = new AdministrationPostCode();
            lWindow.ShowDialog();
        }

        private void Click_Promotion(object sender, RoutedEventArgs e)
        {
            AdministrationPromotion lPromotion = new AdministrationPromotion();
            lPromotion.ShowDialog();
        }

        private void Click_DeliveryAddress(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                AdministrationDeliveryAddress lDeliveryAddress = new AdministrationDeliveryAddress();
                lDeliveryAddress.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                AdministrationData2.Refresh();
                ProductDataStatic.Refresh();
                DeliveryAddressStatic.Refresh();
                MessageBox.Show("DataTemplates have been refreshed successfully");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (Settings.CurrentCustomerId != 0)
                {
                    CustomerData3 lCustomer = new CustomerData3(Settings.CurrentCustomerId);
                    labelCurrentCustomer.Content = lCustomer.Surname + "\n" + Settings.CurrentCustomerId.ToString();
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "DisplayCustomerId", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }
        }

        #endregion

        #region Product

        private void Click_Deliver(object sender, RoutedEventArgs e)
        {
            //Subs.Presentation.Product frmDeliver = new Product();
            //frmDeliver.SelectTab(Subs.Presentation.Product.Tabs.Generate);
            //frmDeliver.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //frmDeliver.ShowDialog();

            Subs4.Presentation.Deliver frmDeliver = new Deliver();
            frmDeliver.ShowDialog();
        }

        private void DeliveryReversal(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.Maintenance lMaintenance = new Subs4.Presentation.Maintenance();
            //lMaintenance.SelectTab(Subs.Presentation.Maintenance.Tabs.Reversal);
            lMaintenance.ShowDialog();
        }

        #endregion

        #region Subscription

        private void Click_SubscriptionPicker(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show("Trying to create SubscriptionPicker2");
                SubscriptionPicker2 lSubscriptionPicker = new SubscriptionPicker2();
                //MessageBox.Show("Created SubscriptionPicker2");
                lSubscriptionPicker.ShowDialog();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Click_SubscriptionPicker", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        private void Click_Quote(object sender, RoutedEventArgs e)
        {
            ProForma2 lProForma = new ProForma2();
            lProForma.ShowDialog();
        }

        private void Click_GlobalSkip(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.Maintenance lMaintenance = new Subs4.Presentation.Maintenance();
            // frmMaintenance.SelectTab(Subs.Presentation.Maintenance2.MaintenanceTabs.Skip);
            lMaintenance.ShowDialog();
        }

        #endregion

        #region Customer

        private void CustomerMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Subs4.Presentation.CustomerPicker3 lCustomerPicker = new Subs4.Presentation.CustomerPicker3();
                lCustomerPicker.ShowDialog();
            }
        }

        private void Click_CustomerGoTo(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.CustomerPicker3 lCustomerPicker = new Subs4.Presentation.CustomerPicker3();
            lCustomerPicker.ShowDialog();
        }

        private void Click_CommunicationInitiate(object sender, RoutedEventArgs e)
        {
            try
            {
                Subs4.Presentation.Maintenance lMaintenance = new Subs4.Presentation.Maintenance();
                lMaintenance.ShowDialog();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Click_CommunicationInitiate", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show("Failed on Click_CommunicationInitiate " + ex.Message);
            }
        }

        private void Click_FNBBankStatement(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.FNBBankStatement lBankstatement = new FNBBankStatement();
            lBankstatement.ShowDialog();
        }

        private void Click_SBBankStatement(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.SBBankStatement lBankStatement = new Subs4.Presentation.SBBankStatement();
            lBankStatement.ShowDialog();
        }


        private void Click_DebitOrderBankStatement(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.DebitOrderBankStatement lBankStatement = new Subs4.Presentation.DebitOrderBankStatement();
            lBankStatement.ShowDialog();
        }

        private void Click_CreditNote(object sender, RoutedEventArgs e)
        {
            Subs4.Presentation.CreditNote lWindow = new Subs4.Presentation.CreditNote();

            lWindow.ShowDialog();
        }

        #endregion

        #region Maintenance

        private void Click_PostCodeStandardisation(object sender, RoutedEventArgs e)
        {
            try
            {

                Cursor = Cursors.Wait;

                if (!DeliveryDataStatic.StandarizePostCodes())
                {
                    MessageBox.Show("Failed due to an error");
                }
                else
                {
                    MessageBox.Show("Done!");
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }

        }

        private void Click_RefreshEnums(object sender, RoutedEventArgs e)
        {
            try
            {
                //RefreshEnums
                AdministrationDoc lAdministrationDoc = new AdministrationDoc();
                MessageBox.Show(lAdministrationDoc.RefreshEnums());
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RefreshEnums", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        private void Click_PostCodeAddSapoCompliment(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;
                if (PostCodeData.AddSapoCompliment())
                {
                    MessageBox.Show("Sapo compliment successfully added");
                }
                else
                {
                    MessageBox.Show("Sapo compliment addition failed");
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        #endregion


        private void Click_Test(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(ProductBiz.DeliverElectronic(118957));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //private void Click_DeallocatePaymentAllocationAdHoc(object sender, RoutedEventArgs e)
        //{
        //    // Handle with Care.
        //    //MessageBox.Show("You  have deallocated R " + IssueBiz.DeallocatePaymentAdHoc(1561,1801.70M).ToString());

        //}
    }
}

