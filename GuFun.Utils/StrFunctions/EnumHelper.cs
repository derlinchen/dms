// ***************************************************************************
// 项目名称：GuFun.Utils 
// 版权信息: Copyright (C), 2003-2010, 南京古方科技有限公司
// 版本信息: 4.0
// 程序名称：EnumHelper
// 功能描述：关于枚举类型使用的公共函数。
// 编写时间：2003-05-05
// 编写人员：cloudy
// 备    注：
// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃   作者  ┃   时间   ┃  版本   ┃              说明              ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20090102 ┃  V4.0   ┃ 重新整理。                     ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
// ***************************************************************************
using System;

namespace GuFun.Utils
{
  public class EnumHelper
  {
    /// <summary>
    /// 从Enum中任意取一个Int值，将其转化成枚举类型值
    /// </summary>
    /// <param name="Type">枚举类型</param>
    /// <param name="Value">转化的值</param>
    /// <returns>转化后的枚举类型值</returns>
    /// <example>ExampleNormalEnum status = (ExampleNormalEnum)EnumHelper.ToEnum(typeof( ExampleNormalEnum ),1); 得到值为 ExampleNormalEnum.Online </example>
    public static object ToEnum(Type Type, int Value)
    {
      return Enum.Parse(Type, Enum.GetName(Type, Value));
    }

    /// <summary>
    /// 从Enum中任意取一个String值，将其转化成枚举类型值
    /// </summary>
    /// <param name="Type">枚举类型</param>
    /// <param name="Value">转化的值</param>
    /// <returns>转化后的枚举类型值</returns>
    /// <example>ExampleNormalEnum status = (ExampleNormalEnum)EnumHelper.ToEnum( typeof( ExampleNormalEnum ),"Offline");得到值为 ExampleNormalEnum.Offline</example>
    public static object ToEnum(Type Type, string Value)
    {
      return Enum.Parse(Type, Value, true);
    }

    /// <summary>
    /// 得到一个Enum中的所有Int值
    /// </summary>
    /// <param name="Type">枚举类型</param>
    /// <returns>枚举类型中所有值数组</returns>
    public static int[] ToInts(Type Type)
    {
      int[] rtn = new int[Enum.GetValues(Type).Length];
      Array.Copy(Enum.GetValues(Type), rtn, Enum.GetValues(Type).Length);

      return rtn;
    }

    /// <summary>
    /// 静态方法,根据枚举类型返回ASCII的字符串值
    /// </summary>
    /// <param name="Type">枚举类型</param>
    /// <param name="Value">枚举值</param>
    /// <returns>ASCII字符串值</returns>
    /// <example>EnumHelper.ToAscii( typeof( ExampleHexEnum ),ExampleHexEnum.Hide );得到的值为"("</example>
    public static string ToAscii(Type Type, object Value)
    {
      return StringHelper.HexToAscii(ToHex(Type, Value));
    }

    /// <summary>
    /// 静态方法,根据枚举类型返回16进制的字符串值
    /// </summary>
    /// <param name="Type">枚举类型</param>
    /// <param name="Value">枚举值</param>
    /// <returns>转化后的16进制字符串值</returns>
    /// <example>EnumHelper.ToHex(typeof( ExampleHexEnum ),ExampleHexEnum.Hide);得到值"00000028"</example>
    public static string ToHex(Type Type, object Value)
    {
      return Enum.Format(Type, Enum.Parse(Type, Enum.GetName(Type, Value)), "X");
    }

    /// <summary>
    /// 将ASCII字符串转换成 Enum 的值
    /// </summary>
    /// <param name="Type">枚举类型</param>
    /// <param name="Value">转化的值</param>
    /// <returns>转化后的枚举类型值</returns>
    /// <example> EnumHelper.ToEnumByAscii( typeof( ExampleHexEnum ),"(") 得到值 "ExampleHexEnum.Hide" </example>
    public static object ToEnumByAscii(Type Type, string Ascii)
    {
      return ToEnumByHex(Type, StringHelper.AsciiToHex(Ascii));
    }    

    /// <summary>
    /// 将16进制转换为 Enum 的值
    /// </summary>
    /// <param name="Type">枚举类型</param>
    /// <param name="Hex">转化的值</param>
    /// <returns>转化后的枚举类型值</returns>
    /// <example>EnumHelper.ToEnumByHex( typeof( ExampleHexEnum ),"28");得到值 "ExampleHexEnum.Hide"</example>
    public static object ToEnumByHex(Type Type, string Hex)
    {
      return Enum.Parse(Type, Enum.GetName(Type, Int16.Parse(Hex, System.Globalization.NumberStyles.AllowHexSpecifier)));
    }
  }
}
