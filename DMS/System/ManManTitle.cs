using GuFun.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public partial class ManManTitle : DMS.BaseParamForm
    {
        public ManManTitle()
        {
            InitializeComponent();
            this.mCode = "0634";
        }

        protected override void OnInitForm()
        {
            iParas.Title = "员工职务管理";
            iParas.DisplayName = "员工职务";
            iParas.IdCode = "Man_Title";
            iParas.IdType = ColumnType.SmallInt;
            iParas.IsIdentity = false;
            iParas.NameCode = "Man_Title_Name";
            iParas.NameLen = 10;
            iParas.TableName = "T_Pmt_Man_Title";

            base.OnInitForm();
        }
    }
}
