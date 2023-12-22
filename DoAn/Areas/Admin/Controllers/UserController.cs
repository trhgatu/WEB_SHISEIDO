using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DoAn.Models;

namespace DoAn.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User1

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string pass)
        {
            mapAccounts map = new mapAccounts();
            var user = map.TimKiem(name, pass); 
            if (user != null)
            {
                return RedirectToAction("Index", "Accounts", new { area = "Admin" });
            }
            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng !";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Accounts model)
        {
            mapAccounts map = new mapAccounts();
            if (map.ThemMoi(model) == true)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);

            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

    }
}