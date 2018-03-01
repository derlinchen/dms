using System;
namespace GuFun.WinCore
{
  public enum LoginStatus
  {
    Valid = 1,
    /// <summary>
    /// 当前用户已经在线
    /// </summary>
    Online,
    /// <summary>
    /// 该机器无注册
    /// </summary>
    NoRegister,
    /// <summary>
    /// 公司状态不正常
    /// </summary>
    InValidCompany,
    /// <summary>
    /// 部门状态不正常
    /// </summary>
    InValidDept,
    /// <summary>
    /// 员工状态不正常
    /// </summary>
    InValidMan,
    /// <summary>
    /// 无返回值
    /// </summary>
    NoReturn,
    /// <summary>
    /// 系统错误
    /// </summary>
    SystemError
  }
}
