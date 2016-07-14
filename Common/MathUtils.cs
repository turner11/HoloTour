using CoreLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace HoloTour.Common
{
    public static class MathUtils
    {
        public static double GetDistance_Meters(Position p1, Position p2)
        {
            return GetDistance_Meters(p1.Latitude, p1.Longitude, p2.Latitude, p2.Longitude);
        }
        public static double GetDistance_Meters(double lat1, double long1, double lat2, double long2)
        {

            double theta = long1 - long2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            //to KM
            dist = dist * 1.609344;
            //if (unit == 'K')
            //{
            //    dist = dist * 1.609344;
            //}
            //else if (unit == 'N')
            //{
            //    dist = dist * 0.8684;
            //}
            return (dist *1000);
            //return 1000;
            //CLLocation pointA = new CLLocation(lat1, long1);
            //CLLocation pointB = new CLLocation(lat2, long2);
            //var distanceToB = pointB.DistanceFrom(pointA);
            //return distanceToB;
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
