using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Web.Http;
using Subs.WebApi.Helpers.Filters;
using Subs.Data;
using Newtonsoft.Json;
using Subs.WebApi.Models;

namespace Subs.WebApi.Controllers
{
    public class UserAPIController : ApiController
    {
      
        //[HttpGet]
        //[ActionName("get-user")]
        //public CustomerData3 GetUser(int CustomerId)
        //{
        //   CustomerData3 lTest = new CustomerData3(CustomerId);

        //    try
        //    {

        //        //Registration lRegistration = (Registration)JsonConvert.DeserializeObject(pRegistrationString);
             

        //        return lTest;    //JsonConvert.SerializeObject(lCustomerData);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetUser", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);
        //        return new CustomerData3();
        //    }
        //}

        //[HttpGet]
        //[ActionName("get-user-by-surname")]
        //public List<CustomerData3> GetUserBySurname(string Surname)
        //{
        //    try
        //    {
        //        Subs.Data.CustomerDoc2TableAdapters.CustomerTableAdapter lCustomerAdapter = new Subs.Data.CustomerDoc2TableAdapters.CustomerTableAdapter();
        //        CustomerDoc2.CustomerDataTable lCustomer = new CustomerDoc2.CustomerDataTable();

        //        lCustomerAdapter.AttachConnection();
        //        int lHits = lCustomerAdapter.FillById(lCustomer, "Surname", 0, "%" + Surname + "%");

        //        var lResult = lCustomer.Select(e => new CustomerData3( e.CustomerId));


        //        return lResult.ToList();
        //    }

        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetUserBySurname", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);
        //        return new List< CustomerData3 >();  // Return an empty list
        //    }
        //}

        //[ActionName("request-reset-password")]
        //[HttpPost]
        //public HttpResponseMessage RequestResetPassword(LoginEmail LoginEmail)
        //{
        //    try
        //    {
        //        AdministrationData2.InsertByGUID(Guid.NewGuid(), "ResetToken", LoginEmail.Email);
        //        return Request.CreateResponse(HttpStatusCode.OK, "OK, GUID created.");
              
        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RequestResetPassword", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);

        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}


        //[HttpPost]
        //public HttpResponseMessage RegisterUser(LoginEmail LoginEmail)
        //{
        //    try
        //    {
        //        // ?parameter will bind to function parameter.

        //        int lCustomerId = CustomerData3.ExistsByLoginEmail(LoginEmail.Email);

        //        if (lCustomerId == 0)
        //        {
        //            AdministrationData2.InsertByGUID(Guid.NewGuid(), "ActivationToken", LoginEmail.Email);
        //            return Request.CreateResponse(HttpStatusCode.OK, "OK, GUID created.");
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You exist on the system already. Please login.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RegisterUser", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);

        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}


        //[ActionName("get-token")]
        //[HttpGet]
        //public HttpResponseMessage GetToken(string LoginEmail, string Usage)
        //{
        //    HttpResponseMessage lResponse = new HttpResponseMessage();
        //    try
        //    {
        //        AdministrationDoc.GUIDTableDataTable lGUIDTable = new AdministrationDoc.GUIDTableDataTable();
        //        if (!AdministrationData2.FillGUIDByEmail(LoginEmail, ref lGUIDTable))
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error in acquiring token");
        //        }

        //        if (lGUIDTable.Count != 1)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token not found");
        //        }
        //        else
        //        {
        //            if (lGUIDTable[0].Usage != Usage)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong kind of token");
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, lGUIDTable[0].GUID);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SendVerification", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);

        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

        ////// POST api/values/mail
        ////[ActionName("send-verification")]
        ////[HttpPost]
        ////public HttpResponseMessage SendVerification([FromBody]LoginEmail Email)
        ////{
        ////    try
        ////    {
        ////        var email_json = "{" +
        ////            "\"personalizations\": [{" +
        ////                "\"to\": [{" +
        ////                    "\"email\": \"" + Email.Email + "\"," +
        ////                    "\"name\": \"Hein Reitmann\"" +

        ////                "}]," +
        ////                "\"substitutions\": {" +
        ////                    "\"%token%\": \"123\"" +
        ////                "}" +
        ////            "}]," +

        ////            "\"from\": {" +
        ////                "\"email\": \"ReitmannH@Timesmedia.co.za\"," +
        ////                "\"name\": \"Hein Reitmann\"" +
        ////            "}," +
        ////            "\"reply_to\": {" +
        ////                "\"email\": \"ReitmannH@Timesmedia.co.za\"," +
        ////                "\"name\": \"Hein Reitmann\"" +
        ////            "}," +
        ////            "\"subject\": \"User verification\"," +
        ////            "\"template_id\": \"bfd8a675-8ba2-42ca-827a-0ffcc9c19f6d\"" +

        ////        "}";
        ////        var client = new RestClient("https://api.sendgrid.com/v3/mail/send");
        ////        var request = new RestRequest(Method.POST);
        ////        request.AddHeader("content-type", "application/json");
        ////        request.AddHeader("authorization", "Bearer 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");
        ////        request.AddParameter("application/json", email_json, ParameterType.RequestBody);
        ////        IRestResponse response = client.Execute(request);
        ////        return Request.CreateResponse("Successfully Sent");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        //Display all the exceptions

        ////        Exception CurrentException = ex;
        ////        int ExceptionLevel = 0;
        ////        do
        ////        {
        ////            ExceptionLevel++;
        ////            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Update", "");
        ////            CurrentException = CurrentException.InnerException;
        ////        } while (CurrentException != null);

        ////        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        ////    }
        ////}

        //// validate-reset-token

        //[ActionName("update-password")]
        //[HttpPost]
        //public HttpResponseMessage ActivatePassword(ActivationToken Token)
        //{
        //    try
        //    {
        //        AdministrationDoc.GUIDTableDataTable lGUIDTable = new AdministrationDoc.GUIDTableDataTable();
        //        if (!AdministrationData2.FillGUIDByGUID(Token.Token, ref lGUIDTable))
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error in acquiring token");
        //        }

        //        if (lGUIDTable.Count != 1)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token not found");
        //        }
        //        else
        //        {
        //            CustomerData3 lCustomerData = new CustomerData3();
        //            lCustomerData.LoginEmail = lGUIDTable[0].Email;
        //            lCustomerData.EmailAddress = lGUIDTable[0].Email;
        //            lCustomerData.Password = Token.Password;
        //            lCustomerData.PhoneNumber = Token.PhoneNumber;
        //            lCustomerData.Update();

        //            return Request.CreateResponse(HttpStatusCode.OK, lCustomerData);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "UpdatePassword", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
        

        //[ActionName("Update")]
        //[HttpPost]
        //public HttpResponseMessage Update(UserTemplate pCustomerData)
        //{
        //    try
        //    {
        //        CustomerData3 lCustomerData = new CustomerData3(pCustomerData.CustomerId);

        //        // Set all the fields, as applicable

        //        if (pCustomerData.TitleId != 0)
        //        {
        //            try { lCustomerData.TitleId = pCustomerData.TitleId; }
        //            catch (Exception Ex) { ModelState.AddModelError("TitleId", Ex.Message); }
        //        }


        //        if (pCustomerData.Initials != "")
        //        {
        //            try { lCustomerData.Initials = pCustomerData.Initials; }
        //            catch (Exception Ex) { ModelState.AddModelError("Initials", Ex.Message); }
        //        }


        //        if (pCustomerData.FirstName != "")
        //        {
        //            try { lCustomerData.FirstName = pCustomerData.FirstName; }
        //            catch (Exception Ex) { ModelState.AddModelError("FirstName", Ex.Message); }
        //        }


        //        if (pCustomerData.Surname != "")
        //        {
        //            try { lCustomerData.Surname = pCustomerData.Surname; }
        //            catch (Exception Ex) { ModelState.AddModelError("Surname", Ex.Message); }
        //        }


        //        if (pCustomerData.LoginEmail != "")
        //        {
        //            try { lCustomerData.LoginEmail = pCustomerData.LoginEmail; }
        //            catch (Exception Ex) { ModelState.AddModelError("LoginEmail", Ex.Message); }
        //        }


        //        if (pCustomerData.EmailAddress != "")
        //        {
        //            try { lCustomerData.EmailAddress = pCustomerData.EmailAddress; }
        //            catch (Exception Ex) { ModelState.AddModelError("EmailAddress", Ex.Message); }
        //        }


        //        if (pCustomerData.Password != "")
        //        {
        //            try { lCustomerData.Password = pCustomerData.Password; }
        //            catch (Exception Ex) { ModelState.AddModelError("Password", Ex.Message); }
        //        }


        //        if (pCustomerData.PhoneNumber != "")
        //        {
        //            try { lCustomerData.PhoneNumber = pCustomerData.PhoneNumber; }
        //            catch (Exception Ex) { ModelState.AddModelError("PhoneNumber", Ex.Message); }
        //        }


        //        if (pCustomerData.CellPhoneNumber != "")
        //        {
        //            try { lCustomerData.CellPhoneNumber = pCustomerData.CellPhoneNumber; }
        //            catch (Exception Ex) { ModelState.AddModelError("CellPhoneNumber", Ex.Message); }
        //        }

     
        //        {
        //            string lResult;
        //            if ((lResult = lCustomerData.Update()) != "OK")
        //            {
        //                ModelState.AddModelError("CustomerId", lResult);
        //            }
        //        }


        //        if (!ModelState.IsValid)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, lCustomerData);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Update", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);
        //        return  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

    }
    

    public class LoginEmail
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Usage { get; set; }
    }

    public class ActivationToken
    {
        [Required(ErrorMessage = "Token is required.")]
        public Guid Token { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

       
    }
}

