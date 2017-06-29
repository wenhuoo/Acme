using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acme
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie setTheme = Request.Cookies.Get("UserSelectedTheme");
            if (setTheme != null)
            {
                Page.Theme = setTheme.Value;
            }
        }
    }
}