using AnimationWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimationWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            var s = Session["login"];
            if (s == null)
            {
                ViewBag.login = "no";
            }
            else
            {
                ViewBag.login = "yes";
                ViewBag.name = Session["name"];
                ViewBag.phone = Session["phone"];
            }


            return View();

        }
        public ActionResult addUser()
        {

            String url = Url.Action("Register", "Login", new { area = "Login" });
            return Redirect(url);
        }
        public ActionResult loginOut()
        {
            ViewBag.login = "no";
            return View("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //重新加载index 轮播图的图片会变形
        //还未解决
        public ActionResult AdminLogin()
        {
         
            string phone = Request["phone"];
            string password = Request["password"];
            using (var context  = new AdminModel()){
                try
                {
                    var q = from t in context.AdminTable
                            where t.phone == phone
                            select t;
                    if (q.Count() == 0)
                    {
                        Response.Write("<script>alert('不存在此用户');</script>");
                        Index();
                        return View("Index");
                    }
                    else if (q.Single().password != password)
                    {
                        Response.Write("<script>alert('密码错误');</script>");
                        return View("Index");

                    }
                    else
                    {
                        Session["admin"] = phone;
                        String url = Url.Action("UserIndex", "User", new { area = "User" });
                        return Redirect(url);
                    }
                }
                catch (Exception e)
                {
                    Response.Write("<script>alert('"+e.Message+"');</script>");
                    
                    return View("LoginIndex");
                }
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ToMsg(string Msgid)
        {
            String url = Url.Action("Index", "NewsMsg", new { area = "NewsMsg", id = Msgid });
            return Redirect(url);
        }
    
    }
}