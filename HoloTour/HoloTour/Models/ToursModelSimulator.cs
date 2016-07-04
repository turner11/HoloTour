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
                new TourModel(JerusalemPointsOfInterests) {Name ="Dead Sea"},
                new TourModel(JerusalemPointsOfInterests) {Name ="New York"},
                new TourModel(JerusalemPointsOfInterests) {Name ="Paris"},
                new TourModel(JerusalemPointsOfInterests) {Name ="Prague"},
            };

        }


        static IEnumerable<PointOfInterestModel> GetJerusalemPointsOfInterest()
        {
            var JerusalemPointsOfInterests = new List<PointOfInterestModel>()
            {
                new PointOfInterestModel(JsonFactory(position:new Position(35.228402,31.776663),imageBytes:null,id:1,title:"Tower of David" )),
                new PointOfInterestModel(JsonFactory(position:new Position(35.225422,31.769718),imageBytes:null,id:2,title:"Menachem Begin Heritage Center")),
                new PointOfInterestModel(JsonFactory(position:new Position(35.212321,31.786871), imageBytes:null,id:2,title:"Shuk Mahane Yehuda"))
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



