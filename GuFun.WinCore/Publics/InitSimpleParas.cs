using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GuFun.Utils;

namespace GuFun.WinCore
{
  public class InitSimpleParas
  {
    private string _title;

    public string Title
    {
      get { return _title; }
      set { _title = value; }
    }

    private string _displayName;

    public string DisplayName
    {
      get { return _displayName; }
      set { _displayName = value; }
    }

    private string _idCode;

    public string IdCode
    {
      get { return _idCode; }
      set { _idCode = value; }
    }

    private string _nameCode;

    public string NameCode
    {
      get { return _nameCode; }
      set { _nameCode = value; }
    }

    private ColumnType _idType;

    public ColumnType IdType
    {
      get { return _idType; }
      set { _idType = value; }
    }

    private string _idValue;

    public string IdValue
    {
      get { return _idValue; }
      set { _idValue = value; }
    }

    private string _nameValue;

    public string NameValue
    {
      get { return _nameValue; }
      set { _nameValue = value; }
    }

    private string _tableName;

    public string TableName
    {
      get { return _tableName; }
      set { _tableName = value; }
    }

    private int _nameLen;

    public int NameLen
    {
      get { return _nameLen; }
      set { _nameLen = value; }
    }

    private int _colLen;

    public int ColLen
    {
      get { return _colLen; }
      set { _colLen = value; }
    }

    private bool _isIdentity;

    public bool IsIdentity
    {
      get { return _isIdentity; }
      set { _isIdentity = value; }
    }

    public InitSimpleParas()
    {
      _tableName = String.Empty;
      _title = String.Empty;
      _nameValue = String.Empty;
      _nameCode = String.Empty;
      _idValue = String.Empty;
      _idType = ColumnType.SmallInt;
      _idCode = String.Empty;
      _displayName = String.Empty;
      _colLen = 6;
      _nameLen = 10;
      _isIdentity = false;
    }

    public DataTable GetList()
    {
      string sql = "select " + _idCode + ", " + _nameCode + " from " + _tableName + " order by " + _idCode;

      DataTable tblMain = DBUtils.ExecuteDataTable(CommandType.Text, sql);
      tblMain.TableName = "SelectMain";

      return tblMain;
    }

    public void Add()
    {
      string sql = String.Empty;

      if ((_idType == ColumnType.Int) || (_idType == ColumnType.SmallInt))
      {
        sql = "insert into " + _tableName + " (" + _idCode + ", " + _nameCode + ") values (" + _idValue + ", '" + _nameValue + "')";
      }
      else
      {
        sql = "insert into " + _tableName + " (" + _idCode + ", " + _nameCode + ") values ('" + _idValue + "', '" + _nameValue + "')";
      }

      if (_isIdentity)
        sql = "insert into " + _tableName + " (" + _nameCode + ") values ('" + _nameValue + "')";

      DBUtils.ExecuteNonQuery(CommandType.Text, sql);
    }

    public void Edit()
    {
      string sql = String.Empty;

      if ((_idType == ColumnType.Int) || (_idType == ColumnType.SmallInt))
        sql = "update " + _tableName + " set " + _nameCode + " = '" + _nameValue + "' where " + _idCode + " = " + _idValue;
      else
        sql = "update " + _tableName + " set " + _nameCode + " = '" + _nameValue + "' where " + _idCode + " = '" + _idValue + "'";

      DBUtils.ExecuteNonQuery(CommandType.Text, sql);
    }

    public void Del()
    {
        string sql = String.Empty;

        if ((_idType == ColumnType.Int) || (_idType == ColumnType.SmallInt))
            sql = "delete from  " + _tableName + " where " + _idCode + " = " + _idValue;
        else
            sql = "delete from  " + _tableName + " where " + _idCode + " = '" + _idValue + "'";

        DBUtils.ExecuteNonQuery(CommandType.Text, sql);
    }
  }
}
