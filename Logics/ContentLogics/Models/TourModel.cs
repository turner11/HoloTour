using Newtonsoft.Json.Linq;
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

        public ReadOnlyCollection<PointOfInterestModel> PointsOfInterest { get; }

        public TourModel(JObject json)
            :this(json["Name"].Value<string>(), json["PointsOfInterest"].Select(poiJson => new PointOfInterestModel(poiJson as JObject)).ToList())
        {
            //var name = json["Name"].Value<string>();
            //var poisJson = json["PointsOfInterest"];
            //var pois = poisJson.Select(poiJson => new PointOfInterestModel(poiJson)).ToList();
           
        }
        public TourModel(string name, IEnumerable<PointOfInterestModel> pointsOfInterest)
        {
            this.Name = name;
            pointsOfInterest = pointsOfInterest ?? new List<PointOfInterestModel>();
            this.PointsOfInterest = new ReadOnlyCollection<PointOfInterestModel>(pointsOfInterest.ToList());
        }

        

        public void Initialize()
        {
            foreach (var poi in this.PointsOfInterest)
            {
                poi.Initialize();
            }
        }

        public override string ToString()
        {
            return $"Tour: {this.Name}; {this.PointsOfInterest} Points of interest";
        }
    }
}
