using AnimationWeb.Areas.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimationWeb.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login/Login
        public ActionResult LoginIndex()
        {
            return View();
        }

        public ActionResult forget()
        {
            return View();
        }
        public ActionResult loginUp()
        {
            String name = Request["name"];
            String password = Request["password"];
            using (var context = new UserModel())
            {
                try
                {
                    var q = from t in context.UserTable
                            where t.phone == name || t.name == name
                            select t;
                    if (q.Count() == 0)
                    {
                        ViewBag.errorMsg = "用户名不存在";
                        //Response.Write("<script>alert('javascript');</script>");
                        return View("LoginIndex");
                    }
                    else if (q.Single().password != password)
                    {
                        ViewBag.errorMsg = "密码错误";

                        return View("LoginIndex");

                    }
                    else
                    {
                        ViewBag.errorMsg = "";
                        Session["login"] ="true";
                        Session["name"] = q.Single().name;
                        Session["phone"] = q.Single().phone;
                        String url = Url.Action("Index", "Home",new { area=""});
                        return Redirect(url);
                        //return View("register");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.errorMsg = e.Message;
                    return View("LoginIndex");
                }
            }
        }
        public ActionResult registerUP()
        {
            String name = Request["name"];
            String phone = Request["phone"];
            String password = Request["password"];
            using (var context = new UserModel())
            {
                
                var q = from t1 in context.UserTable
                        where t1.phone == phone
                        select t1;
                if (q.Count() != 0)
                {
                    ViewBag.registerMsg = "手机号已经注册";
                    return View("register");
                }

                UserTable user = new UserTable()
                {
                    name = name,
                    password = password,
                    phone = phone
                };
                try
                {
                    context.UserTable.Add(user);
                    context.SaveChanges();
                    ViewBag.registerMsg = "";
                    Session["name"] = name;
                    Session["phone"] = phone;
                    Response.Write("<script>alert('注册成功');</script>");
                    Session["login"] = "true";
                    String url = Url.Action("Index", "Home", new { area = "" });
                    return Redirect(url);
                }
                catch(Exception e)
                {
                    ViewBag.registerMsg = e.Message;
                    return View("register");
                }
            }
        }
        public ActionResult Register()
        {
            return View("register");
        }


        public ActionResult FrogetPsd()
        {
            string phone = Request["phone"];
            string password = Request["password"];
            using (var context = new UserModel())
            {

                var q = from t1 in context.UserTable
                        where t1.phone == phone
                        select t1;
                if (q.Count() == 0)
                {
                    ViewBag.registerMsg = "手机号不存在";
                    return View("forget");
                }


                try
                {
                    foreach (var v in q)
                    {
                        v.password = password;
                    }
                    context.SaveChanges();
                    ViewBag.registerMsg = "";
                    Response.Write("<script>alert('修改成功');</script>");
                    return View("LoginIndex");
                }
                catch (Exception e)
                {
                    ViewBag.registerMsg = e.Message;
                    return View("forget");
                }
            }

        }
    }
}