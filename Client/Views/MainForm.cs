using Autofac;
using Client.Helpers;
using Client.Extensions;
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
using Server.Models;

namespace Client.Views
{
    public partial class MainForm : Form
    {
        #region Init

        private readonly ILifetimeScope _lifetimeScope;
        private readonly INguoiChoiService _nguoiChoiService;
        private readonly IDatSoService _datSoService;
        private DateTime _thoiGian;
        private DateTime _thoiGianGetDatSoTiepTheo;

        public MainForm(ILifetimeScope lifetimeScope, INguoiChoiService nguoiChoiService, IDatSoService datSoService)
        {
            InitializeComponent();
            _lifetimeScope = lifetimeScope;
            _nguoiChoiService = nguoiChoiService;
            _datSoService = datSoService;
        }

        #endregion

        #region Function

        private void ResetUI()
        {
            tvDatSo.ResetText();
            tvDatSo.Focus();
            lblHoTen.ResetText();
            lblNgaySinh.ResetText();
            lblDienThoai.ResetText();
            lblClock.ResetText();
            lvSoDaDat.ResetText();
            lvSoDaDat.Items.Clear();
            _thoiGian = DateTime.Now;
            _thoiGianGetDatSoTiepTheo = DateTime.MinValue;
        }

        public void LoadAll()
        {
            ResetUI();
            GetGioServer();
            GetThongTin();
            GetSoDaDat();
        }

        private void GetGioServer()
        {
            if (wTimer.IsBusy)
            {
                return;
            }
            pbThoiGian.Value = 0;
            pbThoiGian.Visible = true;
            wTimer.RunWorkerAsync();
        }

        private void GetThongTin()
        {
            if (wThongTin.IsBusy)
            {
                return;
            }
            pbThongTin.Value = 0;
            pbThongTin.Visible = true;
            wThongTin.RunWorkerAsync(Properties.Settings.Default.DienThoaiDangNhap);
        }

        private void DatSoAction()
        {
            if (wDatSo.IsBusy)
            {
                return;
            }
            if (int.TryParse(tvDatSo.Text, out int soDat))
            {
                pbDatSo.Value = 0;
                pbDatSo.Visible = true;
                var item = new DatSoModel();
                item.GiaTri = soDat;
                item.Ngay = _thoiGian.Date;
                item.Gio = _thoiGian.Hour + 1;
                item.IDNguoiChoi = Properties.Settings.Default.IDNguoiChoi;

                wDatSo.RunWorkerAsync(item);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tvDatSo.Focus();
            }
        }

        private void GetSoDaDat()
        {
            if (wSoDaDat.IsBusy)
            {
                return;
            }
            pbSoDaDat.Value = 0;
            pbSoDaDat.Visible = true;
            _thoiGianGetDatSoTiepTheo = _thoiGian.Date.AddHours(_thoiGian.Hour + 1);
            wSoDaDat.RunWorkerAsync(Properties.Settings.Default.IDNguoiChoi);
        }

        #endregion

        // Events

        #region Event form load, closed, logout

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DienThoaiDangNhap = "";
            Properties.Settings.Default.IDNguoiChoi = 0;
            Properties.Settings.Default.Save();
            var dangNhapForm = _lifetimeScope.Resolve<DangNhapForm>();
            dangNhapForm.Show();
            dangNhapForm.ResetUI();
            Hide();
        }

        #endregion

        #region Event thời gian

        private void timerClock_Tick(object sender, EventArgs e)
        {
            _thoiGian = _thoiGian.AddSeconds(1);
            lblClock.Text = _thoiGian.ToString("dd\\/MM\\/yyyy HH:mm:ss");
            if (_thoiGian.Minute % 1 == 0 && _thoiGian.Second == 0)
            {
                GetGioServer();
            }
            if (_thoiGianGetDatSoTiepTheo <= _thoiGian)
            {
                GetSoDaDat();
            }
        }

        private void wTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            var rs = _datSoService.GetThoiGianServer();
            e.Result = rs;
        }

        private void wTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var rs = (ApiRequestResult<DateTime>)e.Result;
            if (rs.IsOk)
            {
                _thoiGian = rs.Result;
                timerClock.Start();
            }
            else
            {
                MessageBox.Show(rs.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pbThoiGian.Visible = false;
        }

        #endregion

        #region Event thông tin

        private void wThongTin_DoWork(object sender, DoWorkEventArgs e)
        {
            var dienThoai = e.Argument.ToStringEx();
            var rs = _nguoiChoiService.GetNguoiChoiByDienThoai(dienThoai);
            e.Result = rs;
        }

        private void wThongTin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var rs = (ApiRequestResult<NguoiChoiModel>)e.Result;
            if (rs.IsOk)
            {
                lblHoTen.Text = rs.Result.HoTen;
                lblDienThoai.Text = rs.Result.DienThoai;
                lblNgaySinh.Text = rs.Result.NgaySinh.GetValueEx().ToString("dd\\/MM\\/yyyy");
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
            pbThongTin.Visible = false;
        }

        #endregion

        #region Event đặt số

        private void tvDatSo_Click(object sender, EventArgs e)
        {
            tvDatSo.SelectAll();
        }

        private void btnDatSo_Click(object sender, EventArgs e)
        {
            DatSoAction();
        }

        private void tvDatSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DatSoAction();
            }
        }

        private void wDatSo_DoWork(object sender, DoWorkEventArgs e)
        {
            var item = (DatSoModel)e.Argument;
            var rs = _datSoService.DatSo(item);
            e.Result = rs;
        }

        private void wDatSo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var rs = (ApiRequestResult)e.Result;
            if (rs.IsOk)
            {
                tvDatSo.Text = "";
                GetSoDaDat();
            }
            else
            {
                MessageBox.Show(rs.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pbDatSo.Visible = false;
        }

        #endregion

        #region Event số đã đặt
       
        private void wSoDaDat_DoWork(object sender, DoWorkEventArgs e)
        {
            var pIDNguoiDat = (int)e.Argument;
            var rs = _datSoService.GetDatSo(pIDNguoiDat, null, null);
            e.Result = rs;
        }

        private void wSoDaDat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var rs = (ApiRequestResult<List<DatSoResultModel>>)e.Result;
            if (rs.IsOk) 
            {
                lvSoDaDat.Items.Clear();
                foreach (var data in rs.Result)
                {
                    var key = data.Id.ToStringEx();
                    var item = new ListViewItem(key);
                    item.Name = key;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, data.GiaTri.ToStringEx()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, data.NgayGioDatStr.ToStringEx()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, data.KetQua.ToStringEx()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, data.DaTrungStr.ToStringEx()));
                    lvSoDaDat.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show(rs.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pbSoDaDat.Visible = false;
        }

        #endregion
    }
}
