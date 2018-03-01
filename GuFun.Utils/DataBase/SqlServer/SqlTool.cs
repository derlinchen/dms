// ***************************************************************************
// 项目名称：GuFun.Utils 
// 版权信息: Copyright (C), 2003-2010, 南京古方科技有限公司
// 版本信息: 4.0
// 程序名称：SqlTool
// 功能描述：自定义数据操作相关属性封装类，针对Sql Server 2000。
// 编写时间：2003-05-05
// 编写人员：cloudy
// 备    注：
// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃   作者  ┃   时间   ┃  版本   ┃              说明              ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20080808 ┃  V3.1   ┃ 以对象的方式进行数据调用参数。 ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20090102 ┃  V4.0   ┃ 重新整理。                     ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
// ***************************************************************************

using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Collections;

namespace GuFun.Utils
{
  public class SqlTool
  {
    #region Public Property

    private SqlConnection _connection;

    /// <summary>
    /// 数据库连接对象
    /// </summary>
    public SqlConnection Connection
    {
      get { return _connection; }
      set { _connection = value; }
    }

    private SqlCommand _command;

    /// <summary>
    /// 数据库命令对象
    /// </summary>
    public SqlCommand Command
    {
      get { return _command; }
      set { _command = value; }
    }

    private SqlOperation _operation;

    /// <summary>
    /// 事务类型
    /// </summary>
    public SqlOperation Operation
    {
      get { return _operation; }
      set { _operation = value; }
    }

    private CommandType _type;

    /// <summary>
    /// 命令类型
    /// </summary>
    public CommandType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    private string _sql;

    /// <summary>
    /// 数据库命令字符串
    /// </summary>
    public string Sql
    {
      get { return _sql; }
      set { _sql = value; }
    }

    private ArrayList _parameters;

    /// <summary>
    /// 命令参数动态数组
    /// </summary>
    public ArrayList Parameters
    {
      get
      {
        if (_parameters == null)
          _parameters = new ArrayList();

        return _parameters;
      }
    }

    #endregion Public Property

    #region .ctor

    public SqlTool()
    {
      _connection = null;
      _command = null;
      _operation = SqlOperation.Internal;
      _type = CommandType.Text;
      _sql = String.Empty;
    }

    #endregion .ctor
  }
}
