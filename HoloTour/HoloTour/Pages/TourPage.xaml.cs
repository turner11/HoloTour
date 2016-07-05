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
        Models.TourModel _model { get; }
        public TourPage(Models.TourModel model)
        {
            InitializeComponent();
            this._model = model;

            //add all points of interest to route
            this.MapView.RouteCoordinates.AddRange(this._model.PointOfInterest.Select(poi=> poi.Position));
            

            this.lblLocation.IsVisible = false;
            this.Appearing += TourPage_Appearing;

            
        }

        private void TourPage_Appearing(object sender, EventArgs e)
        {
            if (this._model.PointOfInterest.Count == 0)
                return;
            var pins = this._model.PointOfInterest.Select(poi => new Pin()
                                                                    {
                                                                        Position = poi.Position,
                                                                        Label = poi.Title,
                                                                        Type = PinType.SearchResult
                                                                    }).ToArray();

            
            var mapLocatoion = this.MapView.RouteCoordinates.FirstOrDefault();
            var region = MapSpan.FromCenterAndRadius(mapLocatoion, Distance.FromKilometers(1));
            this.MapView.MoveToRegion(region);
            foreach (var pin in pins)
            {
                pin.Clicked += Pin_Clicked;
                this.MapView.Pins.Add(pin);
            }
        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {
            Pin pin = sender as Pin;
            if (pin == null)
                return;

            var poi = this._model.PointOfInterest.Where(p => p.Position == pin.Position).FirstOrDefault();
                
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
