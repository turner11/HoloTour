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
        
        TourViewModel[] _tours
        {
            get
            {
                TourViewModel[] ret = 
                    this.Session[SessionKey_Tours] as
                TourViewModel[];
                if (ret == null)
                {
                    ret = 
                    this.ContentService.GetTours().Select(t => new TourViewModel(t)).ToArray();
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
    }
}