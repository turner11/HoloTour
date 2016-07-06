using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using HoloTour.DataAcesss.Interfaces;

namespace HoloTour.DataAcesss
{
    class DataSimulator : DataCollector
    {
        public override List<JObject> GetTours()
        {
            Debug.Assert(false,"Implement!");
            //TODO: THe parsing should be done in logics level. This layer should return the JSON.
            //In order to do that, collect all pois in single Json + the name of tour.

            var JerusalemPointsOfInterestsJSON = GetJerusalemPointsOfInterest();
            return JerusalemPointsOfInterestsJSON.ToList();
            //var jPos = JerusalemPointsOfInterestsJSON.Select(jObj => new PointOfInterestModel( jObj.ToString().Trim())).ToList();

            //var simulatedLocations = new List<string>
            //{
            //    "Jerusalem",
            //    "Dead Sea" ,
            //    "New York" ,
            //    "Paris"    ,
            //    "Prague"   ,
            //};

            //var ret = new List<TourModel>();
            //foreach (var tourname in simulatedLocations)
            //{
            //    ret.Add(new TourModel( tourname,jPos));
            //}
            //return ret;
        }


        IEnumerable<JObject> GetJerusalemPointsOfInterest()
        {
            var JerusalemPointsOfInterests = new List<JObject>()
            {
                JsonFactory(position:new Position(35.228402,31.776663),imageBytes:null,id:1,title:"Tower of David" ),
                JsonFactory(position:new Position(35.225422,31.769718),imageBytes:null,id:2,title:"Menachem Begin Heritage Center"),
                JsonFactory(position:new Position(35.212321,31.786871), imageBytes:null,id:2,title:"Shuk Mahane Yehuda")
            };

            return JerusalemPointsOfInterests;

        }


        private static JObject JsonFactory(int id, string title, Position position, byte[] imageBytes = null)
        {

            imageBytes = imageBytes ?? new byte[] { 1, 2, 3 };

            var positionObjectaaa = new JObject(//"Position",
                            new JProperty("latitude", position.Latitude),
                            new JProperty("longitude", position.Longitude)
                            );

            var positionObject = new JProperty("Position", position.Longitude, position.Latitude);
            var imageObject = new JProperty("imageBytes", imageBytes);

            JObject obj = new JObject(
                new JProperty("Id", id),
                new JProperty("Title", title),
                positionObject,
                //new JArray(imageBytes)
                imageObject


                );


            return obj;//.ToString().Trim();

        }

        public override JObject GetPoiGuide(IPointOfInterest pointofInterest)
        {
            1.ToString();
            throw new NotImplementedException();
        }
    }
}
