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
public partial class info_manage_user_list_modify : System.Web.UI.Page
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
            ds = user.power_query();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "power";
            DropDownList1.DataValueField = "power";
            DropDownList1.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('查询数据库失败');location='user_list.aspx';</script>");
        }
    }
    public void news_load()
    {
        string sql = "select * from tb_user where id='" + Request.QueryString["id"] + "'";
        try
        {
            DataSet ds = dbhelp.getdsbysql(sql);
            Label1.Text = ds.Tables[0].Rows[0]["name"].ToString();
            tb_password.Text = ds.Tables[0].Rows[0]["password"].ToString();
            tb_email.Text = ds.Tables[0].Rows[0]["email"].ToString();
            tb_tel.Text = ds.Tables[0].Rows[0]["tel"].ToString();
            tb_department.Text = ds.Tables[0].Rows[0]["department"].ToString();
            DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["power"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (((user)Session["user"]).name == Label1.Text||((user)Session["user"]).power =="超级管理员")
            if (((user)Session["user"]).power == "超级管理员")
            {
            string sql = "update tb_user set password='" +
               tb_password.Text + "',power='" +
               DropDownList1.SelectedValue + "',tel='" +
               tb_tel.Text + "',email='" +
               tb_email.Text + "',department='" + tb_department.Text + "' where id='" + Request.QueryString["id"] + "'";
            try
            {
                int i = dbhelp.ExeSql(sql);
                if (i > 0)
                    log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "修改用户信息");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "修改用户信息");
                    Response.Write("<script>alert('修改成功！');location='user_list.aspx';</script>");
            }
            catch
            {
                Response.Write("<script>alert('修改失败！');location='user_list.aspx';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('修改失败！你不是超级管理员');location='user_list.aspx';</script>");
        }
     }

   
}

