using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.Common.EventArgs
{
    using Interfaces;
    using EventArgs = System.EventArgs;
    public class IPointOfInterestArgs:EventArgs
    {
        public IPointOfInterest PointOfInterest { get; }
        public IPointOfInterestArgs(IPointOfInterest pointOfInterest)
        {
            this.PointOfInterest = pointOfInterest;
        }
    }
}
