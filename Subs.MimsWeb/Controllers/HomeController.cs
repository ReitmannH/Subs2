using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Subs.Data;
using Subs.Business;
using Subs.MimsWeb.Models;
using System.Collections.Specialized;

namespace Subs.MimsWeb.Controllers
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

                // Ask person to check his email to set or reset his password
                Guid lGuid = Guid.NewGuid();
                AdministrationData2.InsertByGUID(lGuid, "ActivationToken", pLoginRequest.Email);

                // Send Email. 

                if (!SendPromptForAccountDetails(lGuid, pLoginRequest.Email))
                {
                    return View();
                }
  
                ViewBag.Message = "Please check your email to complete the registration.";
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RegisterEmail", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "Error in RegisterEmail" + ex.Message;
                return View();
            }
        }

        private bool SendPromptForAccountDetails(Guid pGuid, string Destination)
        {
            try
            {
                SmtpClient myClient = new SmtpClient();
                MailMessage myMessage = new MailMessage("vandermerwer@mims.co.za", Destination);
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
            try
            {
                //  Validate the RegisterToken

                AdministrationDoc.GUIDTableDataTable lGUIDTable = new AdministrationDoc.GUIDTableDataTable();
                AdministrationData2.FillGUIDByGUID(pGuid, ref lGUIDTable);

                if (lGUIDTable.Count != 1)
                {
                    ViewBag.Message = "Invalid attempt to register a user profile";
                    return View("Empty");
                }

                // Capture the account details
             
                LoginRequest lLoginRequest = new LoginRequest() { Email = lGUIDTable[0].Email };

                Session["LoginRequest"] = lLoginRequest;

                return RedirectToAction("Account");
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


        [HttpGet]
        public ActionResult Account()
        {
            UserTemplate lUserTemplate = new UserTemplate();

            try
            {
                // Populate Titlelist

                List<ListItem> lListItems = new List<ListItem>();
                foreach (int i in Enum.GetValues(typeof(Title)))
                {
                    ListItem lNewItem = new ListItem();
                    lNewItem.Key = i;
                    lNewItem.Value = Enum.GetName(typeof(Title), i);
                    lListItems.Add(lNewItem);
                }
                lUserTemplate.TitleSelectList = new SelectList(lListItems, "Key", "Value", 1);
  
               // Populate Countrieslist

               var lCountryQuery = from lRow in AdministrationData2.Country
                                    select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };
               lUserTemplate.CountrySelectList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value", 1);

                // Populate Classification1

                List<ListItem> lClassification1Items = new List<ListItem>();
                List<ListItem> lClassification2Items = new List<ListItem>();

                lClassification1Items = AdministrationData2.Classification.Where(p => p.ParentId == 1).Select(q => new ListItem(){ Key = q.ClassificationId, Value = q.Classification}).ToList();
                lUserTemplate.Classification1SelectList = new SelectList(lClassification1Items, "Key", "Value", 1);

                // Populate initial values

                LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
                if (lLoginRequest.CustomerId == null)
                {
                    lUserTemplate.EmailAddress = lLoginRequest.Email;

                    lClassification2Items = AdministrationData2.Classification.Where(p => p.ParentId == 9).Select(q => new ListItem()
                    {
                        Key = q.ClassificationId,
                        Value = q.Classification
                    }).ToList();
                    
                    lUserTemplate.Classification2SelectList = new SelectList(lClassification2Items, "Key", "Value", 1);

                    lUserTemplate.Classification1Id = 9;
                    lUserTemplate.Classification2Id = 23;
                    lUserTemplate.CountryId = 61; // Default
                }
                else
                { 
                    // This is an existing customer
  
                    CustomerData3 lCustomerData = new CustomerData3((int)lLoginRequest.CustomerId);

                    // Map the values

                    lClassification2Items = AdministrationData2.Classification.Where(p => p.ParentId == lCustomerData.ClassificationId1).Select(q => new ListItem() 
                    { Key = q.ClassificationId, 
                      Value = q.Classification }).ToList();
                    
                    lUserTemplate.Classification2SelectList = new SelectList(lClassification2Items, "Key", "Value", 1);
 
                 
                    lUserTemplate.Password = lCustomerData.Password;
                    lUserTemplate.CustomerId = lCustomerData.CustomerId;
                    lUserTemplate.TitleId = lCustomerData.TitleId;
                    lUserTemplate.Initials = lCustomerData.Initials;
                    lUserTemplate.FirstName = lCustomerData.FirstName;
                    lUserTemplate.Surname = lCustomerData.Surname;
                    lUserTemplate.EmailAddress = lCustomerData.EmailAddress;
                    lUserTemplate.PhoneNumber = lCustomerData.PhoneNumber;
                    lUserTemplate.CellPhoneNumber = lCustomerData.CellPhoneNumber;
                    if (lCustomerData.CompanyId == 4)
                    {
                        lUserTemplate.CompanyNaam = lCustomerData.CompanyNameUnverified; 
                    }
                    else
                    {
                        lUserTemplate.CompanyNaam = lCustomerData.CompanyNaam;
                    }
                    lUserTemplate.Address1 = lCustomerData.Address1;
                    lUserTemplate.Address2 = lCustomerData.Address2;
                    lUserTemplate.Address3 = lCustomerData.Address3;
                    lUserTemplate.Address4 = lCustomerData.Address4;
                    lUserTemplate.CountryId = lCustomerData.CountryId;
                    lUserTemplate.Address5 = lCustomerData.Address5;
                    lUserTemplate.Password = lCustomerData.Password;
                    lUserTemplate.ConfirmedPassword = lCustomerData.Password;
                    lUserTemplate.CouncilNumber = lCustomerData.CouncilNumber;
                    lUserTemplate.Classification1Id = lCustomerData.ClassificationId1;
                    lUserTemplate.Classification2Id = lCustomerData.ClassificationId2 ?? null;

                    if (lCustomerData.PhysicalAddressId > 0)
                    {
                        DeliveryAddressData2 lDeliveryAddressData = new DeliveryAddressData2(lCustomerData.PhysicalAddressId);
                        lUserTemplate.DeliveryAddressId = lDeliveryAddressData.DeliveryAddressId;
                        lUserTemplate.CountryId = lDeliveryAddressData.CountryId;
                        lUserTemplate.Province = lDeliveryAddressData.Province;
                        lUserTemplate.City = lDeliveryAddressData.City;
                        lUserTemplate.Suburb = lDeliveryAddressData.Suburb;
                        lUserTemplate.Street = lDeliveryAddressData.Street;
                        lUserTemplate.StreetExtension = lDeliveryAddressData.StreetExtension;
                        lUserTemplate.StreetSuffix = lDeliveryAddressData.StreetSuffix;
                        lUserTemplate.StreetNo = lDeliveryAddressData.StreetNo;
                        lUserTemplate.PostCode = lDeliveryAddressData.PostCode;
                        lUserTemplate.Building = lDeliveryAddressData.Building;
                        lUserTemplate.Floor = lDeliveryAddressData.Floor;
                        lUserTemplate.Room = lDeliveryAddressData.Room;
                    }

                }
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
            CustomerData3 lCustomerData;

            // Prime customerData

            if (lLoginRequest.CustomerId == null)
            {
                lCustomerData = new CustomerData3();
            }
            else
            {
                lCustomerData = new CustomerData3((int)lLoginRequest.CustomerId);
            }

     
            try
            {
                //Map all the fields, as applicable

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


                if (UserTemplate.EmailAddress != "")
                {
                    try { lCustomerData.EmailAddress = UserTemplate.EmailAddress; }
                    catch (Exception Ex) { ModelState.AddModelError("EmailAddress", Ex.Message); }
                }

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

                if (lCustomerData.CompanyId == 4)
                {
                    // CompanyName was unverified
                    lCustomerData.CompanyNameUnverified = UserTemplate.CompanyNaam;
                }
                else
                {
                    // The verified companyName has been changed
                    try 
                    { 
                       lCustomerData.CompanyNameUnverified = UserTemplate.CompanyNaam;
                       lCustomerData.CompanyId = 4;
                    }
                    catch (Exception Ex) { ModelState.AddModelError("CompanyNaam", Ex.Message); }
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

                if (UserTemplate.ConfirmedPassword != null)
                {
                    if (UserTemplate.Password == UserTemplate.ConfirmedPassword)
                    {
                        lCustomerData.Password = UserTemplate.Password;
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "The confirmed password does not match the original password.");
                    }
                }

                if (UserTemplate.CouncilNumber != "")
                {
                    try { lCustomerData.CouncilNumber = UserTemplate.CouncilNumber; }
                    catch (Exception Ex) { ModelState.AddModelError("CouncilNumber", Ex.Message); }
                }
                
                DeliveryAddressData2 lDeliveryAddress = new DeliveryAddressData2(lCustomerData.PhysicalAddressId);
                if (UserTemplate.Province != "")
                {
                    try { lDeliveryAddress.Province = UserTemplate.Province; }
                    catch (Exception Ex) { ModelState.AddModelError("Province", Ex.Message); }
                }

                if (UserTemplate.City != "")
                {
                    try { lDeliveryAddress.City = UserTemplate.City; }
                    catch (Exception Ex) { ModelState.AddModelError("City", Ex.Message); }
                }

                if (UserTemplate.Street != "")
                {
                    try { lDeliveryAddress.Street = UserTemplate.Street; }
                    catch (Exception Ex) { ModelState.AddModelError("Street", Ex.Message); }
                }

                if (UserTemplate.StreetExtension != "")
                {
                    try { lDeliveryAddress.StreetExtension = UserTemplate.StreetExtension; }
                    catch (Exception Ex) { ModelState.AddModelError("StreetExtension", Ex.Message); }
                }

                if (UserTemplate.StreetSuffix != "")
                {
                    try { lDeliveryAddress.StreetSuffix = UserTemplate.StreetSuffix; }
                    catch (Exception Ex) { ModelState.AddModelError("StreetSuffix", Ex.Message); }
                }

                if (UserTemplate.StreetNo != "")
                {
                    try { lDeliveryAddress.StreetNo = UserTemplate.StreetNo; }
                    catch (Exception Ex) { ModelState.AddModelError("StreetNo", Ex.Message); }
                }

                if (UserTemplate.PostCode != "")
                {
                    try { lDeliveryAddress.PostCode = UserTemplate.PostCode; }
                    catch (Exception Ex) { ModelState.AddModelError("PostCode", Ex.Message); }
                }


                if (UserTemplate.Building != "")
                {
                    try { lDeliveryAddress.Building = UserTemplate.Building; }
                    catch (Exception Ex) { ModelState.AddModelError("Building", Ex.Message); }
                }

                if (UserTemplate.Floor != "")
                {
                    try { lDeliveryAddress.Floor = UserTemplate.Floor; }
                    catch (Exception Ex) { ModelState.AddModelError("Floor", Ex.Message); }
                }
                if (UserTemplate.Room != "")
                {
                    try { lDeliveryAddress.Room = UserTemplate.Room; }
                    catch (Exception Ex) { ModelState.AddModelError("Room", Ex.Message); }
                }

                if (!ModelState.IsValid)
                {
                    // Give the user another chance to improve on his capture

                    List<ListItem> lListItems = new List<ListItem>();

                    foreach (int i in Enum.GetValues(typeof(Title)))
                    {
                        ListItem lNewItem = new ListItem();
                        lNewItem.Key = i;
                        lNewItem.Value = Enum.GetName(typeof(Title), i);
                        lListItems.Add(lNewItem);
                    }

                    SelectList lTitleList = new SelectList(lListItems, "Key", "Value", UserTemplate.TitleId);
                    UserTemplate.TitleSelectList = lTitleList;

                    var lCountryQuery = from lRow in AdministrationData2.Country
                                        select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };

                    SelectList lCountryList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value", UserTemplate.CountryId);

                    UserTemplate.CountrySelectList = lCountryList;

                    List<ListItem> lClassification1Items = new List<ListItem>();
                    lClassification1Items = AdministrationData2.Classification.Where(p => p.ParentId == 1).Select(q => new ListItem() { Key = q.ClassificationId, Value = q.Classification }).ToList();
                    UserTemplate.Classification1SelectList = new SelectList(lClassification1Items, "Key", "Value", 1);

                    List<ListItem> lClassification2Items = new List<ListItem>();
                    lClassification2Items = AdministrationData2.Classification.Where(p => p.ParentId == lCustomerData.ClassificationId1).Select(q => new ListItem()
                    {
                        Key = q.ClassificationId,
                        Value = q.Classification
                    }).ToList();
                   
                    UserTemplate.Classification2SelectList = new SelectList(lClassification2Items, "Key", "Value", 1);

                    ViewBag.Message = "Sorry, some of the data are in error.";

                    return View("Account", UserTemplate);   // Here I want to invoke the Account view with the pUserTemplate again, plus the ModelState 
                }
                else
                {
                    // See if this is a duplicate entry, i.e. whether the customer exists already

                    if (lLoginRequest.CustomerId == null)
                    {
                        {
                            string lResult4;

                            if ((lResult4 = CustomerBiz.ValidateDuplicate(lCustomerData)) != "OK")
                            {
                                ViewBag.Message = lResult4;

                                return View("Empty", UserTemplate);
                            }
                        }
                    }
                }


                // Try to update the physical address data

                lDeliveryAddress.Verified = false;

                string lResult2;
                if ((lResult2 = lDeliveryAddress.Update()) != "OK")
                {
                    ViewBag.Message = lResult2;
                    return View("Account", UserTemplate);
                }

                // Try to update the customer data

                lCustomerData.PhysicalAddressId = lDeliveryAddress.DeliveryAddressId;

                string lResult;
                if ((lResult = lCustomerData.Update()) != "OK")
                {
                    ViewBag.Message = lResult;
                    return View("Account", UserTemplate);
                }

                try { lCustomerData.ClassificationId2 = UserTemplate.Classification2Id; } // This cannot be done until you have a customerid
                catch (Exception Ex) { ModelState.AddModelError("Classification2Id", Ex.Message); }

                string lResult3;
                if ((lResult3 = lCustomerData.Update()) != "OK")
                {
                    ViewBag.Message = lResult3;
                    return View("Account", UserTemplate);
                }

                if (lLoginRequest.CustomerId == null )
                {
                    //This is a new user, so log him on automatically

                    lLoginRequest.CustomerId = lCustomerData.CustomerId;
                    lLoginRequest.Email = lCustomerData.LoginEmail;
                    lLoginRequest.Password = lCustomerData.Password;
                    lLoginRequest.PhysicalAddressId = lCustomerData.PhysicalAddressId;
                    Session["LoginRequest"] = lLoginRequest;
                    ViewBag.Message = "Welcome " + lCustomerData.Title + " " + lCustomerData.Surname + ".You are now logged in. Please proceed.";
                    return View("Empty");
                }

                ViewBag.Message = "Update of account data for customer " + lCustomerData.CustomerId.ToString() + " was successful." ;
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Account", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
                return View("Empty");
            }
        }

        public JsonResult Classifications(int? ParentClassificationId = 2)
        {
            List<ListItem> lClassification2Items = new List<ListItem>();
            lClassification2Items = AdministrationData2.Classification.Where(p => p.ParentId == ParentClassificationId).Select(q => new ListItem()
            {
                Key = q.ClassificationId,
                Value = q.Classification
            }).ToList();

            return Json(lClassification2Items, JsonRequestBehavior.AllowGet);
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
            CustomerData3 lCustomerData;

            try
            {
                // See if the user is logged in already for this session
                LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
                if (lLoginRequest != null)
                {
                    ViewBag.Message = "You are logged in already. Welcome once again.";
                    return View();
                }

                if (!CustomerData3.Exists((int)pLoginRequest.CustomerId))
                {
                    ViewBag.Message = "You are not a registered as a customer.";

                    return View();
                }
                else
                {
                    lCustomerData = new CustomerData3((int)pLoginRequest.CustomerId);
                }

                
                if (String.IsNullOrWhiteSpace(lCustomerData.Password))
                {
                    if (SendResetPassword(lCustomerData))
                    {
                        ViewBag.Message = "You are an existing customer, but your password has not yet been set. Please check your email for a generated password.";
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong with your request.";
                    }

                    return View("Login");
                }
                    

                if (pLoginRequest.ResetPassword)
                { 
                    if (SendResetPassword(lCustomerData))
                    {
                        ViewBag.Message = "Please check your email for a generated password.";
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong with your request.";
                    }

                    return View("Login");
                }


                if (lCustomerData.Password == pLoginRequest.Password)
                {
                    pLoginRequest.CustomerId = pLoginRequest.CustomerId;
                    pLoginRequest.Email = lCustomerData.EmailAddress;
                    pLoginRequest.PhysicalAddressId = lCustomerData.PhysicalAddressId;
                    pLoginRequest.CountryId = lCustomerData.CountryId;
                    Session["LoginRequest"] = pLoginRequest;

                    ViewBag.User = lCustomerData.FirstName;
                    ViewBag.Message = "Welcome, " + lCustomerData.Title + " " + lCustomerData.Surname + ", you are now logged in.";
                    return View("Welcome");
                }
                else
                {
                    ViewBag.Message = "Unfortunately, your password did not match. Please try again.";
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Login", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "Error in RequestLogin" + ex.Message;
                return View();
            }
        }
       
        private bool SendResetPassword(CustomerData3 pCustomerData)
        {
           
            try
            {
                string lGeneratedPassword = "";
                int lKey = (3 * DateTime.Now.Second) + (4 * DateTime.Now.Millisecond);
                if (lKey > 500)
                {
                    lGeneratedPassword = pCustomerData.EmailAddress.Substring(2, 1).ToUpper() + lKey.ToString() + pCustomerData.EmailAddress.Substring(5, 1).ToLower();
                }
                else
                { 
                    lGeneratedPassword = pCustomerData.EmailAddress.Substring(6,1).ToUpper() + lKey.ToString() + pCustomerData.EmailAddress.Substring(4, 1).ToLower();
                }

                pCustomerData.Password = lGeneratedPassword;
                pCustomerData.Update();

                SmtpClient myClient = new SmtpClient();
                MailMessage myMessage = new MailMessage("vandermerwer@mims.co.za", pCustomerData.EmailAddress);
                myMessage.Subject = "Mims";
                string myBody = "As requested: " + lGeneratedPassword + ". Once logged in, you can change it to something of closer to your preference.";

                myMessage.Body = myBody;
                myClient.Host = EMailHostIP;
                myClient.UseDefaultCredentials = true;
                myClient.Send(myMessage);
                return true;
            }
            catch (Exception Ex)
            {
                // Record the event in the Exception table
                ExceptionData.WriteException(1, Ex.Message, this.ToString(), "SendResetPassword", pCustomerData.CustomerId.ToString());
                return false;
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
