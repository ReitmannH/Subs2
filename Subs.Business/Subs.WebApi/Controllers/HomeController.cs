using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Data;
using Subs.WebApi.Models;
using Newtonsoft.Json;

namespace Subs.WebApi.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }


        [HttpGet]
        public ViewResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult LoginForm(LoginRequest pLoginRequest)
        {
            CustomerData3 lCustomerData = new CustomerData3(pLoginRequest.CustomerId);

            return View("LoginResponse", lCustomerData);
        }



        [HttpGet]
        public ViewResult Register()
        {
            CustomerData3 lCustomerData = new CustomerData3();

            //use AdministrationData2.Title to populate an array of Text and Value. Put that in a ViewBag as Titles.


            return View("Register", lCustomerData);
        }


        [HttpPost]
        public ViewResult Register(CustomerData3 pCustomerData)
        {
            //string lRegistrationString = JsonConvert.SerializeObject(pRegistration);

            // Post to WebApi service.

            //CustomerData3 lCustomerData = new CustomerData3();

            //lCustomerData.Surname = pRegistration.Surname;




            {
                string lResult;

                if ((lResult = pCustomerData.Update()) != "OK")
                {
                    ViewBag.ResponseMessage = lResult;

                    return View("Register", pCustomerData);
                }
                else
                    ViewBag.CustomerId = pCustomerData.CustomerId.ToString();
            }

            return View("LoginResponse", pCustomerData);
        }



        public ActionResult ProductCatalog()
        {

            ProductDoc.ProductDataTable lProduct = new ProductDoc.ProductDataTable();
            Data.ProductDocTableAdapters.ProductTableAdapter lAdapter = new Data.ProductDocTableAdapters.ProductTableAdapter();
            lAdapter.AttachConnection();
            lAdapter.Fill(lProduct);

            return View("ProductCatalog", lProduct);
        }


    }
}

