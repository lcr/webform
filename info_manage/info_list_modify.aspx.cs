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
public partial class info_manage_info_add : System.Web.UI.Page
{
    DB_Help dbhelp = new DB_Help();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dr_load();
            news_load();
        }
    }
    public void dr_load()
    {

        try
        {
            DataSet ds = new DataSet();
            ds = news.class_query();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('查询数据库失败');location='info_add.aspx';</script>");
        }
    }
    public void news_load()
    {
        string sql = "select * from tb_news where id='" + Request.QueryString["id"] + "'";
        try
        {
            DataSet ds = dbhelp.getdsbysql(sql);
            tb_title.Text = ds.Tables[0].Rows[0]["title"].ToString();

            content1.Value = StringClass.htmlStr(ds.Tables[0].Rows[0]["content"].ToString());
            DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["class_id"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //修改信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (((user)Session["user"]).power == "超级管理员")
        {
            string sql = "update tb_news set title='" + tb_title.Text + "',class_id='" +
           DropDownList1.SelectedValue + "',content='" +
           StringClass.cutBadStr(content1.Value) + "',clicks=0 where id='" + Request.QueryString["id"] + "'";
            try
            {
                int i = dbhelp.ExeSql(sql);
                if (i > 0)
                    log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "修改信息");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "修改信息");
                Response.Write("<script>alert('修改成功');location='info_list.aspx';</script>");
            }
            catch
            {
                Response.Write("<script>alert('修改失败');location='info_list.aspx';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('你不是超级管理员！');location='info_add.aspx';</script>");
        }

    }

    //添加类别
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (news.class_add(TextBox1.Text) == true)
        {
            log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加信息类别");
            log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加信息类别");
            Response.Write("<script>alert('添加成功');location='info_add.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('添加失败');location='info_add.aspx';</script>");
        }
    }

    //删除类别
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (((user)Session["user"]).power == "超级管理员")
        {
            if (news.class_del(DropDownList1.SelectedValue) == true)
            {
                log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除信息类别");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除信息类别");
                Response.Write("<script>alert('删除成功');location='info_add.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');location='info_add.aspx';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('你不是超级管理员！');location='info_add.aspx';</script>");
        }
    }
}

