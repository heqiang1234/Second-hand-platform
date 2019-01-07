using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class resgister : System.Web.UI.Page
{
    private bool UserNameIselgal = false;
    private bool PsdIselgal = false;
    private bool CanRegister = false;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LnkbtnCheck_Click(object sender, EventArgs e)
    {
        int value = CheckName();
        if(value==-1)
        {
            Response.Write("<script>alert('用户名存在');</script>");
            this.rUserNameText.Focus();
        }
        else if(value==2)
        {
            Response.Write("<script>alert('恭喜你！该用户尚未注册！');</script>");
            this.rUserNameText.Focus();
        }
    }
    protected void linkToLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    public int CheckName()
    {
        DB db = new DB();
        string userName = rUserNameText.Text;
        string passWd = rPsdText.Text;
        string sql= "select * from T_user where userName='" + userName + "'";
       // Response.Write(sql);
        try
        {
            int i = DB.Sql_Select(sql).Tables[0].Rows.Count;
            Response.Write(i+"   ");
            if (i > 0)
            {
                return -1;
            }
            else
            {
                return 2;
            }
        }
        catch(Exception e)
        {
            return 0;
        }
    }
    
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int value = CheckName();
        if (value == -1)
        {
            Response.Write("<script>alert('用户名存在');</script>");
        }
        else
        {
            string userName = rUserNameText.Text;
            string passWord = rPsdText.Text;
            string sql = "insert into T_User(userName,userPassword) values('"+ userName+"','"+ passWord + "')";
            DB conn = new DB();
            try 
            {
                int i= DB.Sql_Insert(sql);
                if(i==-1)
                {
                    Response.Write("<script>alert('注册失败');</script>");
                }
                else
                {
                    Response.Write("<script>alert('注册成功');location=('Login.aspx')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('注册失败');</script>");
            }





        }

    }
}