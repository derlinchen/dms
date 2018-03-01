using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 数据查询方式，这里指通过Sql语句或者存储过程进行数据库数据检索时候采用的方式。
  /// </summary>
  public enum DataGetAction
  {
    /// <summary>
    /// 全部数据
    /// </summary>
    Full = 1,
    /// <summary>
    /// 获得某行的数据
    /// </summary>
    Row,
    /// <summary>
    /// 根据条件获得满足该条件的数据行集合
    /// </summary>
    ListRows,
    /// <summary>
    /// 获得某行的某列值
    /// </summary>
    Scalar,
    /// <summary>
    /// 条件筛选
    /// </summary>
    Condition,
    /// <summary>
    /// 根据查询方式获得满足条件的数据
    /// </summary>
    SearchType,
    /// <summary>
    /// 配合WinForm的DataGridView进行简化SQL查询
    /// </summary>
    SimpleList,
    /// <summary>
    /// 对于特定的数据获得状态正常的所有的数据（指不进行物理删除的）
    /// </summary>
    ValidList,
    /// <summary>
    /// 配合WinForm的DataGridView进行简化SQL查询以获取正常的数据
    /// </summary>
    SimpleValid,
    /// <summary>
    /// 自定义
    /// </summary>
    Custom
  }
}
