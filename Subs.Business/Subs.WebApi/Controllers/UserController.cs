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
    public class UserController : ApiController
    {
      
        [HttpGet]
        [ActionName("get-user")]
        public IWebApiCustomerData GetUser(int CustomerId)
        {
            IWebApiCustomerData lTest = (IWebApiCustomerData)new CustomerData3(CustomerId);

            try
            {

                //Registration lRegistration = (Registration)JsonConvert.DeserializeObject(pRegistrationString);
             

                return lTest;    //JsonConvert.SerializeObject(lCustomerData);
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetUser", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
                return (IWebApiCustomerData)new CustomerData3();
            }
        }


        // get-all-users

        // requestreset(email)

        // reset-password 

        [Route("api/User/register-user")]
        [HttpPost]
        public HttpResponseMessage RegisterUser(LoginEmail LoginEmail)
        {
            HttpResponseMessage lResponse = new HttpResponseMessage();
            try
            {
                // ?parameter will bind to function parameter.

                int lCustomerId = CustomerData3.ExistsByLoginEmail(LoginEmail.Email);

                if (lCustomerId == 0)
                {
                    AdministrationData2.InsertByGUID(Guid.NewGuid(), "ActivationToken", LoginEmail.Email);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You exist on the system already. Please login.");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "RegisterUser", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [Route("api/User/send-verification")]
        [HttpPost]
        public HttpResponseMessage SendVerification(LoginEmail LoginEmail)
        {
            HttpResponseMessage lResponse = new HttpResponseMessage();
            try
            {
                AdministrationDoc.GUIDTableDataTable lGUIDTable = new AdministrationDoc.GUIDTableDataTable();
                if (!AdministrationData2.FillGUIDByEmail(LoginEmail.Email, ref lGUIDTable))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error in acquiring token");
                }

                if (lGUIDTable.Count != 1)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token not found");
                }
                else
                {
                    // Send Email Plus temporary GUID




                    return Request.CreateResponse(HttpStatusCode.OK);
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SendVerification", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //SendVerification   takes email as parameter.

        // validate-reset-token

        [ActionName("validate-activationtoken")]
        [HttpPost]
        public HttpResponseMessage ValidateActivationToken(ActivationToken Token)
        {
            try
            {
                AdministrationDoc.GUIDTableDataTable lGUIDTable = new AdministrationDoc.GUIDTableDataTable();
                if (!AdministrationData2.FillGUIDByGUID(Token.Token, ref lGUIDTable))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error in acquiring token");
                }

                if (lGUIDTable.Count != 1)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Token not found");
                }
                else
                {
                    CustomerData3 lCustomerData = new CustomerData3();
                    lCustomerData.LoginEmail = lGUIDTable[0].Email;
                    lCustomerData.EMailAddress = lGUIDTable[0].Email;
                    lCustomerData.Password = Token.Password;
                    lCustomerData.PhoneNumber = Token.PhoneNumber;
                    lCustomerData.Update();

                    return Request.CreateResponse(HttpStatusCode.OK, lCustomerData);

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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ValidateActivationToken", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [ActionName("Update")]
        [HttpPost]
        public HttpResponseMessage Update(UserTemplate pCustomerData)
        {
            try
            {
                CustomerData3 lCustomerData = new CustomerData3(pCustomerData.CustomerId);

                try
                {
                    // Set all the fields, as applicable

                    lCustomerData.FirstName = pCustomerData.FirstName;
                    lCustomerData.Surname = pCustomerData.Surname;
                    lCustomerData.EMailAddress = "Koos";

                    lCustomerData.Update();
                }
                catch (Exception Ex)
                {
                    ModelState.AddModelError("EMailAddress", Ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }


            return Request.CreateResponse(HttpStatusCode.OK, lCustomerData);
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
                return  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
    

    public class LoginEmail
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
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

