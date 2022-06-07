using CoreStandardProject.DATA.Model.Global;
using System.Web.Mvc;
using System.Web;


namespace CoreStandardProject.UI.Models
{
    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            try
            {
                bool errorLogging = false;
                bool.TryParse(new SSMAuthentication.ConfigurationSettings().GetAppKeyValueByKey("SSM_GLOBAL", "ErrorLogging").LookupValue, out errorLogging);
                if (errorLogging)
                {
                    ErrorLogging error = new ErrorLogging();
                    error.StackTrace = filterContext.Exception.StackTrace;
                    error.Message = filterContext.Exception.Message;

                    error.JSON += "{";

                    foreach (var viewDataItem in filterContext.Controller.ViewData)
                    {
                        if (error.JSON != "{")
                            error.JSON += ", ";

                        error.JSON += viewDataItem.Key.ToString() + ": " + viewDataItem.Value.ToString();
                    }
                    error.JSON += "}";
                    error.Save();
                }
                
                if (!filterContext.ExceptionHandled)
                {
                    filterContext.Result = new RedirectResult("~/HttpError/HttpRequestValidationError");
                    filterContext.ExceptionHandled = true;
                }
            }
            catch
            {
                //this should run if there is another issue like a network error or a sql server issue.
                filterContext.Result = new RedirectResult("~/HttpError/HttpRequestValidationError");
                filterContext.ExceptionHandled = false;
            }
        }
    }
}
