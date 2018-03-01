using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuFun.WinCore
{
    public class PageBusHours
    {
        private string _search;

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private int _start;

        public int Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private int _end;

        public int End
        {
            get { return _end; }
            set { _end = value; }
        }

        private int _total;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _getAction;

        public string GetAction
        {
            get { return _getAction; }
            set { _getAction = value; }
        }

        public PageBusHours()
        {
            _search = String.Empty;
            _start = 0;
            _end = 0;
            _total = 0;
            _getAction = String.Empty;
        }
    }
}
