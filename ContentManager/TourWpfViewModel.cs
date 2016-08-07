using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ContentManager.ViewModels
{
    
    public class TourWpfViewModel : HoloTour.ViewModels.TourViewModel
    {

        public BitmapImage BitmapSource { get; }

        public byte[] ImageBytes{get{ return this._tour.ImageBytes; }}

        string _imageBytesAsStringCache;
        public string ImageBytesAsString
        {
            get {
                this._imageBytesAsStringCache = this._imageBytesAsStringCache ??
                  Convert.ToBase64String(this.ImageBytes);
                return this._imageBytesAsStringCache;
                    }
        }



        public TourWpfViewModel(HoloTour.ViewModels.ShallowTourViewModel other)
            : this((TourModel)other)
        {

        }
        public TourWpfViewModel(TourModel tour) : base(tour)
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
