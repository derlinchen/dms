using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 定义下拉列表的内容功能项的添加类型
  /// </summary>
  public enum DropAddFlag
  {
    /// <summary>
    /// 无任何操作
    /// </summary>
    None = 0,

    /// <summary>
    /// 增加请选择选项
    /// </summary>
    Select = -1,

    /// <summary>
    /// 增加选择全部选项
    /// </summary>
    All = -2,

    /// <summary>
    /// 增加空选项
    /// </summary>
    Null = -3,
    /// <summary>
    /// 自定义
    /// </summary>
    Custom = -4
  }
}
