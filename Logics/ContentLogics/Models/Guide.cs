using HoloTour.Common.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace HoloTour.Models
{
    public class Guide: ContentLogics.Models.ModelBase
    {
        public int PointOfInterestId { get; }
        public string PointOfInterestTitle { get; }
        /// <summary>
        /// Gets the audio guide.
        /// </summary>
        /// <value>
        /// The audio guide.
        /// </value>
        public byte[] Audio { get; set; } = new byte[0];//TODO:Implemet...

        /// <summary>
        /// Gets the images associated toth is guide (key:location).
        /// </summary>
        /// <value>
        /// images associated toth is guide 
        /// </value>
        public KeyValuePair<Position,Xamarin.Forms.Image[]> ImagesByLocation { get; }

        /// <summary>
        /// Gets the images associated toth is guide (key: Time span = location on sound track).
        /// </summary>
        /// <value>
        /// images associated toth is guide 
        /// </value>
        public KeyValuePair<TimeSpan, Xamarin.Forms.Image[]> ImagesByLocationOnAudio{ get; }//TODO:Once inplemented, give more descriptive name
        public string Text { get ; }


        
        public Guide(JObject json):
            this(json[nameof(PointOfInterestId)].Value<int>(),
                json[nameof(PointOfInterestTitle)].Value<string>(),
                json[nameof(Text)].Value<string>())
        {

        }

        public Guide(IPointOfInterest pointOfInterest, string text):this(pointOfInterest.Id,pointOfInterest.Title, text)
        {
          
        }
        public Guide(int pointOfInterestId, string pointOfInterestTitle, string text)
        {
            this.PointOfInterestId = pointOfInterestId;
            this.PointOfInterestTitle = pointOfInterestTitle;
            this.Text = text;
        }

        public override string ToString()
        {
            return $"Guide of {this.PointOfInterestTitle}";
        }
    }
}