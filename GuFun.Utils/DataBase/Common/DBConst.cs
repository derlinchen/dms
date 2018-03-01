using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 定义系统使用的数据库常量
  /// </summary>
  internal sealed class DBConst
  {
    /// <summary>
    /// 数据库类型常量
    /// Access -- Microsoft Access 数据库（mdb）
    /// Sql Server -- Microsoft Sql Server 7.0
    /// Sql Server 2000 -- Microsoft Sql Server 2000
    /// Sql Server 2005 -- Micorsoft Sql Server 2005
    /// Oracle 7.0 -- Oracle 7.0
    /// Oracle 8.0 -- Oracel 8.0
    /// Oracle 9i -- Oracle 9i
    /// Informix -- IBM Informix
    /// Sybase -- Sybase
    /// MySql -- MySql
    /// </summary>
    public const string DB_TYPE_ACCESS = "ACCESS";
    public const string DB_TYPE_SQL7 = "SQL SERVER";
    public const string DB_TYPE_SQL2000 = "SQL SERVER 2000";
    public const string DB_TYPE_SQL2005 = "SQL SERVER 2005";
    public const string DB_TYPE_ORACLE7 = "ORACLE 7";
    public const string DB_TYPE_ORACLE8 = "ORACLE 8";
    public const string DB_TYPE_ORACLE9i = "ORACLE 9i";
    public const string DB_TYPE_INFORMIX = "INFORMIX";
    public const string DB_TYPE_SYBASE = "SYBASE";
    public const string DB_TYPE_MYSQL = "MYSQL";
  }
}
