using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.ViewModels
{
    public class TourViewModel:ShallowTourViewModel
    {
        
        public TourViewModel(TourModel tour) :base(tour)
        {
            this._tour.Initialize();
        }

      
        
    }
}
