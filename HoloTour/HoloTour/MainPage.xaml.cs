using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HoloTour
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
            this.DelayedZoomIn();

           
            
        }

        private async void DelayedZoomIn()
        {
            
            await Task.Run(async () =>
            {
                await Task.Delay(30000);
                var region = MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(0.3));
                this.MyMap.MoveToRegion(region);
            }).ConfigureAwait(false);
        }
    }
}
