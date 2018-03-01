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
    public partial class EditHours : DMS.BaseEditForm
    {
        private short ml = 0;
        public string id = String.Empty;
        public ManHours parentForm;

        public EditHours()
        {
            InitializeComponent();

            this.Text = "工时管理";
            this.mCode = "0401";
            tssPrint.Visible = false;
            tsbPreview.Visible = false;
            tsbPrint.Visible = false;
            this.WorkStart.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.WorkEnd.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            ml = SqlBaseProvider.GetSetManLevel();
        }

        private void EditProject_Load(object sender, EventArgs e)
        {
            //this.allCtrls = new object[] { txtProjectCode, txtProjectName, ddlProjectType, ddlProjectStatus, ddlProjectManager, txtWorkDate, ddlWorkUnit, txtProjectDesc };
            //this.editCtrls = new object[] { };
            OnInitData(); 
        }

        protected override bool OnSaveData()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Global.ShowSysError(ex);
                return false;
            }

            return true;
        }

        protected override void OnInitData()
        {
            base.OnInitData();
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    
                }
                else
                {
                   
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
    }
}
