<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>登陆</title>
     <style>
         body{
             background:skyblue;
         }


    span{
        display:block;
    }
        	form{
  
   
    color:#575454;  
    width:500px;
    margin: auto;
    font-size:15px;
    margin-top:260px;
	}

   div{
       margin:30px auto;
       align-content:center;
   } 
   .textbox{
       border:none;
       border-bottom:1px solid black;
       background:rgba(0, 0, 0, 0);
   }
  
   #Button1{
  
       border-radius:5px;
       border:solid 1px;
    background-color:transparent;
     margin-top:20px;
   }
   .loginbtn{
       cursor:pointer;
   }
   input,button,select,textarea{outline:none}
   a{
       text-decoration:none;
   }
  body{
            background-image: url("");
            font-family: -apple-system,BlinkMacSystemFont,"Segoe UI",Helvetica,Arial,sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol";
        }
  .LinkButton1:hover{
      text-decoration:underline;
  }
  

  
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="formbox">
            <div>
                <span id="spanuser">用户名:</span>
                <asp:TextBox ID="TextUserName" runat="server" class="input" CssClass="textbox" Height="30px" Width="50%"></asp:TextBox>
            </div>
 
            <div>
                <span id="spanpsd">密码:</span>
                <asp:TextBox ID="TextPassWd" runat="server" class="input" CssClass="textbox" Height="30px" Width="50%" TextMode="Password"></asp:TextBox>
                
            </div>
              <asp:Button ID="Button1" runat="server" Text="登 录" CssClass="loginbtn" Width="52%" Height="40px" OnClick="btnLogin_Click" />
            <div>

                <asp:LinkButton CssClass="LinkButton1" runat="server" OnClick="btnToRegister_Click">没有账号?点我注册</asp:LinkButton>
               <div>
                <asp:LinkButton CssClass="LinkButton1" runat="server" OnClick="btnToHome_Click">返回首页</asp:LinkButton>
                 <br />
                
            </div>
        </div>
       </div>    
    </form>
</body>
</html>
