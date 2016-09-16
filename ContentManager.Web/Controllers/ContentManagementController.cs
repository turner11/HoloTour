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
            var tour = this._tours.FirstOrDefault(t=> t.Id == tourId);
            if (tour != null)
                return View(tour);
           
            return View("Failed to find requested tour");
        }
    }
}