// ***************************************************************************
// 项目名称：Bblives.Utils 
// 版权信息: Copyright (C), 2003-2008, 南京古方科技有限公司
// 版本信息: 3.0
// 程序名称：DBUtils
// 功能描述：数据库操作方式，针对Sql Server 2000。
// 编写时间：2003-05-05
// 编写人员：cloudy
// 备    注：
// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃   作者  ┃   时间   ┃  版本   ┃              说明              ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20040514 ┃  V1.0   ┃ 新建项目。                     ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20060119 ┃  V2.0   ┃ 整体调整。                     ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20070113 ┃  V3.0   ┃ 转换为C#。                     ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20080808 ┃  V3.1   ┃ 调整函数，增加了动态数组的处理 ┃
// ┃         ┃          ┃         ┃ 方式，并且实现了数据类作为函数 ┃
// ┃         ┃          ┃         ┃ 参数的方法，为了考虑以前的项目 ┃
// ┃         ┃          ┃         ┃ ，故保留了前期的函数多态的实现 ┃
// ┃         ┃          ┃         ┃ 方式。                         ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
// ***************************************************************************

using System;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Xml;
using System.Collections;

namespace GuFun.Utils
{
  /// <summary>
  /// 设置数据库操作对象，提供公用的数据库接口
  /// </summary>
  public sealed class DBUtils
  {
    #region -Utility Methods-

    /// <summary>
    /// 获得系统设置的数据库类型（App.Config或者Web.Config）
    /// </summary>
    /// <returns>数据库类型</returns>
    public static string GetDatabaseType()
    {
      return ConfigurationManager.AppSettings["DatabaseType"].ToUpper();
    }

    /// <summary>
    /// 获取系统设置的数据库连接字
    /// </summary>
    /// <returns>数据库连接字</returns>
    public static string GetConnectionString()
    {
      // 读取数据库连接字的关键字
      string sConnection = ConfigurationManager.AppSettings["ConnectionString"];

      if (String.IsNullOrEmpty(sConnection))
        return String.Empty;

      // 根据数据库连接字的关键字读取配置文件中的数据库连接字
      string connection = Crypto.DecryptoString(ConfigurationManager.AppSettings[sConnection]);
      if (String.IsNullOrEmpty(connection))
        return String.Empty;

      return Crypto.ConfigSecret(connection);
    }

    /// <summary>
    /// 根据系统默认的数据库连接字获得数据库连接对象
    /// </summary>
    /// <returns>数据库连接对象</returns>
    public static SqlConnection GetConnection()
    {
      string databasetype = GetDatabaseType();
      string connection = GetConnectionString();

      return GetConnection(connection, databasetype);
    }

    /// <summary>
    /// 根据指定的数据库连接字获得数据库连接对象
    /// </summary>
    /// <param name="connectionString">指定的数据库连接字</param>
    /// /// <param name="databasetype">数据库类型</param>
    /// <returns>数据库连接对象</returns>
    public static SqlConnection GetConnection(string connection, string databasetype)
    {
      SqlConnection conn = new SqlConnection(connection);

      if (conn != null)
        conn.Open();

      return conn;
    }

    /// <summary>
    /// 判断数据库连接对象的状态，并打开数据库连接
    /// </summary>
    /// <param name="connection">需要打开数据库连接的对象</param>
    public static void OpenConnection(SqlConnection connection)
    {
      if ((connection != null) && (connection.State == ConnectionState.Closed))
      {
        connection.Open();
      }
    }

    /// <summary>
    /// 获取数据库操作COMMAND对象
    /// </summary>
    /// <returns>数据库COMMAND对象</returns>
    public static SqlCommand GetCommand()
    {
      return new SqlCommand();
    }

    /// <summary>
    /// 获取数据库ADAPTER对象
    /// </summary>
    /// <returns>生成的ADAPTER对象</returns>
    public static SqlDataAdapter GetAdapter()
    {
      return new SqlDataAdapter();
    }

    /// <summary>
    /// 根据COMMAND对象获取数据库ADAPTER对象
    /// </summary>
    /// <param name="command">COMMAND对象</param>
    /// <returns>生成的ADAPTER对象</returns>
    public static SqlDataAdapter GetAdapter(SqlCommand command)
    {
      return new SqlDataAdapter(command);
    }

    /// <summary>
    /// 清除和释放数据库连接对象
    /// </summary>
    /// <param name="connection">数据连接对象</param>
    /// <param name="command">数据库命令对象</param>
    public static void SetDispose(SqlConnection connection, SqlCommand command)
    {
      if (command != null)
        command.Dispose();

      if (connection != null)
      {
        connection.Close();
        connection.Dispose();
      }
    }

    #endregion Utility Methods

    #region -Parameters Methods-

    public static ArrayList ConvertParameters(params SqlParameter[] parameters)
    {
      ArrayList paras = new ArrayList();

      if (parameters != null)
      {
        foreach (SqlParameter p in parameters)
        {
          paras.Add(p);
        }
      }

      return paras;
    }

    public static ArrayList ConvertParameters(params object[] parameters)
    {
      ArrayList paras = new ArrayList();

      if (parameters != null)
      {
        foreach (object p in parameters)
        {
          paras.Add(p);
        }
      }

      return paras;
    }

    public static ArrayList ConvertParameters(params string[] parameters)
    {
      ArrayList paras = new ArrayList();

      if (parameters != null)
      {
        foreach (string p in parameters)
        {
          paras.Add(p);
        }
      }

      return paras;
    }

    /// <summary>
    /// 将参数数组加入到指定的SqlCommand中
    /// </summary>
    /// <param name="command">要加入参数的SqlCommand</param>
    /// <param name="parameters">SqlParameter数组</param>
    public static void AddParameters(SqlCommand command, SqlParameter[] parameters)
    {
      AddParameters(command, ConvertParameters(parameters));
    }

    /// <summary>
    /// 将动态参数数组加入到指定的SqlCommand中
    /// </summary>
    /// <param name="command">要加入参数的SqlCommand</param>
    /// <param name="parameters">SqlParameter动态数组数组</param>
    public static void AddParameters(SqlCommand command, ArrayList parameters)
    {
      for (int i = 0; i < parameters.Count; i++)
      {
        SqlParameter p = (SqlParameter)parameters[i];

        AddParameters(command, p);
      }
    }

    /// <summary>
    /// 将参数加入到指定的SqlCommand中
    /// </summary>
    /// <param name="command">要加入参数的SqlCommand</param>
    /// <param name="parameter">SqlParameter参数</param>
    public static void AddParameters(SqlCommand command, SqlParameter parameter)
    {
      // 检查参数的输送方式判断是否为空，则给参数赋值为DBNull
      if ((parameter.Direction == ParameterDirection.InputOutput) && (parameter.Value == null))
      {
        parameter.Value = DBNull.Value;
      }

      // 对于日期型，C#和Sql Server的最小值不一样，故设置为空
      if ((parameter.DbType == DbType.DateTime) && ((DateTime)parameter.Value == DateTime.MinValue))
      {
        parameter.Value = DBNull.Value;
      }

      command.Parameters.Add(parameter);
    }

    /// <summary>
    /// 将值数组分配给指定的参数数组
    /// </summary>
    /// <param name="parameters">参数数组</param>
    /// <param name="values">值数组</param>
    public static void AssignParameterValues(SqlParameter[] parameters, object[] values)
    {
      AssignParameterValues(ConvertParameters(parameters), ConvertParameters(values));
    }

    /// <summary>
    /// 将值动态数组分配给指定的参数动态数组
    /// </summary>
    /// <param name="parameters">参数动态数组</param>
    /// <param name="values">值动态数组</param>
    public static void AssignParameterValues(ArrayList parameters, ArrayList values)
    {
      if ((parameters == null) || (values == null))
      {
        return;
      }

      // 参数数组和值数组的长度必须一直
      if (parameters.Count != values.Count)
      {
        throw new ArgumentException("参数数组和值数组的长度不一致！");
      }

      for (int i = 0; i < parameters.Count; i++)
      {
        AssignParameterValue((SqlParameter)parameters[i], (object)values[i]);
      }
    }

    /// <summary>
    /// 将值分配给指定的参数
    /// </summary>
    /// <param name="parameter">参数</param>
    /// <param name="value">值</param>
    public static void AssignParameterValue(SqlParameter parameter, object value)
    {
      if ((parameter == null) || (value == null))
      {
        return;
      }

      parameter.Value = value;
    }

    /// <summary>
    /// 根据指定的参数名称给Command的参数对象赋值
    /// </summary>
    /// <param name="command">数据库命令对象</param>
    /// <param name="name">参数名称</param>
    /// <param name="value">参数的值</param>
    public static void AssignParameterValue(SqlCommand command, string name, object value)
    {
      if (String.IsNullOrEmpty(name) || (value == null))
      {
        return;
      }

      for (int i = 0; i < command.Parameters.Count; i++)
      {
        if (command.Parameters[i].ParameterName == name)
        {
          command.Parameters[i].Value = value;
          break;
        }
      }

    }

    /// <summary>
    /// 根据指定的参数名称给Command的参数对象赋值
    /// </summary>
    /// <param name="command">数据库命令对象</param>
    /// <param name="names">参数名称数组</param>
    /// <param name="values">参数的值数组</param>
    public static void AssignParameterValues(SqlCommand command, string[] names, object[] values)
    {
      AssignParameterValues(command, ConvertParameters(names), ConvertParameters(values));
    }

    /// <summary>
    /// 根据指定的参数名称给Command的参数对象赋值
    /// </summary>
    /// <param name="command">数据库命令对象</param>
    /// <param name="names">参数名称动态数组</param>
    /// <param name="values">参数的值动态数组</param>
    public static void AssignParameterValues(SqlCommand command, ArrayList names, ArrayList values)
    {
      if ((names == null) || (values == null))
      {
        return;
      }

      if (names.Count != values.Count)
        throw new ArgumentException("参数数组和值数组的长度不一致！");

      for (int i = 0; i < names.Count; i++)
      {
        AssignParameterValue(command, names[i] as string, (object)values[i]);
      }
    }

    /// <summary>
    /// 输出参数值设置
    /// </summary>
    /// <param name="command">数据库命令对象</param>
    /// <param name="parameters">参数数组</param>
    private static void OutPutParameters(SqlCommand command, SqlParameter[] parameters)
    {
      OutPutParameters(command, ConvertParameters(parameters));
    }

    /// <summary>
    /// 输出参数值设置
    /// </summary>
    /// <param name="command">数据库命令对象</param>
    /// <param name="parameters">参数动态数组</param>
    private static void OutPutParameters(SqlCommand command, ArrayList parameters)
    {
      for (int i = 0; i < parameters.Count; i++)
      {
        // 判断参数的输出方式
        SqlParameter p = (SqlParameter)parameters[i];

        if ((p.Direction == ParameterDirection.InputOutput) && (p.Direction == ParameterDirection.Output))
        {
          p.Value = command.Parameters[p.ParameterName].Value;
        }
      }
    }

    /// <summary>
    /// 设置输入参数
    /// </summary>
    /// <param name="name">参数名称</param>
    /// <param name="type">参数类型</param>
    /// <param name="size">参数长度</param>
    /// <param name="value">参数值</param>
    /// <returns>生成的SqlParameter参数</returns>
    public static SqlParameter MakeInParam(string name, SqlDbType type, int size, object value)
    {
      return MakeParam(name, type, size, ParameterDirection.Input, value);
    }

    /// <summary>
    /// 设置输入参数
    /// </summary>
    /// <param name="name">参数名称</param>
    /// <param name="type">参数类型</param>
    /// <param name="value">参数值</param>
    /// <returns>生成的SqlParameter参数</returns>
    public static SqlParameter MakeInParam(string name, SqlDbType type, object value)
    {
      return MakeParam(name, type, 0, ParameterDirection.Input, value);
    }

    /// <summary>
    /// 设置输出参数
    /// </summary>
    /// <param name="name">参数名称</param>
    /// <param name="type">参数类型</param>
    /// <param name="size">参数长度</param>
    /// <returns>生成的SqlParameter参数</returns>
    public static SqlParameter MakeOutParam(string name, SqlDbType type, int size)
    {
      return MakeParam(name, type, size, ParameterDirection.Output, null);
    }

    /// <summary>
    /// 设置输出参数
    /// </summary>
    /// <param name="name">参数名称</param>
    /// <param name="type">参数类型</param>
    /// <returns>生成的SqlParameter参数</returns>
    public static SqlParameter MakeOutParam(string name, SqlDbType type)
    {
      return MakeParam(name, type, 0, ParameterDirection.Output, null);
    }

    /// <summary>
    /// 设置参数
    /// </summary>
    /// <param name="name">参数名称</param>
    /// <param name="type">参数类型</param>
    /// <param name="size">参数长度</param>
    /// <param name="direction">参数输出输入方向</param>
    /// <param name="value">参数值</param>
    /// <returns>生成的SqlParameter参数</returns>
    public static SqlParameter MakeParam(string name, SqlDbType type, int size, ParameterDirection direction, object value)
    {
      SqlParameter param = new SqlParameter();

      param.ParameterName = name;
      param.SqlDbType = type;

      if ((size > 0) || (direction != ParameterDirection.ReturnValue))
      {
        param.Size = size;
      }

      param.Direction = direction;

      if (!(direction == ParameterDirection.Output && value == null))
      {
        param.Value = value;
      }

      return param;
    }

    #endregion Parameters Methods

    #region -Prepared Methods-

    /// <summary>
    /// 数据库命令对象准备
    /// </summary>
    /// <param name="command">将要进行准备的数据库命令对象</param>
    /// <param name="text">Sql或者Procedure</param>
    /// <param name="parameters">准备参数数组</param>
    private static void PrepareCommand(SqlCommand command, string text, SqlParameter[] parameters)
    {
      PrepareCommand(command, null, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 数据库命令对象准备
    /// </summary>
    /// <param name="command">将要进行准备的数据库命令对象</param>
    /// <param name="text">Sql或者Procedure</param>
    /// <param name="parameters">准备参数动态数组</param>
    private static void PrepareCommand(SqlCommand command, string text, ArrayList parameters)
    {
      PrepareCommand(command, null, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 数据库命令对象准备
    /// </summary>
    /// <param name="command">将要进行准备的数据库命令对象</param>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="text">Sql或者Procedure</param>
    /// <param name="parameters">准备参数数组</param>
    private static void PrepareCommand(SqlCommand command, SqlConnection connection, string text, SqlParameter[] parameters)
    {
      PrepareCommand(command, connection, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 数据库命令对象准备
    /// </summary>
    /// <param name="command">将要进行准备的数据库命令对象</param>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="text">Sql或者Procedure</param>
    /// <param name="parameters">准备参数动态数组</param>
    private static void PrepareCommand(SqlCommand command, SqlConnection connection, string text, ArrayList parameters)
    {
      PrepareCommand(command, connection, CommandType.Text, text, parameters);
    }

    /// <summary>
    ///数据库命令对象准备
    /// </summary>
    /// <param name="command">将要进行准备的数据库命令对象</param>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="type">解释命令字符串类型</param>
    /// <param name="text">Sql或者Procedure</param>
    /// <param name="parameters">准备参数数组</param>
    private static void PrepareCommand(SqlCommand command, SqlConnection connection, CommandType type, string text, SqlParameter[] parameters)
    {
      PrepareCommand(command, connection, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    ///数据库命令对象准备
    /// </summary>
    /// <param name="command">将要进行准备的数据库命令对象</param>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="type">解释命令字符串类型</param>
    /// <param name="text">Sql或者Procedure</param>
    /// <param name="parameters">准备参数动态数组</param>
    private static void PrepareCommand(SqlCommand command, SqlConnection connection, CommandType type, string text, ArrayList parameters)
    {
      if (connection != null)
      {
        OpenConnection(connection);

        // 为数据库命令对象指定数据库连接对象
        command.Connection = connection;
      }

      // 设置命令字符串
      command.CommandText = text;

      // 设置命令字符串类型
      command.CommandType = type;

      // 设置命令参数
      if (parameters != null)
      {
        AddParameters(command, parameters);
      }

      return;
    }



    #endregion Prepared Methods

    #region -Check Methods-

    /// <summary>
    /// 判断对象是否为空值
    /// </summary>
    /// <param name="value">需要进行判断的对象</param>
    /// <returns>如果为空值返回true，否则返回false</returns>
    public static bool CheckDBNull(object value)
    {
      return (value is DBNull);
    }

    /// <summary>
    /// 判断字符串是否为空值，并转换成字符串
    /// </summary>
    /// <param name="value">需要进行判断的对象</param>
    /// <returns>判断后的字符串</returns>
    public static string CheckNullString(object value)
    {
      if (value is DBNull)
      {
        return String.Empty;
      }

      return (string)value;
    }

    /// <summary>
    /// 判断字符串是否为空值
    /// </summary>
    /// <param name="value">需要进行判断的字符串</param>
    /// <returns>判断后的对象</returns>
    public static object CheckNull(string value)
    {
      if (String.IsNullOrEmpty(value))
      {
        return System.DBNull.Value;
      }

      return value;
    }

    /// <summary>
    /// 判断对象是否为空值
    /// </summary>
    /// <param name="value">需要进行判断的对象</param>
    /// <returns>判断后的对象</returns>
    public static string CheckNull(object value)
    {
      if ((value == null) || (value == System.DBNull.Value))
        return String.Empty;

      return value.ToString();
    }

    /// <summary>
    /// 判断对象是否为空值
    /// </summary>
    /// <param name="value">需要进行判断的对象</param>
    /// <returns>判断后的对象</returns>
    public static string CheckNull(DBNull value)
    {
      return String.Empty;
    }

    /// <summary>
    /// 转换日期格式
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string GetSafeSqlDateTimeFormat(DateTime date)
    {
      return date.ToString(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern);
    }

    /// <summary>
    /// 转换为安全日期
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetSafeSqlDateTime(DateTime date)
    {

      if (date < DateTime.MinValue)
        return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
      else if (date > DateTime.MaxValue)
        return (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue;

      return date;
    }

    /// <summary>
    /// 转换为安全整型
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static int GetSafeSqlInt(int i)
    {

      if (i <= (int)System.Data.SqlTypes.SqlInt32.MinValue)
        return (int)System.Data.SqlTypes.SqlInt32.MinValue + 1;
      else if (i >= (int)System.Data.SqlTypes.SqlInt32.MaxValue)
        return (int)System.Data.SqlTypes.SqlInt32.MaxValue - 1;

      return i;

    }

    /// <summary>
    /// 转换为安全短整型
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static short GetSafeSqlShort(short i)
    {

      if (i <= (short)System.Data.SqlTypes.SqlInt16.MinValue)
        return (short)(System.Data.SqlTypes.SqlInt16.MinValue + 1);
      else if (i >= (short)System.Data.SqlTypes.SqlInt16.MaxValue)
        return (short)(System.Data.SqlTypes.SqlInt16.MaxValue - 1);
      return i;

    }

    /// <summary>
    /// 转换为安全浮点型
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static double GetSafeSqlDouble(double i)
    {

      if (i <= Convert.ToDouble(System.Data.SqlTypes.SqlDecimal.MinValue))
        return Convert.ToDouble(System.Data.SqlTypes.SqlDecimal.MinValue) + 1;
      else if (i >= Convert.ToDouble(System.Data.SqlTypes.SqlDecimal.MaxValue))
        return Convert.ToDouble(System.Data.SqlTypes.SqlDecimal.MaxValue) - 1;
      return i;

    }

    #endregion Check Methods

    #region -ExecuteNonQuery Methods-

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(string text)
    {
      return ExecuteNonQuery(null, null, SqlOperation.Internal, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(CommandType type, string text)
    {
      return ExecuteNonQuery(null, null, SqlOperation.Internal, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(string text, params SqlParameter[] parameters)
    {
      return ExecuteNonQuery(null, null, SqlOperation.Internal, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数动态数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(string text, ArrayList parameters)
    {
      return ExecuteNonQuery(null, null, SqlOperation.Internal, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="pParameters">执行参数数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(CommandType type, string text, params SqlParameter[] parameters)
    {
      return ExecuteNonQuery(null, null, SqlOperation.Internal, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="pParameters">执行参数动态数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(CommandType type, string text, ArrayList parameters)
    {
      return ExecuteNonQuery(null, null, SqlOperation.Internal, type, text, parameters);
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, string text)
    {
      return ExecuteNonQuery(connection, command, SqlOperation.External, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, CommandType type, string text)
    {
      return ExecuteNonQuery(connection, command, SqlOperation.External, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, string text, params SqlParameter[] parameters)
    {
      return ExecuteNonQuery(connection, command, SqlOperation.External, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数动态数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, string text, ArrayList parameters)
    {
      return ExecuteNonQuery(connection, command, SqlOperation.External, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, CommandType type, string text, params SqlParameter[] parameters)
    {
      return ExecuteNonQuery(connection, command, SqlOperation.External, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, CommandType type, string text, ArrayList parameters)
    {
      return ExecuteNonQuery(connection, command, SqlOperation.External, type, text, parameters);
    }


    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="sqloperation">事务操作方式</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, params SqlParameter[] parameters)
    {
      return ExecuteNonQuery(connection, command, sqloperation, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="SqlOper">数据库操作自定义对象</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlTool oper)
    {
      if (oper == null)
        return -1;

      if (oper.Connection == null)
        return ExecuteNonQuery(oper.Type, oper.Sql, oper.Parameters);

      return ExecuteNonQuery(oper.Connection, oper.Command, oper.Operation, oper.Type, oper.Sql, oper.Parameters);
    }

    /// <summary>
    /// 执行数据库命令
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">预准备的数据库命令对象</param>
    /// <param name="sqloperation">事务操作方式</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">执行参数数组</param>
    /// <returns>数据库命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, ArrayList parameters)
    {
      if ((sqloperation == SqlOperation.External) && ((connection == null) || (command == null)))
      {
        throw new ArgumentNullException("当事务在外部提交时，缺少数据库连接和命令对象！");
      }

      SqlConnection conn = connection;
      SqlCommand cmd = command;

      try
      {
        if (sqloperation == SqlOperation.Internal)
        {
          conn = GetConnection();
          cmd = GetCommand();
        }

        // 预准备数据库命令对象
        PrepareCommand(cmd, conn, type, text, parameters);

        if (sqloperation == SqlOperation.Internal)
        {
          cmd.Transaction = cmd.Connection.BeginTransaction();
        }

        // 执行数据库命令
        int retval = cmd.ExecuteNonQuery();

        // 如果执行的是存储过程，则获取返回值
        if (type == CommandType.StoredProcedure)
          OutPutParameters(cmd, parameters);

        // 清除参数以再次使用
        cmd.Parameters.Clear();

        if (sqloperation == SqlOperation.Internal)
          cmd.Transaction.Commit();

        return retval;
      }
      catch
      {
        if (sqloperation == SqlOperation.Internal)
          cmd.Transaction.Rollback();

        throw;
      }
      finally
      {
        // 如果事务为内部提交，则释放数据库连接和命令对象
        if (sqloperation == SqlOperation.Internal)
          SetDispose(conn, cmd);
      }
    }

    #endregion ExecuteNonQuery Methods

    #region -ExecuteDataSet Methods-

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(string text)
    {
      return ExecuteDataSet(null, null, SqlOperation.Internal, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(CommandType type, string text)
    {
      return ExecuteDataSet(null, null, SqlOperation.Internal, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(string text, SqlParameter[] parameters)
    {
      return ExecuteDataSet(null, null, SqlOperation.Internal, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(string text, ArrayList parameters)
    {
      return ExecuteDataSet(null, null, SqlOperation.Internal, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteDataSet(null, null, SqlOperation.Internal, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(CommandType type, string text, ArrayList parameters)
    {
      return ExecuteDataSet(null, null, SqlOperation.Internal, type, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(SqlConnection connection, SqlCommand command, string text)
    {
      return ExecuteDataSet(connection, command, SqlOperation.External, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(SqlConnection connection, SqlCommand command, CommandType type, string text)
    {
      return ExecuteDataSet(connection, command, SqlOperation.External, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(SqlConnection connection, SqlCommand command, string text, SqlParameter[] parameters)
    {
      return ExecuteDataSet(connection, command, SqlOperation.External, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(SqlConnection connection, SqlCommand command, string text, ArrayList parameters)
    {
      return ExecuteDataSet(connection, command, SqlOperation.External, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(SqlConnection connection, SqlCommand command, SqlOperation sqloperation, CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteDataSet(connection, command, sqloperation, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="SqlOper">数据库操作自定义对象</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(SqlTool oper)
    {
      if (oper == null)
        return new DataSet();

      if (oper.Connection == null)
        return ExecuteDataSet(oper.Type, oper.Sql, oper.Parameters);

      return ExecuteDataSet(oper.Connection, oper.Command, oper.Operation, oper.Type, oper.Sql, oper.Parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果集
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果集</returns>
    public static DataSet ExecuteDataSet(SqlConnection connection, SqlCommand command, SqlOperation sqloperation, CommandType type, string text, ArrayList parameters)
    {
      if ((sqloperation == SqlOperation.External) && ((connection == null) || (command == null)))
      {
        throw new ArgumentNullException("当事务在外部提交时，缺少数据库连接和命令对象！");
      }

      SqlConnection conn = connection;
      SqlCommand cmd = command;

      try
      {
        DataSet ds = new DataSet();

        if (sqloperation == SqlOperation.Internal)
        {
          conn = GetConnection();
          cmd = GetCommand();
        }

        // 预准备数据库命令对象
        PrepareCommand(cmd, conn, type, text, parameters);

        // 读取数据集
        SqlDataAdapter da = GetAdapter(cmd);

        // 填充数据
        da.Fill(ds);

        // 清除参数以再次使用
        cmd.Parameters.Clear();

        return ds;
      }
      catch
      {
        throw;
      }
      finally
      {
        // 如果事务为内部提交，则释放数据库连接和命令对象
        if (sqloperation == SqlOperation.Internal)
          SetDispose(conn, cmd);
      }
    }

    #endregion ExecuteDataSet Methods

    #region -ExecuteDataTable Methods-

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(string text)
    {
      return ExecuteDataTable(null, null, SqlOperation.Internal, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">t数据库命令字符串</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(CommandType type, string text)
    {
      return ExecuteDataTable(null, null, SqlOperation.Internal, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(string text, SqlParameter[] parameters)
    {
      return ExecuteDataTable(null, null, SqlOperation.Internal, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(string text, ArrayList parameters)
    {
      return ExecuteDataTable(null, null, SqlOperation.Internal, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteDataTable(null, null, SqlOperation.Internal, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(CommandType type, string text, ArrayList parameters)
    {
      return ExecuteDataTable(null, null, SqlOperation.Internal, type, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, string text)
    {
      return ExecuteDataTable(connection, command, SqlOperation.External, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, CommandType type, string text)
    {
      return ExecuteDataTable(connection, command, SqlOperation.External, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, string text, SqlParameter[] parameters)
    {
      return ExecuteDataTable(connection, command, SqlOperation.External, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, string text, ArrayList parameters)
    {
      return ExecuteDataTable(connection, command, SqlOperation.External, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteDataTable(connection, command, SqlOperation.External, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, CommandType type, string text, ArrayList parameters)
    {
      return ExecuteDataTable(connection, command, SqlOperation.External, type, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteDataTable(connection, command, sqloperation, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="SqlOper">数据库操作自定义对象</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlTool oper)
    {
      if (oper == null)
        return new DataTable();

      if (oper.Connection == null)
        return ExecuteDataTable(oper.Type, oper.Sql, oper.Parameters);

      return ExecuteDataTable(oper.Connection, oper.Command, oper.Operation, oper.Type, oper.Sql, oper.Parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据结果表
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据结果表</returns>
    public static DataTable ExecuteDataTable(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, ArrayList parameters)
    {
      if ((sqloperation == SqlOperation.External) && ((connection == null) || (command == null)))
      {
        throw new ArgumentNullException("当事务在外部提交时，缺少数据库连接和命令对象！");
      }

      SqlConnection conn = connection;
      SqlCommand cmd = command;

      try
      {
        DataTable dt = new DataTable();

        if (sqloperation == SqlOperation.Internal)
        {
          conn = GetConnection();
          cmd = GetCommand();
        }

        // 预准备数据库命令对象
        PrepareCommand(cmd, conn, type, text, parameters);

        SqlDataAdapter da = GetAdapter(cmd);

        // 读取数据集
        da.Fill(dt);

        // 清除参数以再次使用
        cmd.Parameters.Clear();

        // 返回数据表
        return dt;
      }
      catch
      {
        throw;
      }
      finally
      {
        // 如果事务为内部提交，则释放数据库连接和命令对象
        if (sqloperation == SqlOperation.Internal)
          SetDispose(conn, cmd);
      }
    }

    #endregion ExecuteDataTable Methods

    #region -ExecuteDatareader Methods-

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(string text)
    {
      return ExecuteReader(null, null, SqlOperation.Internal, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(CommandType type, string text)
    {
      return ExecuteReader(null, null, SqlOperation.Internal, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(string text, SqlParameter[] parameters)
    {
      return ExecuteReader(null, null, SqlOperation.Internal, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(string text, ArrayList parameters)
    {
      return ExecuteReader(null, null, SqlOperation.Internal, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteReader(null, null, SqlOperation.Internal, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(CommandType type, string text, ArrayList parameters)
    {
      return ExecuteReader(null, null, SqlOperation.Internal, type, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, string text)
    {
      return ExecuteReader(connection, command, SqlOperation.External, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, CommandType type, string text)
    {
      return ExecuteReader(connection, command, SqlOperation.External, type, text, new ArrayList());
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, string text, SqlParameter[] parameters)
    {
      return ExecuteReader(connection, command, SqlOperation.External, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, string text, ArrayList parameters)
    {
      return ExecuteReader(connection, command, SqlOperation.External, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteReader(connection, command, SqlOperation.External, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, CommandType type, string text, ArrayList parameters)
    {
      return ExecuteReader(connection, command, SqlOperation.External, type, text, parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteReader(connection, command, sqloperation, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="SqlOper">数据库操作自定义对象</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlTool oper)
    {
      if (oper == null)
        return null;

      if (oper.Connection == null)
        return ExecuteReader(oper.Type, oper.Sql, oper.Parameters);

      return ExecuteReader(oper.Connection, oper.Command, oper.Operation, oper.Type, oper.Sql, oper.Parameters);
    }

    /// <summary>
    /// 执行数据查询返回数据读取对象
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据读取对象</returns>
    public static SqlDataReader ExecuteReader(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, ArrayList parameters)
    {
      if ((sqloperation == SqlOperation.External) && ((connection == null) || (command == null)))
      {
        throw new ArgumentNullException("当事务在外部提交时，缺少数据库连接和命令对象！");
      }

      SqlConnection conn = connection;
      SqlCommand cmd = command;
      SqlDataReader dr;

      try
      {
        if (sqloperation == SqlOperation.Internal)
        {
          conn = GetConnection();
          cmd = GetCommand();
        }

        // 预准备数据库命令对象
        PrepareCommand(cmd, conn, type, text, parameters);

        if (sqloperation == SqlOperation.Internal)
        {
          dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        else
        {
          dr = cmd.ExecuteReader();
        }

        // 清除参数以再次使用
        cmd.Parameters.Clear();

        return dr;
      }
      catch
      {
        throw;
      }
      finally
      {
        // 如果事务为内部提交，则释放数据库连接和命令对象
        //if (sqloperation == SqlOperation.Internal) 
        //  SetDispose(conn, cmd);
      }
    }

    #endregion ExecuteDatareader Methods

    #region -ExecuteScalar Methods-

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(string text)
    {
      return ExecuteScalar(null, null, SqlOperation.Internal, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(CommandType type, string text)
    {
      return ExecuteScalar(null, null, SqlOperation.Internal, type, text, new ArrayList());
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(string text, SqlParameter[] parameters)
    {
      return ExecuteScalar(null, null, SqlOperation.Internal, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(string text, ArrayList parameters)
    {
      return ExecuteScalar(null, null, SqlOperation.Internal, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteScalar(null, null, SqlOperation.Internal, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(CommandType type, string text, ArrayList parameters)
    {
      return ExecuteScalar(null, null, SqlOperation.Internal, type, text, parameters);
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, string text)
    {
      return ExecuteScalar(connection, command, SqlOperation.External, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, CommandType type, string text)
    {
      return ExecuteScalar(connection, command, SqlOperation.External, type, text, new ArrayList());
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, string text, SqlParameter[] parameters)
    {
      return ExecuteScalar(connection, command, SqlOperation.External, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, string text, ArrayList parameters)
    {
      return ExecuteScalar(connection, command, SqlOperation.External, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteScalar(connection, command, SqlOperation.External, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, CommandType type, string text, ArrayList parameters)
    {
      return ExecuteScalar(connection, command, SqlOperation.External, type, text, parameters);
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteScalar(connection, command, sqloperation, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="SqlOper">数据库操作自定义对象</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlTool oper)
    {
      if (oper == null)
        return String.Empty;

      if (oper.Connection == null)
        return ExecuteScalar(oper.Type, oper.Sql, oper.Parameters);

      return ExecuteScalar(oper.Connection, oper.Command, oper.Operation, oper.Type, oper.Sql, oper.Parameters);
    }

    /// <summary>
    /// 读取数据值
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>数据值对象</returns>
    public static object ExecuteScalar(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, ArrayList parameters)
    {
      if ((sqloperation == SqlOperation.External) && ((connection == null) || (command == null)))
      {
        throw new ArgumentNullException("当事务在外部提交时，缺少数据库连接和命令对象！");
      }

      SqlConnection conn = connection;
      SqlCommand cmd = command;

      try
      {
        if (sqloperation == SqlOperation.Internal)
        {
          conn = GetConnection();
          cmd = GetCommand();
        }

        PrepareCommand(cmd, conn, type, text, parameters);

        object retval = cmd.ExecuteScalar();

        if (type == CommandType.StoredProcedure)
          OutPutParameters(cmd, parameters);

        cmd.Parameters.Clear();

        return retval;
      }
      catch
      {
        throw;
      }
      finally
      {
        if (sqloperation == SqlOperation.Internal) SetDispose(conn, cmd);
      }
    }

    #endregion ExecuteScalar Methods

    #region -ExecuteXmlReader Methods-

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(string text)
    {
      return ExecuteXmlReader(null, null, SqlOperation.Internal, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(CommandType type, string text)
    {
      return ExecuteXmlReader(null, null, SqlOperation.Internal, type, text, new ArrayList());
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(string text, SqlParameter[] parameters)
    {
      return ExecuteXmlReader(null, null, SqlOperation.Internal, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(string text, ArrayList parameters)
    {
      return ExecuteXmlReader(null, null, SqlOperation.Internal, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteXmlReader(null, null, SqlOperation.Internal, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(CommandType type, string text, ArrayList parameters)
    {
      return ExecuteXmlReader(null, null, SqlOperation.Internal, type, text, parameters);
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, string text)
    {
      return ExecuteXmlReader(connection, command, SqlOperation.External, CommandType.Text, text, new ArrayList());
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, CommandType type, string text)
    {
      return ExecuteXmlReader(connection, command, SqlOperation.External, type, text, new ArrayList());
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, string text, SqlParameter[] parameters)
    {
      return ExecuteXmlReader(connection, command, SqlOperation.External, CommandType.Text, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, string text, ArrayList parameters)
    {
      return ExecuteXmlReader(connection, command, SqlOperation.External, CommandType.Text, text, parameters);
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteXmlReader(connection, command, SqlOperation.External, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数动态数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, CommandType type, string text, ArrayList parameters)
    {
      return ExecuteXmlReader(connection, command, SqlOperation.External, type, text, parameters);
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, SqlParameter[] parameters)
    {
      return ExecuteXmlReader(connection, command, sqloperation, type, text, ConvertParameters(parameters));
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="SqlOper">数据库操作自定义对象</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlTool oper)
    {
      if (oper == null)
        return null;

      if (oper.Connection == null)
        return ExecuteXmlReader(oper.Type, oper.Sql, oper.Parameters);

      return ExecuteXmlReader(oper.Connection, oper.Command, oper.Operation, oper.Type, oper.Sql, oper.Parameters);
    }

    /// <summary>
    /// 读取XML数据
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="command">数据库命令对象</param>
    /// <param name="sqloperation">事务类型</param>
    /// <param name="type">命令类型</param>
    /// <param name="text">数据库命令字符串</param>
    /// <param name="parameters">参数数组</param>
    /// <returns>XML数据对象</returns>
    public static XmlReader ExecuteXmlReader(SqlConnection connection, SqlCommand command, SqlOperation sqloperation,
          CommandType type, string text, ArrayList parameters)
    {
      if (GetDatabaseType() != DBConst.DB_TYPE_SQL2000)
      {
        throw new ArgumentNullException("数据库类型必须为Sql Server 2000！");
      }

      if ((sqloperation == SqlOperation.External) && ((connection == null) || (command == null)))
      {
        throw new ArgumentNullException("当事务在外部提交时，缺少数据库连接和命令对象！");
      }

      SqlConnection conn = connection;
      SqlCommand cmd = command;

      try
      {
        if (sqloperation == SqlOperation.Internal)
        {
          conn = GetConnection();
          cmd = GetCommand();
        }

        PrepareCommand(cmd, conn, type, text, parameters);

        XmlReader retval = ((SqlCommand)cmd).ExecuteXmlReader();

        cmd.Parameters.Clear();

        return retval;
      }
      catch
      {
        throw;
      }
      finally
      {
        if (sqloperation == SqlOperation.Internal) SetDispose(conn, cmd);
      }
    }

    #endregion ExecuteXmlReader Methods
  }
}
