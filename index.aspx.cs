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

public partial class index : System.Web.UI.Page
{
    public DB_Help dbhelp = new DB_Help();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.DataBind();
            load();
        }
    }
    //public DataSet player()
    //{
    //    return news.player();
    //}
    public void load()
    {
        GridView1.DataSource = news.index_query("Lipsum", 5);
        GridView1.DataBind();

        GridView3.DataSource = news.index_query("简中假文", 5);
        GridView3.DataBind();

        GridView4.DataSource = news.index_query("日本语", 5);
        GridView4.DataBind();

        GridView5.DataSource = news.index_query("ABCDE", 5);
        GridView5.DataBind();
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

    //登录按钮
    protected void Login_Click(object sender, EventArgs e)
    {
        DataSet ds = user.login(TextBox1.Text, TextBox2.Text);
        if (ds == null)
        {
            Response.Write("<script>alert('账号或密码错误!');location='index.aspx';</script>");
        }
        else
        {
            log.add_log_tofile(TextBox1.Text, Request.UserHostAddress, System.DateTime.Now.ToString(), "登录");
            user user1 = new user(ds);
            Session["user"] = user1;
            Response.Redirect("info_manage/main.aspx");
        }
    }



    //图片按钮
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    DataSet ds = user.login(TextBox1.Text, TextBox2.Text);
    //    if (ds == null)
    //    {
    //        Response.Write("<script>alert('用户名或密码错误!');location='index.aspx';</script>");
    //    }
    //    else
    //    {
    //        log.add_log_tofile(TextBox1.Text, Request.UserHostAddress, System.DateTime.Now.ToString(), "登录");
    //        user user1 = new user(ds);
    //        Session["user"] = user1;
    //        Response.Redirect("info_manage/main.aspx");
    //    }
    //}

    //重置按钮
    //protected void Reset_Click(object sender, EventArgs e)
    //{
    //    TextBox1.Text = "";
    //    TextBox2.Text = "";
    //}
}
