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
public partial class info_manage_user_add : System.Web.UI.Page
{
    DB_Help dbhelp = new DB_Help();
    public static DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dr_load();
        }
    }

    public void dr_load()
    {
        try
        {
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


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (((user)Session["user"]).power == "超级管理员")
        {

            if (user.add_user(tb_name.Text, tb_password.Text, DropDownList1.SelectedValue, tb_email.Text, tb_tel.Text, tb_department.Text) == true)
            {
                log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加用户");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加用户");
                Response.Write("<script>alert('添加成功！');location='user_add.aspx'</script>");
            }
            else
                Response.Write("<script>alert('添加失败！');location='user_add.aspx'</script>");
        }
        else
            Response.Write("<script>alert('添加失败！你不是超级管理员');location='info_list.aspx';</script>");
    }
}
