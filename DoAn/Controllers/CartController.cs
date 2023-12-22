using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        QLWebShiseidoEntities3 db = new QLWebShiseidoEntities3();
        public List<Cart> LayGioHang()
        {
            List<Cart> lstGioHang = Session["GioHang"] as List<Cart>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<Cart>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(int ms, string strURL)
        {
            List<Cart> lstGioHang = LayGioHang();
            Cart SanPham = lstGioHang.Find(sp => sp.iProductID == ms);
            if (SanPham == null)
            {
                SanPham = new Cart(ms);
                lstGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iQuantity++;
                return Redirect(strURL);
            }
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<Cart> lstGioHang = Session["GioHang"] as List<Cart>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iQuantity);
            }
            return tsl;
        }
        private double TongThanhTien()
        {
            double ttt = 0;
            List<Cart> lstGioHang = Session["GioHang"] as List<Cart>;
            if (lstGioHang != null)
            {
                ttt += lstGioHang.Sum(sp => sp.dTotalPrice);
            }
            return ttt;
        }
        //
        // GET: /GioHang/
        public ActionResult GioHang()
        {
            List<Cart> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return PartialView();
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            List<Cart> lstGioHang = LayGioHang();
            Cart sp = lstGioHang.Single(s => s.iProductID == MaSP);
            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.iProductID == MaSP);
                return RedirectToAction("GioHang", "Cart");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Error", "Cart+");
            }
            return RedirectToAction("GioHang", "Cart");
        }
        public ActionResult XoaGioHang_All()
        {
            List<Cart> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("Error", "Cart");
        }
        public ActionResult CapNhatGioHang(int MaSP, FormCollection f)
        {
            List<Cart> lstGioHang = LayGioHang();
            Cart sp = lstGioHang.Single(s => s.iProductID == MaSP);
            if (sp != null)
            {
                sp.iQuantity = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang", "Cart");
        }
        public ActionResult Error()
        {
            return View();
        }

    }

}