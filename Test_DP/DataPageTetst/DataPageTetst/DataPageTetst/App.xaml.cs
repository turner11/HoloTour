using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DataPageTetst
{
    public partial class App : Application
    {
        public App()
        {
            // The root page of your application
            var pl = new DataPageTetst.PlacesPage();
            MainPage = new NavigationPage(pl);
        }
    }
}
