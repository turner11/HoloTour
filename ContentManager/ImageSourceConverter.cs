using HoloTour.Models;
using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ContentManager
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            bool isvalid = targetType == typeof(TourWpfViewModel);
            if (!isvalid)
            {
                throw new ArgumentException("The converter handles only TourWpfViewModel - TourViewModel conversions");
            }
            var vm = value as ShallowTourViewModel;
            var model =  (TourModel)vm;
            return new TourWpfViewModel(model);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            bool isvalid = targetType == typeof(TourViewModel);
            if (!isvalid)
            {
                throw new ArgumentException("The converter handles only TourWpfViewModel - TourViewModel conversions");
            }
            var vm = value as ShallowTourViewModel;
            var model =  (TourModel)vm;
            return new TourViewModel(model);
        }
    }
}
