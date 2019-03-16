using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHGoldenJuteApp.Models
{
    public class PurchaseDetail
    {
        public Int64 PurchaseDetailId { get; set; }
        public Int64 PurchaseId { get; set; }
        public Int64 ItemGroupId { get; set; }
        public string ItemGroupName { get; set; }
        public Int64 ItemId { get; set; }
        public string ItemName { get; set; }
        public int GodownId { get; set; }
        public string GodownName { get; set; }
        public Int64 SupplierId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public string BillNo { get; set; }
        public string Remarks { get; set; }
        public string IsApproved { get; set; }
        public string MmoNo { get; set; }

    }
}