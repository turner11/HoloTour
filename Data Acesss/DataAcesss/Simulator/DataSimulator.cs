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
    partial class DataSimulator : DataCollector
    {
        readonly List<PointOfInterestSimulatedData> _poiSimulatedData;
        public DataSimulator()
        {
            this._poiSimulatedData = SimulatedTourData.GetAllpoiSimulatedData();
        }



        public override List<JObject> GetTours()
        {
            return SimulatedTourData.GetTours();
           
            
        }

      

        public override JObject GetPoiGuide(IPointOfInterest pointofInterest)
        {
            
            var jsonStrTemplate =
@"{
  'PointOfInterestId': @id,
  'PointOfInterestTitle': '@title',
  'Audio': 'AQEBAQEBAQEBAQE=',
  'ImageBytes': '@imageBytes',
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
  'Text': '@text'
}".Replace("'","\"");

            var dataHolder = this._poiSimulatedData.FirstOrDefault(d => d.Title == pointofInterest.Title);
            dataHolder = dataHolder ?? PointOfInterestSimulatedData.NullObject;
            var jsonStr = jsonStrTemplate.Replace("@id", pointofInterest.Id.ToString())
                                         .Replace("@title", dataHolder.Title)
                                         .Replace("@text", dataHolder.Text)
                                         .Replace("@imageBytes", dataHolder.ImageBytes);

            return JObject.Parse(jsonStr);
        }
    }
}
