using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Management;
using System.IO;
using System.Collections;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using System.Xml;
using System.Windows.Forms;

namespace GuFun.Utils
{
  public class Publics
  {
    #region Register Methods

    public static string GetProcessorID()
    {
      // 获取CPU的ID
      string cpuInfo = String.Empty;

      ManagementClass cimobject = new ManagementClass("Win32_Processor");
      ManagementObjectCollection moc = cimobject.GetInstances();
      
      foreach (ManagementObject mo in moc)
      {
        cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
        if (!String.IsNullOrEmpty(cpuInfo))
          break;
      }

      return cpuInfo;
    }

    public static string GetFirstHDid()
    {

      //获取硬盘的ID
      String hdInfo = String.Empty;

      ManagementClass cimobject = new ManagementClass("Win32_DiskDrive");
      ManagementObjectCollection moc = cimobject.GetInstances();
      foreach (ManagementObject mo in moc)
      {
        hdInfo = mo.Properties["Model"].Value.ToString();
        if (!String.IsNullOrEmpty(hdInfo))
          break;
      }
      return hdInfo;
    }

    public static string GetFirstMacAddress()
    {
      // 获取第一块网卡的ID
      string macInfo = String.Empty;

      ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
      ManagementObjectCollection moc = mc.GetInstances();
      foreach (ManagementObject mo in moc)
      {
        if ((bool)mo.Properties["IPEnabled"].Value == true)
          macInfo = mo.Properties["MacAddress"].Value.ToString();
        if (!String.IsNullOrEmpty(macInfo))
          break;
      }
      return macInfo;
    }

    public static string GetRegisterNumber(string source)
    {
      string rn = String.Empty;

      if (String.IsNullOrEmpty(source))
        return rn;

      source = Crypto.MD5Crypto16(source);

      if (source.Length != 16)
        return rn;

      rn += source.ToUpper().Substring(11, 1);
      rn += source.ToUpper().Substring(8, 1);
      rn += source.ToUpper().Substring(10, 1);
      rn += source.ToUpper().Substring(9, 1);
      rn += "-";

      rn += source.ToUpper().Substring(5, 1);
      rn += source.ToUpper().Substring(7, 1);
      rn += source.ToUpper().Substring(4, 1);
      rn += source.ToUpper().Substring(6, 1);
      rn += "-";

      rn += source.ToUpper().Substring(14, 1);
      rn += source.ToUpper().Substring(15, 1);
      rn += source.ToUpper().Substring(12, 1);
      rn += source.ToUpper().Substring(13, 1);
      rn += "-";

      rn += source.ToUpper().Substring(2, 1);
      rn += source.ToUpper().Substring(1, 1);
      rn += source.ToUpper().Substring(3, 1);
      rn += source.ToUpper().Substring(0, 1);

      return rn;
    }

    #endregion Register Methods

    #region Public Data Opers

    public static float GetPixelToMM(int pixel, float dpi)
    {
      return GetPixelToMM(pixel, dpi, 1.0f);
    }

    public static float GetPixelToMM(int pixel, float dpi, float scale)
    {
      return float.Parse(GetFmtMM((float)(pixel * 25.4 / (dpi * scale))));
    }

    public static int GetPixelToIntMM(int pixel, float dpi)
    {
      return GetPixelToIntMM(pixel, dpi, 1.0f);
    }

    public static int GetPixelToIntMM(int pixel, float dpi, float scale)
    {
      return (int)(float.Parse(GetFmtMM((float)(pixel * 25.4 / (dpi * scale)))) * 10);
    }

    public static int GetMMToPixel(float mm, float dpi)
    {
      return GetMMToPixel(mm, dpi, 1.0f);
    }

    public static int GetMMToPixel(float mm, float dpi, float scale)
    {
      //return (int)Math.Round(((mm * dpi * scale) / 25.4), 0, MidpointRounding.AwayFromZero);
      return (int)Math.Round(((mm * 100.0f * scale) / 25.4), 0, MidpointRounding.AwayFromZero);
    }

    public static string GetFmtMM(float mm)
    {
      return mm.ToString("0.0");
    }

    public static float GetFmtMMFloat(float mm)
    {
      return float.Parse(mm.ToString("0.0"));
    }

    public static string GetFmtDouble(double dt)
    {
      return dt.ToString("0.00");
    }

    public static string GetFmtShortDate(DateTime dt)
    {
      if ((dt != null) && (dt != DateTime.MinValue))
        return dt.ToString("yyyy年MM月dd日");

      return String.Empty;
    }

    public static string GetFmtLongDate(DateTime dt)
    {
      if ((dt != null) && (dt != DateTime.MinValue))
        return dt.ToString("yyyy年MM月dd日 HH:mm:ss");

      return String.Empty;
    }

    public static string GetFmtDate(DateTime dt)
    {
      if ((dt != null) && (dt != DateTime.MinValue))
        return dt.ToString("yyyyMMdd");

      return String.Empty;
    }

    public static object GetDataDateTime(DateTime dt)
    {
      if (dt == DateTime.MinValue)
        return DBNull.Value;

      return dt;
    }

    public static DateTime GetFmtDateTime(string dt, string fmt)
    {
      if (!String.IsNullOrEmpty(dt))
        return DateTime.ParseExact(dt, fmt, Thread.CurrentThread.CurrentCulture);
      else
        return DateTime.MinValue;
    }

    public static DateTime GetRptBeginDate(string year, string month)
    {
      return GetFmtDateTime(year + month + "01 00:00:00", "yyyyMMdd HH:mm:ss");
    }

    public static DateTime GetRptBeginDate(string year)
    {
      return GetFmtDateTime(year + "0101 00:00:00", "yyyyMMdd HH:mm:ss");
    }

    public static DateTime GetRptBeginDate(string year, int quarter)
    {
      int begin = ((quarter - 1) * 3 + 1);

      return GetFmtDateTime(year + StringHelper.LeftFill(begin.ToString(), 2) + "01 00:00:00", "yyyyMMdd HH:mm:ss");
    }

    public static DateTime GetRptEndDate(string year, string month)
    {
      DateTime rtn = GetFmtDateTime(year + month + "01 00:00:00", "yyyyMMdd HH:mm:ss");
      rtn = rtn.AddMonths(1);

      return rtn;
    }

    public static DateTime GetRptEndDate(string year)
    {
      DateTime rtn = GetFmtDateTime(year + "0101 00:00:00", "yyyyMMdd HH:mm:ss");
      rtn = rtn.AddYears(1);

      return rtn;
    }

    public static DateTime GetRptEndDate(string year, int quarter)
    {
      int begin = ((quarter - 1) * 3 + 1);
      DateTime rtn = GetFmtDateTime(year + StringHelper.LeftFill(begin.ToString(), 2) + "01 00:00:00", "yyyyMMdd HH:mm:ss");
      rtn = rtn.AddMonths(3);

      return rtn;
    }

    #endregion Public Data Opers

    #region Check Methods

    public static bool CheckInt16(string check)
    {
      if (String.IsNullOrEmpty(check))
        return false;

      try
      {
        short i = Convert.ToInt16(check);
      }
      catch
      {
        return false;
      }

      return true;
    }

    public static bool CheckInt32(string check)
    {
      if (String.IsNullOrEmpty(check))
        return false;

      try
      {
        int i = Convert.ToInt32(check);
      }
      catch
      {
        return false;
      }

      return true;
    }

    public static bool CheckDouble(string check)
    {
      if (String.IsNullOrEmpty(check))
        return false;

      try
      {
        double i = Convert.ToDouble(check);
      }
      catch
      {
        return false;
      }

      return true;
    }

    public static bool CheckMoney(string check)
    {
      if (String.IsNullOrEmpty(check))
        return false;

      try
      {
        double i = Convert.ToDouble(check);

        string[] moneys = check.Split('.');

        if (moneys.Length > 1)
        {
          if (moneys[1].Length != 2)
            return false;
        }
      }
      catch
      {
        return false;
      }

      return true;
    }

    public static bool CheckMaxMoney(string check)
    {
      if (String.IsNullOrEmpty(check))
        return false;

      try
      {
        double i = Convert.ToDouble(check);

        if (i > 999999999.99)
          return false;
      }
      catch
      {
        return false;
      }

      return true;
    }

    public static bool CheckMinMoney(string check)
    {
      if (String.IsNullOrEmpty(check))
        return false;

      try
      {
        double i = Convert.ToDouble(check);

        // modify by cloudy 20150711
        if (i < 0)
          return false;
      }
      catch
      {
        return false;
      }

      return true;
    }

    public static bool CheckDateTime(string check, string format)
    {
      if (String.IsNullOrEmpty(check))
        return false;

      try
      {
        DateTime i = DateTime.ParseExact(check, format, Thread.CurrentThread.CurrentCulture);
      }
      catch
      {
        return false;
      }

      return true;
    }

    #endregion Check Methods

    #region IP Methods

    public static long ConvertIpToNumber(string ip)
    {
      long rtn = 0;

      try
      {
        rtn = IPAddress.Parse(ip).Address;
      }
      catch
      {
        rtn = -1;
      }

      return rtn;
    }

    public static string ConvertNumberToIp(long ip)
    {
      string rtn = String.Empty;

      try
      {
        IPAddress ipaddress = new IPAddress(ip);

        rtn = ipaddress.ToString();
      }
      catch { }

      return rtn;
    }

    #endregion IP Methods

    #region App.Config Methods

    public static void UpdateConfig(string path, string name, string value)
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(path + ".config");
      XmlNode node = doc.SelectSingleNode(@"//add[@key='" + name + "']");
      XmlElement ele = (XmlElement)node;
      ele.SetAttribute("value", value);
      doc.Save(path + ".config");
    }   

    #endregion App.Config Methods    

    public static bool ValidMMEnter(Char enterKey, string enterString)
    {
      if ((enterKey == '.') && (enterString.IndexOf('.') < 0))
        return false;

      if ((enterKey == (char)13) || (enterKey == (char)127) || (enterKey == (char)9) || (enterKey == (char)8))
        return false;

      if (Char.IsDigit(enterKey))
        return false;      

      return true;
    }

    public static bool ValidMMEnterNe(Char enterKey, string enterString)
    {
      if ((enterKey == '.') && (enterString.IndexOf('.') < 0))
        return false;

      if ((enterKey == '-') && (enterString.Length == 0))
        return false;

      if ((enterKey == (char)13) || (enterKey == (char)127) || (enterKey == (char)9) || (enterKey == (char)8))
        return false;

      if (Char.IsDigit(enterKey))
        return false;

      return true;
    }

    public static void ValidMMLeave(TextBox sender)
    {
      string enter = sender.Text;

      if (String.IsNullOrEmpty(enter))
        enter = "0";

      sender.Text = Publics.GetFmtMM(float.Parse(enter));
    }

    public static void ValidMoneyLeave(TextBox sender)
    {
      string enter = sender.Text;

      if (String.IsNullOrEmpty(enter))
        enter = "0";

      sender.Text = Convert.ToDouble(enter).ToString("0.00");
    }    
  }
}
