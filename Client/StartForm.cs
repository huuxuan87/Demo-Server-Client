using Autofac;
using Client.Hubs;
using Client.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class StartForm : Form
    {
        #region Init

        private readonly ILifetimeScope _lifetimeScope;
        private readonly HubConnection _monHub;

        public StartForm(ILifetimeScope lifetimeScope, HubConnection monHub)
        {
            InitializeComponent();
            _lifetimeScope = lifetimeScope;
            _monHub = monHub;
        }

        #endregion

        #region Function

        private void ShowBeginForm()
        {
            Form beginForm = null;
            var isUserRegisted = Properties.Settings.Default.IsUserRegisted;
            if (isUserRegisted)
            {
                beginForm = _lifetimeScope.Resolve<DangNhapForm>();
            }
            else
            {
                beginForm = _lifetimeScope.Resolve<DangKyForm>();
            }
            beginForm.Show();
        }

        #endregion

        // Events

        private void StartForm_Load(object sender, EventArgs e)
        {
            wLoad.RunWorkerAsync();
        }

        private void wLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _monHub.StartAsync().Wait();
                _monHub.Closed += _monHub_Closed;
                e.Result = true;
            }
            catch (Exception)
            {
                e.Result = false;
            }
        }

        private async Task _monHub_Closed(Exception arg)
        {
            while (true)
            {
                try
                {
                    await _monHub.StartAsync();
                    BeginInvoke(new Action(async () =>
                    {
                        var mainForm = _lifetimeScope.Resolve<MainForm>();
                        if (mainForm != null && mainForm.Visible)
                        {
                            await _monHub.SendNguoiChoiKetNoiAsync(Properties.Settings.Default.DienThoaiDangNhap);
                        }
                    }));
                    break;
                }
                catch (Exception)
                {
                    await Task.Delay(5000);
                }
            }
        }

        private void wLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var rs = (bool)e.Result;
            if (rs)
            {
                ShowBeginForm();
                Hide();
            }
            else
            {
                var userSelect = MessageBox.Show("Chưa kết nối được với Server. \n Bạn muốn tải lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (userSelect == DialogResult.Yes)
                {
                    wLoad.RunWorkerAsync();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
