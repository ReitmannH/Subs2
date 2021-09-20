using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Subs.MimsWeb.Models;
using Subs.Data;
using Subs4.Presentation;
using Subs.Business;
using System.Collections.Specialized;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading;

namespace Subs.MimsWeb.Controllers
{
    public class PromotionController : Controller
    {
        private ProductData gProductData;
        private List<WebProduct> gWebProducts = new List<WebProduct>();
        private readonly MIMSDataContext gMIMSDataContext = new MIMSDataContext(Settings.ConnectionString);

        public PromotionController()
        {
            gProductData = new ProductData();
        }

        [HttpGet]
        public ViewResult SelectList()
        {
            // Present the selection options
            
            return View("SelectList");
        }

        [HttpPost]
        public ActionResult SelectList(ProductSelector pProductSelector)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Message = ModelState.ToString();
                    return View("Error");
                }
 
                Session["ProductSelector"] = pProductSelector;
 
                if (gProductData.WebProducts(pProductSelector).Count() == 0)
                {
                    ViewBag.Message = "Sorry, no product satsifies these requirements";
                    return View("SelectList");
                }
                else
                {
                    gWebProducts = gProductData.WebProducts(pProductSelector);
                    LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];

                    if (lLoginRequest != null)
                    {
                        foreach (WebProduct item in gWebProducts)
                        {
                            item.Price = SubscriptionBiz.StandardProductPrice(item.ProductId, (int)lLoginRequest.CustomerId);
                        }
                    }
                    return View("List", gWebProducts);
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SelectList - post", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = ex.Message;

                return View("Error");
            }
        }

        [HttpGet]
        public ViewResult List()
        {
            try
            {
                List<WebProduct> lOriginalSelection = gProductData.WebProducts((ProductSelector)Session["ProductSelector"]);
                
                // Add the original prices
                LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
                if (lLoginRequest != null)
                {
                    foreach (WebProduct item in gWebProducts)
                    {
                        item.Price = SubscriptionBiz.StandardProductPrice(item.ProductId, (int)lLoginRequest.CustomerId);
                    }
                }

                List<WebProduct> lSecondSelection = (List<WebProduct>)Session["Products"];
 
                if (lSecondSelection != null)
                {
                    WebProduct[] lProductArray = lSecondSelection.ToArray();
                    int i = 0;
                    foreach (WebProduct lProduct in lOriginalSelection)
                    {
                        if (lProductArray[i].Checked)
                        {
                            lProduct.Checked = true;
                        }
                        i++;
                    }
                }
                return View("List", lOriginalSelection);
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "List", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult List(List<WebProduct> pProducts)
        {
            LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
            Session["Products"] = pProducts;

            try 
            {

                if (lLoginRequest == null)
                {
                    ViewBag.Message = "Sorry, I cannot quote a price for you unless you are first logged in.";
                    return View("Empty");
                }

                // Create template subscriptions for the checked products

                Basket lBasket = new Basket();


                foreach (WebProduct lProduct in pProducts)
                {
                    if (lProduct.Checked)
                    {
                        SubscriptionData3 lSubscription = new SubscriptionData3();

                        lSubscription.PayerId = (int)lLoginRequest.CustomerId;
                        lSubscription.ReceiverId = (int)lLoginRequest.CustomerId;
                        lSubscription.ProductId = lProduct.ProductId;
                        //lSubscription.PayerCountryId = lLoginRequest.CountryId;
                        
                        {
                            string lResult;

                            if ((lResult = SubscriptionBiz.SetInitialValues(lSubscription, DateTime.Now)) != "OK")
                            {
                                ViewBag.Message = lResult;
                                return View("Error");
                            }
                        }
                        
                        BasketItem lBasketItem = new BasketItem() { Subscription = lSubscription };
                        lBasketItem.ProductName = lProduct.Heading;
                        lBasket.BasketItems.Add(lBasketItem);
                    }
                    else
                    {
                        lProduct.Subscription = null;
                    }
                } // end of foreach on pProduct

                if (SubscriptionBiz.CalculateBasket(lBasket.BasketItems))
                {

                    foreach (BasketItem lBasketItem in lBasket.BasketItems)
                    {
                        lBasket.TotalPrice += lBasketItem.Price;
                        lBasket.TotalDiscount += lBasketItem.Discount;
                     }

                    lBasket.TotalDiscountedPrice = lBasket.TotalPrice - lBasket.TotalDiscount;

                    if (lBasket.BasketItems.Count() == 1)
                    {
                        ViewBag.Message = "There is " + lBasket.BasketItems.Count() + " product selected, resulting in a price of " + lBasket.TotalDiscountedPrice.ToString("R #####0.00");
                    }
                    else
                    { 
                        ViewBag.Message = "There are " + lBasket.BasketItems.Count() + " products selected, resulting in a price of " + lBasket.TotalDiscountedPrice.ToString("R #####0.00");
                    }
                }
                else
                {
                    ViewBag.Message = "There was a problem calculating the basket value";
                    return View("Empty");
                }

                Session["Basket"] = lBasket;

                return View("Basket", lBasket); // This goes back to the browser.
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "List", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult BasketModification(IList<BasketModification> pModifications)
        {
            try
            {
               // For some reason I cannot get it via a parameter. Possibly, becasue there has not been a preceding [HTTPGet]

               // NameValueCollection lForm = this.ControllerContext.RequestContext.HttpContext.Request.Form;

                //First, you will have to rebuild the basket, substitute the changed values and then you can continue.

                Basket lBasket = (Basket)Session["Basket"];
 
                int i = 0;
                ObservableCollection<BasketItem> lToBeRemoved = new ObservableCollection<BasketItem>();


                foreach (BasketItem item in lBasket.BasketItems)
                {
                    BasketModification lModification = pModifications[i];
                    if (lModification.Drop)
                    {
                        lToBeRemoved.Add(item);
                    }
                    item.Subscription.UnitsPerIssue = pModifications[i].UnitsPerIssue;
                    item.Subscription.DeliveryMethodInt = pModifications[i].DeliveryMethod;
                    i++;
                }

                // Remove the marked entries.

                foreach (BasketItem item in lToBeRemoved)
                {
                    lBasket.BasketItems.Remove(item);
                }
                lToBeRemoved.Clear();

              
                int Changes = lBasket.BasketItems.Count;

                // Recalculate the basket
           

                if (SubscriptionBiz.CalculateBasket(lBasket.BasketItems))
                {
                    foreach (BasketItem lBasketItem in lBasket.BasketItems)
                    {
                        lBasket.TotalPrice += lBasketItem.Price;
                        lBasket.TotalDiscount += lBasketItem.DiscountedPrice;
                    }

                    lBasket.TotalDiscountedPrice = lBasket.TotalPrice - lBasket.TotalDiscount;

                    LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];

                    CustomerData3 lCustomerData = new CustomerData3((int)lLoginRequest.CustomerId);
                    if (lCustomerData.PhysicalAddressId == 0)
                    {

                        // If there are non electronic deliverymethods, you are going to need a deliveryaddress

                        DeliveryMethod[] lMethodsRequiringAddress = { DeliveryMethod.Courier, DeliveryMethod.Mail, DeliveryMethod.RegisteredMail };

                        int lPhysicalAddressNeeded = lBasket.BasketItems.Where(p => lMethodsRequiringAddress.Contains(p.Subscription.DeliveryMethod)).Count();

                        if (lPhysicalAddressNeeded > 0)
                        {
                            lBasket.RequiresDeliveryAddress = true;
                        }
                    }
                    else 
                    {
                        lBasket.RequiresDeliveryAddress = false;
                    }

                    if (lBasket.BasketItems.Count() == 1)
                    {
                        ViewBag.Message = "There is " + lBasket.BasketItems.Count() + " product selected, resulting in a price of " + lBasket.TotalDiscountedPrice.ToString("R #####0.00");
                    }
                    else
                    {
                        ViewBag.Message = "There are " + lBasket.BasketItems.Count() + " products selected, resulting in a price of " + lBasket.TotalDiscountedPrice.ToString("R #####0.00");
                    }
                }
                else
                {
                    ViewBag.Message = "There was a problem calculating the basket value";
                    return View("Empty");
                }

                Session["Basket"] = lBasket;

                return View("Basket", lBasket);
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "BasketModification", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "There was a problem calculating the basket value";
                return View("Empty");
            }

        }

        public ActionResult Basket(Basket pBasket)
        {
            return View("Basket", pBasket);
        }

        [HttpGet]
        public ActionResult Submit()
        {
            Basket lBasket = (Basket)Session["Basket"];
            LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
            StringBuilder lPositiveResult = new StringBuilder();

            try 
            { 

                // Validate all the subscriptions

                foreach (BasketItem lBasketItem in lBasket.BasketItems)
                {
                    Subs.Data.MimsValidationResult lValidationResult = lBasketItem.Subscription.Validate();

                    if (lValidationResult.Message != "OK")
                    {
                        if (lValidationResult.Prompt)
                        {
                            if (lValidationResult.Message.Contains("overlaps"))
                            {
                                // Write a synchronous modal dialog here.
                                // For now, ignore it.
                            }

                        }
                        else
                        {
                            ExceptionData.WriteException(1, lValidationResult.Message, this.ToString(), "Pay", "Receiver = " + lBasketItem.Subscription.ReceiverId.ToString());
                            ViewBag.Message = lValidationResult.Message;
                            return View("Empty");
                        }
                    }

                    lBasketItem.Subscription.gReadyToSubmit = true;

                } // End of validation loop


                // Submit all the subscriptions
                   // Start the transaction
               
                SqlConnection lConnection = new SqlConnection();
                lConnection.ConnectionString = Settings.ConnectionString;

                if (lConnection.State != ConnectionState.Open)
                {
                    lConnection.Open();
                }

                SqlTransaction lTransaction = lConnection.BeginTransaction("Submit");

                lPositiveResult.AppendLine("The following subscriptions have been submitted successfully: ");

                foreach (BasketItem lBasketItem in lBasket.BasketItems)
                {
                    // Initialise the subscription
                    string ResultOfInitialise = SubscriptionBiz.Initialise(lTransaction, lBasketItem.Subscription);
                    if (ResultOfInitialise != "OK")
                    {
                        lTransaction.Rollback("Submit");
                        ViewBag.Message = ResultOfInitialise;
                        return View("Empty");
                    }
                    else
                    {
                        lPositiveResult.AppendLine(lBasketItem.Subscription.SubscriptionId.ToString());
                    }

                }  //End of foreach
                lTransaction.Commit();

                // Generate and submit an invoice.

                List<InvoiceSpecification> lInvoiceSpecification = gMIMSDataContext.MIMS_LedgerData_LoadInvoiceBatch("ForCustomerId", lLoginRequest.CustomerId).ToList();

                int lInvoiceId = AdministrationData2.GetInvoiceId();
                lBasket.InvoiceId = lInvoiceId;
                Session["Basket"] = lBasket;

                decimal lCurrentInvoiceValue = 0M;

                foreach (InvoiceSpecification item in lInvoiceSpecification)
                {
                    //Link the invoice to each subscription

                    SubscriptionData3 lSubscriptionData = new SubscriptionData3(item.SubscriptionId);
                    lSubscriptionData.InvoiceId = lInvoiceId;

                    if (!lSubscriptionData.Update())
                    {
                        ViewBag.Message = "Error updating subscription: " + item.SubscriptionId.ToString();
                        return View("Empty");
                    }
                       
                    lCurrentInvoiceValue = lCurrentInvoiceValue + lSubscriptionData.UnitPrice * lSubscriptionData.UnitsPerIssue * lSubscriptionData.NumberOfIssues;
                }

                // Write an entry to the log
                LedgerData.Invoice((int)lLoginRequest.CustomerId, lInvoiceId, 0, lCurrentInvoiceValue);

                // Process the invoice in a seperate single apartment thread.
                Thread lWorkerThread = new Thread(ProcessInvoice);
                lWorkerThread.SetApartmentState(ApartmentState.STA);
                object pState = lInvoiceId;  // Box it
                lWorkerThread.Start(pState);
                lWorkerThread.Join();
  

                // Email the invoice

                string lFileName = Settings.DirectoryPath + "\\" 
                    +"INV_"
                    + lLoginRequest.CustomerId.ToString()
                    + "_"
                    + lInvoiceId.ToString()
                    + ".pdf";

                if(!Maintenance.SendEmailInvoice(lFileName, lLoginRequest.Email, (int)lLoginRequest.CustomerId))
                {
                    ViewBag.Message = "There was a problem emailing the invoice";
                    return View("Empty");
                }
 

                lPositiveResult.AppendLine("A corresponding invoice has been emailed to you.");
                ViewBag.Message = lPositiveResult;
                return RedirectToAction("Pay");
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Submit", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "There was a problem calculating the basket value";
                return View("Empty");
            }
        }

        private void ProcessInvoice(object pState)
        {
            try
            {

                InvoiceControl lInvoiceControl = new InvoiceControl();
                string lResult;
                if ((lResult = lInvoiceControl.LoadAndRenderInvoice((int)pState)) != "OK")
                {
                    ViewBag.Message = lResult;
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ProcessInvoice", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
            }
        }

        [HttpGet]
        public ActionResult Pay()
        {
            try
            {
                return View("Pay");
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Pay", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return View("Empty");
            }
        }

        [HttpGet]
        public ActionResult PayEFT()
        {
            try
            {
                return View("PayEFT");
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Pay", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return View("Empty");
            }
        }


    }
}