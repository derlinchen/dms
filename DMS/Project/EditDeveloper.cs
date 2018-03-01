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
    public partial class EditDeveloper : DMS.BaseEditForm
    {

        public string id = String.Empty;
        public SetDeveloper parentForm;
        public DataTable tblMan;

        public EditDeveloper()
        {
            InitializeComponent();

            this.Text = "分配人员";
            this.mCode = "0603";
            tssPrint.Visible = false;
            tsbPreview.Visible = false;
            tsbPrint.Visible = false;
            tsbSave.Text = "设置";

            allCtrls = new object[] { clMan };
            this.fState = FormState.Edit;
        }

        private void EditDeveloper_Load(object sender, EventArgs e)
        {
            OnInitData();
        }

        protected override void OnInitData()
        {
            base.OnInitData();

            clMan.Items.Clear();

            tblMan = SqlBaseProvider.GetDeveloper(id);

            foreach (DataRow mandr in tblMan.Rows)
            {
                clMan.Items.Add(mandr["Man_Name"], Convert.ToBoolean(mandr["Is_Select"]));
            }
        }

        protected override bool OnSaveData()
        {
            if (tblMan == null) return false;

            try
            {
                SqlBaseProvider.SaveDeveloper(id, tblMan);

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

        private void clMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblMan == null)
                return;

            if ((clMan.SelectedIndex >= 0) && (clMan.SelectedIndex < clMan.Items.Count))
            {
                if (clMan.GetItemChecked(clMan.SelectedIndex))
                {
                    tblMan.Rows[clMan.SelectedIndex]["Is_Select"] = 1;
                }
                else
                {
                    tblMan.Rows[clMan.SelectedIndex]["Is_Select"] = 0;
                }
            }
        }
    }
}
