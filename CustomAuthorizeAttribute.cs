using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BurlOakMovers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string ViewName { get; set; }

        public CustomAuthorizeAttribute()
        {
            ViewName = "AuthorizeFailed";
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }
        void IsUserAuthorized(AuthorizationContext filterContext)
        {
            //User Authorized
            if(filterContext.Result == null)
            {
                return;
            }
            if(filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewDataDictionary dic = new ViewDataDictionary();
                dic.Add("Message", "You are not allowed to view this page");
                var result = new ViewResult() { ViewName = this.ViewName, ViewData = dic };
                filterContext.Result = result;
            }
        }
    }
}