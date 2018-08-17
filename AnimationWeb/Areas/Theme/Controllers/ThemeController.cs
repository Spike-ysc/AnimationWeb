using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimationWeb.Areas.Theme.Controllers
{
    public class ThemeController : Controller
    {
        // GET: Theme/Theme
        public ActionResult ThemeIndex()
        {
            return View();
        }
        public ActionResult ToMsg(string Msgid)
        {
            String url = Url.Action("Index", "NewsMsg", new { area="NewsMsg", id =Msgid});
            return Redirect(url);
        }
    }
}