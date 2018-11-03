namespace PwBot
{
    partial class PwBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PwBot));
            this.PRS = new System.Windows.Forms.ComboBox();
            this.SCAN = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RunTrayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BotClose = new System.Windows.Forms.ToolStripMenuItem();
            this.TC1 = new System.Windows.Forms.TabControl();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PRS
            // 
            this.PRS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PRS.FormattingEnabled = true;
            this.PRS.Location = new System.Drawing.Point(263, 9);
            this.PRS.Name = "PRS";
            this.PRS.Size = new System.Drawing.Size(250, 21);
            this.PRS.TabIndex = 3;
            this.PRS.SelectedIndexChanged += new System.EventHandler(this.PRS_SelectedIndexChanged);
            // 
            // SCAN
            // 
            this.SCAN.Location = new System.Drawing.Point(519, 8);
            this.SCAN.Name = "SCAN";
            this.SCAN.Size = new System.Drawing.Size(105, 23);
            this.SCAN.TabIndex = 4;
            this.SCAN.Text = "Найти клиенты";
            this.SCAN.UseVisualStyleBackColor = true;
            this.SCAN.Click += new System.EventHandler(this.SCAN_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "PW BOT";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunTrayMenu,
            this.BotClose});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(158, 48);
            // 
            // RunTrayMenu
            // 
            this.RunTrayMenu.Name = "RunTrayMenu";
            this.RunTrayMenu.Size = new System.Drawing.Size(157, 22);
            this.RunTrayMenu.Text = "Запустить игру";
            // 
            // BotClose
            // 
            this.BotClose.Name = "BotClose";
            this.BotClose.Size = new System.Drawing.Size(157, 22);
            this.BotClose.Text = "Закрыть Бота";
            this.BotClose.Click += new System.EventHandler(this.BotClose_Click);
            // 
            // TC1
            // 
            this.TC1.Location = new System.Drawing.Point(0, 40);
            this.TC1.Margin = new System.Windows.Forms.Padding(0);
            this.TC1.Name = "TC1";
            this.TC1.Padding = new System.Drawing.Point(0, 0);
            this.TC1.SelectedIndex = 0;
            this.TC1.Size = new System.Drawing.Size(638, 475);
            this.TC1.TabIndex = 5;
            this.TC1.TabStop = false;
            // 
            // PwBot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.TC1);
            this.Controls.Add(this.SCAN);
            this.Controls.Add(this.PRS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PwBot";
            this.Text = "Бот";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PWS_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PWS_KeyDown);
            this.Resize += new System.EventHandler(this.PwBot_Resize);
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox PRS;
        private System.Windows.Forms.Button SCAN;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem BotClose;
        private System.Windows.Forms.ToolStripMenuItem RunTrayMenu;
        private System.Windows.Forms.TabControl TC1;
    }
}

