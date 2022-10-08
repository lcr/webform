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
            //if(Session)
            dr_load();

        }
    }

    //类别下拉菜单的查询
    public void dr_load()
    {
        string sql = "select * from tb_class";
        try
        {
            DataSet ds = new DataSet();
            ds = dbhelp.getdsbysql(sql);
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

    //通过之前的链接的点击将对应的文本对到相应的地方
    public void news_Load()
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



    ////需要登录才能添加的控制
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    if (news.add_news(tb_title.Text, ((user)Session["user"]).name, DropDownList1.SelectedValue, StringClass.cutBadStr(content1.Value), System.DateTime.Now.ToString(), RadioButtonList1.SelectedValue, Label1.Text) == true)
    //    {
    //        log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加信息");
    //        log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加信息");
    //        Response.Write("<script>alert('添加成功！');location='info_add.aspx'</script>");
    //    }
    //    else
    //        Response.Write("<script>alert('添加失败！');location='info_add.aspx'</script>");

    //    //应用了SESSION读取登陆用户名的要先登陆才可以
    //}



    //需要登录才能添加的控制
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (news.add_news(tb_title.Text,((user)Session["user"]).name, DropDownList1.SelectedValue, StringClass.cutBadStr(content1.Value), System.DateTime.Now.ToString()) == true)
        {
            log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加信息");
            log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加信息");
            Response.Write("<script>alert('添加成功！');location='info_add.aspx'</script>");
        }
        else
            Response.Write("<script>alert('添加失败！');location='info_add.aspx'</script>");

        //应用了SESSION读取登陆用户名的要先登陆才可以
    }


    //添加信息
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sql = "insert into tb_class(name) values('" + TextBox1.Text + "')";
        try
        {
            int i = dbhelp.ExeSql(sql);
            if (i > 0)
                log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加类别");
            log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "添加类别");
            Response.Write("<script>alert('添加成功');location='info_add.aspx';</script>");
        }
        catch
        {
            Response.Write("<script>alert('添加失败');location='info_add.aspx';</script>");
        }
    }




    //删除类别
    protected void Button3_Click(object sender, EventArgs e)
    {
        string sql = "delete from tb_class where id='" + DropDownList1.SelectedValue + "'";
        if (((user)Session["user"]).power == "超级管理员")
        {
            try
            {
                int i = dbhelp.ExeSql(sql);
                if (i > 0)
                    log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除类别");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除类别");
                Response.Write("<script>alert('删除成功');location='info_add.aspx';</script>");
            }
            catch
            {
                Response.Write("<script>alert('删除失败');location='info_add.aspx';</script>");
            }

        }
        else
            Response.Write("<script>alert('你不是超级管理员！');location='info_list.aspx';</script>");


    }






    //上传文件格式的控制
    //protected void Button4_Click(object sender, EventArgs e)
    //{
    //    bool fileIsValid = false;
    //    if (FileUpload1.HasFile == true)
    //    {
    //        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
    //        string[] restrictExtension = { ".jpg", ".gif", ".bmp", ".png" };
    //        for (int i = 0; i < restrictExtension.Length; i++)
    //        {
    //            if (fileExtension == restrictExtension[i])
    //            {
    //                fileIsValid = true;
    //                break;
    //            }
    //        }
    //        if (fileIsValid == true)
    //        {
    //            if (FileUpload1.PostedFile.ContentLength < 3 * 1024 * 1024)
    //            {
    //                try
    //                {
    //                    FileUpload1.SaveAs(Server.MapPath("~/upload") + "/" + FileUpload1.FileName);
    //                }
    //                catch
    //                {
    //                    Label1.Text = "上传失败！";
    //                }
    //                Label1.Text = "upload/" + FileUpload1.FileName;
    //            }
    //            else
    //            {
    //                Label1.Text = "文件大小超过3M！";
    //            }
    //        }
    //        else
    //        {
    //            Label1.Text = "图片类型不正确！";
    //        }
    //    }
    //    else
    //    {
    //        Label1.Text = "请选择图片！";
    //    }
    //}
}

