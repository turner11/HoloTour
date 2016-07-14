using HoloTour.Common;
using HoloTour.ViewModels;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HoloTour.Pages
{
    public partial class TourPage : CarouselPage
    {
        TourViewModel _tourViewModel { get; }
        TourOverviewPage _tourOverviewpage;

        private readonly IGeolocator _geolocator;

        public TourPage(TourViewModel viewModel)
        {
            InitializeComponent();
            this._tourViewModel = viewModel;

            this._tourOverviewpage = new TourOverviewPage(this._tourViewModel);
            this._tourOverviewpage.PointOfInterest_Selected += TourOverviewpage_PointOfInterest_Selected;
            Children.Add(this._tourOverviewpage);
            var pois = this._tourViewModel.PointsOfInterest;

            foreach (var poi in pois)
            {
                var poiPage = new PointofInterestPage(poi);
                Children.Add(poiPage);
            }


            this._geolocator = CrossGeolocator.Current;
            this.BindToLocationChanges();
        }
       
        private async void BindToLocationChanges()
        {
            //MinDistance and Mintime to the Native api and the API decided what they mean 
            //IE for android: https://developer.android.com/reference/android/location/LocationManager.html
            //          minTime	long: minimum time interval between location updates, in milliseconds
            //          minDistance float: minimum distance between location updates, in meters

            this._geolocator.DesiredAccuracy = 20;
            this._geolocator.PositionChanged += Geolocator_PositionChanged;
            int minTime = (int)TimeSpan.FromSeconds(15).TotalMilliseconds;
            double minDistance = 20;
            try
            {
                await this._geolocator.StartListeningAsync(minTime, minDistance, true).ConfigureAwait(false);

            }
            catch (Exception ex)
            {

                //TODO: Add login / notification
            }

           

        }

        private void Geolocator_PositionChanged(object sender, PositionEventArgs e)
        {
            var currLocation = new Xamarin.Forms.Maps.Position(e.Position.Latitude,e.Position.Longitude);
            var closestPage = this.Children.OfType<PointofInterestPage>()
                .Select(p=> new {Distance = MathUtils.GetDistance_Meters(currLocation, p.PointOfInterestVM.Position),
                                 Page = p})
                .OrderBy(an => an.Distance).FirstOrDefault();

            if (closestPage != null)
            {
                bool jumpToPage = closestPage.Distance <= 30 
                                  && this.CurrentPage != closestPage.Page;
                if (jumpToPage)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        this.CurrentPage = closestPage.Page;
                    });
                }
            }




               
        }

        private void TourOverviewpage_PointOfInterest_Selected(object sender, Common.EventArgs.IPointOfInterestArgs e)
        {
            var selectedPage = this.Children.OfType<PointofInterestPage>()
                .Where(p => p.PointOfInterestVM.Id == e.PointOfInterest.Id)
                .FirstOrDefault();
            if (selectedPage != null)
            {
                this.CurrentPage = selectedPage;
            }
        }
    }
}
