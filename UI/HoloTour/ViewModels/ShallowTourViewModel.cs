using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoloTour.ViewModels
{
    public class ShallowTourViewModel
    {
        protected TourModel _tour;
        public string Name { get { return $"{this._tour.City.Title}, {this._tour.Name}"; } }
        public ReadOnlyCollection<PointOfInterestModel> PointsOfInterest { get { return this._tour.PointsOfInterest; } }

     
        public ImageSource ImageAsImageSource
        {
            get
            {
                return ImageSource.FromStream(() => new System.IO.MemoryStream(this._tour.ImageBytes));

            }
        }
        public string Caption { get { return this._tour.Caption; } }

        public ShallowTourViewModel(TourModel tour)
        {
            this._tour = tour;

        }

        public static explicit operator TourModel(ShallowTourViewModel shVM)
        {
            return shVM._tour;
        }


    }
}
