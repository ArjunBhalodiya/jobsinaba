using System.Web.Mvc;

namespace JobsInABA.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
    }
}
