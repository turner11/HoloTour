using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.ViewModels
{
    public class GuideViewModel:ViewModelBase<Guide>
    {
      

        private readonly Guide _guide;
        [DataType(DataType.MultilineText)]
        public string Text { get { return this._guide.Text; } }

        public GuideViewModel(Guide guide):base(guide)
        {
            this._guide = guide;
        }
    }
}
