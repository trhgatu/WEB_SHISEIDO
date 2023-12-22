using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Pay()
        {
            
            return View();
        }
    }
}