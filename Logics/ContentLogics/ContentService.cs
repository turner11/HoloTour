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
            
            //var g = new Guide(pointofInterest, "TTTTTTTTTTTTTTTTTTTT")
            //{
            //    Audio = new byte[] { 1,1,1,1,1,1,1,1,1,1,1}
            //};
            //var v =JObject.FromObject(g);

            JObject guideJson = this._dataCollector.GetPoiGuide(pointofInterest);
            return new Guide( guideJson);

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
