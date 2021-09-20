using Subs.Data;
using System;
using System.Windows;
using System.Windows.Data;

namespace Subs.Presentation
{

    public partial class AdministrationDeliveryAddress : Window
    {
        private readonly Subs.Data.DeliveryAddressDocTableAdapters.CountryTableAdapter gCountryTableAdapter = new Subs.Data.DeliveryAddressDocTableAdapters.CountryTableAdapter();
        private readonly Subs.Data.DeliveryAddressDocTableAdapters.ProvinceTableAdapter gProvinceTableAdapter = new Subs.Data.DeliveryAddressDocTableAdapters.ProvinceTableAdapter();
        private readonly Subs.Data.DeliveryAddressDocTableAdapters.CityTableAdapter gCityTableAdapter = new Subs.Data.DeliveryAddressDocTableAdapters.CityTableAdapter();
        private readonly Subs.Data.DeliveryAddressDocTableAdapters.SuburbTableAdapter gSuburbTableAdapter = new Subs.Data.DeliveryAddressDocTableAdapters.SuburbTableAdapter();
        private readonly Subs.Data.DeliveryAddressDocTableAdapters.StreetTableAdapter gStreetTableAdapter = new Subs.Data.DeliveryAddressDocTableAdapters.StreetTableAdapter();
        private Subs.Data.DeliveryAddressDoc gDeliveryAddressDoc;
        private CollectionViewSource gCountryViewSource;  

        //private DateTime gStartTime;
        //private DateTime gEndTime;
        //private TimeSpan gInterval;

        public AdministrationDeliveryAddress()
        {
            InitializeComponent();
            gCountryViewSource = (CollectionViewSource)Resources["countryViewSource"];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                gDeliveryAddressDoc = ((Subs.Data.DeliveryAddressDoc)(this.FindResource("deliveryAddressDoc")));

                gCountryTableAdapter.AttachConnection();
                gProvinceTableAdapter.AttachConnection();
                gCityTableAdapter.AttachConnection();
                gSuburbTableAdapter.AttachConnection();
                gStreetTableAdapter.AttachConnection();

                //gStartTime = DateTime.Now;

                gCountryTableAdapter.Fill(gDeliveryAddressDoc.Country);
                gProvinceTableAdapter.Fill(gDeliveryAddressDoc.Province);
                gCityTableAdapter.Fill(gDeliveryAddressDoc.City);
                gSuburbTableAdapter.Fill(gDeliveryAddressDoc.Suburb);
                gStreetTableAdapter.Fill(gDeliveryAddressDoc.Street);

                int lIndex = gDeliveryAddressDoc.Country.Rows.IndexOf(gDeliveryAddressDoc.Country.FindByCountryId(61));
                gCountryViewSource.View.MoveCurrentToPosition(lIndex);
                countryDataGrid.ScrollIntoView(gCountryViewSource.View.CurrentItem);



            //    gEndTime = DateTime.Now;
            //    gInterval = gEndTime - gStartTime;
            //    ExceptionData.WriteException(5, "It took " + gInterval.ToString() + " to load and bind the deliveryaddresses", this.ToString(), "Window_Loaded", "");

            }
            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Window_Loaded", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                MessageBox.Show("Error in Window_Loaded");
            }
        }

        private void SubmitCountry(object sender, RoutedEventArgs e)
        {
            gCountryTableAdapter.Update(gDeliveryAddressDoc.Country);
            gCountryTableAdapter.Fill(gDeliveryAddressDoc.Country);
        }

        private void SubmitProvince(object sender, RoutedEventArgs e)
        {
            gProvinceTableAdapter.Update(gDeliveryAddressDoc.Province);
            gProvinceTableAdapter.Fill(gDeliveryAddressDoc.Province);
        }


        private void SubmitCity(object sender, RoutedEventArgs e)
        {
            gCityTableAdapter.Update(gDeliveryAddressDoc.City);
            gCityTableAdapter.Fill(gDeliveryAddressDoc.City);
        }

        private void SubmitSuburb(object sender, RoutedEventArgs e)
        {
            gSuburbTableAdapter.Update(gDeliveryAddressDoc.Suburb);
            gSuburbTableAdapter.Fill(gDeliveryAddressDoc.Suburb);
        }

        private void SubmitStreet(object sender, RoutedEventArgs e)
        {
            gStreetTableAdapter.Update(gDeliveryAddressDoc.Street);

        }
    }
}
