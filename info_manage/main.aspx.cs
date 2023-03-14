using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class info_manage_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Write("<script>alert('请先登录');location='../index.aspx';</script>");
        }
        else
        {
            Label2.Text = "当前用户：" + ((user)Session["user"]).name;
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../index.aspx");
    }
}
