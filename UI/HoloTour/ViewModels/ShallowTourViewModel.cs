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
    public class ShallowTourViewModel: ViewModelBase
    {
        protected TourModel _tour;
        public string Name { get { return $"{this._tour.City.Title}, {this._tour.Name}"; } }
        public ReadOnlyCollection<PointOfInterestViewModel> PointsOfInterest { get; }

     
        public ImageSource ImageAsImageSource
        {
            get
            {
                return ViewModelBase.BytesToImage(this._tour.ImageBytes); 

            }
        }
        public string Caption { get { return this._tour.Caption; } }

        public ShallowTourViewModel(TourModel tour)
        {
            this._tour = tour;
            var pois = this._tour.PointsOfInterest.Select(p=> new PointOfInterestViewModel(p)).ToList();
            this.PointsOfInterest = new ReadOnlyCollection<PointOfInterestViewModel>(pois);

        }

        public static explicit operator TourModel(ShallowTourViewModel shVM)
        {
            return shVM._tour;
        }


    }
}
