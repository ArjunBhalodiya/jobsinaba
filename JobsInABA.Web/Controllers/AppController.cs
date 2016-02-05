using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsInABA.Web.Controllers
{
    /// <summary>
    /// Create an ActionResult and PartialView for each angular partial view you want to attatch to a route in the angular app.js file.
    /// </summary>
    public class AppController : Controller
    {
        public ActionResult Register()
        {
            return PartialView();
        }
        public ActionResult SignIn()
        {
            return PartialView();
        }
        public ActionResult Home()
        {
            return PartialView();
        }
        public ActionResult PersonProfile()
        {
            return PartialView();
        }
        public ActionResult RightProfilePanelPortion()
        {
            return PartialView();
        }
        public ActionResult LeftProfilePanelPortion()
        {
            return PartialView();
        }
        public ActionResult ProfileSummery()
        {
            return PartialView();
        }
        public ActionResult ProfileExperiance()
        {
            return PartialView();
        }
        public ActionResult ProfileAchievement()
        {
            return PartialView();
        }
        public ActionResult ProfileEducation()
        {
            return PartialView();
        }
        public ActionResult ProfileSkillSet()
        {
            return PartialView();
        }
        public ActionResult ProfileLanguage()
        {
            return PartialView();
        }
        [Authorize]
        public ActionResult TodoManager()
        {
            return PartialView();
        }
    }
}