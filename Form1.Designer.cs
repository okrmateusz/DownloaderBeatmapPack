namespace DownloaderBeatmapPack
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.downloadButton = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelPath = new System.Windows.Forms.Label();
            this.progressBarAll = new System.Windows.Forms.ProgressBar();
            this.numericUpDownFrom = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTo = new System.Windows.Forms.NumericUpDown();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelProgressAll = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.extractFileCheckbox = new System.Windows.Forms.CheckBox();
            this.checkBoxStandard = new System.Windows.Forms.CheckBox();
            this.checkBoxMania = new System.Windows.Forms.CheckBox();
            this.checkBoxTaiko = new System.Windows.Forms.CheckBox();
            this.checkBoxCatch = new System.Windows.Forms.CheckBox();
            this.buttonChangePath = new System.Windows.Forms.Button();
            this.statusLimitLabel = new System.Windows.Forms.Label();
            this.extractFileAndDeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(436, 426);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "start";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 34);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(43, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Status: ";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(517, 426);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limitToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // limitToolStripMenuItem
            // 
            this.limitToolStripMenuItem.Checked = true;
            this.limitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.limitToolStripMenuItem.Name = "limitToolStripMenuItem";
            this.limitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.limitToolStripMenuItem.Text = "Limit";
            this.limitToolStripMenuItem.Click += new System.EventHandler(this.limitToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemVersion});
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.versionToolStripMenuItem.Text = "Version";
            // 
            // toolStripMenuItemVersion
            // 
            this.toolStripMenuItemVersion.Name = "toolStripMenuItemVersion";
            this.toolStripMenuItemVersion.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemVersion.Text = "0.0.0.2";
            this.toolStripMenuItemVersion.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(12, 381);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(60, 13);
            this.labelPath.TabIndex = 4;
            this.labelPath.Text = "Path Save:";
            // 
            // progressBarAll
            // 
            this.progressBarAll.Location = new System.Drawing.Point(51, 426);
            this.progressBarAll.Name = "progressBarAll";
            this.progressBarAll.Size = new System.Drawing.Size(379, 23);
            this.progressBarAll.TabIndex = 6;
            // 
            // numericUpDownFrom
            // 
            this.numericUpDownFrom.Location = new System.Drawing.Point(436, 358);
            this.numericUpDownFrom.Maximum = new decimal(new int[] {
            1318,
            0,
            0,
            0});
            this.numericUpDownFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFrom.Name = "numericUpDownFrom";
            this.numericUpDownFrom.Size = new System.Drawing.Size(156, 20);
            this.numericUpDownFrom.TabIndex = 7;
            this.numericUpDownFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFrom.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDownTo
            // 
            this.numericUpDownTo.Location = new System.Drawing.Point(436, 397);
            this.numericUpDownTo.Maximum = new decimal(new int[] {
            1318,
            0,
            0,
            0});
            this.numericUpDownTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTo.Name = "numericUpDownTo";
            this.numericUpDownTo.Size = new System.Drawing.Size(156, 20);
            this.numericUpDownTo.TabIndex = 8;
            this.numericUpDownTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTo.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(433, 381);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(16, 13);
            this.labelTo.TabIndex = 9;
            this.labelTo.Text = "to";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(436, 342);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(27, 13);
            this.labelFrom.TabIndex = 10;
            this.labelFrom.Text = "from";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(51, 397);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(379, 23);
            this.progressBar.TabIndex = 11;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(12, 404);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(33, 13);
            this.labelProgress.TabIndex = 12;
            this.labelProgress.Text = "100%";
            // 
            // labelProgressAll
            // 
            this.labelProgressAll.AutoSize = true;
            this.labelProgressAll.Location = new System.Drawing.Point(12, 431);
            this.labelProgressAll.Name = "labelProgressAll";
            this.labelProgressAll.Size = new System.Drawing.Size(0, 13);
            this.labelProgressAll.TabIndex = 13;
            // 
            // textBox
            // 
            this.textBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox.DetectUrls = false;
            this.textBox.Location = new System.Drawing.Point(15, 61);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textBox.Size = new System.Drawing.Size(415, 317);
            this.textBox.TabIndex = 15;
            this.textBox.Text = "";
            // 
            // extractFileCheckbox
            // 
            this.extractFileCheckbox.AutoSize = true;
            this.extractFileCheckbox.Location = new System.Drawing.Point(436, 61);
            this.extractFileCheckbox.Name = "extractFileCheckbox";
            this.extractFileCheckbox.Size = new System.Drawing.Size(74, 17);
            this.extractFileCheckbox.TabIndex = 16;
            this.extractFileCheckbox.Text = "extract file";
            this.extractFileCheckbox.UseVisualStyleBackColor = true;
            this.extractFileCheckbox.CheckedChanged += new System.EventHandler(this.extractFile_CheckedChanged);
            // 
            // checkBoxStandard
            // 
            this.checkBoxStandard.AutoSize = true;
            this.checkBoxStandard.Checked = true;
            this.checkBoxStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStandard.Enabled = false;
            this.checkBoxStandard.Location = new System.Drawing.Point(436, 220);
            this.checkBoxStandard.Name = "checkBoxStandard";
            this.checkBoxStandard.Size = new System.Drawing.Size(87, 17);
            this.checkBoxStandard.TabIndex = 19;
            this.checkBoxStandard.Text = "osu!standard";
            this.checkBoxStandard.UseVisualStyleBackColor = true;
            // 
            // checkBoxMania
            // 
            this.checkBoxMania.AutoSize = true;
            this.checkBoxMania.Enabled = false;
            this.checkBoxMania.Location = new System.Drawing.Point(436, 243);
            this.checkBoxMania.Name = "checkBoxMania";
            this.checkBoxMania.Size = new System.Drawing.Size(74, 17);
            this.checkBoxMania.TabIndex = 20;
            this.checkBoxMania.Text = "osu!mania";
            this.checkBoxMania.UseVisualStyleBackColor = true;
            // 
            // checkBoxTaiko
            // 
            this.checkBoxTaiko.AutoSize = true;
            this.checkBoxTaiko.Enabled = false;
            this.checkBoxTaiko.Location = new System.Drawing.Point(436, 266);
            this.checkBoxTaiko.Name = "checkBoxTaiko";
            this.checkBoxTaiko.Size = new System.Drawing.Size(69, 17);
            this.checkBoxTaiko.TabIndex = 21;
            this.checkBoxTaiko.Text = "osu!taiko";
            this.checkBoxTaiko.UseVisualStyleBackColor = true;
            // 
            // checkBoxCatch
            // 
            this.checkBoxCatch.AutoSize = true;
            this.checkBoxCatch.Enabled = false;
            this.checkBoxCatch.Location = new System.Drawing.Point(436, 289);
            this.checkBoxCatch.Name = "checkBoxCatch";
            this.checkBoxCatch.Size = new System.Drawing.Size(73, 17);
            this.checkBoxCatch.TabIndex = 22;
            this.checkBoxCatch.Text = "osu!catch";
            this.checkBoxCatch.UseVisualStyleBackColor = true;
            // 
            // buttonChangePath
            // 
            this.buttonChangePath.Location = new System.Drawing.Point(436, 34);
            this.buttonChangePath.Name = "buttonChangePath";
            this.buttonChangePath.Size = new System.Drawing.Size(156, 23);
            this.buttonChangePath.TabIndex = 24;
            this.buttonChangePath.Text = "Change Path";
            this.buttonChangePath.UseVisualStyleBackColor = true;
            this.buttonChangePath.Click += new System.EventHandler(this.changePathButton_Click);
            // 
            // statusLimitLabel
            // 
            this.statusLimitLabel.AutoSize = true;
            this.statusLimitLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLimitLabel.Location = new System.Drawing.Point(436, 318);
            this.statusLimitLabel.Name = "statusLimitLabel";
            this.statusLimitLabel.Size = new System.Drawing.Size(82, 13);
            this.statusLimitLabel.TabIndex = 25;
            this.statusLimitLabel.Text = "Limit is enabled!";
            // 
            // extractFileAndDeleteCheckbox
            // 
            this.extractFileAndDeleteCheckbox.AutoSize = true;
            this.extractFileAndDeleteCheckbox.Location = new System.Drawing.Point(436, 85);
            this.extractFileAndDeleteCheckbox.Name = "extractFileAndDeleteCheckbox";
            this.extractFileAndDeleteCheckbox.Size = new System.Drawing.Size(127, 17);
            this.extractFileAndDeleteCheckbox.TabIndex = 26;
            this.extractFileAndDeleteCheckbox.Text = "extract file and delete";
            this.extractFileAndDeleteCheckbox.UseVisualStyleBackColor = true;
            this.extractFileAndDeleteCheckbox.CheckedChanged += new System.EventHandler(this.extractFileAndDelete_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.extractFileAndDeleteCheckbox);
            this.Controls.Add(this.statusLimitLabel);
            this.Controls.Add(this.buttonChangePath);
            this.Controls.Add(this.checkBoxCatch);
            this.Controls.Add(this.checkBoxTaiko);
            this.Controls.Add(this.checkBoxMania);
            this.Controls.Add(this.checkBoxStandard);
            this.Controls.Add(this.extractFileCheckbox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelProgressAll);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.numericUpDownTo);
            this.Controls.Add(this.numericUpDownFrom);
            this.Controls.Add(this.progressBarAll);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVersion;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.ProgressBar progressBarAll;
        private System.Windows.Forms.NumericUpDown numericUpDownFrom;
        private System.Windows.Forms.NumericUpDown numericUpDownTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelProgressAll;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.ToolStripMenuItem limitToolStripMenuItem;
        private System.Windows.Forms.CheckBox extractFileCheckbox;
        private System.Windows.Forms.CheckBox checkBoxStandard;
        private System.Windows.Forms.CheckBox checkBoxMania;
        private System.Windows.Forms.CheckBox checkBoxTaiko;
        private System.Windows.Forms.CheckBox checkBoxCatch;
        private System.Windows.Forms.Button buttonChangePath;
        private System.Windows.Forms.Label statusLimitLabel;
        private System.Windows.Forms.CheckBox extractFileAndDeleteCheckbox;
    }
}

