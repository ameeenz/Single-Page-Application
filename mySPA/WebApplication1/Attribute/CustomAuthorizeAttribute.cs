using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication1.Attribute
{
    public class CustomAuthorizeAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var autHeader = actionContext.Request.Headers.Authorization;
            if (autHeader!=null)
            {
                var autTokken = autHeader.Parameter;
                var DecodeAutTokken = Encoding.UTF8.GetString(Convert.FromBase64String(autTokken));
                string UserName = DecodeAutTokken.Split(':')[0];
                string Password = DecodeAutTokken.Split(':')[1];
                bool IsValid = (UserName == "kahkeshan" && Password == "kahkeshan");
                if (IsValid)
                {
                    var Principal = new GenericPrincipal(new GenericIdentity(UserName), null);
                    Thread.CurrentPrincipal = Principal;
                    return;
                }
                else
                {
                    handleUnAuthorized(actionContext);
                }
            }
            else
            {
                handleUnAuthorized(actionContext);
            }
        }
        protected static void handleUnAuthorized(HttpActionContext actioncontext)
        {
            actioncontext.Response = actioncontext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}