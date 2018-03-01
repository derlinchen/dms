// ***************************************************************************
// 项目名称：GuFun.Utils 
// 版权信息: Copyright (C), 2003-2010, 南京古方科技有限公司
// 版本信息: 4.0
// 程序名称：Crypto
// 功能描述：字符串加密解密对象，用户可以提供密匙对属于自己的信息进行加密，从
//           而保护自己的信息不被未经许可的人查询，用户私有密匙可以通过自己定
//           义的加密函数加密，但必须是字母和数字的组合，这样用户可以登记一次
//           密匙而起到保护信息的作用。
// 编写时间：2003-05-05
// 编写人员：cloudy
// 备    注：
// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃   作者  ┃   时间   ┃  版本   ┃              说明              ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20040514 ┃  V1.0   ┃ 新建项目。                     ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20060119 ┃  V2.0   ┃ 整体调整。                     ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20070113 ┃  V3.0   ┃ 转换为C#。                     ┃
// ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
// ┃ cloudy  ┃ 20090102 ┃  V4.0   ┃ 重新整理。                     ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
// ***************************************************************************

using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace GuFun.Utils
{
  /// <summary>
  /// 字符串加密解密
  /// </summary>
  /// <remarks>
  /// 用户可以提供密匙对属于自己的信息进行加密，从而保护自己的信息不被未经许可的人
  /// 查询，用户私有密匙可以通过自己定义的加密函数加密，但必须是字母和数字的组合，
  /// 这样用户可以登记一次密匙而起到保护信息的作用。
  /// </remarks>
  public sealed class Crypto
  {
    #region Private Secret Key

    private static byte[] KEY = { 2, 252, 6, 51, 53, 91, 193, 134, 193, 121, 222, 164, 
      57, 128, 91, 91, 19, 39, 111, 197, 125, 98, 89, 48, 97, 154, 83, 187, 222, 167, 171, 74};

    private static byte[] IV = { 9, 61, 235, 120, 122, 120, 80, 248, 13, 182, 196, 212, 176, 46, 28, 85 };

    private static string InKey = "bA@rHaBqJI$QpCcRzP#sK1_doSe2O3DhtnfT5LiguY4Em7UvMjX6yFl0wV8ZNxkGW9";
    private static string OutKey = "o3J@bI4qNmHK2pcMn15LFlGrQOd6kEaPsR7j$eZDtSzU8iyTY9WB_f0VuAxX#Chwgv";

    #endregion Private Secret Key

    #region String Encrypt Methods

    /// <summary>
    /// 加密字符串（带私有密匙）
    /// </summary>
    /// <param name="CryptoString">需要进行加密的字符串</param>
    /// <param name="PrivateKey">私有密匙</param>
    /// <returns>加密后的结果</returns>
    private string EncryptString(string CryptoString, byte[] PrivateKey)
    {
      byte[] bCrypto = Encoding.ASCII.GetBytes(CryptoString.ToCharArray());
      byte[] bEncode = new byte[0];
      byte[] bKey = PrivateKey;

      MemoryStream MS = new MemoryStream();
      RijndaelManaged RM = new RijndaelManaged();
      CryptoStream CS = new CryptoStream(MS, RM.CreateEncryptor(bKey, IV), CryptoStreamMode.Write);

      try
      {
        CS.Write(bCrypto, 0, bCrypto.Length);
        CS.FlushFinalBlock();
        bEncode = MS.ToArray();
      }
      finally
      {
        MS.Close();
        CS.Close();
      }

      return System.Convert.ToBase64String(bEncode);
    }

    /// <summary>
    /// 加密字符串（使用缺省的密匙）
    /// </summary>
    /// <param name="CryptoString">需要进行加密的字符串</param>
    /// <returns>加密后的结果</returns>
    public static string EncryptString(string CryptoString)
    {
      return new Crypto().EncryptString(CryptoString, KEY);
    }

    /// <summary>
    /// 加密字符串（带私有密匙， 私有密匙为字符串）
    /// </summary>
    /// <param name="CryptoString">需要进行加密的字符串</param>
    /// <param name="PrivateKey">私有密匙，此处指定为字符串</param>
    /// <returns>加密后的结果</returns>
    public static string EncryptString(string CryptoString, string PrivateKey)
    {
      byte[] bKey = Encoding.ASCII.GetBytes(PrivateKey.ToCharArray()); ;
      return new Crypto().EncryptString(CryptoString, bKey);
    }

    /// <summary>
    /// 解密字符串（使用缺省的密匙）
    /// </summary>
    /// <param name="CryptoString">需要进行解密的字符串</param>
    /// <param name="PrivateKey">私有密匙</param>
    /// <returns>解密后的结果</returns>
    private string DecryptoString(string CryptoString, byte[] PrivateKey)
    {
      byte[] bCrypto = System.Convert.FromBase64String(CryptoString);
      byte[] bKey = PrivateKey;
      byte[] Init = new byte[bCrypto.Length + 1];

      MemoryStream MS = new MemoryStream(bCrypto);
      RijndaelManaged RM = new RijndaelManaged();
      CryptoStream CS = new CryptoStream(MS, RM.CreateDecryptor(bKey, IV), CryptoStreamMode.Read);
      StringBuilder SB = new StringBuilder();

      try
      {
        CS.Read(Init, 0, Init.Length);
      }
      finally
      {
        MS.Close();
        CS.Close();
      }

      for (int i = 0; i < Init.Length; i++)
      {
        if (Init[i] != 0)
        {
          char cConvert = System.Convert.ToChar(Init[i]);
          SB.Append(cConvert);
        }
      }

      return SB.ToString();
    }

    /// <summary>
    /// 解密字符串（使用缺省的密匙）
    /// </summary>
    /// <param name="CryptoString">需要进行解密的字符串</param>
    /// <returns>解密后的结果</returns>
    public static string DecryptoString(string CryptoString)
    {
      return new Crypto().DecryptoString(CryptoString, KEY);
    }

    /// <summary>
    /// 解密字符串（带私有密匙， 私有密匙为字符串）
    /// </summary>
    /// <param name="CryptoString">需要进行解密的字符串</param>
    /// <param name="PrivateKey">私有密匙，此处指定为字符串</param>
    /// <returns>解密后的结果</returns>
    public static string DecryptoString(string CryptoString, string PrivateKey)
    {
      byte[] bKey = Encoding.ASCII.GetBytes(PrivateKey.ToCharArray()); ;
      return new Crypto().DecryptoString(CryptoString, bKey);
    }

    #endregion String Encrypt Methods

    #region MD5 Methods

    /// <summary>
    /// MD5加密（加密后带分隔符）
    /// </summary>
    /// <param name="CryptoString">需要进行MD5加密的字符串</param>
    /// <returns>带分隔符的经过MD5加密的字符串</returns>
    public static string MD5CryptoSplit(string CryptoString)
    {
      UTF8Encoding Enc = new UTF8Encoding();
      byte[] Data = new MD5CryptoServiceProvider().ComputeHash(Enc.GetBytes(CryptoString));

      return System.BitConverter.ToString(Data);
    }

    /// <summary>
    /// MD5加密（加密后带分隔符）16位
    /// </summary>
    /// <param name="CryptoString">需要进行MD5加密的字符串</param>
    /// <returns>带分隔符的经过MD5加密的字符串</returns>
    public static string MD5CryptoSplit16(string CryptoString)
    {
      UTF8Encoding Enc = new UTF8Encoding();
      byte[] Data = new MD5CryptoServiceProvider().ComputeHash(Enc.GetBytes(CryptoString));

      return System.BitConverter.ToString(Data, 4, 8);
    }

    /// <summary>
    /// MD5加密（加密后不带分隔符）
    /// </summary>
    /// <param name="CryptoString">需要进行MD5加密的字符串</param>
    /// <returns>带分隔符的经过MD5加密的字符串</returns>
    public static string MD5Crypto(string CryptoString)
    {
      string CryptoSplit = MD5CryptoSplit(CryptoString);

      CryptoSplit = CryptoSplit.Replace("-", "");
      return CryptoSplit;
    }

    /// <summary>
    /// MD5加密（加密后不带分隔符）16位
    /// </summary>
    /// <param name="CryptoString">需要进行MD5加密的字符串</param>
    /// <returns>带分隔符的经过MD5加密的字符串</returns>
    public static string MD5Crypto16(string CryptoString)
    {
      string CryptoSplit = MD5CryptoSplit16(CryptoString);

      CryptoSplit = CryptoSplit.Replace("-", "");
      return CryptoSplit;
    }

    #endregion MD5 Methods

    #region Config Secret Methods

    public static string ConfigSecret(string str)
    {
      // 读取配置文件中的信息判断关键字是否进行了加密
      string secret = ConfigurationManager.AppSettings["IsSecret"];

      if (!String.IsNullOrEmpty(secret) && bool.Parse(secret))
      {
        // 如果设置了加密处理，则读取解密方式
        //string decrypt = ConfigurationManager.AppSettings["DecryptMethod"];

        //if (!String.IsNullOrEmpty(decrypt))
        // 采取单一方式加密，不再使用Elib的类库 - 20090102
        return DecryptoString(str);
      }

      return str;
    }

    #endregion Config Secret Methods

    #region Custom Secret Methods

    /// <summary>
    /// 在进行自定义加解密时进行字符串的转换操作
    /// </summary>
    /// <param name="Out">转换的字符串，作为返回值</param>
    /// <param name="Begin">开始的匹配字符</param>
    /// <param name="End">结束的匹配字符</param>
    /// <returns>返回操作字符串转换是否成功</returns>
    public static bool PasswdConvert(string Out, string Begin, string End)
    {
      string Tmp = Out;
      string Link = String.Empty;
      int offset = 0;

      for (int i = 0; i < Tmp.Length; i++)
      {
        for (offset = 1; offset <= 65; offset++)
        {
          if (Out[i] == Begin[offset]) break;
        }
        Link += End[offset].ToString();
      }

      Out = Link;

      return true;
    }

    /// <summary>
    /// 自定义加密
    /// </summary>
    /// <param name="In">需要加密的字符串</param>
    /// <param name="Out">加密后的结果</param>
    /// <returns>自定义加密操作是否成功</returns>
    public static bool PasswdTo(string In, string Out)
    {
      if (In == null || In == string.Empty)
      {
        Out = string.Empty;
        return true;
      }

      int offset = DateTime.Now.Second + Convert.ToInt16((new Random()).Next() * 5 + 1);
      string Tmp = In;
      string ToKey = InKey;
      char cTmp;

      for (offset = 0; offset <= 66; offset++)
      {
        if (ToKey[offset] == Tmp[0]) break;
      }

      ToKey += ToKey;
      cTmp = ToKey[0];
      ToKey = ToKey.Substring(offset, 66);
      Out = In;
      PasswdConvert(Out, OutKey, InKey);
      Out = cTmp.ToString() + Out;

      return true;
    }

    /// <summary>
    /// 自定义解密
    /// </summary>
    /// <param name="In">需要解密的字符串</param>
    /// <param name="Out">解密后的结果</param>
    /// <returns>自定义解密操作是否成功</returns>
    public static bool PasswdFrom(string In, string Out)
    {
      if (In == null || In == string.Empty)
      {
        Out = string.Empty;
        return true;
      }

      int offset = 0;
      string Tmp = In;
      string ToKey = InKey;

      for (offset = 0; offset <= 66; offset++)
      {
        if (ToKey[offset] == Tmp[0]) break;
      }

      ToKey += ToKey;
      ToKey = ToKey.Substring(offset, 66);
      Out = ToKey.Substring(2, In.Length);
      PasswdConvert(Out, OutKey, InKey);

      return true;
    }

    #endregion Custom Secret Methods
  }
}
