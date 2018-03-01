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
    public partial class ManDeptType : DMS.BaseParamForm
    {
        public ManDeptType()
        {
            InitializeComponent();
            this.mCode = "0631";
        }

        protected override void OnInitForm()
        {
            iParas.Title = "部门类型管理";
            iParas.DisplayName = "部门类型";
            iParas.IdCode = "Dept_Type";
            iParas.IdType = ColumnType.SmallInt;
            iParas.IsIdentity = false;
            iParas.NameCode = "Dept_Type_Name";
            iParas.NameLen = 10;
            iParas.TableName = "T_Pmt_Dept_Type";

            base.OnInitForm();
        }
    }
}
