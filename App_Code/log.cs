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
using System.IO;

public class log
{
    public log()
    {
        //TODO: 在此处添加构造函数逻辑
    }
    public static bool add_log(string name, string ip, string log_time, string operate)
    {
        DB_Help dbhelp = new DB_Help();
        string sql = "insert into tb_log(name,ip,log_time,operate) values('" + name + "','" + ip + "','" + log_time + "','" + operate + "')";
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
    public static void add_log_tofile(string name, string ip, string log_time, string operate)
    {
        string LogMsg = log_time + "," + name + "在Ip地址为" + ip + "的主机上进行了" + operate + "操作.";
        string LogFileAddress = System.Configuration.ConfigurationSettings.AppSettings["logfileaddress"];
        LogFileAddress = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + LogFileAddress;
        if (!System.IO.Directory.Exists(LogFileAddress)) System.IO.Directory.CreateDirectory(LogFileAddress);
        string logFileName = LogFileAddress + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
        StreamWriter logFile = new StreamWriter(logFileName, true);
        logFile.WriteLine(LogMsg);
        logFile.Close();
    }
}
