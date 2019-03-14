using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHGoldenJuteApp.Models
{
    public class SessionKeeper
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public SessionKeeper()
        {
            UserId = (int)HttpContext.Current.Session["UserId"];
            UserName = (string)HttpContext.Current.Session["UserName"];
        }
    }
}