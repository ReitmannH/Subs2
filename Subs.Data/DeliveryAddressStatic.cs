using System;
using System.Data;
using System.Linq;

namespace Subs.Data
{
    public static class DeliveryAddressStatic
    {
        #region Globals

        public static DeliveryAddressDoc DeliveryAddresses = new DeliveryAddressDoc();
        public static bool Loaded = false;
        private static readonly Data.DeliveryAddressDocTableAdapters.DeliveryAddressTableAdapter gDeliveryTableAdapter = new Data.DeliveryAddressDocTableAdapters.DeliveryAddressTableAdapter();
        private static readonly Data.DeliveryAddressDocTableAdapters.CountryTableAdapter gCountryTableAdapter = new Data.DeliveryAddressDocTableAdapters.CountryTableAdapter();
        private static readonly Data.DeliveryAddressDocTableAdapters.ProvinceTableAdapter gProvinceTableAdapter = new Data.DeliveryAddressDocTableAdapters.ProvinceTableAdapter();
        private static readonly Data.DeliveryAddressDocTableAdapters.CityTableAdapter gCityTableAdapter = new Data.DeliveryAddressDocTableAdapters.CityTableAdapter();
        private static readonly Data.DeliveryAddressDocTableAdapters.SuburbTableAdapter gSuburbTableAdapter = new Data.DeliveryAddressDocTableAdapters.SuburbTableAdapter();
        private static readonly Data.DeliveryAddressDocTableAdapters.StreetTableAdapter gStreetTableAdapter = new Data.DeliveryAddressDocTableAdapters.StreetTableAdapter();

        #endregion

        public static bool Refresh()
        {
            try
            {
                DeliveryAddresses.Street.Clear();
                DeliveryAddresses.Suburb.Clear();
                DeliveryAddresses.City.Clear();
                DeliveryAddresses.Province.Clear();
                DeliveryAddresses.Country.Clear();

                gCountryTableAdapter.Fill(DeliveryAddresses.Country);
                gProvinceTableAdapter.Fill(DeliveryAddresses.Province);
                gCityTableAdapter.Fill(DeliveryAddresses.City);
                gSuburbTableAdapter.Fill(DeliveryAddresses.Suburb);
                gStreetTableAdapter.Fill(DeliveryAddresses.Street);

                Loaded = true;
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
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, "DeliveryAddressStatatic", "Refresh", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                Loaded = false;
                return false;
            }

        }

        public static bool Exists(int pDeliveryAddressId)
        {
            int lCount = DeliveryAddresses.DeliveryAddress.Where(p => p.DeliveryAddressId == pDeliveryAddressId).Count<DeliveryAddressDoc.DeliveryAddressRow>();
            if (lCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static DeliveryAddressStatic()
        {
            try
            {
                gDeliveryTableAdapter.AttachConnection();
                gCountryTableAdapter.AttachConnection();
                gProvinceTableAdapter.AttachConnection();
                gCityTableAdapter.AttachConnection();
                gSuburbTableAdapter.AttachConnection();
                gStreetTableAdapter.AttachConnection();

                //DateTime gStartTime;
                //DateTime gEndTime;
                //TimeSpan gInterval;

                //gStartTime = DateTime.Now;

                gDeliveryTableAdapter.Fill(DeliveryAddresses.DeliveryAddress);
                gCountryTableAdapter.Fill(DeliveryAddresses.Country);
                gProvinceTableAdapter.Fill(DeliveryAddresses.Province);
                gCityTableAdapter.Fill(DeliveryAddresses.City);
                gSuburbTableAdapter.Fill(DeliveryAddresses.Suburb);
                gStreetTableAdapter.Fill(DeliveryAddresses.Street);

                //gEndTime = DateTime.Now;
                //gInterval = gEndTime - gStartTime;

                //ExceptionData.WriteException(5, "It took " + gInterval.ToString() + " to load the deliveryaddresses", "DeliveryAddressStatic", "DeliveryAddressStatic", "");
            }


            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, "DeliveryAddressStatic", "DeliveryAddressStatic", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);
            }
        }
    }
}
