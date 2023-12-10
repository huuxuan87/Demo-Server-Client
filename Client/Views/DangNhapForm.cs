using Autofac;
using Client.Extensions;
using Client.Helpers;
using Client.Models;
using Server.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class DangNhapForm : Form
    {
        #region Init

        private readonly ILifetimeScope _lifetimeScope;
        private readonly INguoiChoiService _nguoiChoiService;

        public DangNhapForm(ILifetimeScope lifetimeScope, INguoiChoiService nguoiChoiService)
        {
            InitializeComponent();
            _lifetimeScope = lifetimeScope;
            _nguoiChoiService = nguoiChoiService;
        }

        #endregion

        #region Function

        public void ResetUI()
        {
            tvDienThoai.ResetText();
            tvDienThoai.Focus();
        }

        private Control ValidateUI()
        {
            Control control = null;
            List<string> errors = new List<string>();

            if (!tvDienThoai.Text.GetOnlyNumbers().IsPhoneNumberValid())
            {
                errors.Add("Vui lòng nhập số điện thoại hợp lệ");
                control = control ?? tvDienThoai;
            }

            if (errors.Count > 0)
            {
                var errorMsg = string.Join("\n", errors);
                MessageBox.Show(errorMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return control;
        }

        private void DangNhapAction()
        {
            if (wDangNhap.IsBusy)
            {
                return;
            }
            var control = ValidateUI();
            if (control != null)
            {
                control.Focus();
            }
            else
            {
                pb.Value = 0;
                pb.Visible = true;
                wDangNhap.RunWorkerAsync(tvDienThoai.Text.GetOnlyNumbers());
            }
        }

        #endregion

        // Events

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            tvDienThoai.Text = Properties.Settings.Default.DienThoaiDangNhap;
        }

        private void DangNhapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lnk_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dangKyForm = _lifetimeScope.Resolve<DangKyForm>();
            dangKyForm.Show();
            dangKyForm.ResetValue();
            Hide();
        }

        private void txtDienThoai_Enter(object sender, EventArgs e)
        {
            tvDienThoai.SelectionStart = 0;
            tvDienThoai.SelectionLength = 0;
        }

        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhapAction();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhapAction();
        }

        private void DangNhapForm_Shown(object sender, EventArgs e)
        {
        }

        private void wDangNhap_DoWork(object sender, DoWorkEventArgs e)
        {
            var rs = _nguoiChoiService.GetNguoiChoiByDienThoai(e.Argument.ToStringEx());
            e.Result = rs;
        }

        private void wDangNhap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var rs = (ApiRequestResult<NguoiChoiModel>)e.Result;
            if (rs.IsOk)
            {
                Properties.Settings.Default.IsUserRegisted = true;
                Properties.Settings.Default.DienThoaiDangNhap = rs.Result.DienThoai;
                Properties.Settings.Default.IDNguoiChoi = rs.Result.Id;
                Properties.Settings.Default.Save();
                var mainForm = _lifetimeScope.Resolve<MainForm>();
                mainForm.Show();
                mainForm.LoadAll();
                Hide();
            }
            else
            {
                if (rs.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Không tìm thấy số điện thoại đã đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(rs.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            pb.Visible = false;
        }
    }
}
