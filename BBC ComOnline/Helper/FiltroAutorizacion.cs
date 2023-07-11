using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBC_ComOnline.Helper
{
    public class FiltroAutorizacion : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) 
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            // Check for authorization
            if (System.Web.HttpContext.Current.Session["Correo"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}