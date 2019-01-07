using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkInfo : System.Web.UI.Page
{
    String type1 = null;
    int PageSize, RecordCount, PageCount, CurrentPage;
    SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchoolBuss;Persist Security Info=True;User ID=sa;Password=123456;");
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (Session["userName"] == null)
        {
            pl1.Visible = true;
            pl2.Visible = false;

        }
        else
        {
            pl1.Visible = false;
            pl2.Visible = true;
            labMessage.Text = "欢迎" + Session["userName"] + "的光临";
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

                if ((RecordCount * 1.0 / PageSize * 1.0) > PageCount)
                {
                    PageCount += 1;
                }
                lblPageCount.Text = PageCount.ToString();
                //  Response.Write("lblPageCount.Text = " + lblPageCount.Text);
                ViewState["PageCount"] = PageCount;
            }
        }
     
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
        s_url = "searchLast.aspx?ssearch=" + searchInput.Text;
        Response.Redirect(s_url);
    }


   
    protected void buy_Button_Click(object sender, DataListCommandEventArgs e)
    {
   
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
            }
            else if (e.CommandName == "love")
            {
              
                int id1 = int.Parse(e.CommandArgument.ToString());
                string sql = "delete from T_Commodity where articleId='" + id1 + "'";
                int i = DB.Sql_Delete(sql);
                if (i > 0)
                {
                    Response.Write("<script>alert('删除成功')</script>");
                    Response.Redirect("checkInfo.aspx");
                }
                else
                    Response.Write("<script>alert('删除失败')</script>");
            }

        }

    }
    protected void Phone_Click_Thing(Object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        type1 = "phone";
        ListBind();

    }
    protected void Computer_Click_Thing(Object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        type1 = "computer";
        ListBind();

    }
    protected void Accessories_Click_Thing(Object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        type1 = "accessories";
        ListBind();

    }
    protected void Device_Click_Thing(Object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        type1 = "device";
        ListBind();

    }
    protected void Book_Click_Thing(Object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        type1 = "book";
        ListBind();

    }



    //计算总共有多少条记录
    public int CalculateRecord()
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        int intCount;
        string strCount = null;
        string usename = Session["userName"].ToString();
        if (type1 == null)
        {

            strCount = "select * from T_Commodity where articleHostName='" + usename + "'";
        }
        else
        {
            strCount = "select * from T_Commodity where articleHostName='" + usename + "' and articledevice='" + type1 + "'";
        }
        DataSet dr = DB.Sql_Select(strCount);
        int Count1 = dr.Tables[0].Rows.Count;
        if (Count1 > 0)
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
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        int StartIndex;
        //设定导入的起终地址
        StartIndex = CurrentPage * PageSize;
        string strSel = null;
        string usename = Session["userName"].ToString();
        if (type1 == null)
        {

            strSel = "select * from T_Commodity where articleHostName='" + usename + "'";
        }
        else
        {
            strSel = "select * from T_Commodity where articleHostName='" + usename + "' and articledevice='" + type1 + "'";
        }
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(strSel, con);
        sda.Fill(ds, StartIndex, PageSize, "Data1");
        return ds.Tables["Data1"].DefaultView;
    }

    public void ListBind()
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
        Data1.DataSource = CreateSource();
        Data1.DataBind();
        lbnNextPage.Enabled = true;
        lbnPrevPage.Enabled = true;
        if (CurrentPage == (PageCount - 1)) lbnNextPage.Enabled = false;
        if (CurrentPage == 0) lbnPrevPage.Enabled = false;
        lblCurrentPage.Text = (CurrentPage + 1).ToString();
    }

    public void Page_OnClick(Object sender, CommandEventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先进行登录')</script>");
            Response.Redirect("Login.aspx");
        }
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



    protected void Data1_EditCommand(object source, DataListCommandEventArgs e)
    {
        Data1.EditItemIndex = e.Item.ItemIndex;
        // e.Item.FindControl("btnUpdate")).s
       
        ListBind(); 
    }

    protected void Data1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        Data1.EditItemIndex = -1;
        ListBind();
    }

    protected void Data1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        //string artID1 = Data1.DataKeys[e.Item.ItemIndex].ToString();
        string artID1 = ((TextBox)e.Item.FindControl("artId")).Text;
        string artName1 = ((TextBox)e.Item.FindControl("artName")).Text;
        string artTime1 = DateTime.Now.ToString(); ;
        string oarticleDescription1 = ((TextBox)e.Item.FindControl("artdecription")).Text;
        string artPrice1 = ((TextBox)e.Item.FindControl("artPrice")).Text;
        string artAddress1 = ((TextBox)e.Item.FindControl("artAddress")).Text;
        string artTel1 = ((TextBox)e.Item.FindControl("artleTel")).Text;
      //  string Idd = "1";
        string sql= "update T_Commodity set articleName='"+ artName1 + "',articleTime='" + artTime1 + "',articleTel='" + artTel1 + "',oarticleDescription='" + oarticleDescription1 + "',articlePrice='" + artPrice1 + "',transactionAddress='" + artAddress1 + "'where articleId=" + artID1;
        int j = DB.Sql_Update(sql);
        Data1.EditItemIndex = -1;
        if (j > 0)
        {
            Response.Write("<script>alert('修改成功')</script>");
            ListBind();
        }
        else
            Response.Write("<script>alert('失败，抱歉未知错误')</script>");
    }
}