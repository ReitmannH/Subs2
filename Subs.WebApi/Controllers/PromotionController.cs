using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Subs.WebApi.Models;
using Subs.Data;
using Subs.Business;
using System.Collections.Specialized;
using System.Text;
using System.Collections.ObjectModel;

namespace Subs.WebApi.Controllers
{
    public class PromotionController : Controller
    {
        private IProductRepository gProductRepository;

        public PromotionController()
        {
            
        }

        [HttpGet]

        public ViewResult CompareMedicine()
        {
            return View();
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

                // Populate gProductRepository , including the comparison.
               
                gProductRepository = new ProductRepository(pProductSelector);
                Session["ProductSelector"] = pProductSelector;

                if (gProductRepository.Products.Count() == 0)
                {
                    ViewBag.Message = "Sorry, no product satsifies these requirements";
                    return View("SelectList");
                }
                else
                {

                    return View("List", gProductRepository);
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

                ViewBag["Message"] = ex.Message;

                return View("Error");
            }
        }




        [HttpGet]

        public ViewResult List()
        {
            try
            {
                List<Product> PastProducts = (List<Product>)Session["Products"];

                if (gProductRepository == null)
                {
                    gProductRepository = new ProductRepository((ProductSelector)Session["ProductSelector"]);
                }
               

                if (PastProducts != null)
                {
                    Product[] lProductArray = PastProducts.ToArray();

                    int i = 0;
                    foreach (Product lProduct in gProductRepository.Products)
                    {
                        if (lProductArray[i].Checked)
                        {
                            lProduct.Checked = true;
                        }
                        i++;
                    }
                }

                return View("List",gProductRepository);
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
        public ActionResult List(List<Product> pProducts)
        {
            LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];
            Session["Products"] = pProducts;

            try {

                    if (lLoginRequest == null)
                    {
                        ViewBag.Message = "Sorry, I cannot quote a price for you unless you are first logged in.";
                        return View("Empty");
                    }


                    // Create template subscriptions for the checked products

                    ObservableCollection<BasketItem> lBasket = new ObservableCollection<BasketItem>();


                    foreach (Product lProduct in pProducts)
                    {
                        if (lProduct.Checked)
                        {
                            SubscriptionData3 lSubscription = new Data.SubscriptionData3();

                            lSubscription.Payer = lLoginRequest.CustomerId;
                            lSubscription.Receiver = lLoginRequest.CustomerId;
                            lSubscription.ProductId = lProduct.ProductId;
                            lSubscription.PayerCountry = lLoginRequest.CountryId;
                        
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
                            lBasketItem.Drop = false;

                            lBasket.Add(lBasketItem);
                        }
                        else
                        {
                            lProduct.Subscription = null;
                        }
                    } // end of foreach on pProduct

                    decimal lFullPrice = 0;
                    decimal lDiscountedPrice = 0;
                    decimal lDiscountPercentage = 0;

                    if (SubscriptionBiz.CalculateBasket(lBasket))
                    {

                    foreach (BasketItem lBasketItem in lBasket)
                    {
                        lFullPrice += lBasketItem.FullPrice;
                        lDiscountedPrice += lBasketItem.DiscountedPrice;
                        lDiscountPercentage = Math.Round((((lFullPrice - lDiscountedPrice) / lFullPrice) * 100), 2);
                    }
                    
                    ViewBag.Message = "There are " + lBasket.Count() + " products selected, resulting in a price of " + lDiscountedPrice.ToString("c");
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
                        ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "List", "");
                        CurrentException = CurrentException.InnerException;
                    } while (CurrentException != null);

                    return View("Error");
                }
            }





        [ValidateInput(false)]

        public ActionResult Basket()
        {
           
            try
            {
                // Get the form data

                // Pick up the changes made in the form and merge to what you have already. Use the index to match them

                NameValueCollection lForm = this.ControllerContext.RequestContext.HttpContext.Request.Form;


                //string[] lDrop = lForm.GetValues("Drop");
                string[] lUnitsPerIssue = lForm.GetValues("Subscription.UnitsPerIssue");
                string[] lDeliveryMethod = lForm.GetValues("Subscription.DeliveryMethod");


                // Get back the previous work that you did on the basket
                ObservableCollection<BasketItem> lBasket = (ObservableCollection<BasketItem>)Session["Basket"];
                Stack<BasketItem> lDeletionStack = new Stack<BasketItem>();



                foreach (BasketItem lBasketItem in lBasket)
                {
                    if (Int32.Parse(lUnitsPerIssue[lBasketItem.Index]) == 0)
                    {
                        lDeletionStack.Push(lBasketItem);
                    }
                    else
                    {
                        lBasketItem.Subscription.DeliveryMethod = (DeliveryMethod)Enum.ToObject(typeof(DeliveryMethod), Int32.Parse(lDeliveryMethod[lBasketItem.Index]));
                        lBasketItem.Subscription.UnitsPerIssue = Int32.Parse(lUnitsPerIssue[lBasketItem.Index]);
                    }
                }

                while (lDeletionStack.Count() > 0)
                {
                    lBasket.Remove(lDeletionStack.Pop());
                }

                // Recalculate the basket

                decimal lFullPrice = 0;
                decimal lDiscountedPrice = 0;
                decimal lDiscountPercentage = 0;

                if (SubscriptionBiz.CalculateBasket(lBasket))
                {
                    foreach (BasketItem lBasketItem in lBasket)
                    {
                        lFullPrice += lBasketItem.FullPrice;
                        lDiscountedPrice += lBasketItem.DiscountedPrice;
                        lDiscountPercentage = Math.Round((((lFullPrice - lDiscountedPrice) / lFullPrice) * 100), 2);

                    }

                    ViewBag.Message = "There are " + lBasket.Count() + " products selected, resulting in a price of " + lDiscountedPrice.ToString("c");
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Basket", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                ViewBag.Message = "There was a problem calculating the basket value";
                return View("Empty");
            }

        }


        [HttpGet]
        public ActionResult DeliveryAddress()
        {
            // If there are non electronic deliverymethods, you are going to need a deliveryaddress

            DeliveryMethod[] lMethodsRequiringAddress = { DeliveryMethod.Courier, DeliveryMethod.Mail, DeliveryMethod.RegisteredMail };

            ObservableCollection<BasketItem> lBasket = (ObservableCollection<BasketItem>)Session["Basket"];
           
            LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];

            int lPhysicalAddressNeeded = lBasket.Where(p => lMethodsRequiringAddress.Contains(p.Subscription.DeliveryMethod)).Count();

            if (lPhysicalAddressNeeded == 0)
            {
                return RedirectToAction("Pay");
            }


            var lCountryQuery = from lRow in AdministrationData2.Country
                                select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };

            SelectList lCountryList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value", lLoginRequest.CountryId);
            
            DeliveryAddressTemplate lDeliveryAddressTemplate = new DeliveryAddressTemplate();
            lDeliveryAddressTemplate.CountryId = lLoginRequest.CountryId;
            lDeliveryAddressTemplate.CountrySelectList = lCountryList;

            if (lLoginRequest.PhysicalAddressId != 0)
            {
                // There is an existing delivery address. Display it.
                    
                DeliveryAddressData2 lDeliveryAddressData = new DeliveryAddressData2(lLoginRequest.PhysicalAddressId);
                lDeliveryAddressTemplate.DeliveryAddressId = lDeliveryAddressData.DeliveryAddressId;
                lDeliveryAddressTemplate.CountryId = lDeliveryAddressData.CountryId;
                lDeliveryAddressTemplate.Province = lDeliveryAddressData.Province;
                lDeliveryAddressTemplate.City = lDeliveryAddressData.City;
                lDeliveryAddressTemplate.Suburb = lDeliveryAddressData.Suburb;
                lDeliveryAddressTemplate.Street = lDeliveryAddressData.Street;
                lDeliveryAddressTemplate.StreetExtension = lDeliveryAddressData.StreetExtension;
                lDeliveryAddressTemplate.StreetSuffix = lDeliveryAddressData.StreetSuffix;
                lDeliveryAddressTemplate.StreetNo = lDeliveryAddressData.StreetNo;
                lDeliveryAddressTemplate.Building = lDeliveryAddressData.Building;
                lDeliveryAddressTemplate.Floor = lDeliveryAddressData.Floor;
                lDeliveryAddressTemplate.Room = lDeliveryAddressData.Room;
            }
                
            return View(lDeliveryAddressTemplate);
        }

        [HttpPost]
        public ActionResult DeliveryAddress(DeliveryAddressTemplate pDeliveryAddress)
        {
            try
            {

                var lCountryQuery = from lRow in AdministrationData2.Country
                                    select new ListItem { Key = lRow.CountryId, Value = lRow.CountryName };

                SelectList lCountryList = new SelectList((IEnumerable<ListItem>)lCountryQuery.ToList(), "Key", "Value");
                pDeliveryAddress.CountrySelectList = lCountryList;

                DeliveryAddressData2 lDeliveryAddressData;
                LoginRequest lLoginRequest = (LoginRequest)Session["LoginRequest"];

                if (lLoginRequest.PhysicalAddressId != 0)
                {
                    // This must have been an existing DeliveryAddress
                    lDeliveryAddressData = new DeliveryAddressData2(lLoginRequest.PhysicalAddressId);
                }
                else
                {
                    // Create a new one
                    lDeliveryAddressData = new DeliveryAddressData2();
                }

                // Update the object

                lDeliveryAddressData.CountryId = pDeliveryAddress.CountryId;
                lDeliveryAddressData.Province = pDeliveryAddress.Province;
                lDeliveryAddressData.City = pDeliveryAddress.City;
                lDeliveryAddressData.Suburb = pDeliveryAddress.Suburb;
                lDeliveryAddressData.Street = pDeliveryAddress.Street;
                lDeliveryAddressData.StreetExtension = pDeliveryAddress.StreetExtension;
                lDeliveryAddressData.StreetSuffix = pDeliveryAddress.StreetSuffix;
                lDeliveryAddressData.StreetNo = pDeliveryAddress.StreetNo;
                lDeliveryAddressData.Building = pDeliveryAddress.Building;
                lDeliveryAddressData.Floor = pDeliveryAddress.Floor;
                lDeliveryAddressData.Room = pDeliveryAddress.Room;
                lDeliveryAddressData.PostCode = pDeliveryAddress.PostCode;


                {
                    string lResult;

                    if ((lResult = lDeliveryAddressData.Update()) != "OK")
                    {
                        ViewBag.Message = lResult;
                        return View("Error");
                    }
                }
               

                if (lLoginRequest.PhysicalAddressId == 0)
                {
                    // Update the Customer record if this is a new physical address
                    lLoginRequest.PhysicalAddressId = lDeliveryAddressData.DeliveryAddressId;
                    CustomerData3 lCustomerData3 = new CustomerData3(lLoginRequest.CustomerId);
                    lCustomerData3.PhysicalAddressId = lDeliveryAddressData.DeliveryAddressId;
                    lCustomerData3.Update();
                }

                // You also have to link the new address

                DeliveryAddressData2.Link(lDeliveryAddressData.DeliveryAddressId, lLoginRequest.CustomerId);

                // If this country is different from what was captured in the subscriptions, you will have to recalculate the price. 

                DeliveryMethod[] lMethodsRequiringAddress = { DeliveryMethod.Courier, DeliveryMethod.Mail, DeliveryMethod.RegisteredMail };

                ObservableCollection<BasketItem> lBasket = (ObservableCollection<BasketItem>)Session["Basket"];

                IEnumerable<BasketItem> lBasketRequiringAddresses = lBasket.Where(p => lMethodsRequiringAddress.Contains(p.Subscription.DeliveryMethod));

                foreach (BasketItem lItem in lBasketRequiringAddresses)
                {
                    if (lItem.Subscription.ReceiverCountry != lDeliveryAddressData.CountryId)
                    {
                        ExceptionData.WriteException(1,
                            "1 " + "Customer changed delivery country from " + lItem.Subscription.ReceiverCountry.ToString() + " to " + lDeliveryAddressData.CountryId.ToString(),
                            this.ToString(), "DeliveryAddress", " Payer = " + lItem.Subscription.Payer.ToString());
                    }
                }

                // If you get here, you are ready to prompt for payment.

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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "DeliveryAddress", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return View("Error");
            }
        }


        //[HttpGet]
        //public ActionResult Pay()
        //{

        //    StringBuilder lPositiveResult = new StringBuilder();
        //    int lCurrentPayer = 0;
        //    SqlConnection lConnection = new SqlConnection();

        //    try
        //    {
        //        ObservableCollection<BasketItem> lBasket = (ObservableCollection<BasketItem>)Session["Basket"];

        //        // Validate the subscriptions


        //        foreach (BasketItem lBasketItem in lBasket)
        //        {
        //            Subs.Data.MimsValidationResult lValidationResult = lBasketItem.Subscription.Validate();

        //            if (lValidationResult.Message != "OK")
        //            {
        //                if (lValidationResult.Prompt)
        //                {
        //                    if (lValidationResult.Message.Contains("overlaps"))
        //                    {
        //                        // Write a synchronous modal dialog here.
        //                        // For now, ignore it.
        //                    }

        //                }
        //                else
        //                { 
        //                    ExceptionData.WriteException(1, lValidationResult.Message, this.ToString(), "Pay", "Receiver = " + lBasketItem.Subscription.Receiver.ToString());
        //                    ViewBag.Message = lValidationResult.Message;
        //                    return View("Empty");
        //                }
        //            }

        //            lBasketItem.Subscription.gReadyToSubmit = true;

        //        } // End of validation loop


        //        // Submit all the subscriptions
                
        //            // Start the transaction

        //        lConnection.ConnectionString = Settings.ConnectionString;

        //        if (lConnection.State != ConnectionState.Open)
        //        {
        //            lConnection.Open();
        //        }

        //        SqlTransaction lTransaction = lConnection.BeginTransaction("Submit");

        //        lPositiveResult.AppendLine("The following subscriptions have been submitted successfully: ");

        //        foreach (BasketItem lBasketItem in lBasket)
        //        {

        //            // Initialise the subscription

        //            string ResultOfInitialise = SubscriptionBiz.Initialise(lTransaction, lBasketItem.Subscription);

        //            if (ResultOfInitialise != "OK")
        //            {
        //                lTransaction.Rollback("Submit");
        //                ViewBag.Message = ResultOfInitialise;
        //                return View("Empty");
        //            }
        //            else
        //            {
        //                lPositiveResult.AppendLine(lBasketItem.Subscription.SubscriptionId.ToString());
        //            }

        //        }  //End of foreach

        //        lTransaction.Commit();

        //        // Allocate money if there is money availible

        //        IssueBiz.AllocatePaymentAutomatically(lCurrentPayer); // I deliberately ignore the return code, since it is immaterial.

        //        // Cleanout all previous selections

        //        List<Product> lProducts = (List<Product>) Session["Products"];

        //        foreach (Product lProduct in lProducts)
        //        {
        //            lProduct.Checked = false;
        //        }

        //        ViewBag.Message = lPositiveResult;
        //        return View("Pay");
        //    }

        //    catch (Exception ex)
        //    {
        //        //Display all the exceptions

        //        Exception CurrentException = ex;
        //        int ExceptionLevel = 0;
        //        do
        //        {
        //            ExceptionLevel++;
        //            ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Pay", "");
        //            CurrentException = CurrentException.InnerException;
        //        } while (CurrentException != null);

        //        return View("Empty");
        //    }
        //    finally
        //    {
        //        if (lConnection.State != ConnectionState.Closed)
        //        {
        //            lConnection.Close();
        //        }
        //    }
        //}

    }
}