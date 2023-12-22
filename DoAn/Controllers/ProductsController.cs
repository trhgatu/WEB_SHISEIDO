using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DoAn.Controllers
{
    public class ProductsController : Controller
    {
        QLWebShiseidoEntities3 db = new QLWebShiseidoEntities3();
        // GET: Products

        public ActionResult XemChiTiet(int id)
        {
            Products products = db.Products.Single(p => p.ProductID == id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }
        
        public ActionResult AllChamSocDa(int? page)
        {
            const int pageSize = 4;
            int pageNumber = page ?? 1; 
            var listSP = db.Products.ToList();
            var dsproducts = db.Products.OrderBy(x => x.ProductID);
            var pagedList = dsproducts.ToPagedList(pageNumber, pageSize);

            return View(pagedList);

        }
        [HttpGet]
        public ActionResult TimKiem(string searchString)
        {
            ViewBag.Keyword = searchString;
            var lstSP = db.Products.Where(n => n.ProductName.Contains(searchString));

            if (!String.IsNullOrEmpty(searchString))
            {
                lstSP = lstSP.Where(p => p.ProductName .Contains(searchString));
            }

            return View(lstSP.ToList());
        }


    }
}