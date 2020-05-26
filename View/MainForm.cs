using DNSsniffer.Controller;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSsniffer.View
{
    public partial class MainForm : Form
    {
        DNSController main = new DNSController();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string key = tboxKey.Text;
            string value = tboxValue.Text.Replace(" ", "");
            main.AddRecord(key, value);
            UpdateDisplay();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvDisplay.SelectedItems)
            {
                main.DelRecord(item.SubItems[0].Text);
            }
            UpdateDisplay();
        }

        /// <summary>
        /// update display infomation
        /// </summary>
        private void UpdateDisplay()
        {
            Dictionary<string, string> records = main.AllRecord();

            lvDisplay.BeginUpdate();
            lvDisplay.Items.Clear();
            foreach (var key in records.Keys)
            {
                lvDisplay.Items.Add(new ListViewItem(new String[] { key, records[key] }));
            }
            lvDisplay.EndUpdate();
        }
        private async void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            btnStop.Enabled = true;
            await Task.Run(() =>
            {
                main.RunDNSService();
            });
            btnRun.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            main.StopDNSService();
        }
    }
}
