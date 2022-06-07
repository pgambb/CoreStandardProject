using Microsoft.AspNetCore.Mvc;

namespace CoreStandardProject.UI.Controllers
{
    public class HttpErrorController : DefaultController
    {
        // GET: HttpError
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [IgnoreAntiforgeryToken]
        public ActionResult HttpRequestValidationError()
        {
            return View();
        }

        public ActionResult AccessDenied(string appName)
        {
            ViewBag.ApplicationName = appName;
            return View();
        }
    }
}
