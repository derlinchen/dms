using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace GuFun.Utils
{
    /// <summary>
    /// 关于控件的一些公共函数
    /// </summary>
    public class CtrlHelper
    {
        #region DataGridView Methods

        public static void InitDataGridView(DataGridView dgv)
        {
            InitDataGridView(dgv, false);
        }

        public static void InitDataGridView(DataGridView dgv, bool disable)
        {
            if (dgv == null)
                return;

            dgv.BackgroundColor = StringHelper.GetColor("#FFFFE1");
            dgv.AlternatingRowsDefaultCellStyle.BackColor = StringHelper.GetColor("#A2E0D6");
            dgv.RowsDefaultCellStyle.BackColor = StringHelper.GetColor("#FFFFE1");
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = StringHelper.GetColor("#A9B4E7");
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 0, 0);
            dgv.MultiSelect = false;
            dgv.AutoGenerateColumns = false;

            if (disable)
                DisableDataGridView(dgv);
        }

        public static void DisableDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
        }

        public static void EnableDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = false;
            dgv.AllowUserToAddRows = true;
            dgv.AllowUserToDeleteRows = true;
        }

        #endregion DataGridView Methods

        #region Enable And Disable Control

        public static void DisableTextBox(TextBox obj)
        {
            //obj.Enabled = false;
            obj.ReadOnly = true;

            obj.BackColor = Color.FromArgb(225, 192, 116);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
        }

        public static void DisableTextBox(string color, TextBox obj)
        {
            //obj.Enabled = false;
            obj.ReadOnly = true;

            obj.BackColor = StringHelper.GetColor(color);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
        }

        public static void EnableTextBox(TextBox obj)
        {
            //obj.Enabled = true;
            obj.ReadOnly = false;

            obj.BackColor = Color.FromArgb(255, 255, 255);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
        }

        public static void DisableDropDownList(ComboBox obj)
        {
            obj.BackColor = Color.FromArgb(225, 192, 116);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
            obj.Enabled = false;
        }

        public static void DisableDropDownList(string color, ComboBox obj)
        {
            obj.BackColor = StringHelper.GetColor(color);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
            obj.Enabled = false;
        }

        public static void EnableDropDownList(ComboBox obj)
        {
            obj.BackColor = Color.FromArgb(255, 255, 255);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
            obj.Enabled = true;
        }

        public static void DisableCheckedListBox(CheckedListBox obj)
        {
            obj.BackColor = Color.FromArgb(225, 192, 116);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
            obj.Enabled = false;
        }

        public static void DisableCheckedListBox(string color, CheckedListBox obj)
        {
            obj.BackColor = StringHelper.GetColor(color);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
            obj.Enabled = false;
        }

        public static void EnableCheckedListBox(CheckedListBox obj)
        {
            obj.BackColor = Color.FromArgb(255, 255, 255);
            obj.ForeColor = Color.FromArgb(0, 0, 0);
            obj.Enabled = true;
        }

        public static void DisableCheckBox(CheckBox obj)
        {
            obj.Enabled = false;
        }

        public static void EnableCheckBox(CheckBox obj)
        {
            obj.Enabled = true;
        }

        public static void DisableButton(Button obj)
        {
            obj.Enabled = false;
        }

        public static void EnableButton(Button obj)
        {
            obj.Enabled = true;
        }

        public static void DisableDateTimePicker(DateTimePicker obj)
        {
            obj.BackColor = Color.FromArgb(225, 192, 116);
            obj.Enabled = false;
        }

        public static void DisableDateTimePicker(string color, DateTimePicker obj)
        {
            obj.BackColor = StringHelper.GetColor(color);
            obj.Enabled = false;
        }

        public static void EnableDateTimePicker(DateTimePicker obj)
        {
            obj.BackColor = Color.FromArgb(255, 255, 255);
            obj.Enabled = true;
        }

        public static void DisableRichTextBox(RichTextBox obj)
        {
            obj.BackColor = Color.FromArgb(225, 192, 116);
            obj.Enabled = false;
        }


        public static void EnableRichTextBox(RichTextBox obj)
        {
            obj.BackColor = Color.FromArgb(255, 255, 255);
            obj.Enabled = true;
        }

        public static void EnableCtrls(params object[] ctrls)
        {
            foreach (object obj in ctrls)
            {
                if (obj is TextBox)
                {
                    EnableTextBox((TextBox)obj);
                }
                else if (obj is ComboBox)
                {
                    EnableDropDownList((ComboBox)obj);
                }
                else if (obj is CheckBox)
                {
                    EnableCheckBox((CheckBox)obj);
                }
                else if (obj is Button)
                {
                    EnableButton((Button)obj);
                }
                else if (obj is CheckedListBox)
                {
                    EnableCheckedListBox((CheckedListBox)obj);
                }
                else if (obj is DateTimePicker)
                {
                    EnableDateTimePicker((DateTimePicker)obj);
                }
                else if (obj is RichTextBox)
                {
                    EnableRichTextBox((RichTextBox)obj);
                }
            }
        }

        public static void DisableCtrls(params object[] ctrls)
        {
            foreach (object obj in ctrls)
            {
                if (obj is TextBox)
                {
                    DisableTextBox((TextBox)obj);
                }
                else if (obj is ComboBox)
                {
                    DisableDropDownList((ComboBox)obj);
                }
                else if (obj is CheckBox)
                {
                    DisableCheckBox((CheckBox)obj);
                }
                else if (obj is Button)
                {
                    DisableButton((Button)obj);
                }
                else if (obj is CheckedListBox)
                {
                    DisableCheckedListBox((CheckedListBox)obj);
                }
                else if (obj is DateTimePicker)
                {
                    DisableDateTimePicker((DateTimePicker)obj);
                }
                else if (obj is RichTextBox)
                {
                    DisableRichTextBox((RichTextBox)obj);
                }
            }
        }

        public static void EnableCtrls(string color, params object[] ctrls)
        {
            foreach (object obj in ctrls)
            {
                if (obj is TextBox)
                {
                    EnableTextBox((TextBox)obj);
                }
                else if (obj is ComboBox)
                {
                    EnableDropDownList((ComboBox)obj);
                }
                else if (obj is CheckBox)
                {
                    EnableCheckBox((CheckBox)obj);
                }
                else if (obj is Button)
                {
                    EnableButton((Button)obj);
                }
                else if (obj is CheckedListBox)
                {
                    EnableCheckedListBox((CheckedListBox)obj);
                }
                else if (obj is DateTimePicker)
                {
                    EnableDateTimePicker((DateTimePicker)obj);
                }
            }
        }

        public static void DisableCtrls(string color, params object[] ctrls)
        {
            foreach (object obj in ctrls)
            {
                if (obj is TextBox)
                {
                    DisableTextBox(color, (TextBox)obj);
                }
                else if (obj is ComboBox)
                {
                    DisableDropDownList(color, (ComboBox)obj);
                }
                else if (obj is CheckBox)
                {
                    DisableCheckBox((CheckBox)obj);
                }
                else if (obj is Button)
                {
                    DisableButton((Button)obj);
                }
                else if (obj is CheckedListBox)
                {
                    DisableCheckedListBox(color, (CheckedListBox)obj);
                }
                else if (obj is DateTimePicker)
                {
                    DisableDateTimePicker(color, (DateTimePicker)obj);
                }
            }
        }

        #endregion Enable And Disable Control

        #region Init Control

        public static void IntiCtrls(params object[] ctrls)
        {
            foreach (object obj in ctrls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = String.Empty;
                }
            }
        }

        public static void HighCtrls(params object[] ctrls)
        {
            string high = ConfigurationManager.AppSettings[PublicConsts.PC_MustColor];

            if (String.IsNullOrEmpty(high))
                return;

            foreach (object obj in ctrls)
            {
                if (obj is Label)
                {
                    ((Label)obj).ForeColor = StringHelper.GetColor(high);
                }
            }
        }

        #endregion Init Control

        #region DropDownList Methods

        public static void SetDropDownListSelect(ComboBox ddl, DataTable data, string colname)
        {
            SetDropDownList(ddl, data, DropAddType.New, DropAddFlag.Select, String.Empty, colname);
        }

        public static void SetDropDownListAll(ComboBox ddl, DataTable data, string colname)
        {
            SetDropDownList(ddl, data, DropAddType.New, DropAddFlag.All, String.Empty, colname);
        }

        public static void SetDropDownListNull(ComboBox ddl, DataTable data, string colname)
        {
            SetDropDownList(ddl, data, DropAddType.New, DropAddFlag.Null, String.Empty, colname);
        }

        public static void SetDropDownListSelect(ComboBox ddl, ArrayList data)
        {
            SetDropDownList(ddl, data, DropAddType.New, DropAddFlag.Select, String.Empty);
        }

        public static void SetDropDownListAll(ComboBox ddl, ArrayList data)
        {
            SetDropDownList(ddl, data, DropAddType.New, DropAddFlag.All, String.Empty);
        }

        public static void SetDropDownListNull(ComboBox ddl, ArrayList data)
        {
            SetDropDownList(ddl, data, DropAddType.New, DropAddFlag.Null, String.Empty);
        }

        public static string GetDropDownListValue(ComboBox ddl)
        {
            if (ddl.SelectedValue == null) return String.Empty;

            return ((ComboBoxItem)ddl.SelectedValue).Value;
        }

        public static void SetDropDownList(ComboBox ddl, DataTable data, string colname)
        {
            if ((ddl == null) || (data == null))
                return;

            ddl.Items.Clear();

            foreach (DataRow row in data.Rows)
            {
                ddl.Items.Add(row[colname].ToString());
            }
        }

        public static void SetDropDownList(ComboBox ddl, DataTable data, DropAddType type, DropAddFlag flag, string index, string colname)
        {
            if ((ddl == null) || (data == null))
            {
                ddl.DataSource = new ArrayList();
                return;
            }
                

            ArrayList items = new ArrayList();

            if (type == DropAddType.New)
            {
                switch (flag)
                {
                    case DropAddFlag.Select:
                        items.Add(new ComboBoxItem("--请选择--", DropAddFlag.Select.ToString()));
                        break;

                    case DropAddFlag.All:
                        items.Add(new ComboBoxItem("--选择全部--", DropAddFlag.All.ToString()));
                        break;

                    case DropAddFlag.Null:
                        items.Add(new ComboBoxItem("", DropAddFlag.Null.ToString()));
                        break;
                }
            }
            else
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i] is ComboBoxItem)
                        items.Add(ddl.Items[i]);
                }
            }

            DataTableToItems(items, data, colname);

            //ddl.Items.Clear();
            if (items.Count > 0)
            {
                ddl.DataSource = items;
                ddl.DisplayMember = "Name";
                ddl.ValueMember = "Value";
            }

            SelectDropDownList(ddl, index);
        }

        public static void SetDropDownList(ComboBox ddl, ArrayList data, DropAddType type, DropAddFlag flag, string index)
        {
            if ((ddl == null) || (data == null))
                return;

            ArrayList items = new ArrayList();

            if (type == DropAddType.New)
            {
                switch (flag)
                {
                    case DropAddFlag.Select:
                        items.Add(new ComboBoxItem("--请选择--", DropAddFlag.Select.ToString()));
                        break;

                    case DropAddFlag.All:
                        items.Add(new ComboBoxItem("--选择全部--", DropAddFlag.All.ToString()));
                        break;

                    case DropAddFlag.Null:
                        items.Add(new ComboBoxItem("", DropAddFlag.Null.ToString()));
                        break;
                }
            }
            else
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i] is ComboBoxItem)
                        items.Add(ddl.Items[i]);
                }
            }

            foreach (ComboBoxItem item in data)
            {
                items.Add(item);
            }

            ddl.Items.Clear();
            if (items.Count > 0)
            {
                ddl.DataSource = items;
                ddl.DisplayMember = "Name";
                ddl.ValueMember = "Value";
            }

            if (String.IsNullOrEmpty(index))
                SelectDropDownList(ddl, index);
        }

        public static void SetDropDownList(ComboBox ddl, ArrayList data, DropAddType type, DropAddFlag flag)
        {
            if ((ddl == null) || (data == null))
                return;

            ArrayList items = new ArrayList();

            if (type == DropAddType.New)
            {
                switch (flag)
                {
                    case DropAddFlag.Select:
                        items.Add(new ComboBoxItem("--请选择--", DropAddFlag.Select.ToString()));
                        break;

                    case DropAddFlag.All:
                        items.Add(new ComboBoxItem("--选择全部--", DropAddFlag.All.ToString()));
                        break;

                    case DropAddFlag.Null:
                        items.Add(new ComboBoxItem("", DropAddFlag.Null.ToString()));
                        break;
                }
            }
            else
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i] is ComboBoxItem)
                        items.Add(ddl.Items[i]);
                }
            }

            foreach (ComboBoxItem item in data)
            {
                items.Add(item);
            }

            ddl.Items.Clear();
            if (items.Count > 0)
            {
                ddl.DataSource = items;
                ddl.DisplayMember = "Name";
                ddl.ValueMember = "Value";
            }
        }

        public static void SetDropDownList(DataGridViewComboBoxColumn ddl, ArrayList data, DropAddType type, DropAddFlag flag)
        {
            if ((ddl == null) || (data == null))
                return;

            ArrayList items = new ArrayList();

            if (type == DropAddType.New)
            {
                switch (flag)
                {
                    case DropAddFlag.Select:
                        items.Add(new ComboBoxItem("--请选择--", DropAddFlag.Select.ToString()));
                        break;

                    case DropAddFlag.All:
                        items.Add(new ComboBoxItem("--选择全部--", DropAddFlag.All.ToString()));
                        break;

                    case DropAddFlag.Null:
                        items.Add(new ComboBoxItem("", DropAddFlag.Null.ToString()));
                        break;
                }
            }
            else
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i] is ComboBoxItem)
                        items.Add(ddl.Items[i]);
                }
            }

            foreach (ComboBoxItem item in data)
            {
                items.Add(item);
            }

            ddl.Items.Clear();
            if (items.Count > 0)
            {
                ddl.DataSource = items;
                ddl.DisplayMember = "Name";
                ddl.ValueMember = "Value";
            }
        }

        public static void SetDropDownList(ComboBox ddl, DropAddType type, DropAddFlag flag)
        {
            if (ddl == null)
                return;

            ArrayList items = new ArrayList();

            if (type == DropAddType.New)
            {
                switch (flag)
                {
                    case DropAddFlag.Select:
                        items.Add(new ComboBoxItem("--请选择--", DropAddFlag.Select.ToString()));
                        break;

                    case DropAddFlag.All:
                        items.Add(new ComboBoxItem("--选择全部--", DropAddFlag.All.ToString()));
                        break;

                    case DropAddFlag.Null:
                        items.Add(new ComboBoxItem("", DropAddFlag.Null.ToString()));
                        break;
                }
            }
            else
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i] is ComboBoxItem)
                        items.Add(ddl.Items[i]);
                }
            }

            ddl.Items.Clear();
            if (items.Count > 0)
            {
                ddl.DataSource = items;
                ddl.DisplayMember = "Name";
                ddl.ValueMember = "Value";
            }

            if (ddl.Items.Count > 0)
                ddl.SelectedIndex = 0;
        }

        public static void SelectDropDownList(ComboBox ddl, string index)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i] is ComboBoxItem)
                {
                    if (((ComboBoxItem)ddl.Items[i]).Value == index)
                    {
                        ddl.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public static void SelectDropDownListName(ComboBox ddl, string index)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i] is ComboBoxItem)
                {
                    if (((ComboBoxItem)ddl.Items[i]).Name == index)
                    {
                        ddl.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #region Convert DataTable To ComboBoxItems

        public static ArrayList DataTableToItems(DataTable dt)
        {
            return DataTableToItems(dt, String.Empty);
        }

        public static ArrayList DataTableToItems(DataTable dt, string colname)
        {
            ArrayList items = new ArrayList();

            string itemname = String.Empty;
            string itemvalue = String.Empty;

            if (!String.IsNullOrEmpty(colname))
            {
                string[] splits = colname.Split(',');

                if (splits.Length == 2)
                {
                    itemname = splits[0];
                    itemvalue = splits[1];
                }
            }

            string name = String.Empty;
            string value = String.Empty;

            foreach (DataRow row in dt.Rows)
            {
                if (!String.IsNullOrEmpty(itemname))
                    name = row[itemname].ToString();
                else
                    name = row[1].ToString();

                if (!String.IsNullOrEmpty(itemvalue))
                    value = row[itemvalue].ToString();
                else
                    value = row[0].ToString();

                items.Add(new ComboBoxItem(name, value));
            }

            return items;
        }

        public static void DataTableToItems(ArrayList items, DataTable dt)
        {
            DataTableToItems(items, dt, String.Empty);
        }

        public static void DataTableToItems(ArrayList items, DataTable dt, string colname)
        {
            if (items == null)
                items = new ArrayList();

            string itemname = String.Empty;
            string itemvalue = String.Empty;

            if (!String.IsNullOrEmpty(colname))
            {
                string[] splits = colname.Split(',');

                if (splits.Length == 2)
                {
                    itemname = splits[0];
                    itemvalue = splits[1];
                }
            }

            string name = String.Empty;
            string value = String.Empty;

            foreach (DataRow row in dt.Rows)
            {
                if (!String.IsNullOrEmpty(itemname))
                    name = row[itemname].ToString();
                else
                    name = row[1].ToString();

                if (!String.IsNullOrEmpty(itemvalue))
                    value = row[itemvalue].ToString();
                else
                    value = row[0].ToString();

                items.Add(new ComboBoxItem(name, value));
            }
        }

        #endregion Convert DataTable To ComboBoxItems

        #endregion DropDownList Methods

        #region ParamCache Methods

        public static ParamCache GetParamCache(string name, DataTable data)
        {
            return GetParamCache(name, data, String.Empty);
        }

        public static ParamCache GetParamCache(string name, DataTable data, string colname)
        {
            ParamCache pc = new ParamCache();
            pc.Name = name;

            string itemname = String.Empty;
            string itemvalue = String.Empty;

            if (!String.IsNullOrEmpty(colname))
            {
                string[] splits = colname.Split(',');

                if (splits.Length == 2)
                {
                    itemname = splits[0];
                    itemvalue = splits[1];
                }
            }

            string rname = String.Empty;
            string rvalue = String.Empty;

            foreach (DataRow row in data.Rows)
            {
                if (!String.IsNullOrEmpty(itemname))
                    rname = row[itemname].ToString();
                else
                    rname = row[1].ToString();

                if (!String.IsNullOrEmpty(itemvalue))
                    rvalue = row[itemvalue].ToString();
                else
                    rvalue = row[0].ToString();

                pc.Items.Add(new ComboBoxItem(rname, rvalue));
            }

            return pc;
        }

        #endregion ParamCache Methods

        #region Key Methods

        public static void SetEnterToTab(Control ctl)
        {
            ctl.KeyPress += new KeyPressEventHandler(SetEnterToTab_KeyPress);
        }

        public static void SetEnterToTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                SendKeys.Send("{TAB}");
        }


        #endregion Key Methods
    }

    /// <summary>
    /// 下拉列表的数据
    /// </summary>
    public class ComboBoxItem
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public ComboBoxItem(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public ComboBoxItem()
        {
            _name = String.Empty;
            _value = String.Empty;
        }
    }

    /// <summary>
    /// 用缓存的方式保存参数数据
    /// </summary>
    public class ParamCache
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private ArrayList _items;

        public ArrayList Items
        {
            get
            {
                if (_items == null)
                    _items = new ArrayList();

                return _items;
            }
            set { _items = value; }
        }

        public ParamCache()
        {
            _name = String.Empty;
        }
    }

    /// <summary>
    /// 用缓存的方式保存参数数据组
    /// </summary>
    public class ParamCaches : CollectionBase
    {
        public ParamCaches()
            : base()
        {
        }

        public ParamCache this[int index]
        {
            get { return (ParamCache)base.List[index]; }
            set { base.List[index] = (ParamCache)value; }
        }

        public ParamCache this[string index]
        {
            get
            {
                foreach (ParamCache param in this)
                {
                    if (param.Name == index)
                    {
                        return param;
                    }
                }

                return new ParamCache();
            }
        }

        public void Add(ParamCache item)
        {
            base.List.Add(item);

        }
        public void Remove(int index)
        {
            if (index > -1 && index < base.Count)
            {
                base.List.RemoveAt(index);
            }
        }
    }
}
