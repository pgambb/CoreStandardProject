using CoreStandardProject.DATA.Model.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using SSMAuthentication;
using System;
using System.Linq;


namespace CoreStandardProject.UI.Controllers
{
    [Models.CustomActionFilter]
    public class DefaultController : Controller
    {
        public AuthUser authUser;

        protected void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext, IHttpContextAccessor httpContextAccessor)
        {            
            string userID = "";
            string domainName = "";

            string[] userInfo = httpContextAccessor.HttpContext.User.Identity.Name.Split('\\');
            var DisplayName = "";

            authUser = new AuthUser();

            if (userInfo.Count() > 0)
            {
                domainName = userInfo[0];
                userID = userInfo[1];
                authUser.User_Id = userID;
                authUser.Domain = domainName;

                if (HttpContext.Session.GetString("DisplayName") == null)
                {
                    HttpContext.Session.SetString("DisplayName", ActiveDirectory.GetDisplayName(authUser.User_Id));
                }

                if (HttpContext.Session.GetString("UserPhone") == null)
                {
                    HttpContext.Session.SetString("UserPhone", ActiveDirectory.GetPhone(authUser.User_Id));
                }

                if (HttpContext.Session.GetString("UserEmail") == null)
                {
                    HttpContext.Session.SetString("UserEmail", ActiveDirectory.GetMail(authUser.User_Id));
                }

                DisplayName = Convert.ToString(HttpContext.Session.GetString("DisplayName"));
                authUser.PhoneNumber = Convert.ToString(HttpContext.Session.GetString("UserPhone"));
                authUser.Email = Convert.ToString(HttpContext.Session.GetString("UserEmail"));
            }

            if (DisplayName.Contains(','))
            {
                string[] UserDisplayName = DisplayName.Split(',');
                authUser.Last_Name = UserDisplayName[0].Trim();
                authUser.First_Name = UserDisplayName[1].Trim();
            }
            else
            {
                authUser.Last_Name = "User";
                authUser.First_Name = "Guest";
                ViewData["AuthUserRoleId"] = 0;
            }

            ViewData["authUser"] = authUser;


        }
    }
}
