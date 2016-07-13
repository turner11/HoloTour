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
        TourOverviewPage _tourOverviewpage;
        public TourPage(TourViewModel viewModel)
        {
            InitializeComponent();
            this._tourViewModel = viewModel;

            this._tourOverviewpage = new TourOverviewPage(this._tourViewModel);
            this._tourOverviewpage.PointOfInterest_Selected += TourOverviewpage_PointOfInterest_Selected;
            Children.Add(this._tourOverviewpage);
            var pois = this._tourViewModel.PointsOfInterest;

            
            foreach (var poi in pois)
            {
                var poiPage = new PointofInterestPage(poi);
                Children.Add(poiPage);
            }
            
        }

        private void TourOverviewpage_PointOfInterest_Selected(object sender, Common.EventArgs.IPointOfInterestArgs e)
        {
            var selectedPage = this.Children.OfType<PointofInterestPage>()
                .Where(p => p.PointOfInterestVM.Id == e.PointOfInterest.Id)
                .FirstOrDefault();
            if (selectedPage != null)
            {
                this.CurrentPage = selectedPage;
            }
        }
    }
}
