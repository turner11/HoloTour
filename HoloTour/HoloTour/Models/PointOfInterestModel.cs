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
    public class PointOfInterestModel
    {
        
        public int Id { get; }
        public string Title { get; }
        public Xamarin.Forms.Maps.Position Position { get; }

        public Xamarin.Forms.Image Image { get; }
        public Guide Guide { get; }

        public PointOfInterestModel(string jsonString)
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

            var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
            this.Id = jsonObject.Value<int>("Id");
            this.Title = jsonObject.Value<string>("Title");
            
            var posArray = jsonObject.GetValue("Position").ToArray();
            var coordinates = posArray.Cast<JValue>().Where(obj => obj.Value is double).Select(obj => (double)obj.Value).ToArray();
            Debug.Assert(coordinates.Length == 2, "Gpt wrong number of coordinates");


            var latitude = coordinates[0];
            var longitude = coordinates[1];
            this.Position = new Xamarin.Forms.Maps.Position(latitude,longitude);

            var bObjs = jsonObject.GetValue("imageBytes").ToArray();
            var imageBytes = bObjs.Cast<JValue>().Where(obj => obj.Value is byte).Select(obj => (byte)obj.Value).ToArray();

            this.Guide = new Guide();
        }
    }
}
