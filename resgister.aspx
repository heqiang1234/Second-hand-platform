<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resgister.aspx.cs" Inherits="resgister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>注册</title>
    <style>

        body,html{
            background:skyblue;
            height:100%;
        }
        	form{
  
   
    color:#575454;  
    width:500px;
    font-size:15px;
     position:fixed;
      top:0;
      bottom:0;
      left:0;
      right:0;
             margin:auto;
                height:600px;
	}

.label{
    color:red;
    font-size:12px;
    font-family:'Lucida Console';
}
       
input.Tb{
    border-radius:5px;
 
}
 .textbox{
       border:none;
       border-bottom:1px solid black;
       background:rgba(0, 0, 0, 0);
   }

 #LinkButton1{
     margin-top:10px;
     vertical-align: bottom;
     margin-left:15px;
 }

input,button,select,textarea{outline:none}
 
     .user_name{ width:240px; height:38px; line-height:38px; border:1px solid #000; background:url(login_img_03.png)  no-repeat left center; padding-left:30px; }  
.user_name input{ width:230px; height:36px; border:1px solid #fff;color:#666;}  
.password{ width:240px; height:38px; line-height:38px; border:1px solid #dfe1e8; background:url(login_img_09.png)  no-repeat left center; padding-left:30px; }  
.password input{ width:230px; height:36px; border:1px solid #000;color:#666;}  
.transButton {
    border:solid 1px;
    background-color:transparent;
}
#btnRegister{
    cursor:pointer;
     border-radius:5px;
       border:solid 1px;
    background-color:transparent;
     margin-top:20px;
    font-size:14px;
}
#linkToLogin{
    text-decoration:none
}
#linkToLogin:hover{
    text-decoration:underline;
}
#ckItem{
    text-decoration:none
}
body{
       background-image:url("rbg.jpg");
       font-family: -apple-system,BlinkMacSystemFont,"Segoe UI",Helvetica,Arial,sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol";
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
                <h2>欢迎注册OA</h2>
      
                <h3>每一天，记录美。</h3>
       
                
       
                <br />
 
       <asp:ScriptManager ID="ScriptManager1" runat="server">
               </asp:ScriptManager> 
       
     
           <asp:TextBox runat="server" ID="rUserNameText"   Height="40px" Width="60%" CssClass="textbox"></asp:TextBox> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LnkbtnCheck_Click">检测用户名是否存在</asp:LinkButton>
 
               <br />  
         
                <br />
            <asp:TextBox runat="server" ID="rPsdText"  TextMode="Password" CssClass="textbox" Height="40px" Width="60%"></asp:TextBox>
            <br /> 
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          
           
             </asp:UpdatePanel>
            <br /> 
           <asp:TextBox runat="server" ID="rrPsdText"  TextMode="Password" CssClass="textbox" Height="40px" Width="60%"  ></asp:TextBox>
           
         <br />
         <table>
            <tr style="height:40px;vertical-align:bottom;">
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />
                </td>
                <td>
                     <span>同意</span>  <asp:LinkButton runat="server" Text="服务条款" ID="ckItem"></asp:LinkButton>
                </td>
               
                <td style="width:20%;">
                                           
                                                                
                           
                </td>
                <td>
                  
                    <asp:LinkButton ID="linkToLogin" runat="server" Text="已有账号?登录" OnClick="linkToLogin_Click"></asp:LinkButton>
                </td>
             </tr>
        </table>
        
           
      
 
       
 
        <asp:Button ID="btnRegister" runat="server" CssClass="transButton" Height="49px" Text="注    册" Width="62%" OnClick="btnRegister_Click" />
            <asp:Button ID="Button1" runat="server" CssClass="transButton" Height="49px" Text="返    回" Width="62%" OnClick="btnReturn_Click" />     
    
    </form>
    </body>
        <script type="text/javascript">  
        function watermark(id, value) {  
            var obj = document.getElementById(id);
            var isPsdMode = false;
            if (obj.type == "password")
            {
                obj.type = "text";
                isPsdMode = true;
            }
            obj.value = value;  
            obj.style.color = "Gray";
            //获取焦点事件  
            obj.onfocus = function () {
                
                obj.style.color = "Black";
                if (isPsdMode)
                {
                    obj.type = "password";
                }
                if (this.value == value) {  
                    this.value = '';  
                }  
            };  
            //失去焦点事件  
            obj.onblur = function () {  
                if (this.value == "") {
                    if (isPsdMode) {
                        obj.type = "text";
                    }
                    this.value = value;  
                    obj.style.color = "Gray";
                }  
                else {  
                    obj.style.color = "Black";
                }  
            };  
        }  
        window.onload = function () {  
            var arr = [{ 'id': 'rUserNameText', 'desc': '用户名' }, { 'id': 'rPsdText', 'desc': '密码' },{ 'id': 'rrPsdText', 'desc': '确认密码' }];
            for (var i = 0; i < arr.length; i++) {  
                watermark(arr[i].id, arr[i].desc);  
            }  
        };  
    </script> 
</html>