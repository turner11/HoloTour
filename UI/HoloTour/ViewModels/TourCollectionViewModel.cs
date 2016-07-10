using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.ViewModels
{
    class TourCollectionViewModel
    {
        ToursModel _toursModel;

        public ReadOnlyCollection<ShallowTourViewModel> Tours { get; }

        public TourCollectionViewModel(ToursModel toursModel)
        {

            this._toursModel = toursModel;
            var tours = this._toursModel.Tours.Select(t => new ShallowTourViewModel(t)).ToList();
            this.Tours = new ReadOnlyCollection<ShallowTourViewModel>(tours);

        }
    }


   

}
