
using Newtonsoft.Json;
using Subs.MimsWeb.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using Subs.Data;

namespace Subs.MimsWeb.Controllers
{
    public class PayUController : Controller
    {
        public ActionResult Index(string orderid)
        {
            //LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
            //CustomerData3 lCustomerData = new  CustomerData3((int)lLoginRequest.CustomerId);
            //Basket lBasket = (Basket)Session["Basket"];

            //****************************************************************
            LoginRequest lLoginRequest = new LoginRequest();
            CustomerData3 lCustomerData = new CustomerData3(11857);
            Basket lBasket = new Basket();
            lBasket.InvoiceId = 123456;
            lBasket.TotalDiscountedPrice = 100.00M;

            string lPayUUrl = "https://staging.payu.co.za";
            string lPayUReturnUrl = "http://www.MIMSWeb.co.za";

            //****************************************************************

            try
            { 
                string _url =lPayUUrl + serviceAPI; //web service url         
                string soapContent = ""; //soap content

                soapContent = "<ns1:setTransaction>";
                soapContent += "<Api>ONE_ZERO</Api>";
                soapContent += "<Safekey>" + "{07F70723-1B96-4B97-B891-7BF708594EEA}" + "</Safekey>";

                //Payment type   
                soapContent += "<TransactionType>PAYMENT</TransactionType>";

                // Additional
                soapContent += "<AdditionalInformation>";
                soapContent += "<redirectChannel>responsive</redirectChannel>";
                // The cancel url for redirect shuold be configured accordingly
                soapContent += "<cancelUrl>" + lPayUReturnUrl + "/PayU/Cancelled</cancelUrl>";

                soapContent += "<merchantReference>" + "INV" + lBasket.InvoiceId.ToString() + "</merchantReference>";

                // The return url for redirect shuold be configured accordingly
                soapContent += "<returnUrl>" + lPayUReturnUrl + "/PayU/Completed</returnUrl>";

                soapContent += "<notificationUrl>" + lPayUReturnUrl + "/PayU/Notified</notificationUrl>";
                soapContent += "<secure3d>true</secure3d>";

                soapContent += "<supportedPaymentMethods>CREDITCARD</supportedPaymentMethods>";
                soapContent += "</AdditionalInformation>";

  //          "Serilog": {
  //              "MinimumLevel": {
  //                  "Default": "Information",
  //    "Override": {
  //                      "Microsoft": "Information",
  //      "System": "Warning"
  //    }
  //              }
  //          },
  //"AllowedHosts": "*",
  //"ElasticConfiguration": {
  //              "Uri": "http://localhost:9200/"
  //},
  //"AppSettings": {
  //              "apiEndpoint": "http://api", //"http://localhost:32788", //"http://localhost:51773",
  //  "AdminEmail": "spadaccinod@tisoblackstar.co.za",
  //  "PayUReturnURL": "https://localhost:32770",
  //  "PayUSafeKey": "{07F70723-1B96-4B97-B891-7BF708594EEA}",
  //  "PayUUsername": "200021",
  //  "PayUPassword": "WSAUFbw6",
  //  "PayUUrl": "https://staging.payu.co.za"
  //}

                //Customer
                soapContent += "<Customer>";
                soapContent += "<merchantUserId>" + lCustomerData.CustomerId + "</merchantUserId>";
                soapContent += "<email>" + lCustomerData.EmailAddress + "</email>";
                soapContent += "<firstName>" + lCustomerData.FirstName + "</firstName>";
                soapContent += "<lastName>" + lCustomerData.Surname + "</lastName>";
                soapContent += "<mobile>" + lCustomerData.PhoneNumber + "</mobile>";
                soapContent += "</Customer>";

                // Basket
                soapContent += "<Basket>";
                soapContent += "<amountInCents>" + Decimal.ToInt32(lBasket.TotalDiscountedPrice * 100) + "</amountInCents>";
                soapContent += "<currencyCode>ZAR</currencyCode>";
                soapContent += "<description>Order No: " + "INV" + lBasket.InvoiceId.ToString() + "</description>";
                soapContent += "</Basket>";
                soapContent += "</ns1:setTransaction>";
                // construct soap object

                XmlDocument soapEnvelopeXml = CreateSoapEnvelope(soapContent);

                // create username and password namespace
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(soapEnvelopeXml.NameTable);
                nsmgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

                // set soap username
                XmlNode userName = soapEnvelopeXml.SelectSingleNode("//wsse:Username", nsmgr);
                userName.InnerText = "200021";

                // set soap password
                XmlNode userPassword = soapEnvelopeXml.SelectSingleNode("//wsse:Password", nsmgr);
                userPassword.InnerText = "WSAUFbw6";


                // construct web request object
                HttpWebRequest webRequest = CreateWebRequest(_url);

                // insert soap envelope into web request
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                // get the PayU reference number from the completed web request.
                string soapResult;
                using (WebResponse webResponse = webRequest.GetResponse())
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }


                // create an empty soap result object
                XmlDocument soapResultXml = new XmlDocument();
                soapResultXml.LoadXml(soapResult.ToString());

                string success = soapResultXml.SelectSingleNode("//successful").InnerText;
                if (success == "true")
                {
                    StringBuilder builder = new StringBuilder();

                    builder.Append(lPayUUrl + redirectAPI);

                    // retrieve payU reference & build url with payU reference query string
                    string payURef = soapResultXml.SelectSingleNode("//payUReference").InnerText;
                    builder.Append(payURef);

                    //var saved = SaveTransaction(Order, payURef);

                    //EmptyCart();
                    // redirect to payU site
                    return Redirect(builder.ToString());
                }
                else
                { 
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Index", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult Cancelled(string pPayUReference)
        {
            // Write to ledger.

            LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
            Basket lBasket = (Basket)Session["Basket"];
            LedgerData.PayU((int)lLoginRequest.CustomerId, pPayUReference, "Cancelled", lBasket.InvoiceId, lBasket.TotalDiscountedPrice);

            // Report back to user.

            ViewBag.Message = "Your payment was cancelled. The PayUReference is " + pPayUReference;
            return RedirectToAction("Pay", "Order");
        }

        //[Route("order/notify")]
        //public ActionResult Notify()
        //{
        //    var xml = "";
        //    using (var receiveStream = Request.Body)
        //    {
        //        using (var readStream = new StreamReader(receiveStream))
        //        {
        //            xml = readStream.ReadToEnd();
        //        }
        //    }

        //    // create an empty soap result object
        //    XmlDocument soapResultXml = new XmlDocument();
        //    soapResultXml.LoadXml(xml.ToString());

        //    var reference = soapResultXml.SelectSingleNode("//PayUReference") == null ? "" : soapResultXml.SelectSingleNode("//PayUReference").InnerText;
        //    MailerHelper mailerHelper = new MailerHelper(_config);
        //    string AdminEmail = AppSettings.Current.AdminEmail;
        //    UserProfile user = HttpContext.Session.GetObject<UserProfile>("User");

        //    string subject = "";
        //    string content = "";
        //    var PayUtransaction = SetPayUTransaction(reference, true);
        //    var transaction = GetTransaction(reference);
        //    subject = "Something went wrong with your order";
        //    content = System.IO.File.ReadAllText("wwwroot/Mailers/PaymentFailed.html");
        //    content = content.Replace("%Year%", DateTime.Now.Year.ToString());
        //    //var user = transaction.Order.UserProfile.Email;

        //    transaction.Order.OrderStatus = "3";
        //    if (PayUtransaction.Successful)
        //    {

        //        subject = "Your order has been successfully completed";
        //        content = System.IO.File.ReadAllText("wwwroot/Mailers/PaymentComplete.html");
        //        content = content.Replace("%Year%", DateTime.Now.Year.ToString());
        //        transaction.Order.OrderStatus = "4";

        //        mailerHelper.SendMailers("A MIMS order has been placed", "A new order with MIMS has been placed by: " + user.Email, this.HttpContext, AdminEmail);
        //    }
        //    else
        //    {
        //        mailerHelper.SendMailers("A MIMS order has failed", "A new order with MIMS has been placed by: " + user.Email + " but was unsuccessful", this.HttpContext, AdminEmail);
        //    }
        //    var httpContent = new StringContent(JsonConvert.SerializeObject(transaction.Order), Encoding.UTF8, "application/json");

        //    var msg = new HttpRequestMessage(HttpMethod.Post, "order/update-order");
        //    //msg.Headers.Authorization = new AuthenticationHeaderValue("bearer", Request.Cookies["mims-token"]);
        //    msg.Content = httpContent;

        //    var responseTask = _httpClient.SendAsync(msg);
        //    responseTask.Wait();

        //    var response = responseTask.Result;
        //    var responseStringTask = response.Content.ReadAsStringAsync();
        //    responseStringTask.Wait();

        //    var responseString = responseStringTask.Result;
        //    var responseCode = response.StatusCode;

        //    mailerHelper.SendMailers(subject, content, this.HttpContext);

        //    if (PayUtransaction.Successful)
        //    {
        //        return View(transaction);

        //    }
        //    else
        //    {
        //        return View("cancelled");
        //    }

        //}

        //[Route("order/complete")]
        //public ActionResult Complete(string PayUReference)
        //{
        //    MailerHelper mailerHelper = new MailerHelper(_config);
        //    string AdminEmail = AppSettings.Current.AdminEmail;
        //    UserProfile user = HttpContext.Session.GetObject<UserProfile>("User");

        //    var transaction = new TransactionsReturn();
        //    try
        //    {
        //        transaction = GetTransaction(PayUReference);
        //    }
        //    catch
        //    {
        //        var PayUtransaction = SetPayUTransaction(PayUReference);
        //    }
        //    if (transaction.TransactionState == null)
        //    {
        //        transaction = GetTransaction(PayUReference);
        //    }
        //    string subject = "";
        //    string content = "";
        //    subject = "Something went wrong with your order";
        //    content = System.IO.File.ReadAllText("wwwroot/Mailers/PaymentFailed.html");
        //    content = content.Replace("%Year%", DateTime.Now.Year.ToString());

        //    if (!transaction.UsedNotify)
        //    {

        //        transaction.Order.OrderStatus = "3";
        //        if (transaction.Successful)
        //        {
        //            subject = "Your order has been successfully completed";
        //            content = System.IO.File.ReadAllText("wwwroot/Mailers/PaymentComplete.html");
        //            content = content.Replace("%Year%", DateTime.Now.Year.ToString());
        //            transaction.Order.OrderStatus = "4";


        //            mailerHelper.SendMailers("A MIMS order has been placed", "A new order with MIMS has been placed by: " + user.Email, this.HttpContext, AdminEmail);

        //            EmptyCart();
        //        }
        //        else
        //        {
        //            mailerHelper.SendMailers("A MIMS order has failed", "A new order with MIMS has been placed by: " + user.Email + " but was unsuccessful", this.HttpContext, AdminEmail);
        //        }
        //        var httpContent = new StringContent(JsonConvert.SerializeObject(transaction.Order), Encoding.UTF8, "application/json");

        //        var msg = new HttpRequestMessage(HttpMethod.Post, "order/update-order");
        //        msg.Headers.Authorization = new AuthenticationHeaderValue("bearer", Request.Cookies["mims-token"]);
        //        msg.Content = httpContent;

        //        var responseTask = _httpClient.SendAsync(msg);
        //        responseTask.Wait();

        //        var response = responseTask.Result;
        //        var responseStringTask = response.Content.ReadAsStringAsync();
        //        responseStringTask.Wait();

        //        var responseString = responseStringTask.Result;
        //        var responseCode = response.StatusCode;

        //        mailerHelper.SendMailers(subject, content, this.HttpContext);
        //    }

        //    if (transaction.Successful)
        //    {
        //        return View(transaction);

        //    }
        //    else
        //    {
        //        return View("cancelled");
        //    }


        //}

        //[Route("order/pending-payment")]
        //public ActionResult PendingPayment()
        //{
        //    return View("pendingPayment");

        //}







        #region SOAP Helpers

        static string serviceAPI = "/service/PayUAPI?wsdl";
        static string redirectAPI = "/rpp.do?PayUReference=";

        static string _soapEnvelope =
                     @"<SOAP-ENV:Envelope xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/' 
                                    xmlns:ns1='http://soap.api.controller.web.payjar.com/' 
                                    xmlns:ns2='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
                                    <SOAP-ENV:Header>
                                        <wsse:Security SOAP-ENV:mustUnderstand='1' xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
                                            <wsse:UsernameToken wsu:Id='UsernameToken-9' xmlns:wsu='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'>
                                                <wsse:Username></wsse:Username>
                                                <wsse:Password Type='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText'></wsse:Password>
                                            </wsse:UsernameToken>
                                        </wsse:Security>
                                    </SOAP-ENV:Header>
                                     <SOAP-ENV:Body>
                                     </SOAP-ENV:Body>
                </SOAP-ENV:Envelope>";

        /// <summary>
        /// Creates the HttpWebRequest object
        /// </summary>
        /// <returns>webRequest</returns>        
        private static HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }


        /// <summary>
        /// Creates the SOAP envelope object
        /// </summary>
        /// <returns>soapEnvelopeXml</returns> 
        private static XmlDocument CreateSoapEnvelope(string content)
        {
            StringBuilder sb = new StringBuilder(_soapEnvelope);
            sb.Insert(sb.ToString().IndexOf("</SOAP-ENV:Body>"), content);

            // create an empty soap envelope
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(sb.ToString());

            return soapEnvelopeXml;
        }

        /// <summary>
        /// Insert soap envelope into web request
        /// </summary>
        /// <returns></returns>
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        #endregion
      
    }
}
