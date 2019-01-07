using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public  class DB 
{
    //private static string connStr = sqlcommDBHelper.connDb();
    //private static string connStr = WebConfigurationManager.ConnectionStrings["testdbConnectionString3"].ConnectionString.ToString();
    private static string connStr= "Data Source=127.0.0.1;Initial Catalog=SchoolBuss;User Id=sa;Password=123456;";
    private static string connStr1 = "Data Source=localhost; Initial Catalog=master; Integrated Security=True;";

    public DB()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region myExecuteReader
    /// <summary>
    /// 用于执行普通查询，并以DataTable离线的方式返回所查询的结果集
    /// </summary>
    /// <param name="cmdText">查询的SQL语句或存储过程名称</param>
    /// <param name="cmdType">Command的操作类型</param>
    /// <param name="cmdParameters">操作所使用到的参数集合</param>
    /// <returns></returns>
    public static DataTable myExecuteReader(string cmdText, CommandType cmdType, List<SqlParameter> cmdParameters)
    {
        //创建连接对象
        SqlConnection conn = new SqlConnection();
        //设置连接字符串
        conn.ConnectionString = connStr;
        //打开连接
        conn.Open();
        //创建命令对象
        SqlCommand comm = new SqlCommand();
        //设置命令对象的数据源连接对象，
        //进行的操作（Sql语句，表明，存储过程）
        //以及操作的类型
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        //添加操作所用的参数
        if (cmdParameters != null)
        {
            foreach (SqlParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }

        //创建离线内存表
        DataTable dataTable = new DataTable();

        SqlDataReader datareader = comm.ExecuteReader();

        dataTable.Load(datareader);

        //创建Adapter对象，并利用查询命令的返回结果填充离线内存表
        //SqlDataAdapter ad = new SqlDataAdapter();
        //ad.SelectCommand = comm;
        //ad.Fill(dataTable);
        //释放相关资源
        datareader.Close();
        comm.Parameters.Clear();
        comm.Dispose();
        conn.Close();
        conn.Dispose();
        //返回结果集
        return dataTable;
    }
    #endregion

    #region ExecuteReader
    /// <summary>
    /// 用于执行普通查询，并以DataTable离线的方式返回所查询的结果集
    /// </summary>
    /// <param name="cmdText">查询的SQL语句或存储过程名称</param>
    /// <param name="cmdType">Command的操作类型</param>
    /// <param name="cmdParameters">操作所使用到的参数集合</param>
    /// <returns></returns>
    public static DataTable ExecuteReader(string cmdText, CommandType cmdType, List<SqlParameter> cmdParameters)
    {
        //创建连接对象
        SqlConnection conn = new SqlConnection();
        //设置连接字符串
        conn.ConnectionString = connStr;
        //打开连接
        conn.Open();
        //创建命令对象
        SqlCommand comm = new SqlCommand();
        //设置命令对象的数据源连接对象，
        //进行的操作（Sql语句，表明，存储过程）
        //以及操作的类型
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        //添加操作所用的参数
        if (cmdParameters != null)
        {
            foreach (SqlParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        //创建离线内存表
        DataTable dataTable = new DataTable();
        //创建Adapter对象，并利用查询命令的返回结果填充离线内存表
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = comm;
        ad.Fill(dataTable);
        //释放相关资源
        comm.Parameters.Clear();
        comm.Dispose();
        conn.Close();
        conn.Dispose();
        //返回结果集
        return dataTable;
    }
    #endregion

    #region ExecuteNonQuery
    /// 用于普通的无事务要求单条编辑操作
    /// </summary>
    /// <param name="cmdText"></param>
    /// <param name="cmdType"></param>
    /// <param name="cmdParameters"></param>
    /// <returns></returns>
    public static Boolean ExecuteNonQuery(string cmdText, CommandType cmdType, List<SqlParameter> cmdParameters)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = connStr;
        conn.Open();
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        if (cmdParameters != null)
        {
            foreach (SqlParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        //执行数据编辑操作
        try
        {
            comm.ExecuteNonQuery();
        }
        catch
        {

            return false;
        }
        finally
        {
            comm.Parameters.Clear();
            comm.Dispose();
            conn.Close();
            conn.Dispose();
        }
        return true;
    }
    #endregion

    #region ExecuteScalar
    /// <summary>
    /// 封装ExecuteScalar,用来返回查询结果中的第一行第一列
    /// </summary>
    /// <param name="cmdText">操作语句</param>
    /// <param name="cmdType">操作类型</param>
    /// <param name="cmdParameters">操作参数</param>
    /// <returns></returns>
    public static object ExecuteScalar(string cmdText, CommandType cmdType, List<SqlParameter> cmdParameters)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = connStr;
        conn.Open();
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        if (cmdParameters != null)
        {
            foreach (SqlParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        //执行ExecuteScalar方法
        object val = comm.ExecuteScalar();
        comm.Dispose();
        conn.Close();
        conn.Dispose();
        return val;
    }
    #endregion

    #region ExecuteDataSetReader
    /// <summary>
    /// 返回DataSet值
    /// </summary>
    /// <param name="cmdText"></param>
    /// <param name="cmdType"></param>
    /// <param name="cmdParameters"></param>
    /// <returns></returns>
    public static DataSet ExecuteDataSetReader(string cmdText, CommandType cmdType, List<SqlParameter> cmdParameters)
    {
        //创建连接对象
        SqlConnection conn = new SqlConnection(DB.connStr);
        //设置连接字符串
        //conn.ConnectionString = connStr;
        //打开连接
        conn.Open();
        //创建命令对象
        SqlCommand comm = new SqlCommand();
        //设置命令对象的数据源连接对象，
        //进行的操作（Sql语句，表明，存储过程）
        //以及操作的类型
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        //添加操作所用的参数
        if (cmdParameters != null)
        {
            foreach (SqlParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        //创建离线内存表
        DataSet ds = new DataSet();
        //创建Adapter对象，并利用查询命令的返回结果填充离线内存表
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = comm;
        ad.Fill(ds);
        //释放相关资源
        comm.Parameters.Clear();
        comm.Dispose();
        conn.Close();
        conn.Dispose();
        //返回结果集
        return ds;
    }
    #endregion

    #region CreateParameters
    /// <summary>
    /// 创建参数对象
    /// </summary>
    /// <param name="paraName">参数名称</param>
    /// <param name="paraType">参数类型</param>
    /// <param name="paraValue">参数的值</param>
    /// <returns></returns>
    public static SqlParameter CreateParameters(string paraName, DbType paraType, string paraValue)
    {
        SqlParameter para = new SqlParameter();
        para.ParameterName = paraName;
        para.DbType = paraType;
        para.Value = paraValue;
        return para;
    }
    #endregion

    #region  Sql数据库操作

    /// <summary>
    /// 插入
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int Sql_Insert(string str)
    {
        //创建连接对象
        SqlConnection Sqlconn = new SqlConnection(DB.connStr);
        //打开连接
        Sqlconn.Open();
        SqlTransaction tx = Sqlconn.BeginTransaction();
        try
        {
            SqlCommand thisCommand = Sqlconn.CreateCommand();
            thisCommand.Transaction = tx;
            thisCommand.CommandText = str;
            int i = thisCommand.ExecuteNonQuery();
            tx.Commit();
            return i;
        }
        catch (Exception ex)
        {
            tx.Rollback();
            return -1;
            throw new Exception("404");//我想产生不同的错误，对应web.config中的statusCode,该如何实现？
            //Err.

            //MessageBox.Show("Sql数据插入出错！" + ex.Message);

        }
        finally
        {
            Sqlconn.Close();
        }
    }


    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int Sql_Update(string str)
    {
        //创建连接对象
        SqlConnection Sqlconn = new SqlConnection(DB.connStr);
        //打开连接
        Sqlconn.Open();
        SqlTransaction tx = Sqlconn.BeginTransaction();
        try
        {
            SqlCommand thisCommand = new SqlCommand(str, Sqlconn);
            thisCommand.Transaction = tx;
            int i = thisCommand.ExecuteNonQuery();
            tx.Commit();
            return i;
        }
        catch (Exception ex)
        {
            tx.Rollback();
            return -1;
            throw new Exception("404");
        }
        finally
        {
            Sqlconn.Close();
        }
    }

    /// <summary>
    /// 判断某一项在数据库中是否存在
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static object Sql_Judge(string str)
    {
        //创建连接对象
        SqlConnection Sqlconn = new SqlConnection(DB.connStr);
        //打开连接
        Sqlconn.Open();
        try
        {
            SqlCommand com = new SqlCommand(str, Sqlconn);
            return com.ExecuteScalar();
        }
        catch (Exception ex)
        {
            return -1;
            throw new Exception("404");
        }
        finally
        {
            Sqlconn.Close();
        }
    }


    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int Sql_Delete(string str)
    {
        //创建连接对象
        SqlConnection Sqlconn = new SqlConnection(DB.connStr);
        //打开连接
        Sqlconn.Open();
        SqlTransaction tx;
        tx = Sqlconn.BeginTransaction();
        try
        {
            SqlCommand thisCommand = new SqlCommand(str, Sqlconn);
            thisCommand.Transaction = tx;
            int i = thisCommand.ExecuteNonQuery();
            tx.Commit();
            return i;
        }
        catch (Exception ex)
        {
            tx.Rollback();
            return -1;
            throw new Exception("404");
        }
        finally
        {
            Sqlconn.Close();
        }
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static DataSet Sql_Select(string str)
    {
        //创建连接对象
        SqlConnection Sqlconn = new SqlConnection(DB.connStr);
        try
        {

            //打开连接
            Sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(str, Sqlconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            return null;
            throw new Exception("404");

        }
        finally
        {
            Sqlconn.Close();
        }
    }

    #endregion
}

