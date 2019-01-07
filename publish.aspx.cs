using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class publish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userName"]==null)
        {
            Response.Redirect("Login.aspx");
        }
    }
    
      protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    protected void btnPublish_Click(object sender, EventArgs e)
    {
        if(imgGoodsPhoto.ImageUrl!="")
        {

            Response.Write("lblPageCount.Text = "+ imgGoodsPhoto.ImageUrl);
            string device = category.Items[category.SelectedIndex].Value;
            string txtName = Session["userName"].ToString();
            string nowTime= DateTime.Now.ToString();
            int valueLove = 0;
            labMessage.Visible = false;
          
          //  Response.Write("<script>alert('hello！');<script>");
           
            int P_Bool_reVal = DB.Sql_Insert("insert into T_Commodity values('" + articleName.Text+"','"+ nowTime+"','"+ txtName+"','"+ oarticleDescription.Text+"','"+imgGoodsPhoto.ImageUrl+"','"+articlePrice.Text+"','"+ valueLove+"','"+ transactionAddress.Text+"','"+ articleTel.Text+"','"+ device+"')");
            String SQL1 = "insert into T_Commodity values('" + articleName.Text + "','" + nowTime + "','" + txtName + "','" + oarticleDescription.Text + "','" + imgGoodsPhoto.ImageUrl + "','" + articlePrice.Text + "','" + valueLove + "','" + transactionAddress.Text + "','" + articleTel.Text + "','" + device + "')";
            Response.Write("SQL = "+ SQL1);
            if (P_Bool_reVal<0)
            {
                Response.Write("<script>alert('操作失败，请重试！');<script>");
            }
            else
            {
            
                Response.Write("<script>alert('操作成功！');<script>");
                articleName.Text = "";
                oarticleDescription.Text = "";
                articlePrice.Text = "";
                transactionAddress.Text = "";
                articleTel.Text = "";
                Response.Redirect("Home.aspx");
               }
        }
        else
        {
            Response.Write("<script>alert('default！');<script>");
            labMessage.Visible = true;
        }
    }
    protected void btnImageUpdload_Click(object sender, EventArgs e)
    {
        if (fulPhoto.FileName == "")
        {
            Response.Write("<script>alert(上传文件不能为空！);<script>");

            return;
        }
        string P_str_name = this.fulPhoto.FileName;
        bool P_bool_fileOK = false;
        if (fulPhoto.HasFile)
        {
            String fileExtension = System.IO.Path.GetExtension(fulPhoto.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    P_bool_fileOK = true;
                }
            }
          
        }
        if (P_bool_fileOK)
        {
            this.fulPhoto.PostedFile.SaveAs(Server.MapPath("~/Image/~") + P_str_name);
            this.imgGoodsPhoto.ImageUrl = "~/Image/~" + P_str_name;
        }
        else
        {
            Response.Write("<script>alert(请选择.gif,.png,.jpeg,.jpg,.bmp 格式的图片文件！);<script>");
        }

    }


}