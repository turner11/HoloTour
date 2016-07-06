using System;
using NUnit.Framework;
using HoloTour.ContentLogics;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ContentServicesTests
    {
        [TestCase(TestName ="Get Tours does not throw exception")]
        public void GetTours()
        {
            //Arrange
            var contentService = ContentService.Factory();
            //Act
            var tours = contentService.GetTours().ToList();
            //Assert
            Assert.IsNotEmpty(tours,"Failed to get tours");
        }

        [TestCase(TestName = "Get Guide for poi does not throw exception")]
        public void GetPois()
        {
            //Arrange
            var contentService = ContentService.Factory();
            //Act
            var tours = contentService.GetTours().ToList();
            var tour = tours.First();
            var poi = tour.PointsOfInterest.First();
            var guide = contentService.GetPoiGuide(poi);
            //Assert
            Assert.IsNotNull(guide,"Got an null guide");
        }
    }
}