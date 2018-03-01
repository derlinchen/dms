using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 定义下拉列表的内容添加类型
  /// </summary>
  public enum DropAddType
  {
    /// <summary>
    /// 清除原有的列表内容，新建列表内容
    /// </summary>
    New,

    /// <summary>
    /// 在原由的列表内容的基础上在尾部追加
    /// </summary>
    Append
  }
}
