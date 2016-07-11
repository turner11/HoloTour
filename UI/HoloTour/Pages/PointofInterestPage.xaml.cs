using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HoloTour.Pages
{
    public partial class PointofInterestPage : ContentPage
    {
        private readonly PointOfInterestViewModel _pointOfInterestVM;

        public PointofInterestPage(PointOfInterestViewModel poi)
        {
            InitializeComponent();
            this._pointOfInterestVM = poi;

            Content = new Label
            {
                Text = this._pointOfInterestVM.Guide.Text
        };
            //var a = _pointOfInterestVM.Guide.Text;
        }
    }
}
