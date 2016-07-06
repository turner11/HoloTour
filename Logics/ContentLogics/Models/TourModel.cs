using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoloTour.Models
{
    public class TourModel
    {
        public string Name { get;  }
        public DateTime Created { get { return DateTime.Today; } }

        public Color Color { get { return Color.Purple; } }

        public ReadOnlyCollection<PointOfInterestModel> PointOfInterest { get; }
        public TourModel(string name, IEnumerable<PointOfInterestModel> pointsOfInterest)
        {
            this.Name = name;
            pointsOfInterest = pointsOfInterest ?? new List<PointOfInterestModel>();
            this.PointOfInterest = new ReadOnlyCollection<PointOfInterestModel>(pointsOfInterest.ToList());
        }

        

        public void Initialize()
        {
            foreach (var poi in this.PointOfInterest)
            {
                poi.Initialize();
            }
        }
    }
}
