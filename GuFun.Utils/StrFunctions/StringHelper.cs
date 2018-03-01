// ***************************************************************************
// 项目名称：GuFun.Utils 
// 版权信息: Copyright (C), 2003-2010, 南京古方科技有限公司
// 版本信息: 4.0
// 程序名称：StringHelper
// 功能描述：关于字符串相关操作的公共函数。
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
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Net;

namespace GuFun.Utils
{
  public class StringHelper
  {
    #region Type Methods

    /// <summary>
    /// 转换16进制字符串为ASCII字符串
    /// </summary>
    /// <param name="Hex">进行转换的16进制字符串</param>
    /// <returns>转换后的ASCII字符串</returns>
    public static string HexToAscii(string Hex)
    {
      int rtn = int.Parse(Hex, System.Globalization.NumberStyles.AllowHexSpecifier);
      return ((char)rtn).ToString();
    }

    /// <summary>
    /// 转换ASCI的字符串为16进制字符串
    /// </summary>
    /// <param name="Ascii">进行转换的ASCII字符串</param>
    /// <returns>转换后的16进制字符串</returns>
    public static string AsciiToHex(string Ascii)
    {
      System.Text.Encoding enc = System.Text.Encoding.GetEncoding("ASCII");

      for (int i = 0; i < Ascii.Length; ++i)
      {
        byte[] bs = enc.GetBytes(Ascii[i].ToString());
        if (bs.Length > 0)
        {
          return bs[0].ToString("X2");
        }
      }

      return "FF";
    }

    /// <summary>
    /// 转换16进制字符串为整型
    /// </summary>
    /// <param name="Hex">进行转换的16进制字符串</param>
    /// <returns>转换后的整型</returns>
    public static int HexToInt(string Hex)
    {
      if (String.IsNullOrEmpty(Hex))
        return 0;

      return Convert.ToInt32((Conversion.Val("&H" + Hex)));
    }

    #endregion Type Methods

    #region Color Methods

    /// <summary>
    /// 将颜色字符串转换成颜色类
    /// </summary>
    /// <param name="Color">进行转换的字符串</param>
    /// <returns>转换后的颜色类型</returns>
    public static Color GetColor(string Name)
    {
      try
      {
        return Color.FromArgb(HexToInt(Name.Substring(1, 2)), HexToInt(Name.Substring(3, 2)), HexToInt(Name.Substring(5, 2)));
      }
      catch
      {
        return Color.FromArgb(0, 0, 0);
      }
    }

    #endregion Color Methods

    /// <summary>
    /// 获取字符串的长度（对中文）
    /// </summary>
    /// <param name="Value">需要计算长度的字符串</param>
    /// <returns>字符串的长度</returns>
    public static int GetStringLength(string Value)
    {
      char[] chars = Value.ToCharArray();
      int len = 0;
      Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);

      for (int i = 0; i < chars.Length; i++)
      {
        if ((regex.IsMatch((chars[i]).ToString())) || (chars[i] > 65280 && chars[i] < 65375) || (chars[i] > 64 && chars[i] < 91))
        {
          len += 2;
        }
        else
        {
          len += 1;
        }
      }

      return len;
    }

    /// <summary>
    /// 按指定长度截取字符串
    /// </summary>
    /// <param name="Value">需要进行截取的字符串</param>
    /// <param name="Len">保留长度</param>
    /// <param name="End">截取后是否加如后缀表示</param>
    /// <returns>截取后的字符串</returns>
    public static string TruncatString(string Value, int Len, string End)
    {
      char[] chars = Value.ToCharArray();
      int nLength = 0;
      StringBuilder sb = new StringBuilder();
      Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
      bool isCut = false;

      for (int i = 0; i < chars.Length; i++)
      {
        if ((regex.IsMatch((chars[i]).ToString())) || (chars[i] > 65280 && chars[i] < 65375) || (chars[i] > 64 && chars[i] < 91))
        {
          nLength += 2;

          if (nLength > Len)
          {
            isCut = true;
            break;
          }
          sb.Append(chars[i]);
        }
        else
        {
          nLength += 1;

          if (nLength > Len)
          {
            isCut = true;
            break;
          }
          sb.Append(chars[i]);
        }
      }

      if (isCut)
      {
        return sb.ToString() + End;
      }
      else
      {
        return sb.ToString();
      }
    }

    /// <summary>
    /// 获取字符的拼音
    /// </summary>
    /// <param name="Value">需要转换为拼音的字符</param>
    /// <returns>转换后的拼音</returns>
    public static string GetPY(string Value)
    {
      byte[] array = new byte[2];
      array = System.Text.Encoding.Default.GetBytes(Value);
      int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

      if (i < 0xB0A1) return "*";
      if (i < 0xB0C5) return "a";
      if (i < 0xB2C1) return "b";
      if (i < 0xB4EE) return "c";
      if (i < 0xB6EA) return "d";
      if (i < 0xB7A2) return "e";
      if (i < 0xB8C1) return "f";
      if (i < 0xB9FE) return "g";
      if (i < 0xBBF7) return "h";
      if (i < 0xBFA6) return "g";
      if (i < 0xC0AC) return "k";
      if (i < 0xC2E8) return "l";
      if (i < 0xC4C3) return "m";
      if (i < 0xC5B6) return "n";
      if (i < 0xC5BE) return "o";
      if (i < 0xC6DA) return "p";
      if (i < 0xC8BB) return "q";
      if (i < 0xC8F6) return "r";
      if (i < 0xCBFA) return "s";
      if (i < 0xCDDA) return "t";
      if (i < 0xCEF4) return "w";
      if (i < 0xD1B9) return "x";
      if (i < 0xD4D1) return "y";
      if (i < 0xD7FA) return "z";

      return "*";
    }

    /// <summary>
    /// 获取字符串的拼音
    /// </summary>
    /// <param name="Value">需要转换为拼音的字符串</param>
    /// <returns>转换后的拼音</returns>
    public static string GetPYString(string Value)
    {
      foreach (char c in Value)
      {
        if ((int)c >= 33 && (int)c <= 126)
        {
          return c.ToString();
        }
        else
        {
          return GetPY(c.ToString());
        }
      }

      return String.Empty;
    }

    private static int[] pyValue = new int[] 
      { -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, 
        -20230, -20051, -20036, -20032, -20026, -20002, -19990, -19986, -19982,
        -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, 
        -19741, -19739, -19728, -19725, -19715, -19540, -19531, -19525, -19515, 
        -19500, -19484, -19479, -19467, -19289, -19288, -19281, -19275, -19270, 
        -19263, -19261, -19249, -19243, -19242, -19238, -19235, -19227, -19224, 
        -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996, -18977,
        -18961, -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, 
        -18731, -18722, -18710, -18697, -18696, -18526, -18518, -18501, -18490,
        -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220,
        -18211, -18201, -18184, -18183, -18181, -18012, -17997, -17988, -17970, 
        -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, -17752, 
        -17733, -17730, -17721, -17703, -17701, -17697, -17692, -17683, -17676,
        -17496, -17487, -17482, -17468, -17454, -17433, -17427, -17417, -17202, 
        -17185, -16983, -16970, -16942, -16915, -16733, -16708, -16706, -16689, 
        -16664, -16657, -16647, -16474, -16470, -16465, -16459, -16452, -16448, 
        -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, 
        -16393, -16220, -16216, -16212, -16205, -16202, -16187, -16180, -16171,
        -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, 
        -15903, -15889, -15878, -15707, -15701, -15681, -15667, -15661, -15659, 
        -15652, -15640, -15631, -15625, -15454, -15448, -15436, -15435, -15419,
        -15416, -15408, -15394, -15385, -15377, -15375, -15369, -15363, -15362, 
        -15183, -15180, -15165, -15158, -15153, -15150, -15149, -15144, -15143, 
        -15141, -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, 
        -14941, -14937, -14933, -14930, -14929, -14928, -14926, -14922, -14921,
        -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, 
        -14678, -14674, -14670, -14668, -14663, -14654, -14645, -14630, -14594,
        -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, -14345,
        -14170, -14159, -14151, -14149, -14145, -14140, -14137, -14135, -14125, 
        -14123, -14122, -14112, -14109, -14099, -14097, -14094, -14092, -14090, 
        -14087, -14083, -13917, -13914, -13910, -13907, -13906, -13905, -13896, 
        -13894, -13878, -13870, -13859, -13847, -13831, -13658, -13611, -13601,
        -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, 
        -13359, -13356, -13343, -13340, -13329, -13326, -13318, -13147, -13138, 
        -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, 
        -12888, -12875, -12871, -12860, -12858, -12852, -12849, -12838, -12831,
        -12829, -12812, -12802, -12607, -12597, -12594, -12585, -12556, -12359,
        -12346, -12320, -12300, -12120, -12099, -12089, -12074, -12067, -12058,
        -12039, -11867, -11861, -11847, -11831, -11798, -11781, -11604, -11589, 
        -11536, -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067,
        -11055, -11052, -11045, -11041, -11038, -11024, -11020, -11019, -11018,
        -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587,
        -10544, -10533, -10519, -10331, -10329, -10328, -10322, -10315, -10309, 
        -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, -10254 
      };

    private static string[] pyName = new string[]
      { "A", "Ai", "An", "Ang", "Ao", "Ba", "Bai", "Ban", "Bang", "Bao", "Bei", 
       "Ben", "Beng", "Bi", "Bian", "Biao", "Bie", "Bin", "Bing", "Bo", "Bu",
       "Ba", "Cai", "Can", "Cang", "Cao", "Ce", "Ceng", "Cha", "Chai", "Chan",
       "Chang", "Chao", "Che", "Chen", "Cheng", "Chi", "Chong", "Chou", "Chu",
       "Chuai", "Chuan", "Chuang", "Chui", "Chun", "Chuo", "Ci", "Cong", "Cou",
       "Cu", "Cuan", "Cui", "Cun", "Cuo", "Da", "Dai", "Dan", "Dang", "Dao", "De", 
       "Deng", "Di", "Dian", "Diao", "Die", "Ding", "Diu", "Dong", "Dou", "Du", 
       "Duan", "Dui", "Dun", "Duo", "E", "En", "Er", "Fa", "Fan", "Fang", "Fei", 
       "Fen", "Feng", "Fo", "Fou", "Fu", "Ga", "Gai", "Gan", "Gang", "Gao", "Ge", 
       "Gei", "Gen", "Geng", "Gong", "Gou", "Gu", "Gua", "Guai", "Guan", "Guang", 
       "Gui", "Gun", "Guo", "Ha", "Hai", "Han", "Hang", "Hao", "He", "Hei", "Hen", 
       "Heng", "Hong", "Hou", "Hu", "Hua", "Huai", "Huan", "Huang", "Hui", "Hun",
       "Huo", "Ji", "Jia", "Jian", "Jiang", "Jiao", "Jie", "Jin", "Jing", "Jiong", 
       "Jiu", "Ju", "Juan", "Jue", "Jun", "Ka", "Kai", "Kan", "Kang", "Kao", "Ke",
       "Ken", "Keng", "Kong", "Kou", "Ku", "Kua", "Kuai", "Kuan", "Kuang", "Kui", 
       "Kun", "Kuo", "La", "Lai", "Lan", "Lang", "Lao", "Le", "Lei", "Leng", "Li",
       "Lia", "Lian", "Liang", "Liao", "Lie", "Lin", "Ling", "Liu", "Long", "Lou", 
       "Lu", "Lv", "Luan", "Lue", "Lun", "Luo", "Ma", "Mai", "Man", "Mang", "Mao",
       "Me", "Mei", "Men", "Meng", "Mi", "Mian", "Miao", "Mie", "Min", "Ming", "Miu",
       "Mo", "Mou", "Mu", "Na", "Nai", "Nan", "Nang", "Nao", "Ne", "Nei", "Nen", 
       "Neng", "Ni", "Nian", "Niang", "Niao", "Nie", "Nin", "Ning", "Niu", "Nong", 
       "Nu", "Nv", "Nuan", "Nue", "Nuo", "O", "Ou", "Pa", "Pai", "Pan", "Pang",
       "Pao", "Pei", "Pen", "Peng", "Pi", "Pian", "Piao", "Pie", "Pin", "Ping", 
       "Po", "Pu", "Qi", "Qia", "Qian", "Qiang", "Qiao", "Qie", "Qin", "Qing",
       "Qiong", "Qiu", "Qu", "Quan", "Que", "Qun", "Ran", "Rang", "Rao", "Re",
       "Ren", "Reng", "Ri", "Rong", "Rou", "Ru", "Ruan", "Rui", "Run", "Ruo", 
       "Sa", "Sai", "San", "Sang", "Sao", "Se", "Sen", "Seng", "Sha", "Shai", 
       "Shan", "Shang", "Shao", "She", "Shen", "Sheng", "Shi", "Shou", "Shu", 
       "Shua", "Shuai", "Shuan", "Shuang", "Shui", "Shun", "Shuo", "Si", "Song", 
       "Sou", "Su", "Suan", "Sui", "Sun", "Suo", "Ta", "Tai", "Tan", "Tang", 
       "Tao", "Te", "Teng", "Ti", "Tian", "Tiao", "Tie", "Ting", "Tong", "Tou",
       "Tu", "Tuan", "Tui", "Tun", "Tuo", "Wa", "Wai", "Wan", "Wang", "Wei",
       "Wen", "Weng", "Wo", "Wu", "Xi", "Xia", "Xian", "Xiang", "Xiao", "Xie",
       "Xin", "Xing", "Xiong", "Xiu", "Xu", "Xuan", "Xue", "Xun", "Ya", "Yan",
       "Yang", "Yao", "Ye", "Yi", "Yin", "Ying", "Yo", "Yong", "You", "Yu", 
       "Yuan", "Yue", "Yun", "Za", "Zai", "Zan", "Zang", "Zao", "Ze", "Zei",
       "Zen", "Zeng", "Zha", "Zhai", "Zhan", "Zhang", "Zhao", "Zhe", "Zhen", 
       "Zheng", "Zhi", "Zhong", "Zhou", "Zhu", "Zhua", "Zhuai", "Zhuan", 
       "Zhuang", "Zhui", "Zhun", "Zhuo", "Zi", "Zong", "Zou", "Zu", "Zuan",
       "Zui", "Zun", "Zuo" };

    public static string ConvertPY(string hzString)
    {
      return ConvertPY(hzString, true);
    }

    public static string ConvertPY(string hzString, bool first)
    {
      char str = '"';//英文状态双引号处理

      if (String.IsNullOrEmpty(hzString))//输入为空
        return String.Empty;

      //字符处理
      hzString = hzString.Trim().Replace(" ", "").Replace("?", "_").Replace("\\", "_").Replace("/", "_").Replace(":", "").Replace("*", "").Replace(">", "").Replace("<", "").Replace("?", "").Replace("|", "").Replace("\"", "'").Replace("(", "_").Replace(")", "_").Replace(";", "_");
      hzString = hzString.Replace("，", ",").Replace(str.ToString(), "").Replace(str.ToString(), "").Replace("；", "_").Replace("。", "_").Replace("[", "").Replace("]", "").Replace("【", "").Replace("】", "");
      hzString = hzString.Replace("{", "").Replace("}", "").Replace("^", "").Replace("&", "_").Replace("=", "").Replace("~", "_").Replace("@", "_").Replace("￥", "");
      
      Regex regex = new Regex(@"([a-zA-Z0-9\._]+)", RegexOptions.IgnoreCase);
      if (regex.IsMatch(hzString))
      {
        if (hzString.Equals(regex.Match(hzString).Groups[1].Value, StringComparison.OrdinalIgnoreCase))
        {
          return hzString;
        }
      }

      // 匹配中文字符          
      regex = new Regex("^[\u4e00-\u9fa5]$");
      byte[] array = new byte[2];
      string pyString = "";
      int chrAsc = 0;
      int i1 = 0;
      int i2 = 0;
      char[] noWChar = hzString.ToCharArray();
      for (int j = 0; j < noWChar.Length; j++)
      {// 中文字符          
        if (regex.IsMatch(noWChar[j].ToString()))
        {
          array = System.Text.Encoding.Default.GetBytes(noWChar[j].ToString());

          if (array.Length >= 2)
          {
            i1 = (short)(array[0]);
            i2 = (short)(array[1]);
            chrAsc = i1 * 256 + i2 - 65536;
            if (chrAsc > 0 && chrAsc < 160)
            {
              pyString += noWChar[j];
            }
            else
            {
              // 修正部分文字          
              if (chrAsc == -9254)  // 修正"圳"字      
              {
                if (first)
                  pyString += "z";
                else
                  pyString += "Zhen";
              }
              else
              {
                for (int i = (pyValue.Length - 1); i >= 0; i--)
                {
                  if (pyValue[i] <= chrAsc)
                  {
                    if (first)
                      pyString += pyName[i].Substring(0, 1);
                    else
                      pyString += pyName[i];
                    break;
                  }
                }
              }
            }
          }
        }
        // 非中文字符      
        else
        {
          pyString += noWChar[j].ToString();
        }
      }

      return pyString.ToLower();
    }

    #region Fill Methods

    /// <summary>
    /// 左填充字符串（默认填充0）
    /// </summary>
    /// <param name="Value">需要进行填充的字符串</param>
    /// <param name="Len">填充后的长度</param>
    /// <returns>填充后的字符串</returns>
    public static string LeftFill(string Value, int Len)
    {
      return LeftFill(Value, Len, '0');
    }

    /// <summary>
    /// 按指定字符串左填充字符串
    /// </summary>
    /// <param name="Value">需要进行填充的字符串</param>
    /// <param name="Len">填充后的长度</param>
    /// <param name="Fill">指定填充的字符</param>
    /// <returns>填充后的字符串</returns>
    public static string LeftFill(string Value, int Len, char Fill)
    {
      int j = 0;
      if (String.IsNullOrEmpty(Value))
        j = 0;
      else
        j = Value.Length;

      for (int i = 0; i < Len - j; i++)
      {
        Value = Fill.ToString() + Value;
      }

      return Value;
    }

    /// <summary>
    /// 右填充字符串（默认填充0）
    /// </summary>
    /// <param name="Value">需要进行填充的字符串</param>
    /// <param name="Len">填充后的长度</param>
    /// <returns>填充后的字符串</returns>
    public static string RightFill(string Value, int Len)
    {
      return RightFill(Value, Len, '0');
    }

    /// <summary>
    /// 按指定字符串右填充字符串
    /// </summary>
    /// <param name="Value">需要进行填充的字符串</param>
    /// <param name="Len">填充后的长度</param>
    /// <param name="Fill">指定填充的字符</param>
    /// <returns>填充后的字符串</returns>
    public static string RightFill(string Value, int Len, char Fill)
    {
      int j = 0;
      if (String.IsNullOrEmpty(Value))
        j = 0;
      else
        j = Value.Length;

      for (int i = 0; i < Len - j; i++)
      {
        Value += Fill.ToString();
      }

      return Value;
    }

    #endregion Fill Methods

    #region IP Methods

    /// <summary>
    /// 将字符型的IP地址转换为长整型
    /// </summary>
    /// <param name="IP">进行转换的IP地址</param>
    /// <returns>转换后的长整型</returns>
    public static long IpToNumber(string IP)
    {
      long rtn = 0;

      try
      {
        rtn = IPAddress.Parse(IP).Address;
      }
      catch
      {
        rtn = -1;
      }

      return rtn;
    }

    /// <summary>
    /// 将长整型转换成IP的字符型
    /// </summary>
    /// <param name="IP">进行转换的IP地址</param>
    /// <returns>转换后的长整型</returns>
    public static string NumberToIp(long IP)
    {
      string rtn = String.Empty;

      try
      {
        IPAddress ipaddress = new IPAddress(IP);

        rtn = ipaddress.ToString();
      }
      catch { }

      return rtn;
    }

    #endregion IP Methods

    #region CapNumber Methods

    /// <summary>
    /// 转换数字金额主函数（包括小数）
    /// </summary>
    /// <param name="Value">数字字符串</param>
    /// <returns>转换成中文大写后的字符串或者出错信息提示字符串</returns>
    public static string ToCapMoneyNum(string Value)
    {
      if (!IsPositveDecimal(Value))
        return "输入的不是正数字！";
      if (Double.Parse(Value) > 999999999999.99)
        return "数字太大，无法换算，请输入一万亿元以下的金额";

      string[] splits = Value.Split('.');//按小数点分割字符串

      string rtn = String.Empty;

      if (splits.Length == 1) //只有整数部分
        rtn = ToZhengShu(Value) + "元整";
      else //有小数部分
        rtn = ToZhengShu(splits[0]) + "元" + ToXiaoShu(splits[1]);

      rtn = rtn.Replace("拾元", "拾元零");
      rtn = rtn.Replace("佰元", "佰元零");
      rtn = rtn.Replace("仟元", "仟元零");
      rtn = rtn.Replace("万元", "万元零");
      rtn = rtn.Replace("拾万", "拾万零");
      rtn = rtn.Replace("佰万", "佰万零");
      rtn = rtn.Replace("仟万", "仟万零");
      rtn = rtn.Replace("亿元", "亿元零");
      rtn = rtn.Replace("万零元", "万元");
      rtn = rtn.Replace("零整", "整");

      if (rtn.Contains("分") && rtn.Contains("元") && !rtn.Contains("角"))
        rtn = rtn.Replace("元", "元零");

      rtn = rtn.Replace("零零", "零").Replace("零零", "零");
      return rtn;
    }

    /// <summary>
    /// 判断是否是正数字字符串
    /// </summary>
    /// <param name="Value"> 判断字符串</param>
    /// <returns>如果是数字，返回true，否则返回false</returns>
    public static bool IsPositveDecimal(string Value)
    {
      try
      {
        Decimal d = Decimal.Parse(Value);

        if (d >= 0)
          return true;
      }
      catch { }

      return false;
    }

    /// <summary>
    /// 转换数字（整数）
    /// </summary>
    /// <param name="Value">需要转换的整数数字字符串</param>
    /// <returns>转换成中文大写后的字符串</returns>
    public static string ToZhengShu(string Value)
    {
      string tmp = String.Empty;
      string rtn = String.Empty;

      if (Value.Length <= 4)//数字长度小于四位
      {
        rtn = ToDigit(Value);
      }
      else
      {
        if (Value.Length <= 8)//数字长度大于四位，小于八位
        {
          rtn = ToDigit(Value.Substring(0, Value.Length - 4)) + "万" + ToDigit(Value.Substring(Value.Length - 4, 4));

          rtn = rtn.Replace("零万", "万").Replace("零零", "零");

        }
        else
          if (Value.Length <= 12)//数字长度大于八位，小于十二位
          {
            rtn = ToDigit(Value.Substring(0, Value.Length - 8)) + "亿" + ToDigit(Value.Substring(Value.Length - 8, 4)) + "万" + ToDigit(Value.Substring(Value.Length - 4, 4));
            rtn = rtn.Replace("零亿", "亿").Replace("零万", "零").Replace("零零", "零").Replace("零零", "零");
          }
      }

      if (rtn.Length >= 2)
      {
        switch (rtn.Substring(rtn.Length - 2, 2)) //截取最后二位数字
        {
          case "佰零": 
          case "仟零": 
          case "万零": 
          case "亿零": 
            rtn = rtn.Substring(0, rtn.Length - 1); 
            break;
        }
      }

      return rtn;
    }

    /// <summary>
    /// 转换数字（小数部分）
    /// </summary>
    /// <param name="Value">需要转换的小数部分数字字符串</param>
    /// <returns>转换成中文大写后的字符串</returns>
    public static string ToXiaoShu(string Value)
    {
      string rtn = String.Empty;

      if (Value.Length == 1)
      {
        rtn = ToChinese(Value) + "角";
        rtn = rtn.Replace("零角", "");
      }
      else if (Value.Length > 1)
      {
        rtn = ToChinese(Value.Substring(0, 1)) + "角" + ToChinese(Value.Substring(1, 1)) + "分";
        rtn = rtn.Replace("零分", "").Replace("零角", "");
      }

      if (String.IsNullOrEmpty(rtn))
        rtn = "整";

      if (!rtn.Contains("分"))
        rtn += "整";

      return rtn;
    }

    /// <summary>
    /// 转换数字
    /// </summary>
    /// <param name="Value">转换的字符串（四位以内）</param>
    /// <returns></returns>
    public static string ToDigit(string Value)
    {
      string rtn = String.Empty;

      switch (Value.Length)
      {
        case 1: rtn = ToChinese(Value); break;
        case 2: rtn = To2Digit(Value); break;
        case 3: rtn = To3Digit(Value); break;
        case 4: rtn = To4Digit(Value); break;
      }

      return rtn.Replace("拾零", "拾");
    }

    /// <summary>
    /// 转换四位数字
    /// </summary>
    /// <param name="Value">转换的字符串（四位）</param>
    /// <returns>转换后的字符串</returns>
    public static string To4Digit(string Value)
    {
      string rtn = String.Empty;
      rtn = ToChinese(Value.Substring(0, 1)) + "仟" + ToChinese(Value.Substring(1, 1)) + "佰" + ToChinese(Value.Substring(2, 1)) + "拾" + ToChinese(Value.Substring(3, 1));
      return rtn.Replace("零仟", "零").Replace("零佰", "零").Replace("零拾", "零").Replace("零零", "零").Replace("零零", "零").Replace("零零", "零");
    }

    /// <summary>
    /// 转换三位数字
    /// </summary>
    /// <param name="Value">转换的字符串（三位）</param>
    /// <returns>转换后的字符串</returns>
    public static string To3Digit(string Value)
    {
      string rtn = String.Empty;
      rtn = ToChinese(Value.Substring(0, 1)) + "佰" + ToChinese(Value.Substring(1, 1)) + "拾" + ToChinese(Value.Substring(2, 1));
      return rtn.Replace("零佰", "零").Replace("零拾", "零").Replace("零零", "零").Replace("零零", "零");
    }

    /// <summary>
    /// 转换二位数字
    /// </summary>
    /// <param name="Value">转换的字符串（二位）</param>
    /// <returns>转换后的字符串</returns>
    public static string To2Digit(string Value)
    {
      string rtn = String.Empty;
      rtn = ToChinese(Value.Substring(0, 1)) + "拾" + ToChinese(Value.Substring(1, 1));
      return rtn.Replace("零拾", "零").Replace("零零", "零");
    }

    /// <summary>
    /// 将一位数字转换成中文大写数字
    /// </summary>
    /// <param name="Value">转换的字符串</param>
    /// <returns>转换后的字符串</returns>
    public static string ToChinese(string Value)
    {
      //"零壹贰叁肆伍陆柒捌玖拾佰仟萬億圆整角分"
      switch (Value)
      {
        case "0": return "零"; 
        case "1": return "壹"; 
        case "2": return "贰"; 
        case "3": return "叁"; 
        case "4": return "肆"; 
        case "5": return "伍"; 
        case "6": return "陆"; 
        case "7": return "柒"; 
        case "8": return "捌"; 
        case "9": return "玖"; 
        default: return String.Empty;
      }
    }

    #endregion CapNumber Methods

    public static string WriteTab(int cnt)
    {
      string rtn = String.Empty;

      for (int i = 0; i < cnt; i++)
      {
        rtn = rtn + "\t";
      }

      return rtn;
    }

    public static string WriteEnter()
    {
      return WriteEnter(1);
    }

    public static string WriteEnter(int cnt)
    {
      string rtn = String.Empty;

      for (int i = 0; i < cnt; i++)
      {
        rtn = rtn + Environment.NewLine;
      }

      return rtn;
    }
  }
}
