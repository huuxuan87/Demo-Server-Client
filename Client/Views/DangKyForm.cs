using Autofac;
using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Extensions;
using AutoMapper;
using Server.Services;
using Client.Helpers;

namespace Client.Views
{
    public partial class DangKyForm : Form
    {
        #region Init

        private readonly ILifetimeScope _lifetimeScope;
        private readonly NguoiChoiModel _model;
        private readonly IMapper _mapper;
        private readonly INguoiChoiService _nguoiChoiService;

        public DangKyForm(ILifetimeScope lifetimeScope, NguoiChoiModel model, IMapper mapper, INguoiChoiService nguoiChoiService)
        {
            InitializeComponent();
            _lifetimeScope = lifetimeScope;
            _model = model;
            _mapper = mapper;
            _nguoiChoiService = nguoiChoiService;
        }

        #endregion

        #region Function

        private void UpdateUI()
        {
            tvHoTen.Text = _model.HoTen;
            dtNgaySinh.Value = _model.NgaySinh.GetValueEx();
            tvDienThoai.Text = _model.DienThoai;
        }

        private void UpdateValueModel()
        {
            _model.Ten = tvHoTen.Text.GetLastName();
            _model.HoDem = tvHoTen.Text.GetFirstName();
            _model.NgaySinh = dtNgaySinh.Value.Date;
            if (tvDienThoai.Text.GetOnlyNumbers().IsPhoneNumberValid())
            {
                _model.DienThoai = tvDienThoai.Text.GetOnlyNumbers();
            }
        }

        private Control ValidateUI()
        {
            Control control = null;
            List<string> errors = new List<string>();

            if (!tvHoTen.Text.IsFullNameValid()) 
            {
                errors.Add("Vui lòng nhập họ tên hợp lệ");
                control = control ?? tvHoTen;
            }

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

        public void ResetValue()
        {
            _model.Ten = "";
            _model.HoDem = "";
            _model.NgaySinh = DateTime.Now;
            _model.DienThoai = "";
            UpdateUI();
            tvHoTen.Focus();
        }

        public void DangKyAction()
        {
            if (wDangKy.IsBusy)
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
                UpdateValueModel();
                pb.Value = 0;
                pb.Visible = true;
                wDangKy.RunWorkerAsync(_model);
            }
        }

        #endregion

        // Events

        private void DangKyForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void DangKyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKyAction();
        }

        private void linkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dangNhapForm = _lifetimeScope.Resolve<DangNhapForm>();
            dangNhapForm.Show();
            Hide();
        }

        private void tvDienThoai_Enter(object sender, EventArgs e)
        {
            tvDienThoai.SelectionStart = 0;
            tvDienThoai.SelectionLength = 0;
        }

        private void tvHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangKyAction();
            }
        }

        private void tvDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangKyAction();
            }
        }

        private void wDangKy_DoWork(object sender, DoWorkEventArgs e)
        {
            var model = (NguoiChoiModel)e.Argument;
            var rs = _nguoiChoiService.AddNguoiChoi(model);
            e.Result = rs;
        }

        private void wDangKy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var rs = (ApiRequestResult<NguoiChoiModel>)e.Result;
            if (rs.IsOk)
            {
                Properties.Settings.Default.IsUserRegisted = true;
                Properties.Settings.Default.DienThoaiDangNhap = _model.DienThoai;
                Properties.Settings.Default.IDNguoiChoi = rs.Result.Id;
                Properties.Settings.Default.Save();
                var mainForm = _lifetimeScope.Resolve<MainForm>();
                mainForm.Show();
                mainForm.LoadAll();
                Hide();
            }
            else
            {
                MessageBox.Show(rs.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pb.Visible = false;
        }
    }
}
