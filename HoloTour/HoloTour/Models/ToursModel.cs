#define SIMULATOR
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
#if SIMULATOR
            return ToursModelSimulator.GetTours();
#else
             return new List<TourModel>()
            {
                
            };
#endif



        }
    }
}
