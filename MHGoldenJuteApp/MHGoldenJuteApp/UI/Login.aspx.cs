using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MHGoldenJuteApp.Models;
using System.Web.UI.WebControls;
using MHGoldenJuteApp.BLL;

namespace MHGoldenJuteApp.UI
{
    public partial class Login : System.Web.UI.Page
    {
        UserHandler aUserManager = new UserHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}