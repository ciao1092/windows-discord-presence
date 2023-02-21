namespace windows_discord_presence
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.syncSettingsButton = new System.Windows.Forms.Button();
            this.instagram_username_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.whatsapp_phone_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.instagram_button_checkbox = new System.Windows.Forms.CheckBox();
            this.whatsapp_button_checkbox = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.hideLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.quitLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "Windows Discord Presence";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Double-Click to show...";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(98, 26);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Image = global::windows_discord_presence.Properties.Resources.discord_ico_64;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(679, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows Discord Presence";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.syncSettingsButton);
            this.groupBox1.Controls.Add(this.instagram_username_textbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.whatsapp_phone_textbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.instagram_button_checkbox);
            this.groupBox1.Controls.Add(this.whatsapp_button_checkbox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 136);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preferences";
            // 
            // syncSettingsButton
            // 
            this.syncSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syncSettingsButton.Location = new System.Drawing.Point(302, 84);
            this.syncSettingsButton.Name = "syncSettingsButton";
            this.syncSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.syncSettingsButton.TabIndex = 6;
            this.syncSettingsButton.Text = "Apply";
            this.syncSettingsButton.UseVisualStyleBackColor = true;
            this.syncSettingsButton.Click += new System.EventHandler(this.syncSettingsButton_Click);
            // 
            // instagram_username_textbox
            // 
            this.instagram_username_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.instagram_username_textbox.Location = new System.Drawing.Point(512, 43);
            this.instagram_username_textbox.Name = "instagram_username_textbox";
            this.instagram_username_textbox.Size = new System.Drawing.Size(155, 23);
            this.instagram_username_textbox.TabIndex = 5;
            this.instagram_username_textbox.Text = "some.username";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username: @";
            // 
            // whatsapp_phone_textbox
            // 
            this.whatsapp_phone_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.whatsapp_phone_textbox.Location = new System.Drawing.Point(512, 18);
            this.whatsapp_phone_textbox.Name = "whatsapp_phone_textbox";
            this.whatsapp_phone_textbox.Size = new System.Drawing.Size(155, 23);
            this.whatsapp_phone_textbox.TabIndex = 3;
            this.whatsapp_phone_textbox.Text = "0 000 000 0000";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone number: +";
            // 
            // instagram_button_checkbox
            // 
            this.instagram_button_checkbox.AutoSize = true;
            this.instagram_button_checkbox.Location = new System.Drawing.Point(12, 47);
            this.instagram_button_checkbox.Name = "instagram_button_checkbox";
            this.instagram_button_checkbox.Size = new System.Drawing.Size(397, 19);
            this.instagram_button_checkbox.TabIndex = 1;
            this.instagram_button_checkbox.Text = "Show a \"Instagram Profile\" button when using Instagram Desktop App";
            this.instagram_button_checkbox.UseVisualStyleBackColor = true;
            // 
            // whatsapp_button_checkbox
            // 
            this.whatsapp_button_checkbox.AutoSize = true;
            this.whatsapp_button_checkbox.Location = new System.Drawing.Point(12, 22);
            this.whatsapp_button_checkbox.Name = "whatsapp_button_checkbox";
            this.whatsapp_button_checkbox.Size = new System.Drawing.Size(338, 19);
            this.whatsapp_button_checkbox.TabIndex = 0;
            this.whatsapp_button_checkbox.Text = "Show a \"Chat on WhatsApp\" button when using WhatsApp";
            this.whatsapp_button_checkbox.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideLink,
            this.quitLink});
            this.statusStrip1.Location = new System.Drawing.Point(0, 158);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(679, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // hideLink
            // 
            this.hideLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.hideLink.ForeColor = System.Drawing.Color.Blue;
            this.hideLink.IsLink = true;
            this.hideLink.Name = "hideLink";
            this.hideLink.Size = new System.Drawing.Size(111, 17);
            this.hideLink.Text = "Hide to System Tray";
            this.hideLink.Click += new System.EventHandler(this.hideLink_Click);
            // 
            // quitLink
            // 
            this.quitLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.quitLink.ForeColor = System.Drawing.Color.Blue;
            this.quitLink.IsLink = true;
            this.quitLink.Name = "quitLink";
            this.quitLink.Size = new System.Drawing.Size(30, 17);
            this.quitLink.Text = "Quit";
            this.quitLink.Click += new System.EventHandler(this.quitLink_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.syncSettingsButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 180);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(695, 177);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Windows Discord Presence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox1;
        private CheckBox whatsapp_button_checkbox;
        private Label label2;
        private CheckBox instagram_button_checkbox;
        private TextBox instagram_username_textbox;
        private Label label3;
        private TextBox whatsapp_phone_textbox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel hideLink;
        private ToolStripStatusLabel quitLink;
        private Button syncSettingsButton;
    }
}