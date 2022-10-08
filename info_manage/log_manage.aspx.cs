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
public partial class info_manage_log_manage : System.Web.UI.Page
{
    public DB_Help dbhelp = new DB_Help();
    public static DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] == null)
        //{
        //    Response.Write("<script>alert('请先登陆！');location='../index.aspx'</script>");
        //}
        if (!IsPostBack)
        {
            load();
            Button2.Attributes.Add("onclick", "javascript:return confirm('是否确认删除？')");
        }
    }
    void load()
    {
        string sql = "select * from tb_log";
        try
        {
            ds.Clear();
            ds = dbhelp.getdsbysql(sql);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            DropDownList2.Items.Clear();
            for (int i = 0; i < GridView1.PageCount; i++)
            {
                DropDownList2.Items.Add((i + 1).ToString());
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }


    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        Label1.Text = string.Format("第 {0} 页,共 {1} 页 {2} 条记录", GridView1.PageIndex + 1, GridView1.PageCount, ds.Tables[0].Rows.Count);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)//首页
    {
        GridView1.PageIndex = 0;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)//上一页
    {
        if (GridView1.PageIndex > 0)
            GridView1.PageIndex--;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)//下一页 PageCount=4  PageIndex=4
    {
        if (GridView1.PageIndex < GridView1.PageCount - 1)
            GridView1.PageIndex++;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)//尾页
    {
        GridView1.PageIndex = GridView1.PageCount - 1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageIndex = Convert.ToInt32(DropDownList2.SelectedItem.Text) - 1;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string sql = "delete from tb_log where id = '" + id + "'";
        if (((user)Session["user"]).power == "超级管理员")
        {
            try
            {
                int i = dbhelp.ExeSql(sql);

                if (i > 0)

                    Response.Write("<script>alert('删除成功！');location='log_manage.aspx'</script>");
                else
                    Response.Write("<script>alert('删除失败！');location='log_manage.aspx'</script>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        else
            Response.Write("<script>alert('你不是超级管理员！');location='log_manage.aspx';</script>");
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ck = sender as CheckBox;//获取 CheckBox2
        if (ck != null)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
                (GridView1.Rows[i].FindControl("CheckBox1") as CheckBox).Checked = ck.Checked;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Button2.Attributes.Add("onclick","javascript:return confirm('是否确认删除？')");
        string id, sql;
        int num = 0;
        if (((user)Session["user"]).power == "超级管理员") {
            try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if ((GridView1.Rows[i].FindControl("CheckBox1") as CheckBox).Checked == true)
                {
                    id = GridView1.DataKeys[i].Value.ToString();
                    sql = "delete from tb_log where id=" + id + "";
                    dbhelp.ExeSql(sql);
                    num++;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        Response.Write("<script>alert('成功删除" + num + "条记录！');location='log_manage.aspx'</script>");
        }
        else
            Response.Write("<script>alert('你不是超级管理员！');location='log_manage.aspx';</script>");
    }

}

