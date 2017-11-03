using HoloTour.ContentLogics;
using HoloTour.Common.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.Models
{
    public class PointOfInterestModel: ContentLogics.Models.ModelBase, IPointOfInterest
    {
        readonly ContentService _contentService;
        /// <summary>
        /// Gets the ID of this instance.
        /// </summary>
        /// <value>
        /// The ID of this instance.
        /// </value>
        public int Id { get; }
        /// <summary>
        /// Gets the Title of this instance.
        /// </summary>
        /// <value>
        /// The ID of Title instance.
        /// </value>
        public string Title { get; }
        public Xamarin.Forms.Maps.Position Position { get; }

        public byte[] ImageBytes { get; }
        public Guide Guide { get; private set; }

        public PointOfInterestModel(JObject jsonObject)
            :this(jsonObject.Value<int>("Id"), jsonObject.Value<string>("Title"), 
                 jsonObject.GetValue("Position").Cast<JValue>().Where(obj => obj.Value is double).Select(obj => (double)obj.Value).ToArray(),
                jsonObject.GetValue("imageBytes").Value<string>())
        {

           
            /*
             * Cannot deserialize the current JSON array (e.g. [1,2,3]) into type 'Xamarin.Forms.Maps.Position' 
             * because the type requires a JSON object (e.g. {"name":"value"}) to deserialize correctly.
             * To fix this error either change the JSON to a JSON object (e.g. {"name":"value"}) 
             * or change the deserialized type to an array or a type that implements a collection interface 
             * (e.g. ICollection, IList) like List<T> that can be deserialized from a JSON array. 
             * JsonArrayAttribute can also be added to the type to force it to deserialize from a JSON array.
Path 'Position', line 4, position 15.
             */

            //var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
            var id = jsonObject.Value<int>("Id");
            var title = jsonObject.Value<string>("Title");

            var posArray = jsonObject.GetValue("Position").ToArray();
            var coordinates = posArray.Cast<JValue>().Where(obj => obj.Value is double).Select(obj => (double)obj.Value).ToArray();
         
        }

        public PointOfInterestModel(int id, string title, double[] coordinates, string base64String)
            :this(id,title,coordinates,Convert.FromBase64String(base64String))
        {

        }
        public PointOfInterestModel(int id, string title, double[] coordinates, byte[] imageBytes)
        {
            this._contentService = ContentService.Factory();
            this.Id = id;
            this.Title = title;

            Debug.Assert(coordinates.Length == 2, "Got wrong number of coordinates");


            var latitude = coordinates[0];
            var longitude = coordinates[1];
            this.Position = new Xamarin.Forms.Maps.Position(latitude, longitude);

            //TODO: add image...
            this.ImageBytes = imageBytes ?? new byte[0];
        }

        internal void Initialize()
        {
            var guide= this._contentService.GetPoiGuide(this);
            this.Guide = guide;
           
        }

        public override string ToString()
        {
            return $"Point of interest: {this.Title}; [{this.Position}]";
        }
    }
}
