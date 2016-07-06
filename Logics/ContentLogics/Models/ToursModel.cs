#define SIMULATOR
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.Models
{
    class ToursModel
    {

        readonly ContentLogics.ContentService _contentService;
        public readonly ReadOnlyCollection<TourModel> Tours;

        public ToursModel()
        {
            this._contentService = ContentLogics.ContentService.Factory();
            
            this.Tours = new ReadOnlyCollection<TourModel>(this._contentService.GetTours().ToList());
        }

        public override string ToString()
        {
            return $"Tours model: {this.Tours.Count} Tours";
        }

    }
}
