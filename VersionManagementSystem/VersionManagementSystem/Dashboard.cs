using FerPROJ.Libraries.UIHelper.Files;
using FerPROJ.Libraries.UIHelper.WinForm.Classes;
using FerPROJ.Libraries.UIHelper.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace VersionManagementSystem {
    public partial class Dashboard : FrmDashboard {
        private List<string> selectedFiles = new List<string>();
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
            await versionModel.CreateDataAsync($"{versionModel.SystemName}_version", false, false, versionModel.SystemName);
            DialogManager.Info("Version information generated and saved successfully.", "Success");
        }

        private void selectZipKryptonLinkLabel_LinkClicked(object sender, EventArgs e) {
            using OpenFileDialog ofd = new OpenFileDialog {
                Multiselect = true,
                Title = "Select files to zip"
            };

            if (ofd.ShowDialog() == DialogResult.OK) {
                selectedFiles.Clear();
                selectedFiles.AddRange(ofd.FileNames);

                filesKryptonListBox.Items.Clear();
                foreach (var file in selectedFiles) {
                    filesKryptonListBox.Items.Add(file);
                }
            }
        }

        private void convertToZipCButton_Click(object sender, EventArgs e) {
            if (selectedFiles.Count == 0) {
                MessageBox.Show("No files selected.");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog {
                Filter = "Zip files (*.zip)|*.zip",
                FileName = "output.zip"
            };

            if (sfd.ShowDialog() == DialogResult.OK) {
                CreateZip(selectedFiles, sfd.FileName);

                DialogManager.Info("ZIP created successfully!", "Success");
            }
        }

        // =========================
        // ZIP LOGIC
        // =========================
        private void CreateZip(List<string> files, string zipPath) {
            // If exists, delete first
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create)) {
                foreach (string file in files) {
                    if (!File.Exists(file))
                        continue;

                    zip.CreateEntryFromFile(
                        file,
                        Path.GetFileName(file),
                        CompressionLevel.Optimal
                    );
                }
            }
        }
    }
    public class VersionModel {
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string DateUpdated { get; set; }
    }
}
