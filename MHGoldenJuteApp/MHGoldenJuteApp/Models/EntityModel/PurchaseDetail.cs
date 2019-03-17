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
        public string PurchaseInvoiceNo { get; set; }
        public Int64 ItemGroupId { get; set; }
        public Int64 ItemId { get; set; }
        public string ItemName { get; set; }
        public int GodownId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public string ChalanNo { get; set; }
        public string Remarks { get; set; }
        public string IsApproved { get; set; }
        public Int64 ApproveByUserId { get; set; }
        public DateTime ApproveDateTime { get; set; }
        public string MrNo { get; set; }

        public string Department { get; set; }
        public string Location { get; set; }

    }
}