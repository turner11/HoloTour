using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace HoloTour.Models
{
    class ToursModelSimulator
    {
        

        public static List<TourModel> GetTours()
        {
            var JerusalemPointsOfInterests = GetJerusalemPointsOfInterest();


            return new List<TourModel>()
            {
                new TourModel(JerusalemPointsOfInterests) {Name ="Jerusalem"},
                new TourModel(null) {Name ="Dead Sea"},
                new TourModel(null) {Name ="New York"},
                new TourModel(null) {Name ="Paris"},
                new TourModel(null) {Name ="Prague"},
            };

        }


        static IEnumerable<PointOfInterestModel> GetJerusalemPointsOfInterest()
        {
            var JerusalemPointsOfInterests = new List<PointOfInterestModel>()
            {
                new PointOfInterestModel(JsonFactory(id:1,title:"Tower of David",position:new Position(31.776663, 35.228402),imageBytes:null)),
                new PointOfInterestModel(JsonFactory(id:2,title:"Menachem Begin Heritage Center",position:new Position(31.769718, 35.225422),imageBytes:null)),
                new PointOfInterestModel(JsonFactory(id:2,title:"Shuk Mahane Yehuda",position:new Position(31.786871, 35.212321),imageBytes:null))
            };

            return JerusalemPointsOfInterests;

        }


        private static string JsonFactory(int id, string title,Position  position,byte[] imageBytes = null)
        {

            imageBytes = imageBytes ?? new byte[] { 1, 2, 3 };
        
            var positionObjectaaa = new JObject(//"Position",
                            new JProperty("latitude", position.Latitude),
                            new JProperty("longitude", position.Longitude)
                            );

             var positionObject = new JProperty("Position",position.Longitude,position.Latitude);
            var imageObject = new JProperty("imageBytes", imageBytes);

            JObject obj = new JObject(
                new JProperty("Id",id),
                new JProperty("Title",title),
                positionObject,
                //new JArray(imageBytes)
                imageObject


                );
          

            return obj.ToString().Trim();

        }
    }
}



