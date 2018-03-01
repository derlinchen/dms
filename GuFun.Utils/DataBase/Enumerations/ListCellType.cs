using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 列表显示字段的类型
  /// </summary>
  public enum ListCellType
  {
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
    /// <summary>
    /// 逻辑型
    /// </summary>
    Bool,
    /// <summary>
    /// 下拉型
    /// </summary>
    DropDown,
    /// <summary>
    /// 日期型
    /// </summary>
    Date,
    /// <summary>
    /// 实数型
    /// </summary>
    Float,
    /// <summary>
    /// 整数型
    /// </summary>
    Integer,
    /// <summary>
    /// 短整型
    /// </summary>
    Short,
    /// <summary>
    /// 字符型
    /// </summary>
    String,
    /// <summary>
    /// 时间日期型
    /// </summary>
    DateTime,
    /// <summary>
    /// 金额型 
    /// </summary>
    Money
  }
}
