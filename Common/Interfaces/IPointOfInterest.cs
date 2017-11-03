using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.Common.Interfaces
{
    public interface IPointOfInterest: IIdAndTitleObject
    {
        Xamarin.Forms.Maps.Position Position { get; }
        byte[] ImageBytes { get; }
    }
}
