using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.ViewModels
{
    class GuideViewModel:ViewModelBase
    {
        private readonly Guide _guide;
        public string Text { get { return this._guide.Text; } }

        public GuideViewModel(Guide guide)
        {
            this._guide = guide;
        }
    }
}
