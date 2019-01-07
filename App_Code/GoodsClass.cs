using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// GoodsClass 的摘要说明
/// </summary>
public class GoodsClass
{
    public GoodsClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    ///<summary>
    /// </summary>
    /// <param name="Data1">DataList控件名</param>
    /// <param name="dsTable">数据集DataSet的表的集合</param>

    public void dlBind(DataList dlName,DataTable dsTable)
    {
        if(dsTable!=null)
        {
            dlName.DataSource = dsTable.DefaultView;
            dlName.DataKeyField = dsTable.Columns[0].ToString();
            dlName.DataBind();
        }
    }

    ///<summary>
    ///
    /// </summary>
    /// <param name="IntDeplay">商品分类标志</param>
    /// <param name="dlName">绑定商品的DataList控件</param>
    /// <param name="TableNme">数据集标志</param>
    public void DLDepalyGI(int IntDeplay,DataList dlName,string TableName)
    {
        DBClass dbObj = new DBClass();
        SqlCommand myCmd = dbObj.GetCommandProc("proc_DeplayGI");
        SqlParameter Deplay = new SqlParameter("@Deplay", SqlDbType.Int, 4);
        Deplay.Value = IntDeplay;
        myCmd.Parameters.Add(Deplay);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, TableName);
        dlBind(dlName, dsTable);
    }

}