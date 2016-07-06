using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoloTour.DataAcesss.Interfaces;

namespace HoloTour.DataAcesss
{
    public abstract class DataCollector : IDataCollector
    {
        public static IDataCollector Factory()
        {
            return new DataSimulator();
        }

        public abstract JObject GetPoiGuide(IPointOfInterest pointofInterest);

        public abstract List<JObject> GetTours();

       
    }
}
