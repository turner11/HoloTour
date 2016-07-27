﻿using HoloTour.ContentLogics;
using HoloTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManager.Web.Controllers
{
    public class ContentManagementController : Controller
    {
        readonly ContentService _contentService;
        readonly TourViewModel[] _tours;
        public ContentManagementController()
        {
            this._contentService = ContentService.Factory();
            this._tours = this._contentService.GetTours().Select(t => new TourViewModel(t)).ToArray();
        }
        // GET: ContentManagement
        public ActionResult Index()
        {
            return View(this._tours);
        }
    }
}