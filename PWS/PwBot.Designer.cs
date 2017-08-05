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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PwBot));
            this.PRS = new System.Windows.Forms.ComboBox();
            this.SCAN = new System.Windows.Forms.Button();
            this.ZB = new System.Windows.Forms.TabPage();
            this.BB_RUN = new System.Windows.Forms.Button();
            this.TP2 = new System.Windows.Forms.TabPage();
            this.ALP = new System.Windows.Forms.TabPage();
            this.SetClient = new System.Windows.Forms.Button();
            this.RemAcc = new System.Windows.Forms.Button();
            this.AddAcc = new System.Windows.Forms.Button();
            this.RunClient = new System.Windows.Forms.Button();
            this.LGS = new System.Windows.Forms.ComboBox();
            this.TC1 = new System.Windows.Forms.TabControl();
            this.FairyStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OBCB = new System.Windows.Forms.CheckBox();
            this.ZB.SuspendLayout();
            this.TP2.SuspendLayout();
            this.ALP.SuspendLayout();
            this.TC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PRS
            // 
            this.PRS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PRS.FormattingEnabled = true;
            this.PRS.Location = new System.Drawing.Point(10, 10);
            this.PRS.Name = "PRS";
            this.PRS.Size = new System.Drawing.Size(192, 21);
            this.PRS.TabIndex = 3;
            this.PRS.SelectedIndexChanged += new System.EventHandler(this.PRS_SelectedIndexChanged);
            // 
            // SCAN
            // 
            this.SCAN.Location = new System.Drawing.Point(208, 9);
            this.SCAN.Name = "SCAN";
            this.SCAN.Size = new System.Drawing.Size(64, 23);
            this.SCAN.TabIndex = 4;
            this.SCAN.Text = "Искать";
            this.SCAN.UseVisualStyleBackColor = true;
            this.SCAN.Click += new System.EventHandler(this.SCAN_Click);
            // 
            // ZB
            // 
            this.ZB.Controls.Add(this.OBCB);
            this.ZB.Controls.Add(this.BB_RUN);
            this.ZB.Location = new System.Drawing.Point(4, 22);
            this.ZB.Margin = new System.Windows.Forms.Padding(0);
            this.ZB.Name = "ZB";
            this.ZB.Size = new System.Drawing.Size(252, 175);
            this.ZB.TabIndex = 2;
            this.ZB.Text = "Звери";
            this.ZB.UseVisualStyleBackColor = true;
            // 
            // BB_RUN
            // 
            this.BB_RUN.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BB_RUN.Location = new System.Drawing.Point(3, 131);
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
            this.TP2.Size = new System.Drawing.Size(252, 175);
            this.TP2.TabIndex = 1;
            this.TP2.Text = "Джин";
            // 
            // ALP
            // 
            this.ALP.BackColor = System.Drawing.Color.White;
            this.ALP.Controls.Add(this.SetClient);
            this.ALP.Controls.Add(this.RemAcc);
            this.ALP.Controls.Add(this.AddAcc);
            this.ALP.Controls.Add(this.RunClient);
            this.ALP.Controls.Add(this.LGS);
            this.ALP.Location = new System.Drawing.Point(4, 22);
            this.ALP.Margin = new System.Windows.Forms.Padding(0);
            this.ALP.Name = "ALP";
            this.ALP.Size = new System.Drawing.Size(252, 175);
            this.ALP.TabIndex = 4;
            this.ALP.Text = "AutoLogin";
            // 
            // SetClient
            // 
            this.SetClient.Location = new System.Drawing.Point(6, 103);
            this.SetClient.Name = "SetClient";
            this.SetClient.Size = new System.Drawing.Size(134, 23);
            this.SetClient.TabIndex = 10;
            this.SetClient.Text = "Указать клиент";
            this.SetClient.UseVisualStyleBackColor = true;
            this.SetClient.Click += new System.EventHandler(this.SetClient_Click);
            // 
            // RemAcc
            // 
            this.RemAcc.Location = new System.Drawing.Point(6, 74);
            this.RemAcc.Name = "RemAcc";
            this.RemAcc.Size = new System.Drawing.Size(134, 23);
            this.RemAcc.TabIndex = 9;
            this.RemAcc.Text = "Удалить аккаунт";
            this.RemAcc.UseVisualStyleBackColor = true;
            this.RemAcc.Click += new System.EventHandler(this.RemAcc_Click);
            // 
            // AddAcc
            // 
            this.AddAcc.Location = new System.Drawing.Point(6, 45);
            this.AddAcc.Name = "AddAcc";
            this.AddAcc.Size = new System.Drawing.Size(134, 23);
            this.AddAcc.TabIndex = 8;
            this.AddAcc.Text = "Добавить аккаунт";
            this.AddAcc.UseVisualStyleBackColor = true;
            this.AddAcc.Click += new System.EventHandler(this.AddAcc_Click);
            // 
            // RunClient
            // 
            this.RunClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RunClient.Location = new System.Drawing.Point(146, 45);
            this.RunClient.Name = "RunClient";
            this.RunClient.Size = new System.Drawing.Size(100, 52);
            this.RunClient.TabIndex = 7;
            this.RunClient.Text = "Запустить";
            this.RunClient.UseVisualStyleBackColor = true;
            this.RunClient.Click += new System.EventHandler(this.RunClient_Click);
            // 
            // LGS
            // 
            this.LGS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LGS.FormattingEnabled = true;
            this.LGS.Location = new System.Drawing.Point(6, 6);
            this.LGS.Name = "LGS";
            this.LGS.Size = new System.Drawing.Size(240, 21);
            this.LGS.TabIndex = 6;
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
            this.TC1.Size = new System.Drawing.Size(260, 201);
            this.TC1.TabIndex = 5;
            // 
            // FairyStart
            // 
            this.FairyStart.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FairyStart.Location = new System.Drawing.Point(3, 131);
            this.FairyStart.Name = "FairyStart";
            this.FairyStart.Size = new System.Drawing.Size(246, 41);
            this.FairyStart.TabIndex = 3;
            this.FairyStart.Text = "Запустить";
            this.FairyStart.UseVisualStyleBackColor = true;
            this.FairyStart.Click += new System.EventHandler(this.FairyStart_Click);
            this.FairyStart.Paint += new System.Windows.Forms.PaintEventHandler(this.FairyStart_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.MaximumSize = new System.Drawing.Size(240, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Купите джинов, положите их в интвентарь. И... Оставьте немного места :)";
            // 
            // FG
            // 
            this.FG.Location = new System.Drawing.Point(58, 62);
            this.FG.Name = "FG";
            this.FG.Size = new System.Drawing.Size(35, 20);
            this.FG.TabIndex = 5;
            this.FG.Text = "70";
            this.FG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Качать: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "из 100";
            // 
            // OBCB
            // 
            this.OBCB.AutoSize = true;
            this.OBCB.Location = new System.Drawing.Point(15, 13);
            this.OBCB.Name = "OBCB";
            this.OBCB.Size = new System.Drawing.Size(119, 17);
            this.OBCB.TabIndex = 1;
            this.OBCB.Text = "Открывать мешки";
            this.OBCB.UseVisualStyleBackColor = true;
            // 
            // PwBot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(284, 256);
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
            this.ZB.ResumeLayout(false);
            this.ZB.PerformLayout();
            this.TP2.ResumeLayout(false);
            this.TP2.PerformLayout();
            this.ALP.ResumeLayout(false);
            this.TC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox PRS;
        private System.Windows.Forms.Button SCAN;
        private System.Windows.Forms.TabPage ZB;
        private System.Windows.Forms.Button BB_RUN;
        private System.Windows.Forms.TabPage TP2;
        private System.Windows.Forms.TabPage ALP;
        private System.Windows.Forms.Button SetClient;
        private System.Windows.Forms.Button RemAcc;
        private System.Windows.Forms.Button AddAcc;
        private System.Windows.Forms.Button RunClient;
        private System.Windows.Forms.ComboBox LGS;
        private System.Windows.Forms.TabControl TC1;
        private System.Windows.Forms.Button FairyStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FG;
        private System.Windows.Forms.CheckBox OBCB;
    }
}

