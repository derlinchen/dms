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
    public partial class ManManType : DMS.BaseParamForm
    {
        public ManManType()
        {
            InitializeComponent();
            this.mCode = "0632";
        }

        protected override void OnInitForm()
        {
            iParas.Title = "员工岗位管理";
            iParas.DisplayName = "员工岗位";
            iParas.IdCode = "Man_Type";
            iParas.IdType = ColumnType.SmallInt;
            iParas.IsIdentity = false;
            iParas.NameCode = "Man_Type_Name";
            iParas.NameLen = 10;
            iParas.TableName = "T_Pmt_Man_Type";

            base.OnInitForm();
        }
    }
}
