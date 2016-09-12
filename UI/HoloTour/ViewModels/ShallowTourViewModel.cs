﻿using HoloTour.Models;
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
    public class ShallowTourViewModel: ViewModelBase
    {
        protected TourModel _tour;

        public int Id { get { return this._tour?.Id ?? -1; } }
        public string Name { get { return $"{this._tour?.City.Title}, {this._tour?.Name}"; } }
        public ReadOnlyCollection<PointOfInterestViewModel> PointsOfInterest { get; }

     
        public ImageSource ImageAsImageSource
        {
            get
            {
                return ViewModelBase.BytesToImage(this._tour.ImageBytes); 

            }
        }
        //[UIHint("TourCaption")]
        [DataType(DataType.MultilineText)]
        public string Caption { get { return this._tour?.Caption; } }

        public ShallowTourViewModel(TourModel tour)
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
