using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class CommonClass
{
    public CommonClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    ///说明： MessageBox用于在客户端弹出对话框
    ///参数:  TexMessage为对话框中显示的内容
    /// </summary>
    public string MessageBox(string TxtMessage)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "')</script>";
        return str;

    }
    ///<summary>
    ///说明： MessageBox用来早客户端弹出对话框，关闭对话框返回指定页
    ///参数： TxtMessage为对话框中显示的内容
    ///参数： Url为对话框关闭后跳转的页
   /// </summary>
    public string MessageBox(string TxtMessage,string Url)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "');location='"+Url+"';</script>";
        return str;
    }
    ///<summary>
    ///说明： MessageBox用来早客户端弹出对话框，关闭对话框返回原页
    ///参数： TxtMessage为对话框中显示的内容
    /// </summary>
    public string MessageBoxPage(string TxtMessage)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "');location='javascript:history.go(-1)';</script>";
        return str;
    }
    ///<summary>
    ///s实现随机验证码
    ///
    /// </summary>
    /// <param name="n">显示验证码的个数</param>
    /// <returns>返回生成的随机数</returns>//
    public string RandomNum(int n)
    {   
        //定义一个包括数字，大写英文字母和小写字母的字符串
        string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        //将 strchar 字符串转化为数组
        //String.Split 方法返回包含此实例 中的子字符串（由指定的char数组的元素分割）的string 数组
        string[] VcArary = strchar.Split(',');
        string VNum = "";
        //记录上次的随机数值，尽量避免产生几个相同的随机数
        int temp = -1;
        //采用一个简单的算法以保证生成随机数的不同
        Random rand = new Random();
        for(int i=1;i<n+1;i++)
        {
            if(temp!=-1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(61);
            if(temp!=-1&&temp==t)
            {
                return RandomNum(n);
            }
            temp = t;
            VNum += VcArary[t];
        }
        return VNum;
    }
}