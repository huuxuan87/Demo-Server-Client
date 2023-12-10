using Autofac;
using Client.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public StartForm(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            InitializeComponent();
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
            ShowBeginForm();
        }

        private void StartForm_Shown(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
