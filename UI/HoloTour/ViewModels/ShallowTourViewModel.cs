using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoloTour.ViewModels
{
    public class ShallowTourViewModel: ViewModelBase<TourModel>
    {
       
        protected TourModel _tour;


        public virtual int Id { get { return this._tour.Id; } }
        public virtual string Name { get { return $"{this._tour.City.Title}, {this._tour.Name}"; } }
        public virtual ReadOnlyCollection<PointOfInterestViewModel> PointsOfInterest { get; protected set; }



        public virtual ImageSource ImageAsImageSource
        {
            get
            {
                return ViewModelBase<TourModel>.BytesToImage(this._tour.ImageBytes); 

            }
        }
        //[UIHint("TourCaption")]
        [DataType(DataType.MultilineText)]

        public virtual string Caption { get { return this._tour.Caption; } }


        public ShallowTourViewModel(TourModel tour) : base(tour)

        {
            this._tour = tour;
            var pois = this._tour?.PointsOfInterest.Select(p=> new PointOfInterestViewModel(p)).ToList();
            this.PointsOfInterest = 
                new ReadOnlyCollection<PointOfInterestViewModel>(pois ?? new List<PointOfInterestViewModel>());

        }

        public static explicit operator TourModel(ShallowTourViewModel shVM)
        {
            return shVM._tour;
        }

       


    }
}
