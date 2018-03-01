using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 定义SQL操作的类型
  /// </summary>
  public enum SqlOperation
  {
    /// <summary>
    /// 内部操作，执行一个完整的事务
    /// </summary>
    Internal,
    /// <summary>
    /// 外部操作，事务由外部调用对象完成或者不需要进行事务操作
    /// </summary>
    External
  }
}
