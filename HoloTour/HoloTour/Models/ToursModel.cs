using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.Models
{
    class ToursModel
    {
        

        public static List<TourModel> GetTours()
        {
            return new List<TourModel>()
            {
                new TourModel() {Name ="Jerusalem"},
                new TourModel() {Name ="Dead Sea"},
                new TourModel() {Name ="New York"},
                new TourModel() {Name ="Paris"},
                new TourModel() {Name ="Prague"},
            };

        } 
    }
}
