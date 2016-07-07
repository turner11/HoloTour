using HoloTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HoloTour.Pages
{
    public partial class ToursPage : ContentPage
    {
        ContentLogics.ContentService _contentService;
        private readonly ListView _lstTours;

        public ToursPage()
        {
            this._contentService = ContentLogics.ContentService.Factory();

            InitializeComponent();
            this._lstTours = this.GetBindedList();
            this._lstTours.BindingContextChanged += lstTours_BindingContextChanged;
            this._lstTours.SeparatorColor = Color.Blue;
            this._lstTours.RowHeight = 200;

            Label header = new Label
            {
                Text = "Avilable Tours",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            this.Content = new StackLayout
            {
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

     

        private ListView GetBindedList()
        {
            var lst = new ListView();
            lst.ItemTemplate = this.GetListTemplate();
            var tours = this._contentService.GetTours();
            lst.ItemsSource = tours;

            return lst;

        }

        private DataTemplate GetListTemplate()
        {
            // Define template for displaying each item.
            // (Argument of DataTemplate constructor is called for 
            //      each item; it must return a Cell derivative.)

            TourModel dummyTour = null;
            var tmplate = new DataTemplate(() =>
             {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                 nameLabel.SetBinding(Label.TextProperty, nameof(dummyTour.Name));
                 nameLabel.HorizontalOptions = LayoutOptions.FillAndExpand;


                 Label birthdayLabel = new Label();
                 birthdayLabel.SetBinding(Label.TextProperty,
                     new Binding(nameof(dummyTour.Created), BindingMode.OneWay,
                         null, null, "Created At {0:d}"));

                 //BoxView boxView = new BoxView();
                 //boxView.SetBinding(BoxView.ColorProperty, nameof(dummyTour.Color));
                 var image = new Image();
                 image.SetBinding(Image.SourceProperty, nameof(dummyTour.ImageAsImageSource));
                 image.Aspect = Aspect.Fill;
                 image.HorizontalOptions = LayoutOptions.Center;
                 // Return an assembled ViewCell.

                 var boxView = new BoxView();
                 boxView.Color = Color.White;
                 //boxView.HeightRequest = 10;
                 boxView.HorizontalOptions = LayoutOptions.FillAndExpand;


                 var outerlayOut = new StackLayout
                 {

                     BackgroundColor = Color.White,
                     //Padding = new Thickness(0, 5),
                     //Orientation = StackOrientation.Horizontal,
                 };


                 var innerLayout = new RelativeLayout();
             innerLayout.Children.Add(image,
            xConstraint: Constraint.Constant(0),
            yConstraint: Constraint.Constant(0),
            widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
            heightConstraint:Constraint.RelativeToParent((parent) => {return parent.Height*3/4;}));

                 innerLayout.Children.Add(nameLabel,
                     Constraint.Constant(0),
                     Constraint.Constant(0),
                     Constraint.RelativeToParent((parent) => { return parent.Width; }),
                     Constraint.RelativeToParent((parent) => { return parent.Height; }));

                 innerLayout.Children.Add(boxView,
                      Constraint.Constant(0),
                        Constraint.Constant(0),
                     Constraint.RelativeToParent((parent) => { return parent.Width; }),
                     Constraint.RelativeToParent((parent) => { return parent.Height < 0 ? parent.Height : parent.Height / 4; }));

                 outerlayOut.Children.Add(innerLayout);
                 return new ViewCell
                 {
                    
                     View = outerlayOut
                 };
             });

            return tmplate;


        }




        private void lstTours_BindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            //var tour= (TourModel)this.BindingContext;
            //var image = this.GetImageForTour(tour);
            
            
        }
    

        private void lstTours_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedTour = e.SelectedItem as TourModel;
            if (selectedTour != null)
            {
                selectedTour.Initialize();
                //Navigation.PushAsync(new  MainPage());
                Navigation.PushAsync(new TourPage(selectedTour));
                //App.Current.MainPage = new MainPage();
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

