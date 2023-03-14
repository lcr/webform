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

public class user
{
    public string id;
    public string name;
    public string password;
    public string email;
    public string tel;
    public string power;
    public string department;
    public user()
    { }
    public user(DataSet ds)
    {
        id = ds.Tables[0].Rows[0]["id"].ToString();
        name = ds.Tables[0].Rows[0]["name"].ToString();
        password = ds.Tables[0].Rows[0]["password"].ToString();
        email = ds.Tables[0].Rows[0]["email"].ToString();
        tel = ds.Tables[0].Rows[0]["tel"].ToString();
        power = ds.Tables[0].Rows[0]["power"].ToString();
        department = ds.Tables[0].Rows[0]["department"].ToString();

    }
    public static DataSet login(string name, string password)
    {
        string sql = "select * from tb_user where name='" + name + "' and password='" + password + "'";
        DataSet ds = new DataSet();
        DB_Help dbhelp = new DB_Help();
        try
        {
            ds = dbhelp.getdsbysql(sql);
            if (ds.Tables[0].Rows.Count > 0)
                return ds;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static DataSet user_query()
    {
        string sql = "select * from tb_user";
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

    public static bool add_user(string name, string password, string email, string tel, string power, string department)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "insert into tb_user(name,password,power,tel,email,department) values('" +
            name + "','" + password + "','" + email + "','" + tel + "','" + power + "','" + department + "')";
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
    public static bool delete(string id)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "delete from tb_user where id='" + id + "'";
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

    public static DataSet power_query()
    {
        string sql = "select * from tb_power";
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
}
