using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["validacion"] == null || (int)Session["permiso"] != 0)
        {
            Response.Redirect("Login.aspx");
        }

        int validacion;
        validacion = (int)Session["validacion"];
        if (validacion != 1)
        {
            HttpContext.Current.Server.Transfer("Login.aspx");
        }
    }
}
