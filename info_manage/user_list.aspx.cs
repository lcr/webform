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

public partial class info_manage_news_list : System.Web.UI.Page
{
    public DB_Help dbhlep = new DB_Help();
    public static DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            user_load();
            
        }
    }
    public void user_load()
    {
        
        ds = user.user_query();
        try
        {
            GridView1.Attributes.Add("BorderColor", "#1278d5");     
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('数据库操作出错！');windows.close();</script>");
        }
        DropDownList1.Items.Clear();
        for (int i = 1; i <= GridView1.PageCount; i++)
        {
            DropDownList1.Items.Add(i.ToString());
        }
    }
    
   
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageIndex =Convert.ToInt32(DropDownList1.SelectedValue)-1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        Label1.Text=string.Format("第 {0} 页,共 {1} 页 {2} 条记录",GridView1.PageIndex+1,GridView1.PageCount,ds.Tables[0].Rows.Count);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = GridView1.PageCount-1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if(GridView1.PageIndex>0)
            GridView1.PageIndex --;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (GridView1.PageIndex<GridView1.PageCount-1)
            GridView1.PageIndex++;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (((user)Session["user"]).power=="超级管理员")
        {
            if (user.delete(id) == true)
            {
                log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除用户");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除用户");
                Response.Write("<script>alert('删除成功');location='user_list.aspx';</script>");
            }
            else
                Response.Write("<script>alert('删除失败');location='user_list.aspx';</script>");
        }
        else
            Response.Write("<script>alert('你不是超级管理员！');location='user_list.aspx';</script>");
    
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
