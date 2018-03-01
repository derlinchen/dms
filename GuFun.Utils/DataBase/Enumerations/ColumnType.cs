using System;

namespace GuFun.Utils
{
  /// <summary>
  /// 数据库字段类型，这里只表示常用的字段类型。
  /// </summary>
  public enum ColumnType
  {
    /// <summary>
    /// 从 -2^31 (-2,147,483,648) 到 2^31 - 1 (2,147,483,647) 的整型数据（所有数字）。
    /// </summary>
    Int = 1,
    /// <summary>
    /// 从 -2^15 (-32,768) 到 2^15 - 1 (32,767) 的整数数据。
    /// </summary>
    SmallInt,
    /// <summary>
    /// 从 -2^63 (-9223372036854775808) 到 2^63-1 (9223372036854775807) 的整型数据（所有数字）。
    /// </summary>
    BigInt,
    /// <summary>
    /// 从 0 到 255 的整数数据。
    /// </summary>
    TinyInt,
    /// <summary>
    /// 可变长度 Unicode 数据，其最大长度为 4,000 字符。
    /// </summary>
    NVarChar,
    /// <summary>
    /// 可变长度的非 Unicode 数据，最长为 8,000 个字符。
    /// </summary>
    VarChar,
    /// <summary>
    /// 可变长度 Unicode 数据，其最大长度为 2^30 - 1 (1,073,741,823) 个字符。
    /// </summary>
    NText,
    /// <summary>
    /// 可变长度的非 Unicode 数据，最大长度为 2^31 - 1 (2,147,483,647) 个字符。
    /// </summary>
    Text,
    /// <summary>
    /// 从 1753 年 1 月 1 日到 9999 年 12 月 31 日的日期和时间数据，精确到百分之三秒（或 3.33 毫秒）。
    /// </summary>
    DateTime,
    /// <summary>
    /// 从 1900 年 1 月 1 日到 2079 年 6 月 6 日的日期和时间数据，精确到分钟。
    /// </summary>
    SmallDateTime,
    /// <summary>
    /// 从 -10^38 +1 到 10^38 –1 的固定精度和小数位的数字数据。
    /// </summary>
    Decimal,
    /// <summary>
    /// 1 或 0 的整数数据。
    /// </summary>
    Bit,
    /// <summary>
    /// 可变长度的二进制数据，其最大长度为 2^31 - 1 (2,147,483,647) 个字节。
    /// </summary>
    Image,
    /// <summary>
    /// 全局唯一标识符 (GUID)。
    /// </summary>
    UniqueIdentifier
  }
}
