using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Data;
using Subs.WebApi.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;
//using Newtonsoft.Json;

namespace Subs.WebApi.Controllers
{

    public class HomeController : Controller
    {
        #region Globals

        private readonly string EMailHostIP = Settings.EMailHostIp; //"172.15.64.23";

        #endregion


        // GET: Home
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }



        // Contact *********************************************************************************************

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        // About *********************************************************************************************

        [HttpGet]
        public ViewResult About()
        {
            return View();
        }



        // Register a user *********************************************************************************************

        [HttpGet]
        public ActionResult RegisterEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterEmail(LoginRequest pLoginRequest)
        {
            int lCustomerId = 0;
            try
            {
                LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];

                if (lLoginRequest != null)
                {
                    ViewBag.Message = "This session is already logged in, not to mention registered.";
                    return View();
                }



                if (Regex.IsMatch(pLoginRequest.Email, @"\.@|@\."))
                {
                    ViewBag.Message = "This is not a valid Email address.";
                    return View();
                }

                if (!Regex.IsMatch(pLoginRequest.Email, @"^([&\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,5}|[0-9]{1,3})(\]?)$"))
                {
                    ViewBag.Message = "This is not a valid Email address.";
                    return View();
                }
                
                
                lCustomerId = CustomerData3.ExistsByLoginEmail(pLoginRequest.Email);
                if (lCustomerId != 0)
                {
                    // This is an existing customer
                    ViewBag.Message = "You are an existing user. Please login.";
                    return View();
                }
                else
                {
                    // Ask person to check his email to set or reset his password
                    Guid lGuid = Guid.NewGuid();
                    AdministrationData2.InsertByGUID(lGuid, "ActivationToken", pLoginRequest.Email);

                    // Send Email. 

                    if (!SendEmailRegisterEmail(lGuid, pLoginRequest.Email))
                        {
                        return View();
                    }


                    //var email_json = "{" +
                    //  "\"personalizations\": [{" +
                    //      "\"to\": [{" +
                    //          "\"email\": \"" + pEmail + "\"," +
                    //          "\"name\": \"Hein Reitmann\"" +

                    //      "}]," +
                    //      "\"substitutions\": {" +
                    //          "\"%token%\": \"123\"" +
                    //      "}" +
                    //  "}]," +

                    //  "\"from\": {" +
                    //      "\"email\": \"ReitmannH@Timesmedia.co.za\"," +
                    //      "\"name\": \"Hein Reitmann\"" +
                    //  "}," +
                    //  "\"reply_to\": {" +
                    //      "\"email\": \"ReitmannH@Timesmedia.co.za\"," +
                    //      "\"name\": \"Hein Reitmann\"" +
                    //  "}," +
                    //  "\"subject\": \"User verification\"," +
                    //  "\"template_id\": \"bfd8a675-8ba2-42ca-827a-0ffcc9c19f6d\"" +

                    //"}";
                    //var client = new RestClient("https://api.sendgrid.com/v3/mail/send");
                    //var request = new RestRequest(Method.POST);
                    //request.AddHeader("content-type", "application/json");
                    //request.AddHeader("authorization", "Bearer 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");
                    //request.AddParameter("application/json", email_json, ParameterType.RequestBody);
                    //IRestResponse response = client.Execute(request);


                    ViewBag.Message = "Please check your email to complete the registration.";
                    return View();
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RegisterEmail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "Error in RegisterEmail" + ex.Message;
                return View();
            }
        }

        private bool SendEmailRegisterEmail(Guid pGuid, string Destination)
        {
            try
            {
                SmtpClient myClient = new SmtpClient();
                MailMessage myMessage = new MailMessage("vandermerwer@timesmedia.co.za", Destination);
                //Attachment myAttachment = new Attachment(FileName, System.Net.Mime.MediaTypeNames.Application.Pdf);
                //myMessage.Attachments.Add(myAttachment);
                myMessage.Subject = "EMail registration";
                string myBody = "Please follow this link: http://196.34.62.96/Home/InitialAccount?pGuid=" + pGuid;

                myMessage.Body = myBody;
                myClient.Host = EMailHostIP;
                myClient.UseDefaultCredentials = true;
                myClient.Send(myMessage);
                return true;
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SendEmailRegisterEmail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message(ex.Message);
                return false;
            }
        }


        [HttpGet]
        public ActionResult InitialAccount(Guid pGuid)
        {
            //  Validate the RegisterToken

            AdministrationDoc.GUIDTableDataTable lGUIDTable = new AdministrationDoc.GUIDTableDataTable();
            AdministrationData2.FillGUIDByGUID(pGuid, ref lGUIDTable);

            if (lGUIDTable.Count != 1)
            {
                ViewBag.Message = "Invalid attempt to register a user profile";
                return View("Empty");
            }


            // Populate titles

            try
            {

                var lTitleQuery = from lRow in AdministrationData2.Title
                                  select new ListItem { Key = lRow.TitleId, Value = lRow.Title };

                SelectList lTitleList = new SelectList((IEnumerable<ListItem>)lTitleQuery.ToList(), "Key", "Value", 1);

                var lCountryQuery = from lRow in AdministrationData2.Country
                                    select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };

                SelectList lCountryList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value", 61);

                UserTemplate lUserTemplate = new UserTemplate();
                lUserTemplate.TitleId = 1;
                lUserTemplate.TitleSelectList = lTitleList;

                lUserTemplate.CountryId = 61;
                lUserTemplate.CountrySelectList = lCountryList;

                lUserTemplate.LoginEmail = lGUIDTable[0].Email; ;
                lUserTemplate.EmailAddress = lGUIDTable[0].Email; ;

                return View("InitialAccount", lUserTemplate);  // Here, lUserTemplate is a model, explicitely populated.. 
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "InitialAccount", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return View("Error");
            }
        }



        [HttpPost]
        public ActionResult InitialAccount(UserTemplate pUserTemplate)
        {

            CustomerData3 lCustomerData = new CustomerData3();

            var lTitleQuery = from lRow in AdministrationData2.Title
                              select new ListItem { Key = lRow.TitleId, Value = lRow.Title };

            SelectList lTitleList = new SelectList((IEnumerable<ListItem>)lTitleQuery.ToList(), "Key", "Value", pUserTemplate.TitleId);
            pUserTemplate.TitleSelectList = lTitleList;

            // Populate countrieslist

            var lCountryQuery = from lRow in AdministrationData2.Country
                                select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };

            SelectList lCountryList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value", pUserTemplate.CountryId);
            pUserTemplate.CountrySelectList = lCountryList;


            try {

                // Set all the fields, as applicable


                if ((int)pUserTemplate.TitleId != 0)
                {
                    try { lCustomerData.TitleId = (int)pUserTemplate.TitleId; }
                    catch (Exception Ex) { ModelState.AddModelError("TitleSelectList", Ex.Message); }
                }

                if (pUserTemplate.Initials != "")
                {
                    try { lCustomerData.Initials = pUserTemplate.Initials; }
                    catch (Exception Ex) { ModelState.AddModelError("Initials", Ex.Message); }
                }


                if (pUserTemplate.FirstName != "")
                {
                    try { lCustomerData.FirstName = pUserTemplate.FirstName; }
                    catch (Exception Ex) { ModelState.AddModelError("FirstName", Ex.Message); }
                }


                if (pUserTemplate.Surname != "")
                {
                    try { lCustomerData.Surname = pUserTemplate.Surname; }
                    catch (Exception Ex) { ModelState.AddModelError("Surname", Ex.Message); }
                }


                if (pUserTemplate.LoginEmail != "")
                {
                    try { lCustomerData.LoginEmail = pUserTemplate.EmailAddress; }
                    catch (Exception Ex) { ModelState.AddModelError("LoginEmail", Ex.Message); }
                }


                if (pUserTemplate.EmailAddress != "")
                {
                    try { lCustomerData.EmailAddress = pUserTemplate.EmailAddress; }
                    catch (Exception Ex) { ModelState.AddModelError("EmailAddress", Ex.Message); }
                }

                if (pUserTemplate.PhoneNumber != "")
                {
                    try { lCustomerData.PhoneNumber = pUserTemplate.PhoneNumber; }
                    catch (Exception Ex) { ModelState.AddModelError("PhoneNumber", Ex.Message); }
                }


                if (pUserTemplate.CellPhoneNumber != "")
                {
                    try { lCustomerData.CellPhoneNumber = pUserTemplate.CellPhoneNumber; }
                    catch (Exception Ex) { ModelState.AddModelError("CellPhoneNumber", Ex.Message); }
                }


                if (pUserTemplate.Address1 != "")
                {
                    try { lCustomerData.Address1 = pUserTemplate.Address1; }
                    catch (Exception Ex) { ModelState.AddModelError("Address1", Ex.Message); }
                }

                if (pUserTemplate.Address2 != "")
                {
                    try { lCustomerData.Address2 = pUserTemplate.Address2; }
                    catch (Exception Ex) { ModelState.AddModelError("Address2", Ex.Message); }
                }

                if (pUserTemplate.Address3 != "")
                {
                    try { lCustomerData.Address3 = pUserTemplate.Address3; }
                    catch (Exception Ex) { ModelState.AddModelError("Address3", Ex.Message); }
                }

                if (pUserTemplate.Address4 != "")
                {
                    try { lCustomerData.Address4 = pUserTemplate.Address4; }
                    catch (Exception Ex) { ModelState.AddModelError("Address4", Ex.Message); }
                }

                if (pUserTemplate.Address5 != "")
                {
                    try { lCustomerData.Address5 = pUserTemplate.Address5; }
                    catch (Exception Ex) { ModelState.AddModelError("Address4", Ex.Message); }
                }


                if (pUserTemplate.CountryId != 0)
                {
                    try { lCustomerData.CountryId = pUserTemplate.CountryId; }
                    catch (Exception Ex) { ModelState.AddModelError("TitleId", Ex.Message); }
                }


                if (pUserTemplate.Password != "")
                {
                    if (pUserTemplate.Password == pUserTemplate.ConfirmedPassword)
                    {
                        lCustomerData.Password = pUserTemplate.Password;
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "The confirmed password does not match the original password.");
                    }
                }


           

                if (!ModelState.IsValid)
                {

                    ViewBag.Message = "Sorry, some of the data are in error.";

                    return View("InitialAccount", pUserTemplate);   // Here I want to invoke the InitialAccount view with the pUserTemplate again, plus the ModelState 
                }
                else
                {
                    {
                        string lResult;
                        if ((lResult = lCustomerData.Update()) != "OK")
                        {
                            ViewBag.Message = lResult;
                            return View("InitialAccount", pUserTemplate);
                        }
                    }

                    CustomerData3 lNewCustomer = new CustomerData3(lCustomerData.CustomerId); // Do this to get the machine readible stuff into the object

                    LoginRequest lLoginRequest = new Models.LoginRequest();
                    lLoginRequest.CustomerId = lCustomerData.CustomerId;
                    lLoginRequest.Email = lCustomerData.LoginEmail;
                    lLoginRequest.Password = lCustomerData.Password;

                    Session["LoginRequest"] = lLoginRequest;
                    ViewBag.Message = "Welcome " + lNewCustomer.Title + " " + lCustomerData.Surname + ".You are now logged in. Please proceed.";
                    return View("Empty");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RequestUserProfile", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
                return View("Empty");
            }
        }




        [HttpGet]
        public ActionResult Account()
        {
            LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];

            CustomerData3 lCustomerData = new CustomerData3(lLoginRequest.CustomerId);

            try
            {

                // Populate titlelist

                var lTitleQuery = from lRow in AdministrationData2.Title
                                  select new ListItem { Key = lRow.TitleId, Value = lRow.Title };

                SelectList lTitleList = new SelectList((IEnumerable<ListItem>)lTitleQuery.ToList(), "Key", "Value", 1);

                // Populate countrieslist

                var lCountryQuery = from lRow in AdministrationData2.Country
                                  select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };

                SelectList lCountryList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value", 1);

                // Map the values

                UserTemplate lUserTemplate = new UserTemplate();

                lUserTemplate.LoginEmail = lCustomerData.LoginEmail;
                lUserTemplate.Password = lCustomerData.Password;
                lUserTemplate.CustomerId = lCustomerData.CustomerId;
                lUserTemplate.TitleId = lCustomerData.TitleId;
                lUserTemplate.TitleSelectList = lTitleList;
                lUserTemplate.Initials = lCustomerData.Initials;
                lUserTemplate.FirstName = lCustomerData.FirstName;
                lUserTemplate.Surname = lCustomerData.Surname;
                lUserTemplate.EmailAddress = lCustomerData.EmailAddress;
                lUserTemplate.PhoneNumber = lCustomerData.PhoneNumber;
                lUserTemplate.CellPhoneNumber = lCustomerData.CellPhoneNumber;

                lUserTemplate.Address1 = lCustomerData.Address1;
                lUserTemplate.Address2 = lCustomerData.Address2;
                lUserTemplate.Address3 = lCustomerData.Address3;
                lUserTemplate.Address4 = lCustomerData.Address4;
                lUserTemplate.CountryId = lCustomerData.CountryId;
                lUserTemplate.CountrySelectList = lCountryList;
                lUserTemplate.Address5 = lCustomerData.Address5;

                return View("Account", lUserTemplate);
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Account", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message(ex.Message);
                return View();
            }
        }
         
        [HttpPost]
        public ActionResult Account(UserTemplate UserTemplate)
        {
            LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
            CustomerData3 lCustomerData = new CustomerData3(lLoginRequest.CustomerId);

            try
            {

                var lTitleQuery = from lRow in AdministrationData2.Title
                              select new ListItem { Key = lRow.TitleId, Value = lRow.Title };

                SelectList lTitleList = new SelectList((IEnumerable<ListItem>)lTitleQuery.ToList(), "Key", "Value", UserTemplate.TitleId);

                UserTemplate.TitleSelectList = lTitleList;

                var lCountryQuery = from lRow in AdministrationData2.Country
                                  select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };

                SelectList lCountryList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value", UserTemplate.CountryId);

                UserTemplate.CountrySelectList = lCountryList;

                //Set all the fields, as applicable

                if (UserTemplate.TitleId != 0)
                {
                    try { lCustomerData.TitleId = UserTemplate.TitleId; }
                    catch (Exception Ex) { ModelState.AddModelError("TitleId", Ex.Message); }
                }

                if (UserTemplate.Initials != "")
                {
                    try { lCustomerData.Initials = UserTemplate.Initials; }
                    catch (Exception Ex) { ModelState.AddModelError("Initials", Ex.Message); }
                }


                if (UserTemplate.FirstName != "")
                {
                    try { lCustomerData.FirstName = UserTemplate.FirstName; }
                    catch (Exception Ex) { ModelState.AddModelError("FirstName", Ex.Message); }
                }


                if (UserTemplate.Surname != "")
                {
                    try { lCustomerData.Surname = UserTemplate.Surname; }
                    catch (Exception Ex) { ModelState.AddModelError("Surname", Ex.Message); }
                }


                if (UserTemplate.LoginEmail != "")
                {
                    try { lCustomerData.LoginEmail = UserTemplate.LoginEmail; }
                    catch (Exception Ex) { ModelState.AddModelError("LoginEmail", Ex.Message); }
                }


                if (UserTemplate.EmailAddress != "")
                {
                    try { lCustomerData.EmailAddress = UserTemplate.EmailAddress; }
                    catch (Exception Ex) { ModelState.AddModelError("EmailAddress", Ex.Message); }
                }


                //if (UserTemplate.Password != "")
                //{
                //    try { lCustomerData.Password = UserTemplate.Password; }
                //    catch (Exception Ex) { ModelState.AddModelError("Password", Ex.Message); }
                //}


                if (UserTemplate.PhoneNumber != "")
                {
                    try { lCustomerData.PhoneNumber = UserTemplate.PhoneNumber; }
                    catch (Exception Ex) { ModelState.AddModelError("PhoneNumber", Ex.Message); }
                }


                if (UserTemplate.CellPhoneNumber != "")
                {
                    try { lCustomerData.CellPhoneNumber = UserTemplate.CellPhoneNumber; }
                    catch (Exception Ex) { ModelState.AddModelError("CellPhoneNumber", Ex.Message); }
                }

                if (UserTemplate.Address1 != "")
                {
                    try { lCustomerData.Address1 = UserTemplate.Address1; }
                    catch (Exception Ex) { ModelState.AddModelError("Address1", Ex.Message); }
                }

                if (UserTemplate.Address2 != "")
                {
                    try { lCustomerData.Address2 = UserTemplate.Address2; }
                    catch (Exception Ex) { ModelState.AddModelError("Address2", Ex.Message); }
                }

                if (UserTemplate.Address3 != "")
                {
                    try { lCustomerData.Address3 = UserTemplate.Address3; }
                    catch (Exception Ex) { ModelState.AddModelError("Address3", Ex.Message); }
                }

                if (UserTemplate.Address4 != "")
                {
                    try { lCustomerData.Address4 = UserTemplate.Address4; }
                    catch (Exception Ex) { ModelState.AddModelError("Address4", Ex.Message); }
                }


                if (UserTemplate.CountryId != 0)
                {
                    try { lCustomerData.CountryId = UserTemplate.CountryId; }
                    catch (Exception Ex) { ModelState.AddModelError("TitleId", Ex.Message); }
                }

                if (UserTemplate.Address5 != "")
                {
                    try { lCustomerData.Address5 = UserTemplate.Address5; }
                    catch (Exception Ex) { ModelState.AddModelError("Address5", Ex.Message); }
                }

                if (!ModelState.IsValid)
                {

                    ViewBag.Message = "Sorry, some of the data are in error.";

                    return View("Account", UserTemplate);   // Here I want to invoke the InitialAccount view with the pUserTemplate again, plus the ModelState 
                }
                else
                {
                    {
                        string lResult;
                        if ((lResult = lCustomerData.Update()) != "OK")
                        {
                            ViewBag.Message = lResult;
                            return View("Account", UserTemplate);
                        }
                        else
                        {
                            ViewBag.Message = "Update of account data was successful";
                            return View("Empty");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RequestAccount", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
                return View("Empty");
            }
        }


        // Login **************************************************************************************************************

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest pLoginRequest)
        {
            int lCustomerId = 0;
            CustomerData3 lCustomerData;

            try
            {
                lCustomerId = CustomerData3.ExistsByLoginEmail(pLoginRequest.Email);
                if (lCustomerId == 0)
                {
                    ViewBag.Message = "You are not a registered as a customer. Please register your email address.";

                    return View();
                }
                else
                {
                    LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
                    if (lLoginRequest != null)
                    {
                        ViewBag.Message = "You are logged in already. Welcome once again.";
                        return View();
                    }

                    // Check his password
                    lCustomerData = new CustomerData3(lCustomerId);
                    if (lCustomerData.Password == pLoginRequest.Password)
                    {
                        pLoginRequest.CustomerId = lCustomerId;
                        pLoginRequest.PhysicalAddressId = lCustomerData.PhysicalAddressId;
                        pLoginRequest.CountryId = lCustomerData.CountryId;
                        Session["LoginRequest"] = pLoginRequest;

                        ViewBag.User = lCustomerData.FirstName;
                        ViewBag.Message = "Welcome, " + lCustomerData.Title + " " + lCustomerData.Surname + ", you are now logged in.";
                        return View("Welcome");
                    }
                    else
                    {
                        ViewBag.Message = "Unfortunately, your password did not match. Please try again or reset your password.";
                        return View();
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RequestLogin", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "Error in RequestLogin" + ex.Message;
                return View();
            }
        }


        // Reset password **************************************************************************************************************

     
        [HttpGet]
        public ViewResult ResetPasswordGUID()
        {
             return View();
        }
    

        [HttpPost]
        public ActionResult ResetPasswordGUID(LoginRequest pLoginRequest)
        {
            try
            {
                //LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];

                //if (lLoginRequest != null)
                //{
                //    // This person is already logged in. Get the new password. 

                //    CustomerData3 lCustomerData = new CustomerData3(lLoginRequest.CustomerId);
                //    if (lCustomerData.LoginEmail == pLoginRequest.Email)
                //    {
                //        lCustomerData.Password = pLoginRequest.Password;
                //        lCustomerData.Update();
                //    }
                //    else
                //    {
                //        ViewBag.Message = "You do not seem to be who I thought you were. No do!";
                //        return View();
                //    }
                    
                //    lLoginRequest.Password = pLoginRequest.Password;
                //    ViewBag.Message = "Password has been reset";
                //    return View();
                //}
                //else
                //{
                    try
                    {
                        // Ask person to check his email to set or reset his password
                        Guid lGuid = Guid.NewGuid();
                        AdministrationData2.InsertByGUID(lGuid, "ResetToken", pLoginRequest.Email);

                        // Send Email. 

                        SendResetPassword(lGuid, pLoginRequest.Email);

                        ViewBag.Message = "Please check your email to complete the password reset process.";
                        return View();

                    }
                    catch (Exception ex)
                    {
                        //Display all the exceptions

                        Exception CurrentException = ex;
                        int ExceptionLevel = 0;
                        do
                        {
                            ExceptionLevel++;
                            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ResetRequestPassword", "");
                            CurrentException = CurrentException.InnerException;
                        } while (CurrentException != null);

                        ViewResult lViewResult = new ViewResult();
                        return new ViewResult();
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ResetRequestPassword", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "Error in ResetRequestPassword" + ex.Message;
                return View();
            }
        }

        private bool SendResetPassword(Guid pGuid, string Destination)
        {
            try
            {
                SmtpClient myClient = new SmtpClient();
                MailMessage myMessage = new MailMessage("vandermerwer@timesmedia.co.za", Destination);
                //Attachment myAttachment = new Attachment(FileName, System.Net.Mime.MediaTypeNames.Application.Pdf);
                //myMessage.Attachments.Add(myAttachment);
                myMessage.Subject = "Password reset";
                string myBody = "Please follow this link: http://196.34.62.96/Home/resetpassword?pGuid=" + pGuid;

                myMessage.Body = myBody;
                myClient.Host = EMailHostIP;
                myClient.UseDefaultCredentials = true;
                myClient.Send(myMessage);
                return true;
            }
            catch (Exception Ex)
            {
                // Record the event in the Exception table
                ExceptionData.WriteException(1, Ex.Message, this.ToString(), "ResetPassword", Destination);
                return false;
            }
        }

        [HttpGet]
        public ActionResult ResetPassword(Guid pGuid)
        {
            try
            {

                //  Validate the RegisterToken

                AdministrationDoc.GUIDTableDataTable lGUIDTable = new AdministrationDoc.GUIDTableDataTable();
                AdministrationData2.FillGUIDByGUID(pGuid, ref lGUIDTable);

                if (lGUIDTable.Count != 1)
                {
                    ViewBag.Message = "Invalid attempt to reset password";
                    return View("Empty");
                }

                if (lGUIDTable[0].Usage != "ResetToken")
                {
                    ViewBag.Message = "Invalid attempt to reset password";
                    return View("Empty");
                }

                //// Ask for the new password
                //LoginRequest lLoginRequest = new LoginRequest();
                //lLoginRequest.Email = lGUIDTable[0].Email;
                //return RedirectToAction("ResetPasswordCapture", lLoginRequest);

                int lCustomerId = CustomerData3.ExistsByLoginEmail(lGUIDTable[0].Email);

                if (lCustomerId == 0)
                {
                    ViewBag.Message = "There is no customer with that login email";
                    return View();
                }

                UserTemplate lUserTemplate = new UserTemplate();

                lUserTemplate.CustomerId = lCustomerId;

                return View("ResetPasswordCapture", lUserTemplate);
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ResetPassword", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = ex.Message;
                return new ViewResult();
            }

        }

        //[HttpGet]
        //public ActionResult ResetPasswordCapture(LoginRequest pLoginRequest)
        //{
        //    try
        //    {

              

        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ResetPasswordCapture", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);

        //        ViewBag.Message = ex.Message;
        //        return new ViewResult();
        //    }
        //}

    

        [HttpPost]
        public ActionResult ResetPasswordCapture(UserTemplate pUserTemplate)
        {
            try
            {
                CustomerData3 lCustomerData = new CustomerData3(pUserTemplate.CustomerId);

                if (pUserTemplate.Password != "")
                {
                    if (pUserTemplate.Password == pUserTemplate.ConfirmedPassword)
                    {
                        lCustomerData.Password = pUserTemplate.Password;
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "The confirmed password does not match the original password.");
                    }
                }


                if (!ModelState.IsValid)
                {

                    ViewBag.Message = "Sorry, some of the data are in error.";

                    return View("ResetPasswordCapture", pUserTemplate);   // Here I want to invoke the InitialAccount view with the pUserTemplate again, plus the ModelState 
                }
                else
                {
                    {
                        string lResult;
                        if ((lResult = lCustomerData.Update()) != "OK")
                        {
                            ViewBag.Message = lResult;
                            return View("ResetPasswordCapture", pUserTemplate);
                        }
                    }

                }

                ViewBag.Message = "Password reset. Please proceed to login.";

                return View("Empty");
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ResetPasswordCapture", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = ex.Message;
                return new ViewResult();
            }
        }


        [HttpGet]
        public ActionResult CPD()
        {
            try
            {
                // Ensure that the person is logged in

                LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
             
                if (lLoginRequest == null)
                {
                    ViewBag.Message = "Sorry, I cannot take you to CPD unless you are first logged in.";
                    return View("Empty");
                }


                return Redirect("http://www.mimscpd.co.za");

                //return View("Empty");
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "CPD", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = ex.Message;
                return new ViewResult();
            }
        }






        // Signout **************************************************************************************************************

        [HttpGet]
        public ViewResult SignOut()
        {
            return View("Empty");
        }



    }
}

