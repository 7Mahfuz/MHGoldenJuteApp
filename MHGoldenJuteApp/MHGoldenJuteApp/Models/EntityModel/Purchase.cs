using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHGoldenJuteApp.Models
{
    public class Purchase
    {
        public Int64 PurchaseID { get; set; }
        public string PurchaseIdCode { get; set; }
        public DateTime PurcahseDate { get; set; }
        public Int64 SupplierId { get; set; }
        public string Products { get; set; }
        public double TotalAmount { get; set; }
        public string BillNo { get; set; }
        public int MyProperty { get; set; }
        public Int64 PurchaseByUSerId { get; set; }
        public Int64 PurchaseApproveUserId { get; set; }
        public DateTime PurchaseApproveDate { get; set; }
        public string IsApproved { get; set; }
        public string MmoNo { get; set; }
    }
}