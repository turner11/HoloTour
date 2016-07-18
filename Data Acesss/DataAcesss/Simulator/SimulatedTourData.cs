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
        abstract partial class SimulatedTourData
        {
            static List<SimulatedTourData> _tourDatas;
            static List<SimulatedTourData> TourDatas
            {
                get {
                    if (_tourDatas == null)
                    {
                        _tourDatas = new List<SimulatedTourData>()
                        {
                            new GoshrimTourData(),
                            new JerusalemTourData(),
                            new DeadSeaTourData(),
                            new NyTour(),
                            new ParisTourData(),
                            new PragueTourData(),
                            new EfratTourData(),
                        };
                    }

                    return _tourDatas;
                }
            }

            public string Name { get; }
            public byte[] ImageBytes { get; }
            public JObject[] PointsOfInterest { get; }
            public string City { get; }
            public string Caption { get; }

            public SimulatedTourData(string name, string imageBytes, string city, string caption)
            {
                    this.Name = name;
                    this.ImageBytes = Convert.FromBase64String(imageBytes);
                    this.PointsOfInterest = this.GetPointOfInterest();
                    this.City =city;
                    this.Caption = caption;
            }

            internal static List<PointOfInterestSimulatedData> GetAllpoiSimulatedData()
            {
                var ret = TourDatas.SelectMany(t => t.GetpoiSimulatedData()).ToList();
                return ret;

            }
            internal abstract List<PointOfInterestSimulatedData> GetpoiSimulatedData();



            internal static List<JObject> GetTours()
            {
                var ret = new List<JObject>();
                foreach (var tour in TourDatas)
                {
                    var Obj = new
                    {
                        Name = tour.Name,
                        ImageBytes = tour.ImageBytes,
                        PointsOfInterest = tour.PointsOfInterest,
                        City = tour.City,
                        Caption = tour.Caption,
                    };
                    var jObj = JObject.FromObject(Obj);
                    ret.Add(jObj);
                }


                return ret;
            }
            static int poiIdCounter;
            private JObject[] GetPointOfInterest()
            {
                var pois = this.GetpoiSimulatedData();

                var ret = new JObject[pois.Count];
                for (int i = 0; i < pois.Count; i++)                
                {
                    var poi = pois[i];
                    var jsonPoi = JsonPoiFactory(poi);
                    ret[i] = jsonPoi;
                }
               
                return ret;
            }

          


            private JObject JsonPoiFactory(PointOfInterestSimulatedData poiData)
            {
                int id = ++poiIdCounter;
                string title = poiData.Title;

               


                //Position position, byte[] imageBytes = null


                var positionObject = new JProperty("Position", poiData.Position.Longitude, poiData.Position.Latitude);
                var imageObject = new JProperty("imageBytes", poiData.ImageBytes);

                JObject obj = new JObject(
                    new JProperty("Id", id),
                    new JProperty("Title", title),
                    positionObject,
                    imageObject
                    );


                return obj;//.ToString().Trim();

            }
        }
    }
}
