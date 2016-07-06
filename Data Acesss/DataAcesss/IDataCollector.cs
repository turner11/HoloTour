using HoloTour.Common.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace HoloTour.DataAcesss
{
    public interface IDataCollector
    {
        List<JObject> GetTours();
        JObject GetPoiGuide(IPointOfInterest pointofInterest);
    }
}