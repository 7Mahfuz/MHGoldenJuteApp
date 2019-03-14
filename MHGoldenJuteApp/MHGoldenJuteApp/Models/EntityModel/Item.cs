using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHGoldenJuteApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int ItemGroupId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Department { get; set; }
        public string Unit { get; set; }
        public double SalesPrice { get; set; }
        public int ReOrderLevel { get; set; }
        public double ReOrderQuantity { get; set; }
        public int ItemType { get; set; }
        public string ImageUrl { get; set; }

    }
}