using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    int PageSize, RecordCount, PageCount, CurrentPage;
    SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchoolBuss;Persist Security Info=True;User ID=sa;Password=123456;");
    protected void Page_Load(object sender, EventArgs e)
    {
        divNewBlock.Style["display"] = "none";
        if (Session["userName"]==null)
        {
            pl1.Visible = true;
            pl2.Visible = false;
            
        }
        else
        {
            pl1.Visible = false;
            pl2.Visible = true;
            labMessage.Text = "欢迎" + Session["userName"] + "的光临";
        }
        PageSize = 9;
        if (!IsPostBack)
        {
            ListBind();
            CurrentPage = 0;
            ViewState["PageIndex"] = 0;

            //计算总共有多少记录
            RecordCount = CalculateRecord();
            lblRecordCount.Text = RecordCount.ToString();
          //  Response.Write("RecordCount = " + RecordCount);
            //计算总共有多少页
            PageCount = RecordCount / PageSize;
          
            if((RecordCount*1.0 / PageSize*1.0)> PageCount)
            {
                PageCount += 1;
            }
            lblPageCount.Text = PageCount.ToString();
          //  Response.Write("lblPageCount.Text = " + lblPageCount.Text);
            ViewState["PageCount"] = PageCount;
        }
    }
    
   protected void phone_Click(object sender, EventArgs e)
    {
        Response.Write("SAFAFASFA");
    }
   protected void buy_Button_Click(object sender, DataListCommandEventArgs e)
    {
        divNewBlock.Style["display"] = "none";
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (e.CommandName == "get")
            {
                int id1 = int.Parse(e.CommandArgument.ToString());
                string sql = "select articleTel from T_Commodity where articleId='" + id1 + "'";
                string i = DB.Sql_Select(sql).Tables[0].Rows[0][0].ToString();
                 artTel.Text = "联系方式 ："+i;
                divNewBlock.Style["display"] = "";             
           

            } else if (e.CommandName == "love")
            {
                int id1 = int.Parse(e.CommandArgument.ToString());
                string sql = "select articleLoveValue from T_Commodity where articleId='" + id1 + "'";
                int i =int.Parse( DB.Sql_Select(sql).Tables[0].Rows[0][0].ToString());
                i++;
                string ssql = "update T_Commodity set articleLoveValue='" +i+"' where articleId='" + id1 + "'";
                int j = DB.Sql_Update(ssql);
                if(j>0)
                Response.Write("<script>alert('感谢您的Skr')</script>");
                else
                 Response.Write("<script>alert('抱歉未知错误')</script>");
            }

 }

    }
    //计算总共有多少条记录
    public int CalculateRecord()
    {
        int intCount;
        string strCount = "select * from T_Commodity";
        DataSet dr=DB.Sql_Select(strCount);
       int  Count1 = dr.Tables[0].Rows.Count;
        if (Count1>0)
        {
            intCount = Count1;
        }
        else
        {
            intCount = 0;
        }
        return intCount;
    }

    ICollection CreateSource()
    {
        int StartIndex;
        //设定导入的起终地址
        StartIndex = CurrentPage * PageSize;
        string strSel = "select * from T_Commodity";
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(strSel, con);
        sda.Fill(ds, StartIndex, PageSize, "Data1");
        return ds.Tables["Data1"].DefaultView;
     }

    public void ListBind()
    {
        Data1.DataSource = CreateSource();
        Data1.DataBind();
        lbnNextPage.Enabled = true;
        lbnPrevPage.Enabled = true;
        if (CurrentPage == (PageCount - 1)) lbnNextPage.Enabled = false;
        if (CurrentPage == 0) lbnPrevPage.Enabled = false;
        lblCurrentPage.Text = (CurrentPage + 1).ToString();
    }

    protected void Search_Click_Thing(Object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");

        }
       
        string s_url;
        //  s_url = "searchLast.aspx?searchinput=" + searchInput.Text;
        s_url = "searchLast.aspx?ssearch="+ searchInput.Text;
        Response.Redirect(s_url);
    }

    public void Page_OnClick(Object sender, CommandEventArgs e)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        PageCount = (int)ViewState["PageCount"];
        string cmd = e.CommandName;
        //判断cmd，以判定翻页方向
        switch (cmd)
        {
            case "next":
                if (CurrentPage < (PageCount - 1)) CurrentPage++;
                break;
            case "prev":
                if (CurrentPage > 0) CurrentPage--;
                break;
        }
        ViewState["PageIndex"] = CurrentPage;
        ListBind();
    }

   
}