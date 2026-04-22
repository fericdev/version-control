namespace VersionManagementSystem {
    partial class Dashboard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            kryptonLinkLabelSelectPath = new Krypton.Toolkit.KryptonLinkLabel();
            cTextBoxKryptonPath = new FerPROJ.Libraries.UIHelper.WinFormControls.CTextBoxKrypton();
            cButtonGenerate = new FerPROJ.Libraries.UIHelper.WinFormControls.CButton();
            convertToZipCButton = new FerPROJ.Libraries.UIHelper.WinFormControls.CButton();
            selectZipKryptonLinkLabel = new Krypton.Toolkit.KryptonLinkLabel();
            filesKryptonListBox = new Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)baseKryptonPanel).BeginInit();
            baseKryptonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // baseKryptonPanel
            // 
            baseKryptonPanel.Controls.Add(filesKryptonListBox);
            baseKryptonPanel.Controls.Add(convertToZipCButton);
            baseKryptonPanel.Controls.Add(selectZipKryptonLinkLabel);
            baseKryptonPanel.Controls.Add(cButtonGenerate);
            baseKryptonPanel.Controls.Add(cTextBoxKryptonPath);
            baseKryptonPanel.Controls.Add(kryptonLinkLabelSelectPath);
            baseKryptonPanel.Size = new Size(623, 389);
            // 
            // kryptonLinkLabelSelectPath
            // 
            kryptonLinkLabelSelectPath.Location = new Point(34, 52);
            kryptonLinkLabelSelectPath.Name = "kryptonLinkLabelSelectPath";
            kryptonLinkLabelSelectPath.Size = new Size(146, 29);
            kryptonLinkLabelSelectPath.StateCommon.ShortText.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonLinkLabelSelectPath.TabIndex = 0;
            kryptonLinkLabelSelectPath.Values.Text = "Select Path:";
            kryptonLinkLabelSelectPath.LinkClicked += kryptonLinkLabelSelectPath_LinkClicked;
            // 
            // cTextBoxKryptonPath
            // 
            cTextBoxKryptonPath.Location = new Point(186, 52);
            cTextBoxKryptonPath.Name = "cTextBoxKryptonPath";
            cTextBoxKryptonPath.Size = new Size(371, 29);
            cTextBoxKryptonPath.StateActive.Back.Color1 = Color.WhiteSmoke;
            cTextBoxKryptonPath.StateActive.Border.Color1 = Color.DarkGray;
            cTextBoxKryptonPath.StateActive.Border.Color2 = Color.White;
            cTextBoxKryptonPath.StateActive.Border.Rounding = 10F;
            cTextBoxKryptonPath.StateActive.Content.Color1 = Color.Black;
            cTextBoxKryptonPath.StateCommon.Back.Color1 = Color.WhiteSmoke;
            cTextBoxKryptonPath.StateCommon.Border.Color1 = Color.White;
            cTextBoxKryptonPath.StateCommon.Border.Color2 = Color.White;
            cTextBoxKryptonPath.StateCommon.Border.Rounding = 10F;
            cTextBoxKryptonPath.StateCommon.Content.Color1 = Color.Black;
            cTextBoxKryptonPath.StateDisabled.Back.Color1 = Color.WhiteSmoke;
            cTextBoxKryptonPath.StateDisabled.Border.Color1 = Color.White;
            cTextBoxKryptonPath.StateDisabled.Border.Color2 = Color.White;
            cTextBoxKryptonPath.StateDisabled.Border.Rounding = 10F;
            cTextBoxKryptonPath.StateDisabled.Content.Color1 = Color.Black;
            cTextBoxKryptonPath.StateNormal.Back.Color1 = Color.WhiteSmoke;
            cTextBoxKryptonPath.StateNormal.Border.Color1 = Color.White;
            cTextBoxKryptonPath.StateNormal.Border.Color2 = Color.White;
            cTextBoxKryptonPath.StateNormal.Border.Rounding = 10F;
            cTextBoxKryptonPath.StateNormal.Content.Color1 = Color.Black;
            cTextBoxKryptonPath.TabIndex = 1;
            cTextBoxKryptonPath.Text = "...";
            // 
            // cButtonGenerate
            // 
            cButtonGenerate.BackColor = Color.Navy;
            cButtonGenerate.BackgroundColor = Color.Navy;
            cButtonGenerate.BorderColor = Color.Green;
            cButtonGenerate.BorderRadius = 20;
            cButtonGenerate.BorderSize = 0;
            cButtonGenerate.FlatAppearance.BorderSize = 0;
            cButtonGenerate.FlatStyle = FlatStyle.Flat;
            cButtonGenerate.Font = new Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cButtonGenerate.ForeColor = Color.White;
            cButtonGenerate.Location = new Point(407, 87);
            cButtonGenerate.Name = "cButtonGenerate";
            cButtonGenerate.Size = new Size(150, 40);
            cButtonGenerate.TabIndex = 2;
            cButtonGenerate.Text = "Generate";
            cButtonGenerate.TextColor = Color.White;
            cButtonGenerate.UseVisualStyleBackColor = false;
            cButtonGenerate.Click += cButtonGenerate_Click;
            // 
            // convertToZipCButton
            // 
            convertToZipCButton.BackColor = Color.Navy;
            convertToZipCButton.BackgroundColor = Color.Navy;
            convertToZipCButton.BorderColor = Color.Green;
            convertToZipCButton.BorderRadius = 20;
            convertToZipCButton.BorderSize = 0;
            convertToZipCButton.FlatAppearance.BorderSize = 0;
            convertToZipCButton.FlatStyle = FlatStyle.Flat;
            convertToZipCButton.Font = new Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            convertToZipCButton.ForeColor = Color.White;
            convertToZipCButton.Location = new Point(407, 264);
            convertToZipCButton.Name = "convertToZipCButton";
            convertToZipCButton.Size = new Size(150, 40);
            convertToZipCButton.TabIndex = 5;
            convertToZipCButton.Text = "ZIP";
            convertToZipCButton.TextColor = Color.White;
            convertToZipCButton.UseVisualStyleBackColor = false;
            convertToZipCButton.Click += convertToZipCButton_Click;
            // 
            // selectZipKryptonLinkLabel
            // 
            selectZipKryptonLinkLabel.Location = new Point(34, 162);
            selectZipKryptonLinkLabel.Name = "selectZipKryptonLinkLabel";
            selectZipKryptonLinkLabel.Size = new Size(146, 29);
            selectZipKryptonLinkLabel.StateCommon.ShortText.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectZipKryptonLinkLabel.TabIndex = 3;
            selectZipKryptonLinkLabel.Values.Text = "Select Path:";
            selectZipKryptonLinkLabel.LinkClicked += selectZipKryptonLinkLabel_LinkClicked;
            // 
            // filesKryptonListBox
            // 
            filesKryptonListBox.Location = new Point(186, 162);
            filesKryptonListBox.Name = "filesKryptonListBox";
            filesKryptonListBox.Size = new Size(371, 96);
            filesKryptonListBox.TabIndex = 6;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 389);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            StateCommon.Back.Color1 = Color.Navy;
            StateCommon.Back.Color2 = Color.Navy;
            StateCommon.Border.Color1 = Color.Navy;
            StateCommon.Border.Color2 = Color.Navy;
            StateCommon.Header.Back.Color1 = Color.Transparent;
            StateCommon.Header.Back.Color2 = Color.Transparent;
            StateCommon.Header.Border.Color1 = Color.Transparent;
            StateCommon.Header.Border.Color2 = Color.Transparent;
            Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)baseKryptonPanel).EndInit();
            baseKryptonPanel.ResumeLayout(false);
            baseKryptonPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FerPROJ.Libraries.UIHelper.WinFormControls.CButton cButtonGenerate;
        private FerPROJ.Libraries.UIHelper.WinFormControls.CTextBoxKrypton cTextBoxKryptonPath;
        private Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabelSelectPath;
        private FerPROJ.Libraries.UIHelper.WinFormControls.CButton convertToZipCButton;
        private Krypton.Toolkit.KryptonLinkLabel selectZipKryptonLinkLabel;
        private Krypton.Toolkit.KryptonListBox filesKryptonListBox;
    }
}