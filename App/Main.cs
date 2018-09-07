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
using App.Properties;
using Microsoft.Data.ConnectionUI;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;

namespace App
{
    public partial class Main : Form
    {
        private IDisposable _server;
        private AuthenticationType _authenticationType = AuthenticationType.Local;
        private readonly Setting _setting;
        public Main()
        {
            InitializeComponent();
            // load settings
            try
            {
                _setting = JsonConvert.DeserializeObject<Setting>((string) Settings.Default.Data) ?? new Setting();
            }
            catch (Exception)
            {
                _setting = new Setting();
            }

            portTxt.Text = _setting.PortNumber.ToString();
            schemaTxt.Text = _setting.Schema;

            portTxt.TextChanged += PortTxt_TextChanged;
            schemaTxt.TextChanged += SchemaTxt_TextChanged;

            conTextBox.Text = _setting.ConnectionString;
        }

        private void SchemaTxt_TextChanged(object sender, EventArgs e)
        {
            _setting.Schema = schemaTxt.Text;
        }

        private void PortTxt_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(portTxt.Text, out var a))
            {
                _setting.PortNumber = int.Parse(portTxt.Text);
            }
            else
            {
                portTxt.Text = _setting.PortNumber.ToString();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var identityAdminManagerService = _setting.Schema != "dbo"
                ? new IdentityAdminManagerService(_setting.ConnectionString, _setting.Schema)
                : new IdentityAdminManagerService(_setting.ConnectionString);
            var settings = new DebugEfRedisCacheSettings();
            DbConfiguration.SetConfiguration(new Configuration(settings));

            var baseAddress = $"http://localhost:{_setting.PortNumber}/";
            _server = WebApp.Start(baseAddress, app => new Startup(_authenticationType).Configuration(app, identityAdminManagerService));
            Process.Start(baseAddress + "admin");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Save settings
            Settings.Default.Data = JsonConvert.SerializeObject(_setting);
            Settings.Default.Save();
            _server?.Dispose();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var dcd = new DataConnectionDialog();
            var dcs = new DataConnectionConfiguration(null);
            dcs.LoadConfiguration(dcd);
            if (DataConnectionDialog.Show(dcd) != DialogResult.OK) return;
            conTextBox.Text = dcd.ConnectionString;
            _setting.ConnectionString = dcd.ConnectionString;
        }
    }
}
