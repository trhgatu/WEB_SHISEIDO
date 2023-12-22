using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QLWebShiseidoEntities3 db = new QLWebShiseidoEntities3();
        public ActionResult Home()
        {
            var products = db.Products.Where(p => p.HomeFlag).OrderBy(p => p.HomeFlag).ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult Login(Customers cus)
        {
            var usernameForm = cus.Username;
            var passwordForm = cus.Password;
            var cusCheck = db.Customers.SingleOrDefault(x => x.Username.Equals(usernameForm) && x.Password.Equals(passwordForm));
            if (cusCheck != null)
            {
                Session["User"] = cusCheck;
                return RedirectToAction("Home", "Home");
            }

            else
            {
                ViewBag.LoginFail = "Tài khoản hoặc mật khẩu không đúng !";
                return View("Login");
            }

        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(Customers cus)
        {
            db.Customers.Add(cus);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Home", "Home");
        }
        public ActionResult Contact()
        {
            return View();
        }



    }
}