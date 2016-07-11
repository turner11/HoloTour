using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoloTour.ViewModels
{
    public abstract class ViewModelBase
    {
        protected static ImageSource BytesToImage(byte[] imageBytes)
        {
           return  ImageSource.FromStream(() => new System.IO.MemoryStream(imageBytes));
        }
    }
}
