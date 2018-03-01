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
    public partial class ManManLevel : DMS.BaseParamForm
    {
        public ManManLevel()
        {
            InitializeComponent();
            this.mCode = "0633";
        }

        protected override void OnInitForm()
        {
            iParas.Title = "员工级别管理";
            iParas.DisplayName = "员工级别";
            iParas.IdCode = "Man_Level";
            iParas.IdType = ColumnType.SmallInt;
            iParas.IsIdentity = false;
            iParas.NameCode = "Man_Level_Name";
            iParas.NameLen = 10;
            iParas.TableName = "T_Pmt_Man_Level";

            base.OnInitForm();
        }
    }
}
