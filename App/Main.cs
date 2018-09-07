using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Cache;
using Microsoft.Data.ConnectionUI;
using Microsoft.Owin.Hosting;

namespace App
{
    public partial class Main : Form
    {
        private IDisposable _server;
        private AuthenticationType _authenticationType = AuthenticationType.Local;
        private string _connectionString;
        public Main()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var adminCoreManager = new IdentityAdminManagerService(_connectionString);
            var settings = new DebugEFRedisCacheSettings();
            DbConfiguration.SetConfiguration(new Configuration(settings));

            var baseAddress = $"http://localhost:9000/";
            _server = WebApp.Start(baseAddress, app => new Startup(_authenticationType).Configuration(app, adminCoreManager));
            Process.Start(baseAddress + "admin");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server?.Dispose();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var dcd = new DataConnectionDialog();
            var dcs = new DataConnectionConfiguration(null);
            dcs.LoadConfiguration(dcd);
            if (DataConnectionDialog.Show(dcd) != DialogResult.OK) return;
            conTextBox.Text = dcd.ConnectionString;
            _connectionString = dcd.ConnectionString;
        }
    }
}
