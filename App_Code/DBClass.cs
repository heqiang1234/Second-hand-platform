using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// DBClass 的摘要说明
/// </summary>
public class DBClass
{
    public DBClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }/// <summary>
    /// 
    /// </summary>
    /// <returns>返回SqlConnection对象</returns>
    public SqlConnection GetConnection()
    {
        string myStr = ConfigurationManager.AppSettings["ConnectionName"].ToString();
        SqlConnection myConn = new SqlConnection(myStr);
        return myConn;
    }
    ///<summary>
    ///执行SQL，返回受影响的行数
    /// 
    /// </summary>
    /// <param name="myCmd">执行SQL命令的SqlCommand对象</param>
    public void ExecNonQuery(SqlCommand myCmd)
    {
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if(myCmd.Connection.State==ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }
    ///|<summary>
    ///返回查询结果中的第一行第一列的值
    /// </summary>
    /// <param name="myCmd></param>
    /// <returns>执行SQL语句中的SqlCommand对象</returns>
    public string ExecScalar(SqlCommand myCmd)
    {
        string strSql;
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            // myCmd.ExecuteNonQuery();
            strSql = Convert.ToString(myCmd.ExecuteScalar());
            return strSql;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }

    ///|<summary>
    ///返回查询结果中的第一行第一列的值
    /// </summary>
    /// 
    /// <returns>执行SQL语句中的SqlCommand对象</returns>
    public DataTable GetDataSet(SqlCommand myCmd,string TableName)
    {
        SqlDataAdapter adapt;
        DataSet ds = new DataSet();
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            // myCmd.ExecuteNonQuery();
            adapt = new SqlDataAdapter(myCmd);
            adapt.Fill(ds, TableName);
            return ds.Tables[TableName];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }

    ///|<summary>
    ///返回查询结果中的第一行第一列的值
    /// </summary>
    /// <param name="strProcName"></param>
    /// <returns>执行SQL语句中的SqlCommand对象</returns>
    public SqlCommand GetCommandProc(string strProcName)
    {
        SqlConnection myConn =GetConnection();
        SqlCommand myCmd = new SqlCommand();
        myCmd.Connection = myConn;
        myCmd.CommandText = strProcName;
        myCmd.CommandType = CommandType.StoredProcedure;
        return myCmd;
    }

}