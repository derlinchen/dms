using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuFun.Utils
{
    public class ToolUtils
    {
        public static string GetAndSearch(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                return " and ";
            }
            else
            {
                return "";
            }
        }
    }
}
