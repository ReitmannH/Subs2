using Subs.Business;
using Subs.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Subs.XMLService
{
    public class AuthorizationHeader : SoapHeader
    {
        public string Type;
        public string Source;
    }

    public class UserInfo
    {
        public string Name;
        public string Surname;
        public string CouncilNumber;
    }

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        public AuthorizationHeader Authentication;

        public void Sevice()
        {

        }

        [SoapHeader("Authentication")]
        [WebMethod]
        public SeatResult Authorize(int pProductId, int pReceiverId)
        {
            try
            {

                if (Authentication.Source == "NJA" &&
                Authentication.Type == "MOBIMims")
                {
                    return SubscriptionBiz.Authorize(pProductId, pReceiverId);
                }
                else
                {
                    throw new Exception("Invalid Source and/or Type");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Authorize", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                SeatResult lSeatResult = new SeatResult();
                lSeatResult.Seats = 0;
                lSeatResult.Reason = "Failed due to technical error";

                return lSeatResult;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public List<AuthorizationResult> Authorizations()
        {
            List<AuthorizationResult> lResult = new List<AuthorizationResult>();

            int lProgress = 0;
            try
            {
                lProgress = 1;
                if (Authentication.Source == "NJA" &&
                Authentication.Type == "MOBIMims")
                {
                    lProgress = 2;
                    lResult = SubscriptionBiz.Authorizations();
                    lProgress = 3;
                    return lResult;
                }
                else
                {
                    lProgress = 4;
                    throw new Exception("Invalid Source and/or Type");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Authorizations", "Progress = " + lProgress.ToString());
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return lResult;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public bool FindEMailByCustomerId(int pCustomerId, out string pEmailAddress)
        {
            pEmailAddress = "Non Existent";

            try
            {

                if (Authentication.Source == "NJA" &&
                Authentication.Type == "MOBIMims")
                {
                    if (CustomerData3.Exists(pCustomerId))
                    {
                        CustomerData3 lCustomerData = new CustomerData3(pCustomerId);
                        pEmailAddress = lCustomerData.EmailAddress;
                    }
                    return true;
                }
                else
                {
                    throw new Exception("Invalid Source and/or Type");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "FindEmailByCustomer", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return false;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public bool FindCustomerIdByEmail(string EmailAddress, out int CustomerId)
        {
            try
            {


                if (Authentication.Source == "NJA" &&
                Authentication.Type == "MOBIMims")
                {
                    return Subs.Data.CustomerData3.FindCustomerId(EmailAddress, out CustomerId);
                }
                else
                {
                    throw new Exception("Invalid Source and/or Type");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "FindCustomerIdByEmail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                CustomerId = 0;

                return false;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public bool FindCustomerIdByNationalId(string NationalId, out int CustomerId)
        {
            try
            {


                if (Authentication.Source == "NJA" &&
                Authentication.Type == "MOBIMims")
                {
                    return Subs.Data.CustomerData3.FindCustomerIdByNationalId(NationalId, out CustomerId);
                }
                else
                {
                    throw new Exception("Invalid Source and/or Type");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "FindCustomerIdByEmail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                CustomerId = 0;

                return false;
            }
        }



        [SoapHeader("Authentication")]
        [WebMethod]
        public string InsertCustomer(ref CustomerData3 pCustomerData)
        {
            try
            {
                if (Authentication.Source != "NJA" ||
                Authentication.Type != "MIMS")
                {
                    return "WebService authentication failed";
                }

                if (Regex.IsMatch(pCustomerData.LoginEmail, @"\.@|@\."))
                {
                    return "This is not a valid login mail address";
                }

                if (!Regex.IsMatch(pCustomerData.LoginEmail, @"^([&\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,20}|[0-9]{1,3})(\]?)$"))
                {
                    return "This is not a valid login email address";
                }

                pCustomerData.CheckpointInvoiceDate = DateTime.Now;
                pCustomerData.CheckpointPaymentDate = DateTime.Now;
                pCustomerData.VerificationDate = DateTime.Now;

                {
                    string lResult;

                    if ((lResult = CustomerBiz.ValidateDuplicate(pCustomerData)) != "OK")
                    {
                        return lResult;
                    }
                }

                {
                    string lResult;

                    if ((lResult = CustomerBiz.UpdateCustomer(pCustomerData)) != "OK")
                    {
                        return "UpdateCustomer failed: " + lResult;
                    }
                    else
                    {
                        return "OK";
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "InsertCustomer", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "InsertCustomer failed: " + ex.Message;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public string GetCustomer(string pLoginEmail, out CustomerData3 pCustomerData)
        {
            pCustomerData = new CustomerData3();

            try
            {
                if (Authentication.Source != "NJA" ||
                Authentication.Type != "MIMS")
                {
                    return "WebService authentication failed";
                }

                CustomerData3 lCustomerData = new CustomerData3(pLoginEmail);
                pCustomerData = lCustomerData;

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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetCustomer", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "GetCustomer failed: " + ex.Message;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public string UpdateCustomer(ref CustomerData3 pCustomerData)
        {
            try
            {
                if (Authentication.Source != "NJA" ||
                Authentication.Type != "MIMS")
                {
                    return "WebService authentication failed";
                }

                if (pCustomerData.CustomerId < 1)
                {
                    return "You cannot update a customer if you have not even loaded it.";
                }

                // I am going to update only some fields.

                CustomerData3 lCustomerData = new CustomerData3(pCustomerData.LoginEmail);

                lCustomerData.TitleId = pCustomerData.TitleId;
                lCustomerData.CompanyId = pCustomerData.CompanyId;

                lCustomerData.Surname = pCustomerData.Surname;
                lCustomerData.CellPhoneNumber = pCustomerData.CellPhoneNumber;
                lCustomerData.EmailAddress = pCustomerData.EmailAddress;
                lCustomerData.PhoneNumber = pCustomerData.PhoneNumber;
                lCustomerData.CouncilNumber = pCustomerData.CouncilNumber;

                lCustomerData.Address1 = pCustomerData.Address1;
                lCustomerData.Address2 = pCustomerData.Address2;
                lCustomerData.Address3 = pCustomerData.Address3;
                lCustomerData.Address4 = pCustomerData.Address4;
                lCustomerData.Address5 = pCustomerData.Address5;
                lCustomerData.AddressType = AddressType.UnAssigned;

                lCustomerData.PhysicalAddressId = pCustomerData.PhysicalAddressId;
                lCustomerData.Correspondence2 = pCustomerData.Correspondence2;

                {
                    string lResult;

                    if ((lResult = CustomerBiz.UpdateCustomer(lCustomerData)) != "OK")
                    {
                        return "UpdateCustomer failed: " + lResult;
                    }
                    else
                    {
                        return "OK";
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "UpdateCustomer", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "UpdateCustomer failed: " + ex.Message;
            }
        }



        [SoapHeader("Authentication")]
        [WebMethod]
        public string InsertDeliveryAddress(ref DeliveryAddressData2 pDeliveryAddressData, int pCustomerId)
        {
            try
            {
                if (pCustomerId == 0)
                {
                    return "0 is not a valid CustomerId";
                }

                if (Authentication.Source != "NJA" ||
                Authentication.Type != "MIMS")
                {
                    return "WebService authentication failed";
                }

                {
                    string lResult;

                    if ((lResult = pDeliveryAddressData.Update()) != "OK")
                    {
                        return lResult;
                    }
                }

                // You also have to link the new address

                DeliveryAddressData2.Link(pDeliveryAddressData.DeliveryAddressId, pCustomerId);

                {
                    string lResult;

                    if ((lResult = DeliveryAddressData2.Link(pDeliveryAddressData.DeliveryAddressId, pCustomerId)) != "OK")
                    {
                        return lResult;
                    }
                }


                // Update the pointer in CustomerData
                CustomerData3 lCustomerData = new CustomerData3(pCustomerId);
                lCustomerData.PhysicalAddressId = pDeliveryAddressData.DeliveryAddressId;
                lCustomerData.Update();

                ExceptionData.WriteException(5, "1" + " " + "DeliveryAddress sucessfully inserted", this.ToString(), "InsertDeliveryAddress", pDeliveryAddressData.DeliveryAddressId.ToString());
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "InsertDeliveryAddress", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "InsertDeliveryAddress failed: " + ex.Message;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public string GetDeliveryAddress(int pDeliveryAddressId, out DeliveryAddressData2 pDeliveryAddressData)
        {
            pDeliveryAddressData = null;

            try
            {
                if (Authentication.Source != "NJA" ||
                Authentication.Type != "MIMS")
                {
                    return "WebService authentication failed";
                }

                DeliveryAddressData2 lDeliveryAddressData = new DeliveryAddressData2(pDeliveryAddressId);
                pDeliveryAddressData = lDeliveryAddressData;

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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetDeliveryAddress", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "GetCustomer failed: " + ex.Message;
            }
        }


        [SoapHeader("Authentication")]
        [WebMethod]
        public string UpdateDeliveryAddress(ref DeliveryAddressData2 pDeliveryAddressData)
        {
            string lCurrentProperty = "Nothing";

            try
            {
                if (Authentication.Source != "NJA" ||
                Authentication.Type != "MIMS")
                {
                    return "WebService authentication failed";
                }

                DeliveryAddressData2 lDeliveryAddressDataTarget = new DeliveryAddressData2(pDeliveryAddressData.DeliveryAddressId);


                PropertyInfo[] lPropertiesSource = pDeliveryAddressData.GetType().GetProperties();

                // Update all the properties

                foreach (PropertyInfo lItem in lPropertiesSource)
                {
                    lCurrentProperty = lItem.Name;

                    MethodInfo lMethodInfo = lItem.SetMethod;

                    if (lMethodInfo != null)
                    {
                        // There is a set method
                        lItem.SetValue(lDeliveryAddressDataTarget, lItem.GetValue(pDeliveryAddressData, null));
                    }
                }

                pDeliveryAddressData = lDeliveryAddressDataTarget; // Serialise the updated object back to the source. 

                return pDeliveryAddressData.Update();

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "UpdateDeliveryAddress", "CurrentItem = " + lCurrentProperty);
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return "UpdateDeliveryAddress failed: " + ex.Message;
            }
        }


    }
}
