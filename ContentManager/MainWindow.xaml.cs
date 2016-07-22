using HoloTour.ContentLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HoloTour.Models;
using System.Collections.ObjectModel;
using HoloTour.ViewModels;

namespace ContentManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TourWpfViewModel> Tours { get; }
        public ObservableCollection<PointOfInterestViewModel> Pois { get; }
        ContentService _contentService;
        public MainWindow()
        {
            this._contentService = ContentService.Factory();
            var tours = this._contentService.GetTours().Select(t => new TourWpfViewModel(t)).ToArray();
            this.Tours = new ObservableCollection<TourWpfViewModel>(tours);
            this.Pois = new ObservableCollection<PointOfInterestViewModel>();
            
            InitializeComponent();
            this.lbTours.SelectionChanged += LbTours_SelectionChanged;

            //this.lbTours.ItemTemplate = this.GetToursItemTemplate();
        }

        private void LbTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTour = e.AddedItems.OfType<TourViewModel>().FirstOrDefault();
            this.Pois.Clear();
            if (selectedTour != null)
            {
                this.Pois.AddRange(selectedTour.PointsOfInterest);
               
            }
        }
    }
}
