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

            var dummyTour = new TourModel("dummy",null);
           var tmplate = new DataTemplate(() =>
            {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, nameof(dummyTour.Name));

                Label birthdayLabel = new Label();
                birthdayLabel.SetBinding(Label.TextProperty,
                    new Binding(nameof(dummyTour.Created), BindingMode.OneWay,
                        null, null, "Created At {0:d}"));

                BoxView boxView = new BoxView();
                boxView.SetBinding(BoxView.ColorProperty, nameof(dummyTour.Color));

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                }
                    }
                };
            });

            return tmplate;
            

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
    }
}

