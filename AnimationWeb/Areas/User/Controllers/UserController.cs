
using AnimationWeb.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnimationWeb.Areas.User.Controllers
{

    public class UserController : Controller
    {
        private AllUserModel db = new AllUserModel();
        // GET: User/User
        public ActionResult UserIndex()
        {
            var admin = Session["admin"];
            if (admin == null)
            {
                //< li > @Html.ActionLink("返回主页", "Index", "Home", new { area = "" }, null) </ li >
                String url = Url.Action("Index", "Home", new { area = "" });
                return Redirect(url);
            }
            else
            {
                ViewBag.admin = admin;
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView(db.UserTable.ToList());
            }
            return View(db.UserTable.ToList());
        }

        // GET: Chapter08/MyTable2/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable myTable2 = db.UserTable.Find(int.Parse(id));
            if (myTable2 == null)
            {
                return HttpNotFound();
            }
            return View(myTable2);
        }

        // POST: Chapter08/MyTable2/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phone, password")] UserTable myTable2)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(myTable2).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("UserIndex");
                }
                catch (Exception e)
                {
                    return JavaScript("alert('失败')");
                }

            }
            return View(myTable2);
        }

        // GET: Chapter08/MyTable2/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserTable myTable2 = db.UserTable.Find(int.Parse(id));


            if (myTable2 == null)
            {
                return HttpNotFound();
            }
            return View(myTable2);
        }

        public ActionResult AllUser()
        {
            string msg = Request["msg"];

            using (var context = new AllUserModel())
            {
                var q = from t in context.UserTable
                        where t.name.Contains(msg) || t.phone.Contains(msg)
                        select t;
                if (q.Count() != 0)
                {
                    if (Request.IsAjaxRequest())
                        return PartialView("testPage", q.ToList());
                    else
                        return View(q.ToList());
                }
                else
                {
                    return PartialView("testPage", q.ToList());
                }
            }
        }
        public ActionResult SelectForm()
        {
            string msg = Request["msg"];

            using (var context = new AllUserModel())
            {
                var q = from t in context.UserTable
                        where t.name.Contains(msg) || t.phone.Contains(msg)
                        select t;
                if (q.Count() != 0)
                {
                    if (Request.IsAjaxRequest())
                        return PartialView(q.ToList());
                    else
                        return View("AllUser", q.ToList());
                }
                else
                {
                    return View("AddUser");
                }
            }

        }

        // POST: Chapter08/MyTable2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserTable myTable2 = db.UserTable.Find(int.Parse(id));
            db.UserTable.Remove(myTable2);
            db.SaveChanges();
            return RedirectToAction("UserIndex");
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult Echarts()
        {
            return View();
        }

        // POST: Chapter08/MyTable2/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,phone,password")] UserTable myTable2)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UserTable.Add(myTable2);
                    db.SaveChanges();
                    Response.Write("<script>alert('注册成功');</script>");
                }
                catch (DataException err)
                {
                    ModelState.AddModelError("phone", "（已存在该手机号，不能重复添加）。\n" + err.Message);
                    Response.Write("<script>alert('已存在该手机号，不能重复添加');</script>");
                    return PartialView();
                }
                return RedirectToAction("UserIndex");
            }

            return View();
        }

        public ActionResult AddAdmin()
        {
            string phone = Request["phone"];
            string password = Request["password"];
            using (var context = new AllUserModel())
            {
                var q = from t1 in context.AdminTable
                        where t1.phone == phone
                        select t1;
                if (q.Count() != 0)
                {
                    Response.Write("<script>alert('手机号已经被注册');</script>");
                    return View("Create");
                }
                AdminTable myadmin = new AdminTable()
                {
                    phone = phone,
                    password = password
                };
                try
                {
                    context.AdminTable.Add(myadmin);
                    context.SaveChanges();
                    Response.Write("<script>alert('注册成功');</script>");

                    return View("Create");
                }
                catch (Exception e)
                {
                    Response.Write("<script>alert('" + e.Message + "');</script>");
                    return View("Create");
                }
            }
        }

        public ActionResult AddUser()
        {
            string name = Request["userName"];
            string phone = Request["userPhone"];
            string password = Request["userPassword"];
            using (var context = new AllUserModel())
            {
                var q = from t1 in context.UserTable
                        where t1.phone == phone
                        select t1;
                if (q.Count() != 0)
                {
                    Response.Write("<script>alert('手机号已经被注册');</script>");
                    return View("Create");
                }
                UserTable myUser = new UserTable()
                {
                    name = name,
                    phone = phone,
                    password = password
                };
                try
                {
                    context.UserTable.Add(myUser);
                    context.SaveChanges();
                    Response.Write("<script>alert('注册成功');</script>");

                    return View("Create");
                }
                catch (Exception e)
                {
                    Response.Write("<script>alert('" + e.Message + "');</script>");
                    return View("Create");
                }
            }

            //    try
            //    {
            //        context.UserTable.Add(user);
            //        context.SaveChanges();
            //        ViewBag.registerMsg = "";
            //        Session["name"] = name;
            //        Session["phone"] = phone;
            //        Response.Write("<script>alert('注册成功');</script>");
            //        Session["login"] = "true";
            //        String url = Url.Action("Index", "Home", new { area = "" });
            //        return Redirect(url);
            //    }
            //    catch (Exception e)
            //    {
            //        ViewBag.registerMsg = e.Message;
            //        return View("register");
            //    }
            //}


        }

        public ActionResult Change(String id)
        {
            if (id == "UserIndex")
            {
                return PartialView(id, db.UserTable.ToList());
            }
            if (id == "AllUser")
            {
                return PartialView(id, null);
            }
            return PartialView(id);
        }
    }
}