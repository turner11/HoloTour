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

            this.SizeChanged += this.ToursPage_SizeChanged;

            this._lstTours = new ListView();
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

        private void ToursPage_SizeChanged(object sender, EventArgs e)
        {
            this.SetListTemplate();
        }
        
        private void BindList()
        {
            var tours = this._contentService.GetTours();
            this._lstTours.ItemsSource = tours;
        }

        private void SetListTemplate()
        {
            this._lstTours.RowHeight = 200;
            this._lstTours.ItemTemplate = this.GetListCellTemplate();
        }

        private DataTemplate GetListCellTemplate()
        {
            // Define template for displaying each item.
            // (Argument of DataTemplate constructor is called for 
            //      each item; it must return a Cell derivative.)
            
            TourModel dummyTour = null;
            var tmplate = new DataTemplate(() =>
             {
                 // Create views with bindings for displaying each property.
                 
                 var image = new Image()
                 {
                     Aspect =Aspect.AspectFill,// Aspect.Fill, //
                     HorizontalOptions = LayoutOptions.Center,
                     WidthRequest=10000000
                    
                 };
                 image.SetBinding(Image.SourceProperty, nameof(dummyTour.ImageAsImageSource));

                 Label nameLabel = new Label()
                 {
                     HorizontalOptions = LayoutOptions.FillAndExpand
                 };
                 nameLabel.SetBinding(Label.TextProperty, nameof(dummyTour.Name));


                 var boxView = new BoxView()
                 {
                     Color = Color.Blue,
                     HorizontalOptions = LayoutOptions.FillAndExpand,
                 };

                 //Creates layouts that will hold views
                 var outerlayOut = new StackLayout
                 {
                     BackgroundColor = Color.White,
                     Padding = new Thickness(0, 5),
                     Orientation = StackOrientation.Horizontal,

                 };
                 //The inner layout will actualy hold the view items
                 var innerLayout = new RelativeLayout() { BackgroundColor = Color.Pink};
                 outerlayOut.Children.Add(innerLayout);


                 innerLayout.Children.Add(image,
                        xConstraint:     Constraint.Constant(0),
                        yConstraint:     Constraint.Constant(0),
                        widthConstraint: Constraint.RelativeToParent((parent) => parent.Width),
                        // heightConstraint:Constraint.RelativeToParent((parent) => {return Math.Max(1,parent.Height*3/4);}));
                        heightConstraint:Constraint.RelativeToParent((parent) =>  parent.Height*4/5)
                                         );

                 innerLayout.Children.Add(nameLabel,
                         xConstraint:     Constraint.Constant(0),
                         yConstraint:     Constraint.Constant(0),
                         widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                         heightConstraint:Constraint.RelativeToParent((parent) => { return parent.Height; }));

                 innerLayout.Children.Add(boxView,
                        xConstraint:     Constraint.Constant(0),
                        yConstraint:     Constraint.RelativeToView(image, (parent, view) => view.Y + view.Height),
                        widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                        heightConstraint: Constraint.RelativeToView(image, (parent, view) => parent.Height - view.Height)
                     );



                 // Return an assembled ViewCell.
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
                this._lstTours.SelectedItem = null;//this is for consecutive clicks on intem will reflect in event...
                //this._lstTours.ItemTemplate = this.GetListCellTemplate();

                //var ts = this._contentService.GetTours();
                //this._lstTours.ItemsSource = ts;
                //return;

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

