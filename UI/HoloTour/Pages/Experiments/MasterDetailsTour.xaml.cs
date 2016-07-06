using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Pages;

namespace HoloTour.Pages
{
    public partial class MasterDetailsTour : MasterDetailPage
    {

        ToursMaster _main;

        public MasterDetailsTour()
        {

           
            InitializeComponent();
            this._main = new ToursMaster();
            Master = _main;
            Detail = new NavigationPage(new SessionDataPage());
        }
       
    }
}
