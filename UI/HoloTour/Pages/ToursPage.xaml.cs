//using HoloTour.Models;
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
    public partial class ToursPage : ContentPage
    {
        private readonly TourCollectionViewModel toursViewModel;
        private readonly ListView _lstTours;

        public ToursPage()
        {
            toursViewModel = new TourCollectionViewModel(new Models.ToursModel());
            InitializeComponent();

            this.SizeChanged += this.ToursPage_SizeChanged;
            this.Appearing += this.ToursPage_Appearing;
            this.Disappearing += ToursPage_Disappearing;

            this._lstTours = new ListView() { HorizontalOptions = LayoutOptions.Center };
            this._lstTours.BindingContextChanged += this.lstTours_BindingContextChanged;

            this.BindList();
            this.SetListTemplate();

            Label header = new Label
            {
                Text = "Avilable Tours",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            this.Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    header,
                    this._lstTours
                }
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this._lstTours.ItemSelected += lstTours_ItemSelected;
        }



        private void BindList()
        {
            this._lstTours.ItemsSource = toursViewModel.Tours;
        }

        private void SetListTemplate()
        {
            this._lstTours.BeginRefresh();
            try
            {
                this._lstTours.HasUnevenRows = true;
                //this._lstTours.RowHeight = 200;
                this._lstTours.ItemTemplate = this.GetListCellTemplate();
            }
            finally
            {
                this._lstTours.EndRefresh();
            }

            this.ForceLayout();
        }


        private DataTemplate GetListCellTemplate()
        {
            // Define template for displaying each item.
            // (Argument of DataTemplate constructor is called for 
            //      each item; it must return a Cell derivative.)

            ShallowTourViewModel dummyTour = null;
            var tmplate = new DataTemplate(() =>
             {
                 // Create views with bindings for displaying each property.

                 #region Define the view items
                 var image = new Image()
                 {
                     Aspect = Aspect.Fill, //Aspect.AspectFill,//
                     HorizontalOptions = LayoutOptions.Fill,// LayoutOptions.Center,
                                                            //WidthRequest=10000000
                     HeightRequest = 200,


                 };
                 image.SetBinding(Image.SourceProperty, nameof(dummyTour.ImageAsImageSource));




                 Label nameLabel = new Label()
                 {
                     // HorizontalOptions = LayoutOptions.FillAndExpand,
                     TextColor = Color.Black,
                     FontAttributes = FontAttributes.Bold,
                 };
                 nameLabel.SetBinding(Label.TextProperty, nameof(dummyTour.Name));



                 Label captionlabel = new Label()
                 {
                     HorizontalOptions = LayoutOptions.FillAndExpand,
                     TextColor = Color.Gray
                 };

                 captionlabel.SetBinding(Label.TextProperty, nameof(dummyTour.Caption));




                 #endregion



                 //var labelslayout = new StackLayout();
                 //labelslayout.Children.Add(nameLabel);
                 //labelslayout.Children.Add(captionlabel);

                 //AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0, 0, 1, 0.69));
                 //AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.SizeProportional);
                 //AbsoluteLayout.SetLayoutBounds(labelslayout, new Rectangle(0, 0, 1, 0.29));
                 //AbsoluteLayout.SetLayoutFlags(labelslayout, AbsoluteLayoutFlags.None);

                 //Add views to layouts
                 var abslayout = new StackLayout() { BackgroundColor = Color.White, Padding = 3, Spacing = 3 };
                 abslayout.Children.Add(image);
                 //abslayout.Children.Add(labelslayout);
                 abslayout.Children.Add(nameLabel);
                 abslayout.Children.Add(captionlabel);


                 return new ViewCell
                 {

                     View = abslayout
                 };
             });

            return tmplate;


        }

        private void ToursPage_Appearing(object sender, EventArgs e)
        {

        }
        private void ToursPage_Disappearing(object sender, EventArgs e)
        {

        }


        private void ToursPage_SizeChanged(object sender, EventArgs e)
        {
            //this._lstTours.BackgroundColor = Color.Lime;
            //(this._lstTours.Parent as View).BackgroundColor = Color.Olive;
            //this.SetListTemplate();
        }

        private void lstTours_BindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            //var tour= (TourModel)this.BindingContext;
            //var image = this.GetImageForTour(tour);


        }


        private async void lstTours_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedTour = e.SelectedItem as ShallowTourViewModel;
            if (selectedTour != null)
            {
                //this._lstTours.SelectedItem = null;//this is for consecutive clicks on intem will reflect in event...
                /////*handy for debugging*/
                //this.BindList();
                //SetListTemplate();
                //this.ForceLayout();
                //return;

                this._lstTours.SelectedItem = null;// this will allow to re select same item...
                var model = (Models.TourModel)selectedTour;
                var vModel = new TourViewModel(model);
                /*-----------------------------*/
                //var tourPage = new MainTourPage(vModel);//this is master detail
                //tourPage.IsPresented = true;
                var tourPage = new TourPage(vModel);
                /*----------------------------*/
                await Navigation.PushAsync(tourPage);
            }
        }

        //Dictionary<string, ImageSource> _imageCache = new Dictionary<string, ImageSource>();

        //ImageSource GetImageForTour(TourModel tm)
        //{
        //    ImageSource retVal = null;

        //    if (!this._imageCache.TryGetValue(tm.Name, out retVal))
        //    {
        //        retVal  = ImageSource.FromStream(() => new System.IO.MemoryStream(tm.ImageBytes));
        //        this._imageCache[tm.Name] = retVal;
        //    }

        //    return retVal;

        //}
    }
}

