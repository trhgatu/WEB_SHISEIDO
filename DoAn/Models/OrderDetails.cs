//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> ShipDate { get; set; }
    
        public virtual Orders Orders { get; set; }
    }
}
