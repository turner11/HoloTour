using CoreLocation;
using MapKit;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HoloTour.Controls.MapWithRoute), typeof(HoloTour.iOS.CustomRenderes.MapWithRouteRenderer))]
namespace HoloTour.iOS.CustomRenderes
{
    public class MapWithRouteRenderer : MapRenderer
    {
        MKPolylineRenderer polylineRenderer;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                nativeMap.OverlayRenderer = null;
            }

            if (e.NewElement != null)
            {
                var formsMap = (Controls.MapWithRoute)e.NewElement;
                var nativeMap = Control as MKMapView;

                nativeMap.OverlayRenderer = GetOverlayRenderer;

                CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[formsMap.RouteCoordinates.Count];

                int index = 0;
                foreach (var position in formsMap.RouteCoordinates)
                {
                    coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
                    index++;
                }

                var routeOverlay = MKPolyline.FromCoordinates(coords);
                nativeMap.AddOverlay(routeOverlay);
            }
        }


        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlay)
        {
            if (polylineRenderer == null)
            {
                polylineRenderer = new MKPolylineRenderer(overlay as MKPolyline);
                polylineRenderer.FillColor = UIColor.Blue;
                polylineRenderer.StrokeColor = UIColor.Red;
                polylineRenderer.LineWidth = 3;
                polylineRenderer.Alpha = 0.4f;
            }
            return polylineRenderer;
        }
    }
}


