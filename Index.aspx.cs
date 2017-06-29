using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acme
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string selectedTheme = Page.Theme;
                    HttpCookie userSelectedTheme =
                    Request.Cookies.Get("UserSelectedTheme");
                    if (userSelectedTheme != null)
                    {
                        selectedTheme = userSelectedTheme.Value;
                    }
                    if (!string.IsNullOrEmpty(selectedTheme) &&
                    ddlSetTheme.Items.FindByValue(selectedTheme) != null)
                    {
                        ddlSetTheme.Items.FindByValue(selectedTheme).Selected =
                        true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            
        }

        private void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie setTheme = Request.Cookies.Get("UserSelectedTheme");
            if (setTheme != null)
            {
                Page.Theme = setTheme.Value;
            }
        }

        protected void ddlSetTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HttpCookie userSeletedTheme = new HttpCookie("UserSelectedTheme");
                userSeletedTheme.Expires = DateTime.Now.AddMonths(6);
                userSeletedTheme.Value = ddlSetTheme.SelectedValue;
                Response.Cookies.Add(userSeletedTheme);
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }
    }
}