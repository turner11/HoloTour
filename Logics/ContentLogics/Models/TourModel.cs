using HoloTour.ContentLogics.Models;
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
        public byte[] ImageBytes { get; }

        public ImageSource ImageAsImageSource
        {
            get
            {
                return ImageSource.FromStream(() => new System.IO.MemoryStream(this.ImageBytes));

            }
        }
        public DateTime Created { get { return DateTime.Today; } }

        public Color Color { get { return Color.Purple; } }

        public ReadOnlyCollection<PointOfInterestModel> PointsOfInterest { get; }

        public City City { get; }
        public string Caption { get; }

        public TourModel(JObject json)
            :this(json["Name"].Value<string>(), 
                 json["ImageBytes"].Value<byte[]>(),
                  json["PointsOfInterest"].Select(poiJson => new PointOfInterestModel(poiJson as JObject)).ToList(),
                  json["City"].Value<string>(),
                  json["Caption"].Value<string>())
        {
           
           
        }
        public TourModel(string name,
            byte[] imageByte, 
            IEnumerable<PointOfInterestModel> pointsOfInterest,
            string city, 
            string caption)
        {
            this.Name = name;
            this.ImageBytes = imageByte;
            pointsOfInterest = pointsOfInterest ?? new List<PointOfInterestModel>();
            this.PointsOfInterest = new ReadOnlyCollection<PointOfInterestModel>(pointsOfInterest.ToList());
            this.City = new City(-1,city,0);
            this.Caption = caption;
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
