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
            this.ALCM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AccAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.AccEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.AccDel = new System.Windows.Forms.ToolStripMenuItem();
            this.ZB = new System.Windows.Forms.TabPage();
            this.SkipBattles = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PointLimit = new System.Windows.Forms.TextBox();
            this.OBCB = new System.Windows.Forms.CheckBox();
            this.BB_RUN = new System.Windows.Forms.Button();
            this.TP2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FairyStart = new System.Windows.Forms.Button();
            this.ALP = new System.Windows.Forms.TabPage();
            this.PIL = new System.Windows.Forms.ListView();
            this.SetClient = new System.Windows.Forms.Button();
            this.AddAcc = new System.Windows.Forms.Button();
            this.TC1 = new System.Windows.Forms.TabControl();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BotClose = new System.Windows.Forms.ToolStripMenuItem();
            this.RunTrayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ALCM.SuspendLayout();
            this.ZB.SuspendLayout();
            this.TP2.SuspendLayout();
            this.ALP.SuspendLayout();
            this.TC1.SuspendLayout();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PRS
            // 
            this.PRS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PRS.FormattingEnabled = true;
            this.PRS.Location = new System.Drawing.Point(10, 10);
            this.PRS.Name = "PRS";
            this.PRS.Size = new System.Drawing.Size(250, 21);
            this.PRS.TabIndex = 3;
            this.PRS.SelectedIndexChanged += new System.EventHandler(this.PRS_SelectedIndexChanged);
            // 
            // SCAN
            // 
            this.SCAN.Location = new System.Drawing.Point(311, 10);
            this.SCAN.Name = "SCAN";
            this.SCAN.Size = new System.Drawing.Size(64, 23);
            this.SCAN.TabIndex = 4;
            this.SCAN.Text = "Искать";
            this.SCAN.UseVisualStyleBackColor = true;
            this.SCAN.Click += new System.EventHandler(this.SCAN_Click);
            // 
            // ALCM
            // 
            this.ALCM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccAdd,
            this.AccEdit,
            this.AccDel});
            this.ALCM.Name = "ALCM";
            this.ALCM.Size = new System.Drawing.Size(129, 70);
            // 
            // AccAdd
            // 
            this.AccAdd.Name = "AccAdd";
            this.AccAdd.Size = new System.Drawing.Size(128, 22);
            this.AccAdd.Text = "Добавить";
            this.AccAdd.Click += new System.EventHandler(this.AccAdd_Click);
            // 
            // AccEdit
            // 
            this.AccEdit.Name = "AccEdit";
            this.AccEdit.Size = new System.Drawing.Size(128, 22);
            this.AccEdit.Text = "Изменить";
            this.AccEdit.Click += new System.EventHandler(this.AccEdit_Click);
            // 
            // AccDel
            // 
            this.AccDel.Name = "AccDel";
            this.AccDel.Size = new System.Drawing.Size(128, 22);
            this.AccDel.Text = "Удалить";
            this.AccDel.Click += new System.EventHandler(this.AccDel_Click);
            // 
            // ZB
            // 
            this.ZB.Controls.Add(this.SkipBattles);
            this.ZB.Controls.Add(this.label4);
            this.ZB.Controls.Add(this.PointLimit);
            this.ZB.Controls.Add(this.OBCB);
            this.ZB.Controls.Add(this.BB_RUN);
            this.ZB.Location = new System.Drawing.Point(4, 22);
            this.ZB.Margin = new System.Windows.Forms.Padding(0);
            this.ZB.Name = "ZB";
            this.ZB.Size = new System.Drawing.Size(357, 320);
            this.ZB.TabIndex = 2;
            this.ZB.Text = "Звери";
            this.ZB.UseVisualStyleBackColor = true;
            // 
            // SkipBattles
            // 
            this.SkipBattles.AutoSize = true;
            this.SkipBattles.Location = new System.Drawing.Point(58, 43);
            this.SkipBattles.Name = "SkipBattles";
            this.SkipBattles.Size = new System.Drawing.Size(189, 17);
            this.SkipBattles.TabIndex = 4;
            this.SkipBattles.Text = "Пропускать бои (иногда падает)";
            this.SkipBattles.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Набить не более";
            // 
            // PointLimit
            // 
            this.PointLimit.Location = new System.Drawing.Point(153, 81);
            this.PointLimit.Name = "PointLimit";
            this.PointLimit.Size = new System.Drawing.Size(45, 20);
            this.PointLimit.TabIndex = 2;
            this.PointLimit.Text = "3000";
            // 
            // OBCB
            // 
            this.OBCB.AutoSize = true;
            this.OBCB.Checked = true;
            this.OBCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OBCB.Location = new System.Drawing.Point(58, 20);
            this.OBCB.Name = "OBCB";
            this.OBCB.Size = new System.Drawing.Size(119, 17);
            this.OBCB.TabIndex = 1;
            this.OBCB.Text = "Открывать мешки";
            this.OBCB.UseVisualStyleBackColor = true;
            // 
            // BB_RUN
            // 
            this.BB_RUN.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BB_RUN.Location = new System.Drawing.Point(58, 276);
            this.BB_RUN.Name = "BB_RUN";
            this.BB_RUN.Size = new System.Drawing.Size(246, 41);
            this.BB_RUN.TabIndex = 0;
            this.BB_RUN.Text = "Запустить";
            this.BB_RUN.UseVisualStyleBackColor = true;
            this.BB_RUN.Click += new System.EventHandler(this.BB_RUN_Click);
            this.BB_RUN.Paint += new System.Windows.Forms.PaintEventHandler(this.BB_RUN_Paint);
            // 
            // TP2
            // 
            this.TP2.BackColor = System.Drawing.Color.White;
            this.TP2.Controls.Add(this.label3);
            this.TP2.Controls.Add(this.label2);
            this.TP2.Controls.Add(this.FG);
            this.TP2.Controls.Add(this.label1);
            this.TP2.Controls.Add(this.FairyStart);
            this.TP2.Location = new System.Drawing.Point(4, 22);
            this.TP2.Margin = new System.Windows.Forms.Padding(0);
            this.TP2.Name = "TP2";
            this.TP2.Size = new System.Drawing.Size(357, 320);
            this.TP2.TabIndex = 1;
            this.TP2.Text = "Джин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "из 100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Качать: ";
            // 
            // FG
            // 
            this.FG.Location = new System.Drawing.Point(103, 71);
            this.FG.Name = "FG";
            this.FG.Size = new System.Drawing.Size(35, 20);
            this.FG.TabIndex = 5;
            this.FG.Text = "70";
            this.FG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 22);
            this.label1.MaximumSize = new System.Drawing.Size(240, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Купите джинов, положите их в интвентарь. И... Оставьте немного места :)";
            // 
            // FairyStart
            // 
            this.FairyStart.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FairyStart.Location = new System.Drawing.Point(58, 276);
            this.FairyStart.Name = "FairyStart";
            this.FairyStart.Size = new System.Drawing.Size(246, 41);
            this.FairyStart.TabIndex = 3;
            this.FairyStart.Text = "Запустить";
            this.FairyStart.UseVisualStyleBackColor = true;
            this.FairyStart.Click += new System.EventHandler(this.FairyStart_Click);
            this.FairyStart.Paint += new System.Windows.Forms.PaintEventHandler(this.FairyStart_Paint);
            // 
            // ALP
            // 
            this.ALP.BackColor = System.Drawing.Color.White;
            this.ALP.Controls.Add(this.PIL);
            this.ALP.Controls.Add(this.SetClient);
            this.ALP.Controls.Add(this.AddAcc);
            this.ALP.Location = new System.Drawing.Point(4, 22);
            this.ALP.Margin = new System.Windows.Forms.Padding(0);
            this.ALP.Name = "ALP";
            this.ALP.Size = new System.Drawing.Size(357, 320);
            this.ALP.TabIndex = 4;
            this.ALP.Text = "AutoLogin";
            // 
            // PIL
            // 
            this.PIL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PIL.ContextMenuStrip = this.ALCM;
            this.PIL.LabelWrap = false;
            this.PIL.Location = new System.Drawing.Point(0, 10);
            this.PIL.Margin = new System.Windows.Forms.Padding(0);
            this.PIL.MultiSelect = false;
            this.PIL.Name = "PIL";
            this.PIL.ShowGroups = false;
            this.PIL.Size = new System.Drawing.Size(357, 281);
            this.PIL.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.PIL.TabIndex = 0;
            this.PIL.UseCompatibleStateImageBehavior = false;
            this.PIL.DoubleClick += new System.EventHandler(this.PIL_DoubleClick);
            // 
            // SetClient
            // 
            this.SetClient.Location = new System.Drawing.Point(3, 294);
            this.SetClient.Name = "SetClient";
            this.SetClient.Size = new System.Drawing.Size(134, 23);
            this.SetClient.TabIndex = 10;
            this.SetClient.Text = "Указать клиент";
            this.SetClient.UseVisualStyleBackColor = true;
            this.SetClient.Click += new System.EventHandler(this.SetClient_Click);
            // 
            // AddAcc
            // 
            this.AddAcc.Location = new System.Drawing.Point(220, 294);
            this.AddAcc.Name = "AddAcc";
            this.AddAcc.Size = new System.Drawing.Size(134, 23);
            this.AddAcc.TabIndex = 8;
            this.AddAcc.Text = "Добавить аккаунт";
            this.AddAcc.UseVisualStyleBackColor = true;
            this.AddAcc.Click += new System.EventHandler(this.AddAcc_Click);
            // 
            // TC1
            // 
            this.TC1.Controls.Add(this.ALP);
            this.TC1.Controls.Add(this.TP2);
            this.TC1.Controls.Add(this.ZB);
            this.TC1.Location = new System.Drawing.Point(10, 45);
            this.TC1.Margin = new System.Windows.Forms.Padding(0);
            this.TC1.Name = "TC1";
            this.TC1.Padding = new System.Drawing.Point(0, 0);
            this.TC1.SelectedIndex = 0;
            this.TC1.Size = new System.Drawing.Size(365, 346);
            this.TC1.TabIndex = 5;
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
            this.TrayMenu.Size = new System.Drawing.Size(158, 70);
            // 
            // BotClose
            // 
            this.BotClose.Name = "BotClose";
            this.BotClose.Size = new System.Drawing.Size(157, 22);
            this.BotClose.Text = "Закрыть Бота";
            this.BotClose.Click += new System.EventHandler(this.BotClose_Click);
            // 
            // RunTrayMenu
            // 
            this.RunTrayMenu.Name = "RunTrayMenu";
            this.RunTrayMenu.Size = new System.Drawing.Size(157, 22);
            this.RunTrayMenu.Text = "Запустить игру";
            // 
            // PwBot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(384, 400);
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
            this.Move += new System.EventHandler(this.PWS_Move);
            this.Resize += new System.EventHandler(this.PwBot_Resize);
            this.ALCM.ResumeLayout(false);
            this.ZB.ResumeLayout(false);
            this.ZB.PerformLayout();
            this.TP2.ResumeLayout(false);
            this.TP2.PerformLayout();
            this.ALP.ResumeLayout(false);
            this.TC1.ResumeLayout(false);
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox PRS;
        private System.Windows.Forms.Button SCAN;
        private System.Windows.Forms.ContextMenuStrip ALCM;
        private System.Windows.Forms.ToolStripMenuItem AccDel;
        private System.Windows.Forms.ToolStripMenuItem AccEdit;
        private System.Windows.Forms.ToolStripMenuItem AccAdd;
        private System.Windows.Forms.TabPage ZB;
        private System.Windows.Forms.CheckBox SkipBattles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PointLimit;
        private System.Windows.Forms.CheckBox OBCB;
        private System.Windows.Forms.Button BB_RUN;
        private System.Windows.Forms.TabPage TP2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FairyStart;
        private System.Windows.Forms.TabPage ALP;
        private System.Windows.Forms.ListView PIL;
        private System.Windows.Forms.Button SetClient;
        private System.Windows.Forms.Button AddAcc;
        private System.Windows.Forms.TabControl TC1;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem BotClose;
        private System.Windows.Forms.ToolStripMenuItem RunTrayMenu;
    }
}

