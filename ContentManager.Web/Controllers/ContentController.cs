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
        protected HttpContext  Application
        {
            get
            {
                return System.Web.HttpContext.Current;

                /*System.Web.HttpContext.Current.Application.Lock();
                System.Web.HttpContext.Current.Application["Name"] = "Value";
                System.Web.HttpContext.Current.Application.UnLock();*/
            }
        }



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