<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkInfo.aspx.cs" Inherits="checkInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title> 校园二手平台</title>
    <link rel="stylesheet" type="text/css" media="screen" href="https://cdn.staticfile.org/ionicons/2.0.1/css/ionicons.min.css"/>

     <style  type="text/css">
         *{
             margin:0;
             padding:0;
         }
         body{
             font-family: -apple-system,BlinkMacSystemFont,"Segoe UI",Helvetica,Arial,sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol" !important;
         }
        li{ display:inline;margin:20px} 

        .style1 {
            /*设置 外边缘和内边缘为0px 边框底部 1px 实线 灰色  边框顶部1px 实线 灰色 */
            margin:0px;padding:0px;border-bottom:1px solid #ccc;border-top:1px solid #ccc;
         
        }
            .style1 li {
                /*display ：内行快 添补 15 30 15 30  边框右侧 1px 实线 #ddd */
                padding:15px 30px 15px 30px;border-right:1px solid #ddd;
            }
            .style1 a {
                /*a标签 字体灰色 下划线取消*/
                color:#666;
                text-decoration:none;
            }

        .style1 a:hover
        /*在a标签上盘旋时  颜色红色*/
        {color:red;}
       a{
           text-decoration:none;
       }
       .header{
           height:110px;
           color:black;
           background:skyblue;
           line-height:110px;
           padding-left:200px;
       }
       .search{
           margin:20px auto;
           width:60%;
       }
       .searchbtn{
               margin-left: -5px;
    background: #46A3FF;
    text-align: center;
    width: 200px;
    height: 30px;
    /* border: 1px solid black; */
    box-sizing: border-box;
    color: white;
    border: none;
    position: relative;
    top: 1px;
       }

       .type li{
           margin-right:120px;
       }
       .type{
           text-align:center;
       }
       .pagelist{
           width:1200px;
           margin:80px auto;
           display:flex;
           flex-direction:row;
           justify-content:flex-end;
       }
       .bdmain{
           width:1200px;margin:60px auto;
       }
       .proup{
             width:300px;
           height:300px;
           position:fixed;
           top:0;
           bottom:0;
           left:0;
           right:0;
           margin:auto;
           background:#f0f0f0;
           border:1px solid black;
           border-radius:5px;
           
       }

       .btn{
           height:25px;
           line-height:25px;
           margin-left:-20px;
           cursor:pointer;
     border-radius:5px;
       border:solid 1px;
    background-color:transparent;
     margin-top:20px;
    font-size:14px;
    width:200px;
       }
    </style>
</head>
   
<body>
    <form id="form1" runat="server">
      <div class="header" >
         <a href="Home.aspx" ></a>
        <ul>
            <li><a href="Home.aspx" style="font-size:30px">首页</a></li>   
            <li><a href="https://ai.taobao.com/?pid=mm_30170492_7332231_66370565" style="font-size:30px">爱淘宝</a></li> 
            <li><a href="RankList.aspx" style="font-size:30px">Rank榜</a></li>
             <li style="float:right"><asp:Panel ID="pl1" runat="server" style="display:inline;" Width="174px">       
                  <a href="Login.aspx">登录</a>
                  <a href="resgister.aspx">注册</a>
              </asp:Panel>  <asp:Panel style="display:inline;" ID="pl2" runat="server">
                 <a href="checkInfo.aspx"> <asp:label id="labMessage" runat="server" ></asp:label></a>
                  <a href="Login.aspx">退出登录</a>
                 </asp:Panel></li>
        </ul>
         <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
              
       </div>
       
           <div class="search">
                <asp:TextBox style="width:60%;height:30px;box-sizing:border-box;"   runat="server" id="searchInput" ></asp:TextBox> 
                <asp:Button class="searchbtn" Text="搜索"  runat="server"  OnClick="Search_Click_Thing"></asp:Button>
                  <a href="publish.aspx" ><i class="icon ion-plus-circled"> </i>添加物品</a>
            </div>
         <div>
           <div style="margin:0 auto" class="category fl">
            <ul class="type">
                
                <li>
                     <asp:Button class="searchbtn" Text="手机"  runat="server"  OnClick="Phone_Click_Thing"></asp:Button>
                   
                </li>
            
                <li>
                    <asp:Button class="searchbtn" Text="电脑"  runat="server"  OnClick="Computer_Click_Thing"></asp:Button>
                   
                </li>
            
                <li>
                    <asp:Button class="searchbtn" Text="配件"  runat="server"  OnClick="Accessories_Click_Thing"></asp:Button>
                  
                </li>
            
                <li>
                    <asp:Button class="searchbtn" Text="电器"  runat="server"  OnClick="Device_Click_Thing"></asp:Button>
                  
                </li>
            
                <li>
                    <asp:Button class="searchbtn" Text="书籍"  runat="server"  OnClick="Book_Click_Thing"></asp:Button>
                
                </li>
     
            </ul>
        </div>
            
                </div> 
       
       
         
        <asp:DataList ID="Data1" runat="server" OnCancelCommand="Data1_CancelCommand" OnEditCommand="Data1_EditCommand" OnUpdateCommand="Data1_UpdateCommand"
             onItemCommand="buy_Button_Click" CellSpacing="3" CellPadding="0" RepeatColumns="3" RepeatDirection="Horizontal"  HorizontalAlign="center" CssClass="bdmain">
            <ItemTemplate > 
               <table style="height:62px" >
                   <tr>
                       <td rowspan="5" style="width:29px">
                       <asp:Image ID="artImg" style="width:200px;height:150px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"articleImage")%>' runat ="server" />
                           </td>
                       <td colspan="2">
                           </td>
                       </tr>
                     <tr>

                      <td>
                        商品编号：
                      </td>
                       <td>
                           <asp:Label ID="artId" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"articleId")%>'></asp:Label>
                       </td>
                   </tr>
                   <tr>

                      <td>
                        商品名：
                      </td>
                       <td>
                           <asp:Label ID="artName" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"articleName")%>'></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="编辑" />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:LinkButton ID="delete_Click" CommandName="love" OnClientClick="return Delete_Confirm()" runat="server"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"articleId")%>'>删除</asp:LinkButton>
                           <asp:Button ID="btnUpdate" runat ="server" style="margin-right:20px;display:none;" CommandName="update" Text="更新"/>
                           <asp:Button ID="btnCancel" runat ="server" style="margin-right:20px;display:none;"  CommandName="cancel" Text="取消"/>
                            </td>
                 </tr> 
           </table>       
       </ItemTemplate>
               <EditItemTemplate>
                   <table style="width:400px;height:200px">
                       <tr>
                       <td rowspan="5" style="width:29px">
                       <asp:Image ID="artImg" style="width:200px;height:150px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"articleImage")%>' runat ="server" />
                           </td>
                       <td colspan="2">
                           </td>
                       </tr>
                   <tr>
                      <td>
                        商品名：
                      </td>
                       <td>
                            <asp:TextBox ID="artId" runat="server" style="display:none" Text='<%# DataBinder.Eval(Container.DataItem,"articleId")%>'></asp:TextBox>
                        <asp:TextBox ID="artName" runat="server"   Text='<%# DataBinder.Eval(Container.DataItem,"articleName")%>'></asp:TextBox>

                       </td>
                   </tr>
                  
                     <tr>

                      <td>
                          商品发布时间：
                      </td>
                       <td>
                          <asp:Label ID="artTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"articleTime")%>'></asp:Label>
                       </td>
                   </tr>
                     <tr>

                      <td>
                          商品描述：
                      </td>
                       <td>
                         <asp:TextBox ID="artdecription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"oarticleDescription")%>'></asp:TextBox>

                       </td>
                   </tr>
                      <tr>

                      <td>
                          商品价格：
                      </td>
                       <td>
                          <asp:TextBox ID="artPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"articlePrice")%>'></asp:TextBox>

                       </td>
                   </tr>
                   <tr>
                      <td>
                          交易地址：
                      </td>
                       <td>
                         <asp:TextBox ID="artAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"transactionAddress")%>'></asp:TextBox>
                       </td>
                   </tr>
                       <tr>
                      <td>
                          联系方式：
                      </td>
                       <td>
                         <asp:TextBox ID="artleTel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"articleTel")%>'></asp:TextBox>
                       </td>
                   </tr>
                       <tr>
                <td>
                    <asp:LinkButton ID="btnCancel" runat="server" Text="取消" CommandName="Cancel"></asp:LinkButton>
                    <asp:LinkButton ID="btnUpdate" runat="server" Text="更新" CommandName="Update"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"articleId")%>'></asp:LinkButton>
                </td>
            </tr>
                </table>
        </EditItemTemplate>
           <EditItemStyle BackColor="Teal" ForeColor="White" />  
        </asp:DataList>
           <div class="pagelist">
            <asp:LinkButton ID="lbnPrevPage"  Text="上一页" CommandName="prev" OnCommand="Page_OnClick"
            runat="server" />
        <asp:LinkButton ID="lbnNextPage" Text="下一页" CommandName="next" OnCommand="Page_OnClick"
            runat="server" />
        共有<asp:Label ID="lblRecordCount" ForeColor="red" runat="server" />条记录 当前为<asp:Label
            ID="lblCurrentPage" ForeColor="red" runat="server" />/<asp:Label ID="lblPageCount"
                ForeColor="red" runat="server" />页      
        </div>  
         
    </form>
   
</body>
    <script type="text/javascript">
        function Delete_Confirm()
        {
            var message = confirm("确认删除该物品吗？")
            if(message==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>
</html>

