using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HoloTour.Pages
{
    public partial class TourPage : ContentPage
    {
        TourViewModel _tourViewModel { get; }
        public TourPage(TourViewModel viewModel)
        {
            InitializeComponent();
            this._tourViewModel = viewModel;
            
            //add all points of interest to route
            this.MapView.RouteCoordinates.AddRange(this._tourViewModel.PointsOfInterest.Select(poi=> poi.Position));
            

            this.lblLocation.IsVisible = false;
            this.Appearing += TourPage_Appearing;
           
        }

        /// <summary>
        /// Indicates that the Page is about to appear.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void TourPage_Appearing(object sender, EventArgs e)
        {
            if (this._tourViewModel.PointsOfInterest.Count == 0)
                return;

            var mapLocatoion = this.MapView.RouteCoordinates.FirstOrDefault();
            var region = MapSpan.FromCenterAndRadius(mapLocatoion, Distance.FromKilometers(1));
            this.MapView.MoveToRegion(region);

            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);//want to see if will load faster and how will look...
            var pins = this._tourViewModel.PointsOfInterest.Select(poi => new Pin()
                                                                    {
                                                                        Position = poi.Position,
                                                                        Label = poi.Title,
                                                                        Type = PinType.SearchResult
                                                                    }).ToArray();

            
            foreach (var pin in pins)
            {
                pin.Clicked += Pin_Clicked;
                await Task.Delay(TimeSpan.FromSeconds(0.25));
                Device.BeginInvokeOnMainThread(()=>this.MapView.Pins.Add(pin));
            }
        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {
            Pin pin = sender as Pin;
            if (pin == null)
                return;

            var poi = this._tourViewModel.PointsOfInterest.Where(p => p.Position == pin.Position).FirstOrDefault();
                
            var textToDisplay = poi.Guide.Text;
            this.lblLocation.Text = pin.Label + ": "+textToDisplay;
            this.lblLocation.IsVisible = true;

            await Task.Delay(3000).ContinueWith((t) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.lblLocation.Text = "";
                    this.lblLocation.IsVisible = true;
                });
            });
        }
    }
}
