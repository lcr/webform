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
public partial class info_manage_info_list : System.Web.UI.Page
{
    public DB_Help dbhlep = new DB_Help();
    public static DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            news_load();
            drlistbind();
        }
    }

    public void news_load()
    {
        ds = news.query();
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
    protected void drlistbind()
    {
        ds = news.class_query();
        try
        {
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "name";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();
            ListItem li = new ListItem("--所有--", "all");
            DropDownList2.Items.Insert(0, li);
        }
        catch
        {
            Response.Write("<script>alert('查询数据库失败');location='info_add.aspx';</script>");
        }

    }
    //--所有--
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql;
        if (DropDownList2.SelectedValue == "all")
        {
            sql = "select  tb_news.id,title,publisher,tb_class.name,clicks,ptime from tb_news,tb_class where tb_news.class_id=tb_class.id ";
        }
        else
        {
            sql = "select  tb_news.id,title,publisher,tb_class.name,clicks,ptime from tb_news,tb_class where tb_news.class_id=tb_class.id and tb_class.id='" + DropDownList2.SelectedValue + "'";
        }
        try
        {
            GridView1.Attributes.Add("BorderColor", "#1278d5");
            ds = dbhlep.getdsbysql(sql);
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

    //搜索查询
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sql;
        if (DropDownList2.SelectedValue == "all")
            sql = "select  tb_news.id,title,publisher,tb_class.name,clicks,ptime from tb_news,tb_class where tb_news.class_id=tb_class.id and title like '%" + TextBox1.Text + "%'";
        else
            sql = "select  tb_news.id,title,publisher,tb_class.name,clicks,ptime from tb_news,tb_class where tb_news.class_id=tb_class.id and tb_class.id='" + DropDownList2.SelectedValue + "'and (title like '%" + TextBox1.Text + "%')";
        try
        {
            GridView1.Attributes.Add("BorderColor", "#1278d5");
            ds = dbhlep.getdsbysql(sql);
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



    //首页
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    //上一页
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (GridView1.PageIndex > 0)
        {
            GridView1.PageIndex--;
        }
        else
        {
            GridView1.PageIndex = 0;
        }
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    //跳转到第几页
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageIndex = Convert.ToInt32(DropDownList1.SelectedValue) - 1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
  
    }

    //下一页
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue == "all")
        {
            if (GridView1.PageIndex < GridView1.PageCount - 1)
            {
                GridView1.PageIndex++;
            }
            else
            {
                GridView1.PageIndex = GridView1.PageCount - 1;
            }
            news_load();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            if (GridView1.PageIndex < GridView1.PageCount - 1)
            {
                GridView1.PageIndex++;
            }
            else
            {
                GridView1.PageIndex = GridView1.PageCount - 1;
            }
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }   
    }

    //尾页
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = GridView1.PageCount - 1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }





    //信息删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (((user)Session["user"]).power == "超级管理员")
        {
            if (news.delete(id) == true)
            {
                log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除信息");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除信息");
                Response.Write("<script>alert('删除成功');location='info_list.aspx';</script>");
            }
            else
                Response.Write("<script>alert('删除失败');location='info_list.aspx';</script>");
        }
        else
            Response.Write("<script>alert('删除失败！你不是超级管理员');location='info_list.aspx';</script>");
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ck = sender as CheckBox;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            (GridView1.Rows[i].FindControl("CheckBox1") as CheckBox).Checked = ck.Checked;
        }
    }

    //批量删除按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id, sql;
        int num = 0;
        if (((user)Session["user"]).power == "超级管理员")
        {
            try
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if ((GridView1.Rows[i].FindControl("CheckBox1") as CheckBox).Checked == true)
                    {
                        id = GridView1.DataKeys[i].Value.ToString();
                        sql = "delete from tb_news where id='" + id + "'";
                        dbhlep.ExeSql(sql);
                        num++;
                    }
                }
                log.add_log_tofile(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除信息");
                log.add_log(((user)Session["user"]).name, Request.UserHostAddress, System.DateTime.Now.ToString(), "删除信息");
                Response.Write("<script>alert('成功删除" + num + "条记录。');location='info_list.aspx';</script>");
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
        else
        {
            Response.Write("<script>alert('删除失败！你不是超级管理员');location='info_list.aspx';</script>");
        }
    }

    //页数
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        Label1.Text = string.Format("第 {0} 页，共 {1} 页 {2} 条记录", GridView1.PageIndex + 1, GridView1.PageCount, ds.Tables[0].Rows.Count);
    }

}


