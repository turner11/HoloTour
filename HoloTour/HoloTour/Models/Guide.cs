using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace HoloTour.Models
{
    public class Guide
    {
        /// <summary>
        /// Gets the audio guide.
        /// </summary>
        /// <value>
        /// The audio guide.
        /// </value>
        public object Audio { get; } = new object();//TODO:Implemet...

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
        public string Text { get { return "This is a lovely place!"; } }


        public Guide(string json)
        {

        }
    }
}