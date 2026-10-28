namespace megafon
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbInput;
        private System.Windows.Forms.ComboBox cbOutput;
        private System.Windows.Forms.Button btnPassthrough;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer recordTimer;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Button btnLoadProfile;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.TextBox txtRecordingDirectory;
        private System.Windows.Forms.TrackBar tbBass;
        private System.Windows.Forms.TrackBar tbEqLow;
        private System.Windows.Forms.TrackBar tbEqMid;
        private System.Windows.Forms.TrackBar tbEqHigh;
        private System.Windows.Forms.TrackBar tbBoost;
        private System.Windows.Forms.Label lblBassValue;
        private System.Windows.Forms.Label lblEqLowValue;
        private System.Windows.Forms.Label lblEqMidValue;
        private System.Windows.Forms.Label lblEqHighValue;
        private System.Windows.Forms.Label lblBoostValue;
        private System.Windows.Forms.ComboBox cbApps;
        private System.Windows.Forms.Button btnRefreshApps;
        private System.Windows.Forms.TrackBar tbAppVolume;
        private System.Windows.Forms.Label lblAppVolume;
        private System.Windows.Forms.Label lblAppStatus;
        private System.Windows.Forms.CheckBox chkAppMute;
        private System.Windows.Forms.MenuStrip languageMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem languageMenu;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbInput = new System.Windows.Forms.ComboBox();
            this.cbOutput = new System.Windows.Forms.ComboBox();
            this.btnPassthrough = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.recordTimer = new System.Windows.Forms.Timer(this.components);
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.btnLoadProfile = new System.Windows.Forms.Button();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.txtRecordingDirectory = new System.Windows.Forms.TextBox();
            this.tbBass = CreateTrackBar(-12, 12, 0);
            this.tbEqLow = CreateTrackBar(-12, 12, 0);
            this.tbEqMid = CreateTrackBar(-12, 12, 0);
            this.tbEqHigh = CreateTrackBar(-12, 12, 0);
            this.tbBoost = CreateTrackBar(0, 12, 0);
            this.lblBassValue = CreateValueLabel();
            this.lblEqLowValue = CreateValueLabel();
            this.lblEqMidValue = CreateValueLabel();
            this.lblEqHighValue = CreateValueLabel();
            this.lblBoostValue = CreateValueLabel();
            this.languageMenuStrip = new System.Windows.Forms.MenuStrip();
            this.languageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.languageMenuStrip.Items.Add(this.languageMenu);
            this.languageMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.languageMenuStrip.Size = new System.Drawing.Size(884, 28);
            this.languageMenuStrip.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.languageMenu.Text = "Dil / Language";
            this.languageMenu.DropDownItems.Add(CreateLanguageMenuItem("Türkçe", "tr"));
            this.languageMenu.DropDownItems.Add(CreateLanguageMenuItem("English", "en"));
            this.languageMenu.DropDownItems.Add(CreateLanguageMenuItem("Русский", "ru"));
            this.languageMenu.DropDownItems.Add(CreateLanguageMenuItem("Français", "fr"));
            this.SuspendLayout();

            System.Windows.Forms.Panel header = new System.Windows.Forms.Panel();
            header.BackColor = System.Drawing.Color.FromArgb(29, 42, 63);
            header.Location = new System.Drawing.Point(0, 28);
            header.Size = new System.Drawing.Size(884, 82);
            header.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            System.Windows.Forms.Label title = CreateLabel("MEGAFON", 24, 13, 260);
            title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            title.ForeColor = System.Drawing.Color.White;
            System.Windows.Forms.Label subtitle = CreateLabel("Mikrofon kontrolü  •  Sesini ayarla, kaydet", 26, 47, 430);
            subtitle.ForeColor = System.Drawing.Color.FromArgb(205, 215, 229);
            header.Controls.Add(title);
            header.Controls.Add(subtitle);

            System.Windows.Forms.GroupBox devices = CreateGroupBox("Ses aygıtları", 22, 126, 840, 112);
            devices.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            devices.Controls.Add(CreateLabel("Mikrofon girişi", 18, 27, 360));
            devices.Controls.Add(CreateLabel("Ses çıkışı", 430, 27, 360));
            this.cbInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInput.Location = new System.Drawing.Point(18, 52);
            this.cbInput.Size = new System.Drawing.Size(390, 25);
            this.cbInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cbOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutput.Location = new System.Drawing.Point(430, 52);
            this.cbOutput.Size = new System.Drawing.Size(390, 25);
            this.cbOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            devices.Controls.Add(this.cbInput);
            devices.Controls.Add(this.cbOutput);

            System.Windows.Forms.GroupBox sound = CreateGroupBox("Ses geliştirme", 22, 248, 840, 184);
            sound.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            string[] settingNames = { "Bas", "Düşük", "Orta", "Yüksek", "Sound booster" };
            System.Windows.Forms.TrackBar[] sliders = { tbBass, tbEqLow, tbEqMid, tbEqHigh, tbBoost };
            System.Windows.Forms.Label[] values = { lblBassValue, lblEqLowValue, lblEqMidValue, lblEqHighValue, lblBoostValue };
            for (int i = 0; i < sliders.Length; i++)
            {
                int x = 18 + i * 163;
                sound.Controls.Add(CreateLabel(settingNames[i], x, 34, 150));
                sliders[i].Location = new System.Drawing.Point(x, 62);
                sliders[i].Size = new System.Drawing.Size(145, 45);
                sliders[i].TickFrequency = 3;
                sliders[i].SmallChange = 1;
                sliders[i].LargeChange = 3;
                sound.Controls.Add(sliders[i]);
                values[i].Location = new System.Drawing.Point(x, 119);
                sound.Controls.Add(values[i]);
            }
            sound.Controls.Add(CreateLabel("EQ bantları ve bas: -12 / +12 dB", 18, 151, 420));

            System.Windows.Forms.GroupBox applications = CreateGroupBox("Windows uygulama sesleri", 22, 442, 840, 150);
            applications.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            applications.Controls.Add(CreateLabel("Ses çalan uygulama", 18, 24, 330));
            applications.Controls.Add(CreateLabel("Ses seviyesi", 500, 24, 180));
            this.cbApps = new System.Windows.Forms.ComboBox();
            this.cbApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApps.Location = new System.Drawing.Point(18, 49);
            this.cbApps.Size = new System.Drawing.Size(330, 25);
            this.btnRefreshApps = StyleButton(new System.Windows.Forms.Button(), "Yenile", 362, 47, 105);
            this.tbAppVolume = CreateTrackBar(0, 100, 100);
            this.tbAppVolume.Location = new System.Drawing.Point(495, 43);
            this.tbAppVolume.Size = new System.Drawing.Size(190, 45);
            this.tbAppVolume.Enabled = false;
            this.tbAppVolume.TickFrequency = 10;
            this.lblAppVolume = CreateValueLabel();
            this.lblAppVolume.Location = new System.Drawing.Point(688, 51);
            this.lblAppVolume.Size = new System.Drawing.Size(48, 22);
            this.lblAppVolume.Text = "100%";
            this.chkAppMute = new System.Windows.Forms.CheckBox();
            this.chkAppMute.Location = new System.Drawing.Point(752, 51);
            this.chkAppMute.Size = new System.Drawing.Size(75, 24);
            this.chkAppMute.Enabled = false;
            this.chkAppMute.Text = "Sessiz";
            this.chkAppMute.ForeColor = System.Drawing.Color.FromArgb(55, 66, 83);
            System.Windows.Forms.Label appEqInfo = CreateLabel("Uygulamaya özel EQ için sanal ses aygıtı/driver gerekir; Windows burada yalnızca ses ve sessiz kontrolü sağlar.", 18, 88, 800);
            appEqInfo.Size = new System.Drawing.Size(800, 24);
            appEqInfo.ForeColor = System.Drawing.Color.FromArgb(103, 111, 124);
            this.lblAppStatus = CreateLabel("Ses çalan uygulamalar aranıyor...", 18, 116, 800);
            applications.Controls.Add(this.cbApps);
            applications.Controls.Add(this.btnRefreshApps);
            applications.Controls.Add(this.tbAppVolume);
            applications.Controls.Add(this.lblAppVolume);
            applications.Controls.Add(this.chkAppMute);
            applications.Controls.Add(appEqInfo);
            applications.Controls.Add(this.lblAppStatus);

            System.Windows.Forms.GroupBox profiles = CreateGroupBox("Profiller", 22, 603, 840, 93);
            profiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            profiles.Controls.Add(CreateLabel("Kayıtlı profil", 18, 27, 175));
            profiles.Controls.Add(CreateLabel("Profil adı", 234, 27, 210));
            this.cbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfiles.Location = new System.Drawing.Point(18, 52);
            this.cbProfiles.Size = new System.Drawing.Size(200, 25);
            this.txtProfileName.Location = new System.Drawing.Point(234, 52);
            this.txtProfileName.Size = new System.Drawing.Size(210, 25);
            this.btnLoadProfile = StyleButton(this.btnLoadProfile, "Profili yükle", 456, 50, 150);
            this.btnSaveProfile = StyleButton(this.btnSaveProfile, "Profili kaydet", 618, 50, 190);
            profiles.Controls.Add(this.cbProfiles);
            profiles.Controls.Add(this.txtProfileName);
            profiles.Controls.Add(this.btnLoadProfile);
            profiles.Controls.Add(this.btnSaveProfile);

            System.Windows.Forms.GroupBox recording = CreateGroupBox("10 saniyelik kayıt", 22, 706, 840, 86);
            recording.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            recording.Controls.Add(CreateLabel("Kayıtların kaydedileceği klasör", 18, 24, 440));
            this.txtRecordingDirectory.Location = new System.Drawing.Point(18, 48);
            this.txtRecordingDirectory.Size = new System.Drawing.Size(690, 25);
            this.txtRecordingDirectory.ReadOnly = true;
            this.txtRecordingDirectory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowseFolder = StyleButton(this.btnBrowseFolder, "Klasör seç", 721, 45, 98);
            recording.Controls.Add(this.txtRecordingDirectory);
            recording.Controls.Add(this.btnBrowseFolder);

            this.btnPassthrough = StyleButton(this.btnPassthrough, "Mikrofonu Başlat", 22, 804, 410);
            this.btnPassthrough.Height = 42;
            this.btnPassthrough.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnPassthrough.BackColor = System.Drawing.Color.FromArgb(36, 119, 89);
            this.btnPassthrough.ForeColor = System.Drawing.Color.White;
            this.btnRecord = StyleButton(this.btnRecord, "10 sn Kayıt", 452, 804, 410);
            this.btnRecord.Height = 42;
            this.btnRecord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRecord.BackColor = System.Drawing.Color.FromArgb(47, 103, 176);
            this.btnRecord.ForeColor = System.Drawing.Color.White;

            this.lblStatus.AutoSize = false;
            this.lblStatus.Location = new System.Drawing.Point(24, 861);
            this.lblStatus.Size = new System.Drawing.Size(838, 24);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(74, 86, 103);
            this.lblStatus.Text = "Durum: Hazır";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.ClientSize = new System.Drawing.Size(884, 903);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnPassthrough);
            this.Controls.Add(recording);
            this.Controls.Add(profiles);
            this.Controls.Add(applications);
            this.Controls.Add(sound);
            this.Controls.Add(devices);
            this.Controls.Add(header);
            this.Controls.Add(this.languageMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.languageMenuStrip;
            this.MinimumSize = new System.Drawing.Size(920, 948);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Megafon | Mikrofon ve Ses Kontrolü";
            this.ResumeLayout(false);
        }

        private static System.Windows.Forms.ToolStripMenuItem CreateLanguageMenuItem(string text, string language)
        {
            return new System.Windows.Forms.ToolStripMenuItem(text) { Tag = language, CheckOnClick = false };
        }

        private static System.Windows.Forms.Label CreateLabel(string text, int x, int y, int width)
        {
            return new System.Windows.Forms.Label
            {
                AutoSize = false,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(width, 22),
                Text = text,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                ForeColor = System.Drawing.Color.FromArgb(55, 66, 83)
            };
        }

        private static System.Windows.Forms.Label CreateValueLabel()
        {
            System.Windows.Forms.Label label = CreateLabel("0 dB", 0, 0, 145);
            label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(47, 103, 176);
            return label;
        }

        private static System.Windows.Forms.TrackBar CreateTrackBar(int minimum, int maximum, int value)
        {
            return new System.Windows.Forms.TrackBar
            {
                Minimum = minimum,
                Maximum = maximum,
                Value = value,
                TickStyle = System.Windows.Forms.TickStyle.BottomRight
            };
        }

        private static System.Windows.Forms.GroupBox CreateGroupBox(string text, int x, int y, int width, int height)
        {
            return new System.Windows.Forms.GroupBox
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(width, height),
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(43, 56, 75),
                BackColor = System.Drawing.Color.White
            };
        }

        private static System.Windows.Forms.Button StyleButton(System.Windows.Forms.Button button, string text, int x, int y, int width)
        {
            button.Location = new System.Drawing.Point(x, y);
            button.Size = new System.Drawing.Size(width, 30);
            button.Text = text;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = System.Drawing.Color.FromArgb(230, 235, 243);
            button.ForeColor = System.Drawing.Color.FromArgb(40, 54, 74);
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            return button;
        }

        #endregion
    }
}
