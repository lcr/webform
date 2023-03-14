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
public partial class info_manage_user_password_modify : System.Web.UI.Page
{
    DB_Help dbhelp = new DB_Help();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        user user1 = new user();
        user1 = (user)Session["user"];
        if (user1.password == TextBox1.Text)
        {
            string sql = "update tb_user set password='" + TextBox2.Text + "' where id='" + user1.id + "'";
            try
            {
                int i = dbhelp.ExeSql(sql);
                if (i > 0)
                    log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "修改密码");
                log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "修改密码");

                Response.Write("<script>alert('修改成功！');window.close();</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('修改出现异常！');location='user_password_modify.aspx';</script>");
            }
        }
        else
            Label1.Text = "旧密码不正确";
    }
}
