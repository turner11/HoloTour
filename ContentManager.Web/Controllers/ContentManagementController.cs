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
        
        readonly TourViewModel[] _tours;
        public ContentManagementController()
        {
            this._tours = this.ContentService.GetTours().Select(t => new TourViewModel(t)).ToArray();
        }
        // GET: ContentManagement
        public ActionResult Index()
        {
            return View(this._tours);
        }
    }
}