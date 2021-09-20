using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Subs.Data;
using Newtonsoft.Json;

namespace Subs.WebApi.Controllers
{
    public class AdministrationController : ApiController
    {
      
        //// GET api/values
        //[Route("Product")]
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    ProductDoc.ProductDataTable lProduct = new ProductDoc.ProductDataTable();
        //    Data.ProductDocTableAdapters.ProductTableAdapter lAdapter = new Data.ProductDocTableAdapters.ProductTableAdapter();
        //    lAdapter.AttachConnection();
        //    lAdapter.Fill(lProduct);

        //    //var productlinq = (from products in lProduct.AsEnumerable()
        //    //                    select new
        //    //                    {
        //    //                        ProductName = products.ProductName,
        //    //                        Hoogte = products.Hoogte
        //    //                        //SafetyStockLevel = products.Field<Int16>("SafetyStockLevel"),
        //    //                        //ReorderPoint = products.Field<Int16>("ReorderPoint")
        //    //                    }).ToList();


        //    List<Product> lResult = new List<Product>();


        //    foreach (ProductDoc.ProductRow lRow in lProduct)
        //    {
        //        Product newProduct = new Product();
        //        newProduct.ProductName = lRow.ProductName;
        //        newProduct.Hoogte = lRow.IsHoogteNull()? 0: lRow.Hoogte;
        //        lResult.Add(newProduct);
        //    }
  
        //    return lResult;

        //}


        // GET api/values
        [Route("Product")]
        [HttpGet]
        public string Get()
        {
            ProductDoc.ProductDataTable lProduct = new ProductDoc.ProductDataTable();
            Data.ProductDocTableAdapters.ProductTableAdapter lAdapter = new Data.ProductDocTableAdapters.ProductTableAdapter();
            lAdapter.AttachConnection();
            lAdapter.Fill(lProduct);
            return JsonConvert.SerializeObject(lProduct, Formatting.Indented);
        }

              
        [ActionName("get-titles")]
        [HttpGet]
        public List<TextValue> GetTitles()
        {
            try
            {
                var lQuery = AdministrationData2.Title.Select(i => new TextValue
                    {
                        Text = i.Title,
                        Number = i.TitleId
                    });
                return lQuery.ToList();                                                        //JsonConvert.SerializeObject(lQuery, Formatting.Indented);
             }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetTitles", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return new List<TextValue>() { new TextValue() { Text = "Not found", Number = 0 } };
            }
        }

        [ActionName("get-countries")]
        [HttpGet]
        public List<TextValue> GetCountriess()
        {
            try
            {
                var lQuery = AdministrationData2.Title.Select(i => new TextValue
                {
                    Text = i.Title,
                    Number = i.TitleId
                });
                return lQuery.ToList();                                                        //JsonConvert.SerializeObject(lQuery, Formatting.Indented);
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "GetCountries", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return new List<TextValue>() { new TextValue() { Text = "Not found", Number = 0 } };
            }
        }




        public class TextValue
        {
            public string Text { get; set; }
            public int Number { get; set; }
        }



    }
}
