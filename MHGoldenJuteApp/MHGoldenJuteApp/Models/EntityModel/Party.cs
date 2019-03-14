using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHGoldenJuteApp.Models
{
    public class Party
    {
        public int PartyId { get; set; }
        public string PartyType { get; set; }
        public string PartyName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public double OpeningBalance { get; set; }
        public string ImageUrl { get; set; }

    }
}