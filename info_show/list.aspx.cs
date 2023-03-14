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
using DataAccess;
public partial class info_show_list : System.Web.UI.Page
{
    public DB_Help dbhelp = new DB_Help();
    public static DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            news_load();
        }
    }
    public void news_load()
    {
        string class_name = Request.QueryString["class_name"];
        Label1.Text = class_name;
        try
        {
            ds = news.list_query(class_name);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch
        {
            Response.Write("");
        }
        DropDownList2.Items.Clear();
        for (int i = 1; i <= GridView1.PageCount; i++)
        {
            DropDownList2.Items.Add(i.ToString());
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (GridView1.PageIndex > 0)
            GridView1.PageIndex--;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        Label2.Text = string.Format("第 {0} 页，共 {1} 页 {2} 条记录", GridView1.PageIndex + 1, GridView1.PageCount, ds.Tables[0].Rows.Count);
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (GridView1.PageIndex < GridView1.PageCount - 1)
            GridView1.PageIndex++;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = GridView1.PageCount - 1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#f5f5f5'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#fff'");
            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageIndex = Convert.ToInt32(DropDownList2.SelectedValue) - 1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}
