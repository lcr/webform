using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.EnterpriseServices.Internal;

public partial class info_show_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            news_load();
        }
    }
    public void news_load()
    {
        string id = Request.QueryString["id"];
        DataSet ds = news.getdsbyid(id);
        Label1.Text = ds.Tables[0].Rows[0]["title"].ToString();
        Label2.Text = ds.Tables[0].Rows[0]["ptime"].ToString();
        Label3.Text = ds.Tables[0].Rows[0]["clicks"].ToString();
        Label4.Text = StringClass.htmlStr(ds.Tables[0].Rows[0]["content"].ToString());
        Label5.Text = ds.Tables[0].Rows[0]["title"].ToString();
        DetailsHyper.Text = ds.Tables[0].Rows[0]["name"].ToString();
        DetailsHyper.NavigateUrl = "list.aspx?class_name=" + ds.Tables[0].Rows[0]["name"].ToString();
        news.update_click(id);
    }
}
