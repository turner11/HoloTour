using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HoloTour.ViewModels;
using System.Collections.ObjectModel;

namespace ContentManager.ViewModels
{
    
    public class EditableTourViewModel : HoloTour.ViewModels.TourViewModel
    {

        public BitmapImage BitmapSource { get; }

        private byte[] _imageBytesCache;
        public byte[] ImageBytes{get{ return this._imageBytesCache ?? this._tour.ImageBytes; }}
        
        string _imageBytesAsStringCache;
        public string ImageBytesAsString
        {
            get
            {
                this._imageBytesAsStringCache = this._imageBytesAsStringCache ??
                  Convert.ToBase64String(this.ImageBytes);
                return this._imageBytesAsStringCache;
            }
            set
            {
                this._imageBytesAsStringCache = null;
                this._imageBytesCache = Convert.FromBase64String(value);
            }
        }


        string _caption;
        public new string Caption
        {
            get{return _caption ?? base.Caption;}
            set {this._caption = value; }
        }

        string _name;
        public new string Name
        {
            get{return this._name ?? base.Name;}
            set { this._name = value; }
        }


        public EditableTourViewModel(HoloTour.ViewModels.ShallowTourViewModel other)
            : this((TourModel)other)
        {

        }
        public EditableTourViewModel(TourModel tour) : base(tour)
        {
            var bytes = this._tour.ImageBytes;

            var byteStream = new System.IO.MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            this.BitmapSource = image;// BitmapSource.Create(2, 2, 300, 300, PixelFormats.Indexed8, BitmapPalettes.Gray256, byteArrayIn, 2);


        }

    }
}
