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

            
            var firstPin = pins.First();
            var region = MapSpan.FromCenterAndRadius(firstPin.Position, Distance.FromKilometers(0.5));
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

            this.lblLocation.Text = pin.Label;
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
