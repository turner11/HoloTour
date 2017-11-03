using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoloTour.ViewModels;

namespace HoloTour.ViewModels
{
    public class EditablePointOfInterestViewModel: HoloTour.ViewModels.PointOfInterestViewModel
    {
        public EditablePointOfInterestViewModel():this(PointOfInterestViewModel.NullObject)
        {

        }

        public EditablePointOfInterestViewModel(PointOfInterestViewModel p):this(p.Model)
        {
        
        }

        public EditablePointOfInterestViewModel(PointOfInterestModel poi) :base(poi)
        {

        }
    }
}
