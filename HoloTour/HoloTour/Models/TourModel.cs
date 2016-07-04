using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoloTour.Models
{
    class TourModel
    {
        public string Name { get; internal set; }
        public DateTime Created { get { return DateTime.Today; } }

        public Color Color { get { return Color.Purple; } }

        public ReadOnlyCollection<PointOfInterestModel> PointOfInterest { get; }
        public TourModel(IEnumerable<PointOfInterestModel> pointsOfInterest)
        {
            pointsOfInterest = pointsOfInterest ?? new List<PointOfInterestModel>();
            this.PointOfInterest = new ReadOnlyCollection<PointOfInterestModel>(pointsOfInterest.ToList());
        }
    }
}
