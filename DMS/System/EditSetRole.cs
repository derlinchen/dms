using GuFun.Utils;
using GuFun.WinCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public partial class EditSetRole : DMS.BaseEditForm
    {
        public string id = String.Empty;
        public SetRole parentForm;
        public DataTable tblRole;

        public EditSetRole()
        {
            InitializeComponent();

            this.Text = "设置角色";
            this.mCode = "0603";
            tssPrint.Visible = false;
            tsbPreview.Visible = false;
            tsbPrint.Visible = false;
            tsbSave.Text = "设置";

            allCtrls = new object[] { clRole };
        }

        private void EditSetRole_Load(object sender, EventArgs e)
        {
            OnInitData();
        }

        protected override void OnInitData()
        {
            base.OnInitData();

            clRole.Items.Clear();

            tblRole = SqlBaseProvider.GetSysRoleByMan(Program.ManInfo.Man.ManID, id);

            foreach (DataRow roledr in tblRole.Rows)
            {
                clRole.Items.Add(roledr["Role_Name"], Convert.ToBoolean(roledr["Is_Select"]));
            }
        }

        protected override bool OnSaveData()
        {
            if (tblRole == null) return false;

            try
            {
                SqlBaseProvider.InsertOperRole(id, tblRole);

                this.OnDisplayAllCtrls(false);
                tsbSave.Visible = false;
                tsbCancel.Visible = false;
                fState = FormState.Detail;

                if (parentForm != null)
                {
                    parentForm.RefreshForm();
                }
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
                return false;
            }

            return true;
        }

        private void clRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblRole == null)
                return;

            if ((clRole.SelectedIndex >= 0) && (clRole.SelectedIndex < clRole.Items.Count))
            {
                if (clRole.GetItemChecked(clRole.SelectedIndex))
                {
                    tblRole.Rows[clRole.SelectedIndex]["Is_Select"] = 1;
                }
                else
                {
                    tblRole.Rows[clRole.SelectedIndex]["Is_Select"] = 0;
                }
            }
        }

    }
}
