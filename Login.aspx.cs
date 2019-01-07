using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DB db = new DB();
        string userName = TextUserName.Text.Trim();
        string passWord = TextPassWd.Text.Trim();
        string sql = "select * from T_User where userName='" + userName + "'and  userPassword='" + passWord + "'";
        int i = DB.Sql_Select(sql).Tables[0].Rows.Count;
        if (i > 0)
        {
            Session["userName"] = userName;
            Response.Redirect("Home.aspx");
        }
        else
        {
            Response.Write("<script>alert('登录失败! 请返回查找原因');location=('Login.aspx')</script>");
        }
    }
    protected void btnToRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Resgister.aspx");
    }
    
        protected void btnToHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
}