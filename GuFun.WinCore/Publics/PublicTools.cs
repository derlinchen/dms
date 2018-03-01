using GuFun.WinCore.Pdm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuFun.WinCore
{
    public class PublicTools
    {
        //替换空格，去掉首尾空格，内部多个连续空格替换成一个空格。
        public static string ReplaceSpace(string myStr)
        {
            int i;
            string[] myStrArr = myStr.Trim().Split(Convert.ToChar(" "));

            string rtnStr = "";

            for (i = 0; i < myStrArr.Length; i++)
            {
                if (myStrArr[i].ToString() != "")
                    rtnStr = rtnStr + myStrArr[i].ToString() + " ";
            }

            return rtnStr.Trim();
        }

        //TextReadLine
        public static string[] TextReadToArr(string myStr)
        {
            return myStr.Split(Convert.ToChar("\n"));
        }

        //Write Some "\t"
        public static string WriteTab(int cnt)
        {
            string rtn = String.Empty;

            for (int i = 0; i < cnt; i++)
            {
                rtn = rtn + "\t";
            }

            return rtn;
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

        public static string GetProperty(string columnname)
        {
            string rtn = String.Empty;

            string[] ps = columnname.ToLower().Split('_');

            int i = 0;

            for (i = 0; i < ps.Length; i++)
            {
                char[] chars = ps[i].ToCharArray();
                if (chars.Length > 0)
                    chars[0] = Char.ToUpper(chars[0]);

                rtn += new string(chars);
            }
            return rtn;
        }

        public static string GetJavaType(ColType type)
        {
            switch (type)
            {
                case ColType.NVarChar:
                case ColType.VarChar:
                    return "String";

                case ColType.SmallInt:
                    return "int";

                case ColType.Int:
                    return "int";

                case ColType.Bit:
                    return "boolean";

                case ColType.DateTime:
                    return "java.util.Date";

                case ColType.Decimal:
                    return "double";

                default:
                    return "String";
            }
        }

        public static string GetNetType(ColType type)
        {
            switch (type)
            {
                case ColType.NVarChar:
                case ColType.VarChar:
                    return "string";

                case ColType.SmallInt:
                    return "short";

                case ColType.Int:
                    return "int";

                case ColType.Bit:
                    return "bool";

                case ColType.DateTime:
                    return "DateTime";

                case ColType.Decimal:
                    return "double";

                default:
                    return "string";
            }
        }

        public static string GetJdbcType(ColType type)
        {
            switch (type)
            {
                case ColType.NVarChar:
                    return "NVARCHAR";

                case ColType.VarChar:
                    return "VARCHAR";

                case ColType.SmallInt:
                    return "SMALLINT";

                case ColType.Int:
                    return "INTEGER";

                case ColType.Bit:
                    return "BOOLEAN";

                case ColType.DateTime:
                    return "DATE";

                case ColType.Decimal:
                    return "DECIMAL";

                default:
                    return "VARCHAR";
            }
        }

        public static string GetOracleProcedureType(ColType type)
        {
            switch (type)
            {
                case ColType.NVarChar:
                    return "varchar2";

                case ColType.VarChar:
                    return "varchar2";

                case ColType.SmallInt:
                    return "number";

                case ColType.Int:
                    return "number";

                case ColType.Bit:
                    return "number";

                case ColType.DateTime:
                    return "datetime";

                case ColType.Decimal:
                    return "number";

                default:
                    return "varchar2";
            }
        }

        public static string GetOracleJdbcType(ColType type)
        {
            switch (type)
            {
                case ColType.NVarChar:
                    return "VARCHAR";

                case ColType.VarChar:
                    return "VARCHAR";

                case ColType.SmallInt:
                    return "NUMERIC";

                case ColType.Int:
                    return "NUMERIC";

                case ColType.Bit:
                    return "NUMERIC";

                case ColType.DateTime:
                    return "TIMESTAMP";

                case ColType.Decimal:
                    return "NUMERIC";

                default:
                    return "VARCHAR";
            }
        }

        public static string GetInitType(ColType type)
        {
            switch (type)
            {
                case ColType.NVarChar:
                case ColType.VarChar:
                    return "\"\"";

                case ColType.SmallInt:
                    return "0";

                case ColType.Int:
                    return "0";

                case ColType.Bit:
                    return "false";

                case ColType.DateTime:
                    return "ToolUtils.GetMinDate()";

                case ColType.Decimal:
                    return "0";

                default:
                    return "\"\"";
            }
        }

        public static string GetNetInitType(ColType type)
        {
            switch (type)
            {
                case ColType.NVarChar:
                case ColType.VarChar:
                    return "String.Empty";

                case ColType.SmallInt:
                    return "0";

                case ColType.Int:
                    return "0";

                case ColType.Bit:
                    return "false";

                case ColType.DateTime:
                    return "DateTime.MinValue";

                case ColType.Decimal:
                    return "0";

                default:
                    return "String.Empty";
            }
        }

        public static ColType CheckColumnType(string type)
        {
            if (type.ToLower().IndexOf("nvarchar") >= 0)
            {
                return ColType.NVarChar;
            }
            else if (type.ToLower().IndexOf("varchar") >= 0)
            {
                return ColType.VarChar;
            }
            else if (type.ToLower().IndexOf("smallint") >= 0)
            {
                return ColType.SmallInt;
            }
            else if (type.ToLower().IndexOf("datetime") >= 0)
            {
                return ColType.DateTime;
            }
            else if (type.ToLower().IndexOf("decimal") >= 0)
            {
                return ColType.Decimal;
            }
            else if (type.ToLower().IndexOf("bit") >= 0)
            {
                return ColType.Bit;
            }
            else if (type.ToLower().IndexOf("int") >= 0)
            {
                return ColType.Int;
            }
            else if (type.ToLower().IndexOf("number") >= 0)
            {
                if (type.ToLower().IndexOf(",") >= 0)
                    return ColType.Decimal;
                else
                    return ColType.Int;
            }

            return ColType.VarChar;
        }

        public static string GetFirstUpper(string name)
        {
            if (name.Length <= 1)
                return name.ToUpper();

            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }

        public static IList<PdmTable> GetPmtTables(IList<PdmTable> tables)
        {
            IList<PdmTable> rtn = new List<PdmTable>();

            foreach (PdmTable pTable in tables)
            {
                if (String.IsNullOrEmpty(pTable.Comment))
                    continue;

                string[] comments = pTable.Comment.Split(Environment.NewLine.ToCharArray());
            }

            return rtn;
        }

        public static string ALG2121(string str)
        {
            char[] a = str.ToCharArray();
            Array.Reverse(a);
            int sum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                int s = Convert.ToInt32(a[i].ToString());

                if (i % 2 == 0)
                {
                    int p = s * 2;
                    if (p / 10 == 1)
                    {
                        sum += 1 + (p % 10);
                    }
                    else
                    {
                        sum += p;
                    }
                }
                else
                {
                    sum += s;
                }
            }

            if (sum % 10 == 0)
                return str + "0";
            else
                return str + (10 - sum % 10).ToString();
        }
    }
}
