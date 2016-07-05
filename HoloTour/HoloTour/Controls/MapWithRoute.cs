using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace HoloTour.Controls
{
    
    public class  MapWithRoute : Map
    {
        public List<Position> RouteCoordinates { get;  }

        public MapWithRoute()
        {
            RouteCoordinates = new List<Position>();
        }
    }

}
