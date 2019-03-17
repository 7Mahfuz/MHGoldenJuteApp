using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHGoldenJuteApp.Models
{
    public class Purchase
    {
        public Int64 PurchaseID { get; set; }
        public string PurchaseInvoiceNo { get; set; }
        public DateTime PurcahseDateTime { get; set; }
        public Int64 SupplierId { get; set; }
        public string Remarks { get; set; }
        public double TotalAmount { get; set; }
        public string ChalanNo { get; set; }
          public Int64 PurchaseByUserId { get; set; }
        public Int64 PurchaseApproveUserId { get; set; }
        public DateTime PurchaseApproveDateTime { get; set; }
        public string IsApproved { get; set; }
        public string MrNo { get; set; }
    }
}