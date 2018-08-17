using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimationWeb.Areas.NewsMsg.Controllers
{
    public class NewsMsgController : Controller
    {
        // GET: NewsMsg/NewsMsg
        public ActionResult Index(string id)
        {
            return View(id);
        }
    }
}