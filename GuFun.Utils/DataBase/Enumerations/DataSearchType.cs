using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 数据查询方式
  /// </summary>
  public enum DataSearchType
  {
    /// <summary>
    /// 模糊查询
    /// </summary>
    Blur = 1,
    /// <summary>
    /// 精确查询
    /// </summary>
    Exact,
    /// <summary>
    /// 左相似查询
    /// </summary>
    Left
  }
}
