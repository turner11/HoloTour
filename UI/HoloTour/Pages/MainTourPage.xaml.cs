using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HoloTour.Pages
{
    [Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
    public partial class MainTourPage : MasterDetailPage
    {
        TourOverviewPage masterPage;
        public MainTourPage(TourViewModel viewModel)
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("@@@@@@@@@@@@ WE ARE HERE! @@@@@@@@@@@@@@@@");
            
            this.masterPage = new TourOverviewPage(viewModel);
            this.masterPage.Title = this.masterPage.Title ?? viewModel.Caption;

            var pois = viewModel.PointsOfInterest;
            var details = new PointofInterestPage(pois.FirstOrDefault());

            this.MasterBehavior = MasterBehavior.SplitOnLandscape;
            Master = masterPage;
            Detail = new NavigationPage(details);

            this.masterPage.ListPointofInterest.ItemSelected += Master_ListPointofInterest_ItemSelected;
        }

     
        void Master_ListPointofInterest_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var poi = e.SelectedItem as PointOfInterestViewModel;
            if (poi != null)
            {
                this.Detail = new NavigationPage(new PointofInterestPage(poi));//new NavigationPage((Page)Activator.CreateInstance(poi.TargetType));
                this.masterPage.ListPointofInterest.SelectedItem = null;
                //this.IsPresented = false;
            }
        }
    }
}
