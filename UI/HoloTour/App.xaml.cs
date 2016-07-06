using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HoloTour
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new HoloTour.Pages.MainPage();
            //var sessionPage = new HoloTour.Pages.SessionDataPage();
            //var navPage = new NavigationPage(sessionPage); 

            //MainPage = new Pages.MasterDetailsTour();

            var toursPae = new Pages.ToursPage();
            MainPage = new NavigationPage(toursPae);
        }

        protected override void OnStart()
        {
            //new Xamarin.Forms.Pages.ListDataPage().StyleId = 
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
