using ContentManager.ViewModels;
using HoloTour.ContentLogics;
using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManager.Web.Controllers
{
    public class ContentManagementController : ContentController
    {

        EditableTourViewModel[] _tours
        {
            get
            {
                var ret = this.Session[SessionKey_Tours] as EditableTourViewModel[];

                if (ret == null)
                {
                    ret =
                    this.ContentService.GetTours().Select(t => new EditableTourViewModel(t)).ToArray();
                    this.Session[SessionKey_Tours] = ret;
                }
                return ret;
            }
        }


        EditablePointOfInterestViewModel[] _pois
        {
            get
            {
                var tours = this._tours;
                var pois = tours.SelectMany(t => t.PointsOfInterest).Distinct()
                    .Select(p=> new EditablePointOfInterestViewModel(p))
                    .ToArray();
                return pois;
            }

        }
        public ContentManagementController()
        {

        }
        // GET: ContentManagement
        public ActionResult Index()
        {
            return View(this._tours);
        }

        // GET: ContentManagement
      
        public ActionResult Tour(int tourId)
        {
            var tour = this._tours.FirstOrDefault(t => t.Id == tourId);
            return Tour(tour);
        }

        private ActionResult Tour(EditableTourViewModel tour)
        {
            if (tour != null)
                return View(tour);

            return View("Failed to find requested tour");
        }


        public ActionResult PointofInterest()
        {
            var p = _pois;
            return View(p);
        }
        

        //
        // POST: /Account/Login
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveTour(EditableTourViewModel editableTourViewModel)
        {
            var a = editableTourViewModel.ToString();
            return Content(a);//View("Posted");
            
        }


        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult SavePoi(IList<EditablePointOfInterestViewModel> pois)
        {
            var a = pois.ToString();
            return Content(a);//View("Posted");

        }
    }
}