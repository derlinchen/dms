using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 判断窗口当前的状态
  /// </summary>
  public enum FormState
  {
    /// <summary>
    /// 无状态
    /// </summary>
    None = 1,
    /// <summary>
    /// 数据列表浏览状态
    /// </summary>
    List,
    /// <summary>
    /// 新增数据状态
    /// </summary>
    New,
    /// <summary>
    /// 修改数据状态
    /// </summary>
    Edit,
    /// <summary>
    /// 明细显示状态
    /// </summary>
    Detail
  }
}
