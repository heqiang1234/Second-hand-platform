<%@ Page Language="C#" AutoEventWireup="true" CodeFile="publish.aspx.cs" Inherits="publish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>

        body,html{
            background:skyblue;
        }
        .textbox{
             border:none;
       border-bottom:1px solid black;
       background:rgba(0, 0, 0, 0);
       width:60% !important;
        }
        	form{
  
   
    color:#575454;  
    width:500px;
    margin: auto;
    font-size:15px;1
    margin-top:260px;
	}

    span{
 
           width: 70px;
    display: inline-block;
    text-align: right;

    }
   #spanpsd{
   }

   div{
       margin:30px auto;
       align-content:center;
   } 
  
   #LinkButton1{
       text-decoration:none;
       color:lightblue;
        margin-left:230px;
       
   }
   #Button1{
       border-radius:2px;
       border:solid 1px;
    background-color:transparent;
    margin-left:150px;
     margin-top:10px;
   }
  body{
            background-image: url("");
        }

  .upimg{
 
  }
  .btns{
      width:100%;
      margin:0 auto;
  }
  .btns input{
      margin-left:60px;
      cursor:pointer;
  }
  
    </style>
</head>
     
<body>
    <form id="form1" runat="server">
    <div>
      
         <div>
        <span id="spanuser">商品名称:</span>
        
         <asp:TextBox ID="articleName" runat="server" CssClass="textbox" Height="30px" Width="210px"></asp:TextBox><br />
                </div>
              <div>
                    <div class="upimg">
        <span id="spanuser">上传图片:</span>
        
            <br />
       <asp:Image runat="server" ID="imgGoodsPhoto" Height="40px" Width="73px" /><br />
       <asp:Label ID="labMessage" runat="server" Text="请选择图片" ForeColor="Red" Visible="false"></asp:Label>
        <asp:FileUpload ID="fulPhoto" runat="server"/><asp:Button ID="Imagebtton" runat="server" Text="上传" Width="54px" OnClick="btnImageUpdload_Click" /><br /> 
                <br />
        </div>
        <span id="spanuser">商品详情:</span>
         <asp:TextBox ID="oarticleDescription" runat="server" CssClass="textbox" Height="30px" Width="210px"></asp:TextBox><br />
                   </div>
                   <div>
        <span id="spanuser">价格:</span>
         <asp:TextBox ID="articlePrice" runat="server" CssClass="textbox" Height="30px" Width="240px"></asp:TextBox><br />
                            </div>
                        <div>        
        <span id="spanuser">地 址:</span>
         <asp:TextBox ID="transactionAddress" runat="server" CssClass="textbox" Height="30px" Width="240px"></asp:TextBox><br />
                                 </div>
                             <div>
        <span id="spanuser">分 类:</span>
        
        <asp:DropDownList ID="category" runat="server">
            <asp:ListItem Text="手机" Value="phone" Selected="true"></asp:ListItem>
            <asp:ListItem Text="电脑" Value="computer" ></asp:ListItem>
            <asp:ListItem Text="配件" Value="accessories" ></asp:ListItem>
            <asp:ListItem Text="电器" Value="device" ></asp:ListItem>
            <asp:ListItem Text="书籍" Value="book"></asp:ListItem>
        </asp:DropDownList><br/>
                                 </div>
                                  <div>
        <span id="spanuser">联系方式:</span>
         <asp:TextBox ID="articleTel" runat="server" CssClass="textbox" Height="30px" Width="210px"></asp:TextBox><br />
                                            </div>
                                       <div class="btns">
            <asp:Button ID="Button2" runat="server" Text="确认发布" Width="270px" Height="40px" OnClick="btnPublish_Click" />
              <asp:Button style="margin-top:20px;" ID="backReturn" runat="server" Text="返回" Width="270px" Height="40px" OnClick="btnBack_Click" />
                                           </div>
    </div>
    </form>
</body>
</html>
