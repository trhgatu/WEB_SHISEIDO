using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace DoAn.Models
{
    public class Cart
    {
        QLWebShiseidoEntities3 db = new QLWebShiseidoEntities3();
        public int iProductID { get; set; }
        public string sProductName {  get; set; }
        public string sThumb { get; set; }
        public double dUnitPrice { get; set; }
        public int iQuantity { get; set; }
        public double dTotalPrice
        {
            get { return iQuantity * dUnitPrice; }
        }
        public Cart(int ProductID)
        {
            iProductID = ProductID;
            Products product = db.Products.Single(s => s.ProductID == iProductID);
            sProductName = product.ProductName;
            sThumb = product.Thumb;
            dUnitPrice = double.Parse(product.Price.ToString());
            iQuantity = 1;
        }
    }
}