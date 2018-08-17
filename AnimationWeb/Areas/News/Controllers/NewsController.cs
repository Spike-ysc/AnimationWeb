using AnimationWeb.Areas.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimationWeb.Areas.News.Controllers
{
    public class NewsController : Controller
    {
        // GET: News/News
        private List<NewsPage> listAll = null;//所有数据库中的页面数据
        private List<NewsPage> listNewsIndex = null; 
        private List<NewsPage> listChinaNews = null;
        private List<NewsPage> listOtherNews = null;
        private List<NewsPage> listWorldNews = null;
        private NewsModel db = new NewsModel();
        public ActionResult NewsIndex( string id)
        {
            if(listAll==null)
                listAll = db.NewsPage.ToList();
            switch (id)
            {
                case null:
                case "NewsIndex":
                    {
                        if(listNewsIndex==null)
                        {
                            listNewsIndex = new List<Models.NewsPage>();
                            foreach (var item in listAll)
                            {
                                if (item.type.Trim() == "NewsIndex")
                                {
                                    listNewsIndex.Add(item);
                                }
                            }
                        }
                        if (Request.IsAjaxRequest())
                        {
                            return PartialView(id, listNewsIndex);
                        }
                        else
                        {
                            return View(id, listNewsIndex);
                        }
                    }
                case "WorldNews":
                    {
                        if (listWorldNews == null)
                        {
                            listWorldNews = new List<Models.NewsPage>();
                            foreach (var item in listAll)
                            {
                                if (item.type.Trim() == "WorldNews")
                                {
                                    listWorldNews.Add(item);
                                }
                            }
                        }
                        if (Request.IsAjaxRequest())
                        {
                            return PartialView(id, listWorldNews);
                        }
                        else
                        {
                            return View(id, listWorldNews);
                        }
                    }
                case "ChinaNews":
                    {
                        if (listChinaNews == null)
                        {
                            listChinaNews = new List<Models.NewsPage>();
                            foreach (var item in listAll)
                            {
                                if (item.type.Trim() == "ChinaNews")
                                {
                                    listChinaNews.Add(item);
                                }
                            }
                        }
                        if (Request.IsAjaxRequest())
                        {
                            return PartialView(id, listChinaNews);
                        }
                        else
                        {
                            return View(id, listChinaNews);
                        }
                    }
                case "OtherNews":
                    {
                        if (listOtherNews == null)
                        {
                            listOtherNews = new List<Models.NewsPage>();
                            foreach (var item in listAll)
                            {
                                if (item.type.Trim() == "OtherNews")
                                {
                                    listOtherNews.Add(item);
                                }
                            }
                        }
                        if (Request.IsAjaxRequest())
                        {
                            return PartialView(id, listOtherNews);
                        }
                        else
                        {
                            return View(id, listOtherNews);
                        }
                    }
                default:
                    break;
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView(id,null);
            }
            else
            {
                return View(id,null);
            }
        }
        public ActionResult NewsPage(string myid)
        {
            String url = Url.Action("Index", "NewsMsg", new {area="NewsMsg", id = myid });
            return Redirect(url);
            //return RedirectToAction("NewsMsg", "NewsMsgIndex");
        }

    }
}