using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoloTour.ViewModels
{
    public class PointOfInterestViewModel: ViewModelBase<PointOfInterestModel>, Common.Interfaces.IPointOfInterest
    {

        public static readonly PointOfInterestViewModel NullObject = new PointOfInterestViewModel(new PointOfInterestModel(-1,"",new double[] {0,0},null as byte[]));
        PointOfInterestModel _pointOfInterestModel { get; }

        public virtual int Id { get { return this._pointOfInterestModel.Id; } }
        public virtual string Title { get { return this._pointOfInterestModel.Title; } }
        public virtual Xamarin.Forms.Maps.Position Position { get { return this._pointOfInterestModel.Position; } }

        public virtual ImageSource ImageAsImageSource
        {
            get
            {
                return ViewModelBase<PointOfInterestModel>.BytesToImage(this.ImageBytes);

            }
        }
        public virtual byte[] ImageBytes { get { return this._pointOfInterestModel.ImageBytes; } }

        GuideViewModel _guide;
        public virtual GuideViewModel Guide
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

    

        public PointOfInterestViewModel(PointOfInterestModel poi) : base(poi)

        {
            this._pointOfInterestModel = poi;
            
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        
    }
}
