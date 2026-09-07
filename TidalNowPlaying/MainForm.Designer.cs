namespace TidalNowPlaying
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button toggleButton;
        private Label statusLabel;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.CheckBox minimizeToTrayCheckbox;
        private CheckBox includePrefixCheckbox;
        private Label trailingSpacesLabel;
        private NumericUpDown trailingSpacesInput;
        private Label outputHelpLabel;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.toggleButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.minimizeToTrayCheckbox = new System.Windows.Forms.CheckBox();
            this.includePrefixCheckbox = new CheckBox();
            this.trailingSpacesLabel = new Label();
            this.trailingSpacesInput = new NumericUpDown();
            this.outputHelpLabel = new Label();
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip();
            this.trayIcon = new System.Windows.Forms.NotifyIcon();

            this.SuspendLayout();

            // toggleButton
            this.toggleButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toggleButton.Location = new System.Drawing.Point(40, 30);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(180, 40);
            this.toggleButton.TabIndex = 0;
            this.toggleButton.Text = "Enable";
            this.toggleButton.UseVisualStyleBackColor = true;
            this.toggleButton.Click += new System.EventHandler(this.toggleButton_Click);

            // statusLabel
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusLabel.Location = new System.Drawing.Point(40, 85);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(114, 19);
            this.statusLabel.Text = "Status: Disabled";

            // minimizeToTrayCheckbox
            this.minimizeToTrayCheckbox.AutoSize = true;
            this.minimizeToTrayCheckbox.Location = new System.Drawing.Point(40, 110);
            this.minimizeToTrayCheckbox.Name = "minimizeToTrayCheckbox";
            this.minimizeToTrayCheckbox.Size = new System.Drawing.Size(113, 19);
            this.minimizeToTrayCheckbox.Text = "Minimize to tray";
            this.minimizeToTrayCheckbox.Checked = false;
            this.minimizeToTrayCheckbox.TabIndex = 1;

            // Text file output settings
            this.includePrefixCheckbox.AutoSize = true;
            this.includePrefixCheckbox.Location = new System.Drawing.Point(40, 145);
            this.includePrefixCheckbox.Name = "includePrefixCheckbox";
            this.includePrefixCheckbox.Text = "Include \"Current Song:\" &prefix";
            this.includePrefixCheckbox.TabIndex = 2;

            this.trailingSpacesLabel.AutoSize = true;
            this.trailingSpacesLabel.Location = new System.Drawing.Point(40, 179);
            this.trailingSpacesLabel.Text = "Trailing &spaces:";
            this.trailingSpacesLabel.TabIndex = 3;

            this.trailingSpacesInput.Location = new System.Drawing.Point(155, 175);
            this.trailingSpacesInput.Name = "trailingSpacesInput";
            this.trailingSpacesInput.Size = new System.Drawing.Size(65, 23);
            this.trailingSpacesInput.Minimum = 0;
            this.trailingSpacesInput.Maximum = OutputSettings.MaxTrailingSpaces;
            this.trailingSpacesInput.AccessibleName = "Trailing spaces";
            this.trailingSpacesInput.TabIndex = 4;

            this.outputHelpLabel.AutoSize = true;
            this.outputHelpLabel.Location = new System.Drawing.Point(40, 210);
            this.outputHelpLabel.Text = "Text file only. Add 0-100 spaces for scrolling.\r\nChanges are saved automatically.";

            // trayIcon
            this.trayIcon.Text = "Tidal Now Playing";
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Visible = true;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(340, 265);
            this.Controls.Add(this.toggleButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.minimizeToTrayCheckbox);
            this.Controls.Add(this.includePrefixCheckbox);
            this.Controls.Add(this.trailingSpacesLabel);
            this.Controls.Add(this.trailingSpacesInput);
            this.Controls.Add(this.outputHelpLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tidal Now Playing";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
