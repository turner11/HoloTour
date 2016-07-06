using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using HoloTour.Common.Interfaces;

namespace HoloTour.DataAcesss
{
    class DataSimulator : DataCollector
    {
        public override List<JObject> GetTours()
        {
            
            var JerusalemPointsOfInterestsJSON = GetJerusalemPointsOfInterest().ToArray();
            
            var simulatedLocations = new List<string>
            {
                "Jerusalem",
                "Dead Sea" ,
                "New York" ,
                "Paris"    ,
                "Prague"   ,
            };

            var ret = new List<JObject>();

            foreach (var location in simulatedLocations)
            {
                var anObj = new { Name = location, PointsOfInterest = JerusalemPointsOfInterestsJSON };
                var json = JObject.FromObject(anObj);
                ret.Add(json);
            }
            
            return ret;
            
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
            var jsonStr =
@"{
  'PointOfInterestId': 1,
  'PointOfInterestTitle': 'Tower of David',
  'Audio': {},
  'ImagesByLocation': {
    'Key': {
      'Latitude': 0.0,
      'Longitude': 0.0
    },
    'Value': null
  },
  'ImagesByLocationOnAudio': {
    'Key': '00:00:00',
    'Value': null
  },
  'Text': '\r\nThe Tower of David\r\n?The Tower of David Museum in Jerusalem is one site that no visitor should miss. This amazing museum offers you the opportunity to experience captivating exhibits that will deepen your understanding of the Holy City. But, even more, its very stones are part of this city’s living history.'
}".Replace("'","\"");
            return JObject.Parse(jsonStr);
        }
    }
}
