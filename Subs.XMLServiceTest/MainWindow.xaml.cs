using Subs.Data;
using Subs.XMLServiceTest.ServiceReference1;
using System;
using System.Linq;
//using Subs.Business;
using System.Reflection;
using System.Windows;

namespace Subs.XMLServiceTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ServiceReference1.CustomerData3 gCustomerDataShallow;
        private ServiceReference1.DeliveryAddressData2 gDeliveryAddressDataShallow;



        public MainWindow()
        {
            InitializeComponent();

            string lConnectionString = global::Subs.XMLServiceTest.Properties.Settings.Default.MIMSConnectionString;

            if (lConnectionString == "")
            {
                throw new Exception("No connection string has been set.");
            }
            else
            {
                Settings.ConnectionString = lConnectionString;
            }
        }

        private void ButtonAuthorize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Business.SeatResult lResult = Subs.Business.SubscriptionBiz.Authorize(17, 89287);

                //MessageBox.Show(lResult.Reason);



                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MOBIMims"
                };

                AuthorizeRequest lRequest = new AuthorizeRequest();
                lRequest.AuthorizationHeader = lHeader;
                lRequest.pProductId = 32;
                lRequest.pReceiverId = 50929;


                AuthorizeResponse lResponse = new AuthorizeResponse();

                lResponse = lClient.Authorize(lRequest);

                MessageBox.Show(lResponse.AuthorizeResult.ExpirationDate.ToString() + " Seats " + lResponse.AuthorizeResult.Seats.ToString() + " " + lResponse.AuthorizeResult.Reason.ToString());

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonAuthorize_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAuthorizations_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MOBIMims"
                };


                AuthorizationsRequest lRequest2 = new AuthorizationsRequest();
                lRequest2.AuthorizationHeader = lHeader;

                // Authorizations

                AuthorizationResult[] lResponse2 = lClient.Authorizations(lRequest2).AuthorizationsResult;

                var Found = lResponse2.Where<AuthorizationResult>(f => f.CustomerId == 50929)
                            .Select(g => new { g.CustomerId, g.Seats, g.ProductId, g.ExpirationDate });

                foreach (var p in Found)
                {
                    MessageBox.Show(p.CustomerId.ToString() + "ProductId= " + p.ProductId.ToString() + "Seats=" + p.Seats.ToString() +
                        "Expire= " + p.ExpirationDate.ToString());
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonAuthorizations_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void ButtonFindCustomerByEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MOBIMims"
                };

                FindCustomerIdByEmailRequest lRequest = new FindCustomerIdByEmailRequest();
                lRequest.AuthorizationHeader = lHeader;
                lRequest.EmailAddress = "spadaccinod@tisoblackstar.co.za";


                FindCustomerIdByEmailResponse lResponse = new FindCustomerIdByEmailResponse();

                lResponse = lClient.FindCustomerIdByEmail(lRequest);

                MessageBox.Show(lResponse.CustomerId.ToString());

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonFindCustomerByEmail_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }

        }


        private void ButtonFindCustomerByNationalId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MOBIMims"
                };

                FindCustomerIdByNationalIdRequest lRequest = new FindCustomerIdByNationalIdRequest();
                lRequest.AuthorizationHeader = lHeader;
                lRequest.NationalId = "9012145134082";


                FindCustomerIdByNationalIdResponse lResponse = new FindCustomerIdByNationalIdResponse();

                lResponse = lClient.FindCustomerIdByNationalId(lRequest);

                MessageBox.Show(lResponse.CustomerId.ToString());

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonFindCustomerByNationalId_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }


        private void ButtonFindEmailByCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MOBIMims"
                };

                FindEMailByCustomerIdRequest lRequest = new FindEMailByCustomerIdRequest();
                lRequest.AuthorizationHeader = lHeader;
                lRequest.pCustomerId = 117224;


                FindEMailByCustomerIdResponse lResponse = new FindEMailByCustomerIdResponse();

                lResponse = lClient.FindEMailByCustomerId(lRequest);

                MessageBox.Show(lResponse.pEmailAddress);

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonFindEmailByCustomer_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }


        }


        private void ButtonInsertCustomer_Click(object sender, RoutedEventArgs e)
        {

            ServiceReference1.InsertCustomerResponse lResponse = new InsertCustomerResponse();

            try
            {

                try
                {
                    ServiceSoapClient lClient = new ServiceSoapClient();
                    AuthorizationHeader lHeader = new AuthorizationHeader
                    {
                        Source = "NJA",
                        Type = "MIMS"
                    };

                    ServiceReference1.InsertCustomerRequest lRequest = new InsertCustomerRequest();
                    lRequest.AuthorizationHeader = lHeader;

                    ServiceReference1.CustomerData3 lCustomerData = new ServiceReference1.CustomerData3();

                    lCustomerData.TitleId = 2;
                    lCustomerData.CompanyId = 3;
                    lCustomerData.CountryId = 61;
                    lCustomerData.Initials = "HD";
                    lCustomerData.Surname = "Reitmann";
                    lCustomerData.CellPhoneNumber = "0829598631";
                    lCustomerData.EmailAddress = "heinreitmann@gmail.com";
                    //lCustomerData.PhoneNumber = "0128070533";
                    lCustomerData.LoginEmail = "heinreitmann@gmail.com";

                    lCustomerData.Address1 = "Remskoen 522";
                    lCustomerData.Address2 = "Iets";
                    lCustomerData.Address3 = "Die Wilgers";
                    lCustomerData.Address4 = "Tshwane";
                    lCustomerData.Address5 = "0041";
                    lCustomerData.AddressType = ServiceReference1.AddressType.UnAssigned;

                    lCustomerData.PhysicalAddressId = 19550;
                    lCustomerData.Correspondence2 = 1;
                    lCustomerData.Liability = 0;
                    lCustomerData.Status = ServiceReference1.CustomerStatus.Active;

                    lCustomerData.PhysicalAddressId = 19550;
                    //lCustomerData.CheckpointInvoiceDate = DateTime.Now;
                    //lCustomerData.CheckpointPaymentDate = DateTime.Now;
                    //lCustomerData.VerificationDate = DateTime.Now;

                    lCustomerData.ModifiedOn = DateTime.Now.Date;
                    lCustomerData.ModifiedBy = "AVUSA\\REITMANNH";

                    lRequest.pCustomerData = lCustomerData;

                    lResponse = lClient.InsertCustomer(lRequest);
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

                    if (ex.Message.Contains("Server was unable to read request"))
                    {
                        MessageBox.Show(ex.Message.Substring(ex.Message.IndexOf('>', 40) + 1));
                        return;
                    }
                    else
                    {
                        throw ex;
                    }
                }


                if (lResponse.InsertCustomerResult != "OK")

                {
                    MessageBox.Show(lResponse.InsertCustomerResult + " " + lResponse.pCustomerData.CustomerId.ToString());
                }
                else
                {
                    MessageBox.Show("CustomerId = " + lResponse.pCustomerData.CustomerId.ToString());
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonInsertCustomer_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }


        private void ButtonGetCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MIMS"
                };

                ServiceReference1.GetCustomerRequest lRequest = new GetCustomerRequest();
                lRequest.AuthorizationHeader = lHeader;

                lRequest.pLoginEmail = "spadaccinod@tisoblackstar.co.za";

                ServiceReference1.GetCustomerResponse lResponse = new GetCustomerResponse();

                lResponse = lClient.GetCustomer(lRequest);

                if (lResponse.GetCustomerResult != "OK")

                {
                    MessageBox.Show(lResponse.GetCustomerResult);
                }
                else
                {
                    gCustomerDataShallow = lResponse.pCustomerData;
                    MessageBox.Show("LoginEmail = " + lResponse.pCustomerData.LoginEmail + " " + lResponse.pCustomerData.NationalId1);
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonGetCustomer_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }






        private void ButtonUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MIMS"
                };

                ServiceReference1.UpdateCustomerRequest lRequest = new UpdateCustomerRequest();
                lRequest.AuthorizationHeader = lHeader;

                if (gCustomerDataShallow == null)
                {
                    MessageBox.Show("There is no customer to update.");
                    return;
                }

                gCustomerDataShallow.PhoneNumber = "0128070533";

                lRequest.pCustomerData = gCustomerDataShallow;

                ServiceReference1.UpdateCustomerResponse lResponse = new UpdateCustomerResponse();

                lResponse = lClient.UpdateCustomer(lRequest);

                if (lResponse.UpdateCustomerResult != "OK")

                {
                    MessageBox.Show(lResponse.UpdateCustomerResult);
                }
                else
                {
                    MessageBox.Show("Address1 was updated to: " + lResponse.pCustomerData.Address1.ToString());
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonUpdateCustomer_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonReflection_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Subs.Data.CustomerData3 lCustomerDataSource = new Data.CustomerData3();
                Subs.Data.CustomerData3 lCustomerDataTarget = new Data.CustomerData3(117224);

                lCustomerDataSource.FirstName = "HAHA";

                PropertyInfo[] lPropertiesSource = lCustomerDataSource.GetType().GetProperties();
                //PropertyInfo[] lPropertiesTarget = lCustomerDataTarget.GetType().GetProperties();


                PropertyInfo InitialsSource = lPropertiesSource[6];
                PropertyInfo InitialsTarget = lPropertiesSource[6];

                InitialsTarget.SetValue(lCustomerDataTarget, InitialsSource.GetValue(lCustomerDataSource, null));

                MessageBox.Show("Target value is for " + InitialsSource.Name + " " + lCustomerDataTarget.FirstName);




                //MessageBox.Show(prop.Name + " " + prop.GetValue(lCustomerDataSource, null).ToString());


                //MessageBox.Show("There are " + lProperties.Count().ToString() + " in CustomerData");

                //foreach (PropertyInfo prop in lProperties)
                //{
                //    MessageBox.Show(prop.Name + " " + prop.GetValue(lCustomerData, null).ToString());
                //}

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonReflection", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonInsertDeliveryAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MIMS"
                };

                ServiceReference1.InsertDeliveryAddressRequest lRequest = new InsertDeliveryAddressRequest();
                lRequest.AuthorizationHeader = lHeader;

                ServiceReference1.DeliveryAddressData2 lDeliveryAddressData = new ServiceReference1.DeliveryAddressData2();

                lDeliveryAddressData.PhoneNumber = "0000000";
                lDeliveryAddressData.CountryId = 61;
                lDeliveryAddressData.Province = "Gauteng";
                lDeliveryAddressData.City = "Tshwane";
                lDeliveryAddressData.Street = "Remskoen";
                lDeliveryAddressData.StreetExtension = "Ext3";
                lDeliveryAddressData.StreetSuffix = "Laan";
                lDeliveryAddressData.StreetNo = "522";

                lDeliveryAddressData.Building = "High";
                lDeliveryAddressData.Floor = "5";
                lDeliveryAddressData.Room = "10";
                lDeliveryAddressData.PostCode = "10000";

                //lDeliveryAddressData.X = "28.2144";
                //lDeliveryAddressData.Y = "-25.72782";

                ServiceReference1.InsertDeliveryAddressResponse lResponse = new InsertDeliveryAddressResponse();

                lRequest.pDeliveryAddressData = lDeliveryAddressData;

                lRequest.pCustomerId = 117990;

                lResponse = lClient.InsertDeliveryAddress(lRequest);

                if (lResponse.InsertDeliveryAddressResult != "OK")

                {
                    MessageBox.Show(lResponse.InsertDeliveryAddressResult);
                }
                else
                {
                    MessageBox.Show("DeliveryAddressId = " + lResponse.pDeliveryAddressData.DeliveryAddressId.ToString());
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonInsertDeliveryAddress_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonGetDeliveryAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MIMS"
                };

                ServiceReference1.GetDeliveryAddressRequest lRequest = new GetDeliveryAddressRequest();
                lRequest.AuthorizationHeader = lHeader;

                lRequest.pDeliveryAddressId = 38401;

                ServiceReference1.GetDeliveryAddressResponse lResponse = new GetDeliveryAddressResponse();

                lResponse = lClient.GetDeliveryAddress(lRequest);

                if (lResponse.GetDeliveryAddressResult != "OK")

                {
                    MessageBox.Show(lResponse.GetDeliveryAddressResult);
                }
                else
                {
                    gDeliveryAddressDataShallow = lResponse.pDeliveryAddressData;
                    MessageBox.Show("Delivery street = " + lResponse.pDeliveryAddressData.Street);
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonGetDeliveryAddress_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonUpdateDeliveryAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceSoapClient lClient = new ServiceSoapClient();
                AuthorizationHeader lHeader = new AuthorizationHeader
                {
                    Source = "NJA",
                    Type = "MIMS"
                };

                ServiceReference1.UpdateDeliveryAddressRequest lRequest = new UpdateDeliveryAddressRequest();
                lRequest.AuthorizationHeader = lHeader;

                if (gDeliveryAddressDataShallow == null)
                {
                    MessageBox.Show("There is no DeliveryAddress to update.");
                    return;
                }

                gDeliveryAddressDataShallow.Street = "EmpireEmpire";

                lRequest.pDeliveryAddressData = gDeliveryAddressDataShallow;

                ServiceReference1.UpdateDeliveryAddressResponse lResponse = new UpdateDeliveryAddressResponse();

                lResponse = lClient.UpdateDeliveryAddress(lRequest);

                if (lResponse.UpdateDeliveryAddressResult != "OK")

                {
                    MessageBox.Show(lResponse.UpdateDeliveryAddressResult);
                }
                else
                {
                    MessageBox.Show("Street was updated to: " + lResponse.pDeliveryAddressData.Street.ToString());
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ButtonUpdateDeliveryAddress_Click", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show(ex.Message);
            }
        }


    }
}
