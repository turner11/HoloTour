using HoloTour.ContentLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManager.Web.Controllers
{
    
    public abstract class ContentController: Controller
    {
        protected const string SessionKey_Tours = "Tours";
        readonly static ContentService _contentService;
        protected ContentService ContentService { get { return _contentService; } }
        static ContentController()
        {
            _contentService = ContentService.Factory();
        }

        public ContentController()
        {

        }
    }
}