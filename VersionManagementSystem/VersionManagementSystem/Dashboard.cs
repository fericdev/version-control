using FerPROJ.Libraries.UIHelper.Extensions;
using FerPROJ.Libraries.UIHelper.Files;
using FerPROJ.Libraries.UIHelper.WinForm.Classes;
using FerPROJ.Libraries.UIHelper.WinForm.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
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
        Dictionary<string, string> selectedFiles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private string selectFileSystemName;
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
                filesKryptonListBox.Items.Clear();

                foreach (var path in ofd.FileNames) {
                    // CASE 1: it's a file
                    if (File.Exists(path)) {
                        AddFile(path);
                    }
                }
            }
        }
        private void selectFoldersKryptonLinkLabel_LinkClicked(object sender, EventArgs e) {
            var dialog = new CommonOpenFileDialog {
                Title = "Select folders",
                IsFolderPicker = true,
                Multiselect = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                foreach (var folder in dialog.FileNames) {
                    AddFolder(folder);
                }
            }
        }
        private void AddFile(string filePath) {
            if (!File.Exists(filePath))
                return;

            var fileName = Path.GetFileName(filePath);

            if (selectedFiles.ContainsKey(filePath))
                return;

            selectedFiles[filePath] = fileName; // root level

            var info = new FileInfo(filePath);

            if (info.Extension.Equals(".exe", StringComparison.OrdinalIgnoreCase)) {
                selectFileSystemName = Path.GetFileNameWithoutExtension(info.Name)
                    .Replace(".", "");
            }

            filesKryptonListBox.Items.Add($"{fileName} ({info.Length / 1024} KB)");
        }
        private void AddFolder(string folderPath) {
            if (!Directory.Exists(folderPath))
                return;

            var rootName = Path.GetFileName(folderPath);

            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files) {
                var relativePath = Path.GetRelativePath(folderPath, file);

                var entryPath = Path.Combine(rootName, relativePath)
                    .Replace("\\", "/"); // important for zip

                if (!selectedFiles.ContainsKey(file)) {
                    selectedFiles[file] = entryPath;

                    var info = new FileInfo(file);
                    filesKryptonListBox.Items.Add($"{entryPath} ({info.Length / 1024} KB)");
                }
            }
        }

        private void convertToZipCButton_Click(object sender, EventArgs e) {
            if (selectedFiles.Count == 0) {
                MessageBox.Show("No files selected.");
                return;
            }

            var saveDirectory = DocWriterManager.GetOrCreateEnvironmentPath("output.zip", false, selectFileSystemName);

            CreateZip(selectedFiles, saveDirectory);

            DialogManager.Info("ZIP created successfully!", "Success");

        }

        // =========================
        // ZIP LOGIC
        // =========================
        private void CreateZip(Dictionary<string, string> files, string zipPath) {
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create)) {
                foreach (var kvp in files) {
                    var fullPath = kvp.Key;
                    var entryName = kvp.Value;

                    if (!File.Exists(fullPath))
                        continue;

                    zip.CreateEntryFromFile(
                        fullPath,
                        entryName.Replace("\\", "/"), // ensure valid zip path
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
