using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoloTour.ViewModels
{
    public class PointOfInterestViewModel: ViewModelBase, Common.Interfaces.IPointOfInterest
    {
        PointOfInterestModel _pointOfInterestModel { get; }

        public int Id { get { return this._pointOfInterestModel.Id; } }
        public string Title { get { return this._pointOfInterestModel.Title; } }
        public Xamarin.Forms.Maps.Position Position { get { return this._pointOfInterestModel.Position; } }

        public ImageSource ImageAsImageSource
        {
            get
            {
                return ViewModelBase.BytesToImage(this.ImageBytes);

            }
        }
        public byte[] ImageBytes { get { return this._pointOfInterestModel.ImageBytes; } }

        GuideViewModel _guide;
        public GuideViewModel Guide
        {
            get
            {
                var shouldGetnewGuide = this._guide == null && this._pointOfInterestModel.Guide != null;
                if (shouldGetnewGuide)
                {
                    this._guide = new GuideViewModel(this._pointOfInterestModel.Guide);
                }
                return this._guide;
            }
        }

    

        public PointOfInterestViewModel(PointOfInterestModel poi)
        {
            this._pointOfInterestModel = poi;
            
        }
    }
}
