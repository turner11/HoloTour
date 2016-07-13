using CoreLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.Common
{
    public static class MathUtils
    {
        public static double GetDistance_Meters(double lat1, double long1, double lat2, double long2)
        {
            return 1000;
            //CLLocation pointA = new CLLocation(lat1, long1);
            //CLLocation pointB = new CLLocation(lat2, long2);
            //var distanceToB = pointB.DistanceFrom(pointA);
            //return distanceToB;
        }
    }
}
