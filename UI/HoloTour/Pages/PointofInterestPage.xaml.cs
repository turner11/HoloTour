using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HoloTour.Pages
{
    public partial class PointofInterestPage : ContentPage
    {
        public readonly PointOfInterestViewModel PointOfInterestVM;

        public PointofInterestPage(PointOfInterestViewModel poi)
        {
            InitializeComponent();
            this.PointOfInterestVM = poi;


            var lblTitle = new Label()
            {
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            };
            lblTitle.SetBinding(Label.TextProperty, nameof(this.PointOfInterestVM.Title));

           


            var image = new Image()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Aspect = Aspect.AspectFit
                
            };

            image.SetBinding(Image.SourceProperty, nameof(this.PointOfInterestVM.ImageAsImageSource));

            var lblGuideText = new Label()
            {
                TextColor = Color.Black,
                
            };
            lblGuideText.BindingContext = this.PointOfInterestVM.Guide;
            lblGuideText.SetBinding(Label.TextProperty, nameof(this.PointOfInterestVM.Guide.Text));

            var lblScroll = new ScrollView { Content = lblGuideText };

            var layout = new RelativeLayout
            {
                BindingContext = this.PointOfInterestVM,
                BackgroundColor = Color.White,
                
                

               // Text = this._pointOfInterestVM.Guide.Text
        };
            Content = layout;

            layout.Children.Add(lblTitle,
                     xConstraint: Constraint.Constant(0),
                     yConstraint: Constraint.Constant(0),
                     widthConstraint: Constraint.RelativeToParent((parent) => parent.Width));

           

            layout.Children.Add(image,
                      xConstraint: Constraint.Constant(0),
                      yConstraint: Constraint.RelativeToView(lblTitle, (parent, view) => view.Y + view.Height),
                      widthConstraint: Constraint.RelativeToParent((parent) => parent.Width),
                      heightConstraint: Constraint.RelativeToParent((parent) => parent.Height/2)
                                       );
            layout.Children.Add(lblScroll,
                      xConstraint: Constraint.Constant(5),
                      yConstraint: Constraint.RelativeToView(image, (parent, view) => view.Y + view.Height),
                      widthConstraint: Constraint.RelativeToParent((parent) => parent.Width),
                      heightConstraint: Constraint.RelativeToView(image, (parent, view) => parent.Height - view.Height)
                                       );

            //var a = _pointOfInterestVM.Guide.Text;
        }
    }
}
