using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using HoloTour.Controls;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
[assembly: ExportRenderer(typeof(MapWithRoute), typeof(HoloTour.Droid.CustomRenderes.MapWithRouteRenderer))]
namespace HoloTour.Droid.CustomRenderes
{
    public class MapWithRouteRenderer : MapRenderer, Android.Gms.Maps.IOnMapReadyCallback
    {
        Android.Gms.Maps.GoogleMap map;
        List<Xamarin.Forms.Maps.Position> routeCoordinates;

      

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)       
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (MapWithRoute)e.NewElement;
                routeCoordinates = formsMap.RouteCoordinates;

                ((Android.Gms.Maps.MapView)Control).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;

            var polylineOptions = new PolylineOptions();
            polylineOptions.InvokeColor(0x66FF0000);

            foreach (var position in routeCoordinates)
            {
                polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
            }

            map.AddPolyline(polylineOptions);
        }
        //...
    }
}
