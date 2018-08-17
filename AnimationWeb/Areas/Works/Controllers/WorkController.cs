using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimationWeb.Areas.Works.Controllers
{
    public class WorkController : Controller
    {
        // GET: Works/Work
        public ActionResult WorkIndex()
        {
            return View();
        }
        public ActionResult ToMsg(string Msgid)
        {
            String url = Url.Action("Index", "NewsMsg", new { area = "NewsMsg", id = Msgid });
            return Redirect(url);
        }
    }
}