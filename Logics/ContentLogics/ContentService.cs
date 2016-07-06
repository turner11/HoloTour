using HoloTour.DataAcesss;
using HoloTour.Common.Interfaces;
using HoloTour.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoloTour.ContentLogics
{
    public class ContentService
    {
        readonly IDataCollector _dataCollector;

        private ContentService(IDataCollector dataCollector)
        {
            this._dataCollector = DataCollector.Factory();
        }

        public static ContentService Factory()
        {
            IDataCollector dataCollector = DataCollector.Factory();
            return new ContentService(dataCollector);
        }


        public Guide GetPoiGuide(IPointOfInterest pointofInterest)
        {
           var str = @"
The Tower of David
​The Tower of David Museum in Jerusalem is one site that no visitor should miss. This amazing museum offers you the opportunity to experience captivating exhibits that will deepen your understanding of the Holy City. But, even more, its very stones are part of this city’s living history.";


           var a=  JObject.FromObject(
                new Guide(pointofInterest, str)
                );
           
            JObject guideJson = this._dataCollector.GetPoiGuide(pointofInterest);

            var jObject = this._dataCollector.GetPoiGuide(pointofInterest);
            return new Guide( jObject);

        }

        public IEnumerable<HoloTour.Models.TourModel> GetTours()
        {
            var ret = new List<TourModel>();
            var toursJsons = this._dataCollector.GetTours();
            foreach (var tJson in toursJsons)
            {
                
                //var name = tJson["Name"].Value<string>();
                //var poisJson = tJson["PointsOfInterest"];
                //var pois = poisJson.Select(json => new PointOfInterestModel(json as JObject)).ToList();
                var tour = new TourModel(tJson);
                ret.Add(tour);
            }

            return ret;
        }
    }
}
