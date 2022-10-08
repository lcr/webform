using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccess;
public class news
{
    public string title;
    public string publisher;
    public string class_id;
    public string content;
    public string ptime;
    public string clicks;


    ///列表查询
    public static DataSet index_query(string class_name, int num)
    {
        string sql = "select top " + num + "id, title,ptime from View_news where name='" + class_name + "' order by id desc ";
        //string sql = "select top " + num + " title,ptime from tb_news,tb_class where tb_news.class_id=tb_class.id
        DataSet ds = new DataSet();
        DB_Help dbhelp = new DB_Help();
        try
        {
            return dbhelp.getdsbysql(sql);
        }
        catch
        {
            return null;
        }
    }
    public static DataSet index_query2(int num)
    {
        string sql = "select  top " + num + " id,title,ptime from tb_news  order by id desc";
        DataSet ds = new DataSet();
        DB_Help dbhelp = new DB_Help();

        try
        {
            return dbhelp.getdsbysql(sql);
        }
        catch
        {
            return null;
        }
    }

    //列表查询
    public static DataSet list_query(string class_name)
    {
        string sql = "select id,title,ptime from View_news where name='" + class_name + "' order by id desc";
        DataSet ds = new DataSet();
        DB_Help dbhelp = new DB_Help();
        try
        {
            return dbhelp.getdsbysql(sql);
        }
        catch
        {
            return null;
        }
    }

    public static DataSet getdsbyid(string id)
    {
        string sql = "select * from View_news where id='" + id + "'";
        DataSet ds = new DataSet();
        DB_Help dbhelp = new DB_Help();

        try
        {
            return dbhelp.getdsbysql(sql);
        }
        catch
        {
            return null;
        }
    }

    ///信息查询
    public static DataSet query()
    {
        string sql = "select  tb_news.id,title,publisher,tb_class.name,clicks,ptime from tb_news,tb_class where tb_news.class_id=tb_class.id ";
        DataSet ds = new DataSet();
        DB_Help dbhelp = new DB_Help();

        try
        {
            return dbhelp.getdsbysql(sql);
        }
        catch
        {
            return null;
        }
    }

    //信息添加
    public static bool add_news(string title, string publisher, string class_id, string content, string ptime)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "insert into tb_news(title,publisher,class_id,content,ptime,clicks) values('" + title + "','" +
                             publisher + "','" + class_id + "','" + content + "','" + ptime + "','0')";
        try
        {
            dbhelp.ExeSql(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    //信息修改
    public static bool modify_new(string title, string publisher, string class_id, string content, string ptime, string clicks)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "update into tb_news(title,publisher,class_id,content,ptime,clicks) values('" + title + "','" +
         publisher + "','" + class_id + "','" + content + "','" + ptime + "','" + clicks + "')";
        try
        {
            dbhelp.ExeSql(sql);
            return true;

        }
        catch
        {
            return false;
        }
    }

    //信息删除
    public static bool delete(string id)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "delete from tb_news where id='" + id + "'";
        try
        {
            dbhelp.ExeSql(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    //点击次数
    public static bool update_click(string id)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "update  tb_news set clicks=clicks+1 where id='" + id + "'";
        try
        {
            dbhelp.ExeSql(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    //类别查询
    public static DataSet class_query()
    {
        string sql = "select * from tb_class ";
        DataSet ds = new DataSet();
        DB_Help dbhelp = new DB_Help();
        try
        {
            return dbhelp.getdsbysql(sql);
        }
        catch
        {
            return null;
        }
    }

    //类别添加
    public static bool class_add(string name)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "insert into tb_class(name) values '" + name + "'";
        try
        {
            dbhelp.ExeSql(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    //类别删除
    public static bool class_del(string name)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "delete from tb_class where id='" + name + "'";
        try
        {
            dbhelp.ExeSql(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    //图片新闻
    //public static DataSet player()
    //{
    //    string sql = "select top 4 * from tb_news where ispic='是' order by id desc";
    //    DataSet ds = new DataSet();
    //    DB_Help dbhelp = new DB_Help();
    //    try
    //    {
    //        return dbhelp.getdsbysql(sql);
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}


    ////信息添加
    //public static bool add_news(string title, string publisher, string class_id, string content, string ptime, string ispic, string picurl)
    //{
    //    DB_Help dbhelp = new DB_Help();
    //    string sql;
    //    if (ispic == "是")
    //    {
    //        sql = "insert into tb_news(title,publisher,class_id,content,ptime,clicks,ispic,picurl) values('" + title + "','" +
    //           publisher + "','" + class_id + "','" + content + "','" + ptime + "','0','是','" + picurl + "')";
    //    }
    //    else
    //    {
    //        sql = "insert into tb_news(title,publisher,class_id,content,ptime,clicks,ispic,picurl) values('" + title + "','" +
    //               publisher + "','" + class_id + "','" + content + "','" + ptime + "','0','否','')";
    //    }
    //    try
    //    {
    //        dbhelp.ExeSql(sql);
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}

}
