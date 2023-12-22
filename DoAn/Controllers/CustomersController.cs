using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public new ActionResult Profile()
        {
            return View();
        }
    }
}