using HoloTour.Controls;
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
    public partial class TourOverviewPage : ContentPage
    {
        private readonly MapWithRoute MapView;
        private ListView _lstPoi;

        TourViewModel _tourViewModel { get; }
        public TourOverviewPage(TourViewModel viewModel)
        {
            InitializeComponent();
            this._tourViewModel = viewModel;

            this._lstPoi = new ListView();
            this._lstPoi.ItemsSource = this._tourViewModel.PointsOfInterest;
            this._lstPoi.ItemTemplate= this.GetListTemplate();
            this._lstPoi.RowHeight = 60;

            this.MapView = new MapWithRoute();
            //add all points of interest to route
            this.MapView.RouteCoordinates.AddRange(this._tourViewModel.PointsOfInterest.Select(poi => poi.Position));

            this.SetLayout();
            //LayoutOptions.Start
            //this.lblLocation.IsVisible = false;
            this.Appearing += TourPage_Appearing;

        }

        private DataTemplate GetListTemplate()
        {
            PointOfInterestViewModel dummyPoi = null;
            var tmplate = new DataTemplate(() =>
            {
                // Create views with bindings for displaying each property.

                #region Define the view items
                var image = new Image()
                {
                    Aspect = Aspect.Fill, //Aspect.AspectFill,//
                    HorizontalOptions = LayoutOptions.Fill,// LayoutOptions.Center,
                                                           //WidthRequest=10000000

                };
                //image.SetBinding(Image.SourceProperty, nameof(dummyPoi.ImageAsImageSource));

                var boxView = new BoxView()
                {
                    Color = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };

                Label titleLabel = new Label()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.Black


                };
                titleLabel.SetBinding(Label.TextProperty, nameof(dummyPoi.Title));

                #endregion


                //Creates layouts that will hold views
                var outerlayOut = new StackLayout
                {
                    BackgroundColor = Color.White,
                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Horizontal,

                };
                //The inner layout will actualy hold the view items
                var innerLayout = new RelativeLayout() { BackgroundColor = Color.White };
                outerlayOut.Children.Add(innerLayout);

                //Add views to layouts
                innerLayout.Children.Add(image,
                       xConstraint: Constraint.Constant(0),
                       yConstraint: Constraint.Constant(0),
                       widthConstraint: Constraint.RelativeToParent((parent) => parent.Width / 5),
                       heightConstraint: Constraint.RelativeToParent((parent) => parent.Height)
                                        );

                innerLayout.Children.Add(boxView,
                     xConstraint: Constraint.RelativeToView(image, (parent, view) => view.X + view.Width),
                     yConstraint: Constraint.RelativeToView(image, (parent, view) => view.Y),
                     widthConstraint: Constraint.RelativeToView(image, (parent, view) => parent.Width - view.Width),
                     heightConstraint: Constraint.RelativeToView(image, (parent, view) => view.Height)
                                      );

                innerLayout.Children.Add(titleLabel,
                    xConstraint: Constraint.RelativeToView(boxView, (parent, view) => view.X + 2),
                     yConstraint: Constraint.RelativeToView(boxView, (parent, view) => view.Y + view.Height / 2)
                     );


                return new ViewCell
                {

                    View = outerlayOut
                };
            });

            return tmplate;
        }

        private void SetLayout()
        {
            var relativeLayout = new RelativeLayout()
            {
                Padding = 10
            };



            relativeLayout.Children.Add(this.MapView,
                 xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent((parent) => parent.Width),
                heightConstraint: Constraint.RelativeToParent((parent) => parent.Height/ 2)

                );

            relativeLayout.Children.Add(this._lstPoi,
                 xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.RelativeToView(this.MapView,(parent, view)=>view.Y+view.Height)
                
                );


            this.Content = relativeLayout;

        }


        /// <summary>
        /// Indicates that the Page is about to appear.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void TourPage_Appearing(object sender, EventArgs e)
        {
            if (this._tourViewModel.PointsOfInterest.Count == 0)
                return;

            var mapLocatoion = this.MapView.RouteCoordinates.FirstOrDefault();
            var region = MapSpan.FromCenterAndRadius(mapLocatoion, Distance.FromKilometers(1));
            this.MapView.MoveToRegion(region);

            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);//want to see if will load faster and how will look...
            var pins = this._tourViewModel.PointsOfInterest.Select(poi => new Pin()
            {
                Position = poi.Position,
                Label = poi.Title,
                Type = PinType.SearchResult
            }).ToArray();


            foreach (var pin in pins)
            {
                pin.Clicked += Pin_Clicked;
                await Task.Delay(TimeSpan.FromSeconds(0.25));
                Device.BeginInvokeOnMainThread(() => this.MapView.Pins.Add(pin));
            }
        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {
            Pin pin = sender as Pin;
            if (pin == null)
                return;

            var poi = this._tourViewModel.PointsOfInterest.Where(p => p.Position == pin.Position).FirstOrDefault();

            var textToDisplay = poi.Guide.Text;
            await DisplayAlert(textToDisplay,"Location data","Close");
            //this.lblLocation.Text = pin.Label + ": " + textToDisplay;
            //this.lblLocation.IsVisible = true;

            //await Task.Delay(3000).ContinueWith((t) =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        this.lblLocation.Text = "";
            //        this.lblLocation.IsVisible = true;
            //    });
            //});
        }
    }
}
