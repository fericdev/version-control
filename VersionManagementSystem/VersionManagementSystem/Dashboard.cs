using FerPROJ.Libraries.UIHelper.Files;
using FerPROJ.Libraries.UIHelper.WinForm.Classes;
using FerPROJ.Libraries.UIHelper.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VersionManagementSystem {
    public partial class Dashboard : FrmDashboard {
        public Dashboard() {
            InitializeComponent();
        }

        private void kryptonLinkLabelSelectPath_LinkClicked(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    cTextBoxKryptonPath.Text = ofd.FileName;
                }
            }
        }

        private async void cButtonGenerate_Click(object sender, EventArgs e) {
            var fileInfo = new FileInfo(cTextBoxKryptonPath.Text);
            var versionInfo = FileVersionInfo.GetVersionInfo(cTextBoxKryptonPath.Text);
            var versionModel = new VersionModel {
                SystemName = Path.GetFileNameWithoutExtension(fileInfo.Name).Replace(".", ""),
                SystemVersion = versionInfo.FileVersion,
                DateUpdated = fileInfo.LastWriteTime.ToShortDateString(),
            };
            await versionModel.CreateDataAsync<VersionModel>($"{versionModel.SystemName}_version", false, false, versionModel.SystemName);
            DialogManager.Info("Version information generated and saved successfully.", "Success");
        }
    }
    public class VersionModel {
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string DateUpdated { get; set; }
    }
}
