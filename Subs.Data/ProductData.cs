using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace Subs.Data
{
    public class ComboItem
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class BasketItem : BaseModel
    {
        private decimal _DiscountedPrice;
        private decimal _FullPrice;
        private decimal _ExplicitDiscountPercentage = 0M;
        private decimal _FinalPriceOverride = 0M;
        
        //public bool Drop = false;
        public string ProductName { get; set; }
        public SubscriptionData3 Subscription { get; set; }
        public string Warning { get; set; }
        public decimal ExplicitDiscountPercentage
        {
            get
            {
                return _ExplicitDiscountPercentage;
            }
            set
            {
                if (value > 100)
                {
                    throw new Exception("You cannot grant more than 100% discount.");
                }

                _ExplicitDiscountPercentage = value;

            }
        }
        public decimal Price
        {
            get
            {
                return _FullPrice;
            }

            set
            {
                _FullPrice = value;
                NotifyPropertyChanged("FullPrice");
                NotifyPropertyChanged("FullDiscount");
            }
        }

        public decimal Discount
        {
            get
            {
                return _FullPrice - _DiscountedPrice;
            }
        }
        public decimal DiscountedPrice
        {
            get
            {
                return _DiscountedPrice;
            }

            set
            {
                _DiscountedPrice = value;
                NotifyPropertyChanged("DiscountedPrice");
                NotifyPropertyChanged("FullDiscount");
            }
        }
        public decimal FinalPriceOverride
        {
            get
            {
                return _FinalPriceOverride;
            }

            set
            {
                _FinalPriceOverride = value;

            }
        }
        public Dictionary<int, string> DeliveryOptions { get; set; }
    }

    public class WebProduct
    {
        public int ProductId { get; set; }
        public int Type { get; set; }
        public int Medium { get; set; }
        public int Category {get; set; }
        public SubscriptionData3 Subscription { get; set; }
        public int DisplaySequence { get; set; }
        public bool Checked { get; set; }
        public bool CPDEnabled { get; set;} 
        public byte[] Picture { get; set; }
        public string Heading { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
    }


    public class DeskTopProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SubscriptionType { get; set; }
        public int SubscriptionMedium { get; set; }
        public string SubscriptionTypeString
        {
            get 
            {
                return Enum.GetName(typeof(SubscriptionType), SubscriptionType);
            }
        }
        public string SubscriptionMediumString
        {
            get
            {
                return Enum.GetName(typeof(SubscriptionMedium), SubscriptionMedium);
            }
        }
    }

    public class ProductSelector
    {
        public int Category { get; set; }
        public int Medium { get; set; }
        public int Type { get; set; }
    }

    public class ProductData
    {
        private readonly ProductDoc.Product2DataTable gProductTable = new ProductDoc.Product2DataTable();
        private readonly Subs.Data.ProductDocTableAdapters.Product2TableAdapter gProductAdapter = new Subs.Data.ProductDocTableAdapters.Product2TableAdapter();
        private readonly MIMSDataContext gDataContext = new MIMSDataContext(Settings.ConnectionString);
        private List<WebProduct> gWebProducts;

        public ProductData()
        {
            try
            {
                gProductAdapter.AttachConnection();

                //DesktopProducts.Clear();

                gProductAdapter.FillById(gProductTable, 0, "Current");
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ProductData", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }

        }

        #region Properties and methods


        public List<DeskTopProduct> DesktopProducts
        {
            get 
            {
                var lDesktopQuery = from lRow in gProductTable
                                    orderby lRow.ProductName ascending
                                    select new DeskTopProduct()
                                    {
                                        ProductId = lRow.ProductId,
                                        ProductName = lRow.ProductName,
                                        SubscriptionType = lRow.Type,
                                        SubscriptionMedium = lRow.Medium
                                    };
                return lDesktopQuery.ToList<DeskTopProduct>();
            }
        
        }
      

        public List<WebProduct> WebProducts(ProductSelector pSelector) 
        {  
            try
            {
                // Slice off the 'Excluding VAT part

                foreach (ProductDoc.Product2Row lRow in gProductTable)
                {
                    if (lRow.Heading.IndexOf("<p>") > 0)
                    {
                        lRow.Heading = lRow.Heading.Remove(lRow.Heading.IndexOf("<p>"));
                    }
                    
                }
 
                var lWebQuery = from lWebRow in gProductTable
                                orderby lWebRow.DisplaySequence ascending
                                where lWebRow.DisplaySequence > 0 & lWebRow.Category1 == pSelector.Category
                                select new WebProduct()
                                {
                                    ProductId = lWebRow.ProductId,
                                    Type = lWebRow.Type,
                                    Medium = lWebRow.Medium,
                                    Category = lWebRow.Category1,
                                    DisplaySequence = lWebRow.DisplaySequence,
                                    Picture = lWebRow.Picture,
                                    Heading = lWebRow.Heading,
                                    ProductDescription = lWebRow.ProductDescription,
                                };

                // All
                if (pSelector.Medium == 1 && pSelector.Type == 1)
                {
                    gWebProducts = lWebQuery.ToList<WebProduct>();
                }

                if (pSelector.Medium != 1 && pSelector.Type == 1)
                {
                    gWebProducts = lWebQuery.Where(p => p.Medium == pSelector.Medium).ToList<WebProduct>();
                }

                if (pSelector.Medium == 1 && pSelector.Type != 1)
                {
                    gWebProducts = lWebQuery.Where(p => p.Type == pSelector.Type).ToList<WebProduct>();
                }

                if (pSelector.Medium != 1 && pSelector.Type != 1)
                {
                    gWebProducts = lWebQuery.Where(p => p.Medium == pSelector.Medium && p.Type == pSelector.Type).ToList<WebProduct>();
                }
  
                List<WebProductAddition> lAdditions = (List<WebProductAddition>)gDataContext.MIMS_ProducData_WebAddition().ToList<WebProductAddition>();

                foreach (WebProduct item in gWebProducts)
                {
                    item.CPDEnabled = lAdditions.Where(p => p.ProductId == item.ProductId).Single().CPDEnabled;
                }

                return gWebProducts;
            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "WebProducts", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return gWebProducts;
            }
        }
        #endregion
    }
}

