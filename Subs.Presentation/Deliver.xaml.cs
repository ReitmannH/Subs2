using Microsoft.Win32;
using Subs.Business;
using Subs.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Subs.Presentation
{
    public partial class Deliver : Window
    {
        #region Globals

        private Subs.Presentation.IssuePicker2 frmIssuePicker;
        //private bool gProposalValid = false;
        private int gIssueId = 0;
        private Subs.Data.DeliveryDoc gDeliveryDoc = new DeliveryDoc();
       // private DeliveryDoc.DeliveryList1DataTable gDeliveryList;
        private readonly CollectionViewSource gDeliveryRecordViewSource;
        private readonly BackgroundWorker gBackgroundWorker;
        private readonly BackgroundWorker gBackgroundWorkerPost;
        private string gCurrentProduct = "";

        [Serializable]
        public class DeliveryItem
        {
            public string WaybillNumber = "               ";
            public string Date;
            public string Contact_NameAndSurname;
            public string Company;
            public string Address1;
            public string Address2;
            public string Address3;
            public string Address4;
            public string PostalCode;
            public string Country;
            public string ContactWork_Cell_Phonenumber;
            public decimal Weight = 1;
            public decimal Length = 1;
            public decimal Width = 1;
            public decimal Height = 1;
            public decimal Value = 1;
            public string WeekendDelivery = "No";
            public string Insured = "No";
            public string IsCollection = "No";
            public string UniqueReferenceNumber;
            public int Pieces;
            public string Special_Instructions = " |";
            public string ProductName;
            public string Classification = "1";
            public int CustomerId;
            public string EmailAddress;
            public DateTime ExpirationDate;
            public string Building;
            public string FloorNo;
            public string Room;
        }


        public List<DeliveryItem> gDeliveryItems = new List<DeliveryItem>();
        private class PackageCounter
        {
            public int CustomerId;
            public string IssueDescription;
            public int UnitsPerIssue;
        }

        private List<PackageCounter> gPackageCounters = new List<PackageCounter>();

        [Serializable]
        public class InventoryItem
        {
            public string IssueDescription;
            public int Units;
        }

        [Serializable]
        public class DeliveriesMethod
        {
            public string Name;
            public List<InventoryItem> Items = new List<InventoryItem>();
        }

        [Serializable]
        public class Inventory
        {
           public List<DeliveriesMethod> Methods = new List<DeliveriesMethod>();
        }

        Inventory gInventory = new Inventory();

        #endregion

        #region Constructor

        public Deliver()
        {
            InitializeComponent();
            gDeliveryRecordViewSource = (CollectionViewSource)this.Resources["deliveryRecordViewSource"];
            gBackgroundWorker = ((BackgroundWorker)this.FindResource("backgroundWorker"));
            gBackgroundWorkerPost = ((BackgroundWorker)this.FindResource("backgroundWorkerPost"));
        }

        #endregion
        
        #region Form management

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gDeliveryDoc = ((Subs.Data.DeliveryDoc)(this.FindResource("deliveryDoc")));
        }

        #endregion

        #region Propose

        private void buttonProposal(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            gCurrentProduct = "";
            // Get an Issueid
            frmIssuePicker = new Subs.Presentation.IssuePicker2();
            frmIssuePicker.ShowDialog();

            if (frmIssuePicker.IssueWasSelected)
            {
                labelProduct.Content = frmIssuePicker.ProductNaam;
                labelIssue.Content = frmIssuePicker.IssueName;
                gIssueId = frmIssuePicker.IssueId;
            }
            else
            {
                MessageBox.Show("You have not selected an issue. Please try again.");
                return;
            }
            
            try
            {
                // Ok if you got this far you have a valid issueid - so you can continue

                gDeliveryDoc.Clear();

                {
                    string lResult;

                    if ((lResult = DeliveryDataStatic.Load(gIssueId, ref gDeliveryDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return;
                    }
                    else
                    {
                        int lUnits = gDeliveryDoc.DeliveryRecord.Sum(p => p.UnitsPerIssue);
                        MessageBox.Show("I have generated " + gDeliveryDoc.DeliveryRecord.Count.ToString() + " proposals for " + lUnits.ToString() + " units.");
                    }
                }

                //gProposalValid = false; // Enforce validation
                gCurrentProduct = frmIssuePicker.IssueName;
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "buttonProposal", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
                return;
            }

            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void buttonProposalActive(object sender, RoutedEventArgs e)
        {
            try
            {
                gCurrentProduct = "";
                labelProduct.Content = "All active products";
                labelIssue.Content = "";

                {
                    string lResult;

                    gDeliveryDoc.Clear();

                    if ((lResult = DeliveryDataStatic.LoadActive(ref gDeliveryDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return;
                    }
                    else
                    {
                        int lUnits = gDeliveryDoc.DeliveryRecord.Count;
                        MessageBox.Show("I have generated a proposal with "  + lUnits.ToString() + " delivery records.");
                    }
                }

                gCurrentProduct = "AllActive";
                //buttonPost.IsEnabled = false;
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "buttonProposalActive", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Validate
 

        private void buttonValidate_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                if (gBackgroundWorker.IsBusy || gBackgroundWorkerPost.IsBusy)
                {
                    return;
                }

                this.Cursor = Cursors.Wait;

                if (gDeliveryDoc.DeliveryRecord.Count == 0)
                {
                    MessageBox.Show("There is nothing to validate.");
                    return;
                }

                gDeliveryDoc.DeliveryRecord.AcceptChanges();

                gBackgroundWorker.RunWorkerAsync(gDeliveryDoc);
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "buttonValidate_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show("Error in button ValidateProposal " + ex.Message.ToString());
             }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DeliveryDoc lDeliveryDoc = (DeliveryDoc)e.Argument;
            e.Result = ProductBiz.ValidateProposal(lDeliveryDoc, gBackgroundWorker);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressType lProgress = (ProgressType)e.Result;

            if (e.Error != null)
            {
                // An error was thrown by the DoWork event handler.
                MessageBox.Show(e.Error.Message, "An error occurred in the background validation");
            }

            int Rejections = 0;
            //gProposalValid = false;
            Rejections = lProgress.Counter2;

            ////Special logging of short fall of stock
            //if (lProgress.StockShortCount > 0)
            //{
            //    MessageBox.Show("There was a stock short fall of " + lProgress.StockShortCount.ToString());
            //}

            if (Rejections == 0)
            {
                // Save the proposal in case there are problems with the post processing.

                gDeliveryDoc.DeliveryRecord.WriteXml(Settings.DirectoryPath + "\\Recovery\\OutputFromSuccessValidation" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");

                int lUnits = gDeliveryDoc.DeliveryRecord.Sum(p => p.UnitsPerIssue);
             
                MessageBox.Show("There where " + gDeliveryDoc.DeliveryRecord.Count.ToString() + " deliverable records for " + lUnits.ToString() + " units. You may proceed to post them!");
                Cursor = Cursors.Arrow;
                buttonValidate.IsEnabled = true;
            }
            else
            {
                //gProposalValid = false;
                //buttonPost.IsEnabled = false;
                MessageBox.Show("There are " + Rejections.ToString() + " invalid proposals.");
                return;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar1.Value = e.ProgressPercentage;
        }

        private void Skip(object sender, RoutedEventArgs e)
        {
            try
            {
                // Warning

                if (MessageBoxResult.No == MessageBox.Show("Are you sure that you want to skip all these entries. To reverse this operation is cumbersome and dangerous!?",
                    "Warning", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning))
                {
                    return;
                }

                ProductDoc.IssueDataTable lIssue = new ProductDoc.IssueDataTable();
                Subs.Data.ProductDocTableAdapters.IssueTableAdapter lAdaptor = new Subs.Data.ProductDocTableAdapters.IssueTableAdapter();
                lAdaptor.AttachConnection();
                lAdaptor.FillById(lIssue, gDeliveryDoc.DeliveryRecord[0].IssueId, "IssueId");

                if (lIssue[0].StartDate > DateTime.Now)
                {

                    if (MessageBoxResult.No == MessageBox.Show("This issue starts in the future" + ".\n This skip cannot be undone. Do you want to continue?",
                      "Warning", MessageBoxButton.YesNo))
                    {
                        return;
                    }
                }

                int lCount = 0;

                this.Cursor = Cursors.Wait;
                foreach (DeliveryDoc.DeliveryRecordRow lRow in gDeliveryDoc.DeliveryRecord)
                {
                    if (lRow.Skip)
                    {
                        {
                            string lResult;

                            if ((lResult = IssueBiz.Skip(lRow.SubscriptionId, lRow.IssueId)) != "OK")
                            {
                                MessageBox.Show(lResult);
                                return;
                            }
                            else
                            {
                                lCount++;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                } // End of foreach

                MessageBox.Show("Success. You have skipped " + lCount.ToString() + " issues. Please regenerate a proposal.");
            } // End of try
            finally
            {
                gDeliveryDoc.DeliveryRecord.Clear();
                Cursor = Cursors.Arrow;
            }
        }


        private void LoadValidProposal(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog lOpenFileDialog = new OpenFileDialog();

                lOpenFileDialog.InitialDirectory = Settings.DirectoryPath + "\\Recovery\\";
                lOpenFileDialog.ShowDialog();
                string FileName = lOpenFileDialog.FileName.ToString();

                if (!File.Exists(FileName))
                {
                    MessageBox.Show("You have not selected a valid source file ");
                    return;
                }

                gDeliveryDoc.DeliveryRecord.Clear();
                gDeliveryDoc.DeliveryRecord.ReadXml(FileName);



                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "LoadValidProposal", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }

        }



        #endregion

        #region Post

        private void buttonPost_Click(object sender, RoutedEventArgs e)
        {
            if (gBackgroundWorker.IsBusy || gBackgroundWorkerPost.IsBusy)
            {
                MessageBox.Show("You are too fast for me. I have not completed the previous task yet. Request will be ignored. ");
                return;
            }

            if(gDeliveryDoc.DeliveryRecord.Where(p => p.ValidationStatus != "Deliverable").Count() > 0)
            {
                MessageBox.Show("The proposal is invalid. It cannot be posted.");
                return;
            }

            // Continue with the proposal

            gDeliveryDoc.DeliveryRecord.AcceptChanges();

            this.Cursor = Cursors.Wait;

            try
            {
                this.Cursor = Cursors.Wait;

                // In case of a crash, you can rerun the delivery from the same XML. The system
                // will not redeliver an issue if is has already been done on the previous run.
                this.Cursor = Cursors.Wait;
                gBackgroundWorkerPost.RunWorkerAsync(gDeliveryDoc);
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Post", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);

                return;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void backgroundWorkerPost_DoWork(object sender, DoWorkEventArgs e)
        {
            DeliveryDoc lDeliveryDoc = (DeliveryDoc)e.Argument;
            e.Result = ProductBiz.PostDelivery(lDeliveryDoc, gBackgroundWorkerPost);
        }

        private void backgroundWorkerPost_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressType lProgress = (ProgressType)e.Result;

            if (e.Error != null)
            {
                // An error was thrown by the DoWork event handler.
                MessageBox.Show(e.Error.Message, "An error occurred in the background post");
                return;
            }

            MessageBox.Show("Posting successful.");
        }

        private void backgroundWorkerPost_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar1.Value = e.ProgressPercentage;
        }

    
        #endregion

        #region Format
        private void ButtonSplitByDeliveryMethod(object sender, RoutedEventArgs e)
        {
            if (gBackgroundWorker.IsBusy || gBackgroundWorkerPost.IsBusy)
            {
                MessageBox.Show("You are too fast for me. I have not completed the previous task yet. Request will be ignored. ");
                return;
            }

            if (gDeliveryDoc.DeliveryRecord.Where(p => p.ValidationStatus != "Deliverable").Count() > 0)
            {
                MessageBox.Show("The proposal is invalid. It cannot proceed to deliver it.");
                return;
            }

            try
            {
                int NumberOfEntries = 0;
                Cursor = Cursors.Wait;

                //Create a file for each delivery method
 
                foreach (int lKey in Enum.GetValues(typeof(DeliveryMethod)))
                {
                    // Save the proposal, e.g. in order to generate labels or collectionlists or deliverylists later on
                    string FileName = Settings.DirectoryPath + "\\Deliveries\\"
                       + Enum.GetName(typeof(DeliveryMethod), lKey)
                       + "_"
                       + gCurrentProduct
                        + "_"
                        + System.DateTime.Now.ToLongDateString()
                        + ".xml";

                    if (!ProductBiz.SplitByDeliveryMethod(ref gDeliveryDoc, FileName, lKey, out int CurrentNumberOfEntries))
                    {
                        return;
                    }

                    NumberOfEntries += CurrentNumberOfEntries;

                } // End of foreach loop

                int Mismatch = gDeliveryDoc.DeliveryRecord.Count - NumberOfEntries;

                if (Mismatch != 0)
                {
                    string Message = "Your XML files do not cover all the deliveries";
                    ExceptionData.WriteException(1, Message, this.ToString(), "GenerateXML", "Mismatched by " + Mismatch.ToString());
                    MessageBox.Show(Message);
                }
                else
                {
                    //buttonGenerateXML.IsEnabled = false;
                    MessageBox.Show("Done");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GenerateXML", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void FormatCourierList(object sender, RoutedEventArgs e)
        {
            if (gBackgroundWorker.IsBusy || gBackgroundWorkerPost.IsBusy)
            {
                return;
            }

            this.Cursor = Cursors.Wait;
            int lCurrentReceiverId = 0; 

            try
            {
                if (checkPayers.IsChecked == false & checkNonPayers.IsChecked == false)
                {
                    MessageBox.Show("This way you are not going to get any labels.");
                    return;
                }
                OpenFileDialog lFileDialog = new OpenFileDialog();

                lFileDialog.InitialDirectory = Settings.DirectoryPath + "\\Deliveries";
                lFileDialog.Multiselect = true;
                lFileDialog.ShowDialog();

                if (lFileDialog.FileNames.Count() == 0)
                {
                    MessageBox.Show("You have not selected any files.");
                    return;
                }

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    if (!lFileName.Contains("\\Courier_"))
                    {
                        MessageBox.Show("I can accept only files of which the name starts with 'Courier'");
                        return;
                    }
                }

                gDeliveryDoc.DeliveryRecord.Clear();

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    //Append all the files into the DeliveryRecord table
                    gDeliveryDoc.DeliveryRecord.ReadXml(lFileName);
                }

                string lResult = ProductBiz.FilterOnPayment((bool)checkPayers.IsChecked, (bool)checkNonPayers.IsChecked, ref gDeliveryDoc);

                if (lResult != "OK")
                {
                    MessageBox.Show(lResult);
                    return;
                }

                //Sort by customerid

                gDeliveryDoc.DeliveryRecord.DefaultView.Sort = "ReceiverId";

                gDeliveryItems.Clear();
                DeliveryItem lNewDeliveryItem = new DeliveryItem();
                gPackageCounters.Clear();

                foreach (DataRowView lDataRowView in gDeliveryDoc.DeliveryRecord.DefaultView)
                {
                    DeliveryDoc.DeliveryRecordRow lRow = (DeliveryDoc.DeliveryRecordRow)lDataRowView.Row;

                    if (lRow.ReceiverId != lCurrentReceiverId)
                    {
                        // This is a new Customer

                        lNewDeliveryItem = new DeliveryItem();
                        gDeliveryItems.Add(lNewDeliveryItem);
                        lCurrentReceiverId = lRow.ReceiverId;

                        lNewDeliveryItem.Date = DateTime.Now.ToString("ddMMyyyy");
                        lNewDeliveryItem.Contact_NameAndSurname = lRow.Title + " " + lRow.Initials + " " + lRow.Surname;
  
                        if (!lRow.IsCompanyNull())
                        {
                            lNewDeliveryItem.Company = lRow.Company;
                        }

                        DeliveryAddressData2 lDeliveryAddressData = new DeliveryAddressData2(lRow.DeliveryAddressId);

                        if (lDeliveryAddressData.Building != "")
                        {
                            lNewDeliveryItem.Address1 = "Building: " + lDeliveryAddressData.Building;
                            if (lDeliveryAddressData.Floor != "")
                            {
                                lNewDeliveryItem.Address1 = lNewDeliveryItem.Address1 + " Floor: " + lDeliveryAddressData.Floor;
                                if (lDeliveryAddressData.Room != "")
                                {
                                    lNewDeliveryItem.Address1 = lNewDeliveryItem.Address1 + " Room: " + lDeliveryAddressData.Room;
                                }
                            };
                        }

                        lNewDeliveryItem.Address2 = lDeliveryAddressData.StreetNo + " " + lDeliveryAddressData.Street + " " + lDeliveryAddressData.StreetExtension
                                                                         + " " + lDeliveryAddressData.StreetSuffix;
                        lNewDeliveryItem.Address3 = lDeliveryAddressData.Suburb;
                        lNewDeliveryItem.Address4 = lDeliveryAddressData.City;
                        lNewDeliveryItem.PostalCode = lDeliveryAddressData.PostCode;
                        lNewDeliveryItem.Country = lDeliveryAddressData.CountryName;

                        CustomerData3 lCustomerData = new CustomerData3(lRow.ReceiverId);

                        if (!lRow.IsPhoneNumberNull())
                        {
                            lNewDeliveryItem.ContactWork_Cell_Phonenumber = lRow.PhoneNumber + " " + lCustomerData.CellPhoneNumber;
                        }

                        lNewDeliveryItem.Weight = lRow.Weight * lRow.UnitsPerIssue; 
                        lNewDeliveryItem.Pieces = lRow.UnitsPerIssue;
                        lNewDeliveryItem.Special_Instructions = lDeliveryAddressData.SDI;
                        lNewDeliveryItem.ProductName = lRow.IssueDescription + " X " + lRow.UnitsPerIssue.ToString() + "; ";
                        lNewDeliveryItem.UniqueReferenceNumber = lRow.ReceiverId.ToString();
                        lNewDeliveryItem.CustomerId = lRow.ReceiverId;
                        lNewDeliveryItem.EmailAddress = lRow.EmailAddress;
                        lNewDeliveryItem.ExpirationDate = lRow.ExpirationDate;

                        lNewDeliveryItem.Building = lDeliveryAddressData.Building;
                        lNewDeliveryItem.FloorNo = lDeliveryAddressData.Floor;
                        lNewDeliveryItem.Room = lDeliveryAddressData.Room;

                        gPackageCounters.Add(new PackageCounter() { CustomerId = lRow.ReceiverId, IssueDescription = lRow.IssueDescription, UnitsPerIssue = lRow.UnitsPerIssue });
                    }
                    else
                    {
                        //Adjust the new row 
                        lNewDeliveryItem.ProductName = lNewDeliveryItem.ProductName + lRow.IssueDescription + " X " + lRow.UnitsPerIssue.ToString() + "; ";
                        lNewDeliveryItem.Weight = lNewDeliveryItem.Weight + lRow.Weight * lRow.UnitsPerIssue;
                        lNewDeliveryItem.Pieces = lNewDeliveryItem.Pieces + lRow.UnitsPerIssue;

                        gPackageCounters.Add(new PackageCounter() { CustomerId = lRow.ReceiverId, IssueDescription = lRow.IssueDescription, UnitsPerIssue = lRow.UnitsPerIssue });
                    }

                } // End of foreach loop

                // Split the deliverylist customers into sub deliverymethods

                List<DeliveryItem> International = new List<DeliveryItem>();
                List<DeliveryItem> Overnight = new List<DeliveryItem>();
                List<DeliveryItem> NextDay = new List<DeliveryItem>();
                List<DeliveryItem> Road = new List<DeliveryItem>();

                foreach (DeliveryItem lItem in gDeliveryItems)
                {
                    if (lItem.Country != "RSA")
                    {
                        International.Add(lItem);
                    }
                    else
                    {
                        if (lItem.Weight <= 2.00M) Overnight.Add(lItem);
                        if (lItem.Weight > 2.00M && lItem.Weight <= 5.00M) NextDay.Add(lItem);
                        if (lItem.Weight > 5.00M) Road.Add(lItem);
                    }
                }

                SerialiseList(International, "International");
                SerialiseList(Overnight, "Overnight");
                SerialiseList(NextDay, "NextDay");
                SerialiseList(Road, "Road");

                // Build the inventory for all deliverymethods
                gInventory.Methods.Clear();
                BuildInventory(International, "International");
                BuildInventory(Overnight, "Overnight");
                BuildInventory(NextDay, "NextDay");
                BuildInventory(Road, "Road");

                // Write the inventory to XML
                string lInventoryFileName = Settings.DirectoryPath + "\\Final_CourierList_ZInventory " + DateTime.Now.ToString("yyyyMMdd") + ".xml";
                FileStream lFileStream = new FileStream(lInventoryFileName, FileMode.Create);
                XmlSerializer lSerializer = new XmlSerializer(typeof(Inventory));
                lSerializer.Serialize(lFileStream, gInventory);
                MessageBox.Show(lInventoryFileName + " successfully written to " +  Settings.DirectoryPath);

                // Write the xsd to the same folder location

                //string lXsdFileName = Settings.DirectoryPath + "\\Final_CourierList_Z.xsd";
                //FileStream lXsdFileStream = new FileStream(lInventoryFileName, FileMode.Create);
                //var lAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                //lXsdFileStream = (FileStream)lAssembly.GetManifestResourceStream("Final_Courier.xsd");
                //lXsdFileStream.Close();
                //lXsdFileStream.Flush();

                //buttonGenerateXML.IsEnabled = false;
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "FormatCourierList", "CurrentReceiverId = " + lCurrentReceiverId.ToString());
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void SerialiseList(List<DeliveryItem> pList, string pMethod)
        {
            try
            {
                // Serialise to XML

                if (pList.Count == 0) return;

                // Serialise to a file stream
                MemoryStream lMemoryStream = new MemoryStream();
                XmlSerializer lSerializer = new XmlSerializer(typeof(List<DeliveryItem>));
     
                // Edit the document
               
                string lFileName = Settings.DirectoryPath + "\\Final_CourierList_" + pMethod + " " + DateTime.Now.ToString("yyyyMMdd") + ".xml";
                FileStream lFileStream = new FileStream(lFileName, FileMode.Create);
                lSerializer.Serialize(lFileStream, pList);
                lFileStream.Flush();
                lFileStream.Close();

                // Ammend the files to point to xsd.
                string[] lLines = File.ReadAllLines(lFileName);
                lLines[1] = lLines[1].Replace(">", " xsi:noNamespaceSchemaLocation=\"DoNotDelete_CourierList.xsd\">");
                File.WriteAllLines(lFileName, lLines);
                             

                MessageBox.Show(pList.Count.ToString() + " Records written to " + lFileName.ToString());
            }

            catch (Exception ex)
            {
                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SerialiseList", "pMethod = " + pMethod);
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                throw ex;
            }
        }
        private  void BuildInventory(List<DeliveryItem> pDeliveryItem, string pMethod)
        {
            try
            {
                if (pDeliveryItem.Count == 0) return;

                gInventory.Methods.Add(new DeliveriesMethod() { Name = pMethod });
                List<PackageCounter> lPackageCounters = new List<PackageCounter>();

                // Accumulate all the relevant package counters for the associated customers.
                foreach (DeliveryItem lItem in pDeliveryItem)
                {
                    if (gPackageCounters.Where(p => p.CustomerId == lItem.CustomerId).Count() > 0)
                    {
                        lPackageCounters.AddRange(gPackageCounters.Where(p => p.CustomerId == lItem.CustomerId).ToList());
                    }
                }

                // Group by IssueDescription
               
                var lAnswer = lPackageCounters.GroupBy(p => p.IssueDescription, (key, values) => new { IssueDescription = key, Units = values.Sum(x => x.UnitsPerIssue) });

                foreach (var lItem2 in lAnswer)
                {
                    gInventory.Methods[gInventory.Methods.Count - 1].Items.Add(new InventoryItem() { IssueDescription = lItem2.IssueDescription, Units = lItem2.Units });
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "BuildInventory", "pMethod = " + pMethod);
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                throw ex;
            }
        }

        private void FormatCollectionList(object sender, RoutedEventArgs e)
        {
            if (gBackgroundWorker.IsBusy || gBackgroundWorkerPost.IsBusy)
            {
                return;
            }

            this.Cursor = Cursors.Wait;
            try
            {
                if (checkPayers.IsChecked == false & checkNonPayers.IsChecked == false)
                {
                    MessageBox.Show("This way you are not going to get any labels.");
                    return;
                }
                //OpenFileDialog lFileDialog = new OpenFileDialog();

                //lFileDialog.InitialDirectory = Settings.DirectoryPath;
                //lFileDialog.ShowDialog();
                //string lFileName = lFileDialog.FileName.ToString();
                //if (!File.Exists(lFileName))

                //{
                //    MessageBox.Show("You have not selected a valid source file ");
                //    return;
                //}

                //gDeliveryDoc.Clear();
                //gDeliveryDoc.DeliveryRecord.ReadXml(lFileName);

                OpenFileDialog lFileDialog = new OpenFileDialog();

                lFileDialog.InitialDirectory = Settings.DirectoryPath + "\\Deliveries";
                lFileDialog.Multiselect = true;
                lFileDialog.ShowDialog();

                if (lFileDialog.FileNames.Count() == 0)
                {
                    MessageBox.Show("You have not selected any files.");
                    return;
                }

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    if (!lFileName.Contains("Collect_"))
                    {
                        MessageBox.Show("I can accept only files of which the name starts with 'Collect_'");
                        return;
                    }
                }

                gDeliveryDoc.DeliveryRecord.Clear();

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    //Append all the files into the DeliveryRecord table
                    gDeliveryDoc.DeliveryRecord.ReadXml(lFileName);
                }



                {
                    string lResult;

                    if ((lResult = ProductBiz.FilterOnPayment((bool)checkPayers.IsChecked, (bool)checkNonPayers.IsChecked, ref gDeliveryDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return;
                    }
                }

                //Sort by customerid

                gDeliveryDoc.DeliveryRecord.DefaultView.Sort = "ReceiverId";

                {
                    string lResult;

                    if ((lResult = ProductBiz.CopyToCollectionList(ref gDeliveryDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return;
                    }
                }

                string OutputFile = Settings.DirectoryPath + "\\Final_CollectionList_" + lFileDialog.SafeFileName;

                gDeliveryDoc.CollectionList.WriteXml(OutputFile);

                MessageBox.Show(gDeliveryDoc.CollectionList.Count.ToString() + " Records written to " + OutputFile.ToString());

                OutputFile = OutputFile.Replace("xml", "xsd");
                gDeliveryDoc.CollectionList.WriteXmlSchema(OutputFile);
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "FormatCollectionList", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                // Stop the thread

                this.Cursor = Cursors.Arrow;
            }

        }

        private void FormatRegisteredMail(object sender, RoutedEventArgs e)
        {
            if (gBackgroundWorker.IsBusy || gBackgroundWorkerPost.IsBusy)
            {
                return;
            }
            this.Cursor = Cursors.Wait;
            try
            {
                if (checkPayers.IsChecked == false & checkNonPayers.IsChecked == false)
                {
                    MessageBox.Show("This way you are not going to get any labels.");
                    return;
                }
                //OpenFileDialog lFileDialog = new OpenFileDialog();

                //lFileDialog.InitialDirectory = Settings.DirectoryPath;
                //lFileDialog.ShowDialog();
                //string lFileName = lFileDialog.FileName.ToString();
                //if (!File.Exists(lFileName))
                //{
                //    MessageBox.Show("You have not selected a valid source file ");
                //    return;
                //}

                //gDeliveryDoc.Clear();
                //gDeliveryDoc.DeliveryRecord.ReadXml(lFileName);

                OpenFileDialog lFileDialog = new OpenFileDialog();

                lFileDialog.InitialDirectory = Settings.DirectoryPath + "\\Deliveries";
                lFileDialog.Multiselect = true;
                lFileDialog.ShowDialog();

                if (lFileDialog.FileNames.Count() == 0)
                {
                    MessageBox.Show("You have not selected any files.");
                    return;
                }

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    if (!lFileName.Contains("\\RegisteredMail_"))
                    {
                        MessageBox.Show("I can accept only files of which the name starts with 'RegisteredMail_'");
                        return;
                    }
                }

                gDeliveryDoc.DeliveryRecord.Clear();

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    //Append all the files into the DeliveryRecord table
                    gDeliveryDoc.DeliveryRecord.ReadXml(lFileName);
                }

                {
                    string lResult;

                    if ((lResult = ProductBiz.FilterOnPayment((bool)checkPayers.IsChecked, (bool)checkNonPayers.IsChecked, ref gDeliveryDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return;
                    }
                }

                // Generate the registered mail list

                //Sort by customerid

                gDeliveryDoc.DeliveryRecord.DefaultView.Sort = "ReceiverId";

                if (!ProductBiz.GenerateRegisteredMail("Surname, Initials", ref gDeliveryDoc))
                {
                    return;
                }

                string OutputFile = Settings.DirectoryPath + "\\Final_RegisteredMailList_" + lFileDialog.SafeFileName;
                gDeliveryDoc.RegisteredMail.WriteXml(OutputFile);

                MessageBox.Show(gDeliveryDoc.RegisteredMail.Count.ToString() + " Records written to " + OutputFile.ToString());

                OutputFile = OutputFile.Replace("xml", "xsd");
                gDeliveryDoc.RegisteredMail.WriteXmlSchema(OutputFile);

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "FormatRegisteredMail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
                return;
            }

            finally
            {
                // Stop the thread

                this.Cursor = Cursors.Arrow;
            }
        }

        private void FormatMagMail(object sender, RoutedEventArgs e)
        {
            if (gBackgroundWorker.IsBusy || gBackgroundWorkerPost.IsBusy)
            {
                return;
            }
            this.Cursor = Cursors.Wait;
            try
            {
                if (checkPayers.IsChecked == false & checkNonPayers.IsChecked == false)
                {
                    MessageBox.Show("This way you are not going to get any labels.");
                    return;
                }
               
                OpenFileDialog lFileDialog = new OpenFileDialog();

                lFileDialog.InitialDirectory = Settings.DirectoryPath + "\\Deliveries";
                lFileDialog.Multiselect = true;
                lFileDialog.ShowDialog();

                if (lFileDialog.FileNames.Count() == 0)
                {
                    MessageBox.Show("You have not selected any files.");
                    return;
                }

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    if (!lFileName.Contains("\\Mail_"))
                    {
                        MessageBox.Show("I can accept only files of which the name starts with 'RegisteredMail_'");
                        return;
                    }
                }

                gDeliveryDoc.DeliveryRecord.Clear();

                foreach (string lFileName in lFileDialog.FileNames)
                {
                    //Append all the files into the DeliveryRecord table
                    gDeliveryDoc.DeliveryRecord.ReadXml(lFileName);
                }

                {
                    string lResult;

                    if ((lResult = ProductBiz.FilterOnPayment((bool)checkPayers.IsChecked, (bool)checkNonPayers.IsChecked, ref gDeliveryDoc)) != "OK")
                    {
                        MessageBox.Show(lResult);
                        return;
                    }
                }

                // Generate the mag mail list

                //Sort by customerid

                gDeliveryDoc.DeliveryRecord.DefaultView.Sort = "ReceiverId";

                if (!ProductBiz.GenerateRegisteredMail("Surname, Initials", ref gDeliveryDoc))
                {
                    return;
                }

                string OutputFile = Settings.DirectoryPath + "\\Final_MagMailList_" + lFileDialog.SafeFileName;
                gDeliveryDoc.RegisteredMail.WriteXml(OutputFile);

                MessageBox.Show(gDeliveryDoc.RegisteredMail.Count.ToString() + " Records written to " + OutputFile.ToString());

                OutputFile = OutputFile.Replace("xml", "xsd");
                gDeliveryDoc.RegisteredMail.WriteXmlSchema(OutputFile);

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "FormatRegisteredMail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
                return;
            }

            finally
            {
                // Stop the thread

                this.Cursor = Cursors.Arrow;
            }

        }

        private void Click_SubscriptionTransactions(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView lRowView = (System.Data.DataRowView)gDeliveryRecordViewSource.View.CurrentItem;
            if (lRowView != null)
            {
                DeliveryDoc.DeliveryRecordRow lRecord = (DeliveryDoc.DeliveryRecordRow)lRowView.Row;
                SubscriptionPicker2 lSubscriptionPicker = new SubscriptionPicker2();
                lSubscriptionPicker.SelectById(lRecord.SubscriptionId);
                lSubscriptionPicker.ShowDialog();
            }
        }
        #endregion
      
    }
}

