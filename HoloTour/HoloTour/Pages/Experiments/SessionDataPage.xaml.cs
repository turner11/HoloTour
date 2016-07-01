using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HoloTour.Pages
{
    public partial class SessionDataPage : Xamarin.Forms.Pages.ListDataPage
    {
        const string DATA_URL = "http://demo3143189.mockable.io/sessions";
        public SessionDataPage()
        {
            this.BackgroundColor = Color.Lime;
            this.Appearing += SessionDataPage_Appearing;
            this.ChildAdded += SessionDataPage_ChildAdded;
            InitializeComponent();
            
            //var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped += (s, e) => {
            //    // handle the tap
            //};
            //Image img = null;
            //img.GestureRecognizers.Add(tapGestureRecognizer);



        }

        private async void SessionDataPage_Appearing(object sender, EventArgs e)
        {
            //await Task.Run(() =>
            //{
            //    Task.Delay(TimeSpan.FromSeconds(3));
            //    this.BindDataSource();
            //}).ConfigureAwait(false);
        }

        

        private void BindDataSource()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var uri = new Uri(DATA_URL);
                var jsonSource = Xamarin.Forms.Pages.JsonSource.FromUri(uri);
                var ds = new Xamarin.Forms.Pages.JsonDataSource() { Source = jsonSource };
                this.DataSource = ds;
            });
        }

        private void SessionDataPage_ChildAdded(object sender, ElementEventArgs e)
        {
            1.ToString();
        }
    }
}
