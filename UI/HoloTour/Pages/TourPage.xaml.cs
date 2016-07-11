using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HoloTour.Pages
{
    public partial class TourPage : CarouselPage
    {
        TourViewModel _tourViewModel { get; }
        public TourPage(TourViewModel viewModel)
        {
            InitializeComponent();
            this._tourViewModel = viewModel;

            Children.Add(new TourOverviewPage(this._tourViewModel));
            var pois = this._tourViewModel.PointsOfInterest;

            
            foreach (var poi in pois)
            {
                var poiPage = new PointofInterestPage(poi);
                Children.Add(poiPage);
            }
            
        }

    }
}
