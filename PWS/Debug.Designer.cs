namespace PwBot
{
    partial class Debug
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
            this.LTB = new System.Windows.Forms.TextBox();
            this.INF = new System.Windows.Forms.Button();
            this.TEST = new System.Windows.Forms.Button();
            this.CurWin = new System.Windows.Forms.Button();
            this.AllWin = new System.Windows.Forms.Button();
            this.NPC = new System.Windows.Forms.Button();
            this.Loot = new System.Windows.Forms.Button();
            this.EH = new System.Windows.Forms.Button();
            this.CTRL = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.TV1 = new System.Windows.Forms.TextBox();
            this.TV2 = new System.Windows.Forms.TextBox();
            this.TV3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LTB
            // 
            this.LTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LTB.Location = new System.Drawing.Point(2, 2);
            this.LTB.Multiline = true;
            this.LTB.Name = "LTB";
            this.LTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LTB.Size = new System.Drawing.Size(535, 335);
            this.LTB.TabIndex = 1;
            // 
            // INF
            // 
            this.INF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.INF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.INF.Location = new System.Drawing.Point(12, 344);
            this.INF.Name = "INF";
            this.INF.Size = new System.Drawing.Size(101, 23);
            this.INF.TabIndex = 2;
            this.INF.Text = "Персонаж";
            this.INF.UseVisualStyleBackColor = true;
            this.INF.Click += new System.EventHandler(this.INF_Click);
            // 
            // TEST
            // 
            this.TEST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TEST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TEST.Location = new System.Drawing.Point(13, 431);
            this.TEST.Name = "TEST";
            this.TEST.Size = new System.Drawing.Size(207, 23);
            this.TEST.TabIndex = 3;
            this.TEST.Text = "!! BEAST !!";
            this.TEST.UseVisualStyleBackColor = true;
            this.TEST.Click += new System.EventHandler(this.TEST_Click);
            // 
            // CurWin
            // 
            this.CurWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurWin.Location = new System.Drawing.Point(12, 373);
            this.CurWin.Name = "CurWin";
            this.CurWin.Size = new System.Drawing.Size(100, 23);
            this.CurWin.TabIndex = 4;
            this.CurWin.Text = "Текущее окно";
            this.CurWin.UseVisualStyleBackColor = true;
            this.CurWin.Click += new System.EventHandler(this.CurWin_Click);
            // 
            // AllWin
            // 
            this.AllWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AllWin.Location = new System.Drawing.Point(12, 402);
            this.AllWin.Name = "AllWin";
            this.AllWin.Size = new System.Drawing.Size(100, 23);
            this.AllWin.TabIndex = 5;
            this.AllWin.Text = "Все окна";
            this.AllWin.UseVisualStyleBackColor = true;
            this.AllWin.Click += new System.EventHandler(this.AllWin_Click);
            // 
            // NPC
            // 
            this.NPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NPC.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NPC.Location = new System.Drawing.Point(119, 344);
            this.NPC.Name = "NPC";
            this.NPC.Size = new System.Drawing.Size(101, 23);
            this.NPC.TabIndex = 6;
            this.NPC.Text = "NPC";
            this.NPC.UseVisualStyleBackColor = true;
            this.NPC.Click += new System.EventHandler(this.NPC_Click);
            // 
            // Loot
            // 
            this.Loot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Loot.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Loot.Location = new System.Drawing.Point(119, 373);
            this.Loot.Name = "Loot";
            this.Loot.Size = new System.Drawing.Size(101, 23);
            this.Loot.TabIndex = 7;
            this.Loot.Text = "Loot";
            this.Loot.UseVisualStyleBackColor = true;
            this.Loot.Click += new System.EventHandler(this.Loot_Click);
            // 
            // EH
            // 
            this.EH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EH.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EH.Location = new System.Drawing.Point(119, 402);
            this.EH.Name = "EH";
            this.EH.Size = new System.Drawing.Size(101, 23);
            this.EH.TabIndex = 8;
            this.EH.Text = "EnterHome";
            this.EH.UseVisualStyleBackColor = true;
            this.EH.Click += new System.EventHandler(this.KMSS_Click);
            // 
            // CTRL
            // 
            this.CTRL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CTRL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CTRL.Location = new System.Drawing.Point(226, 344);
            this.CTRL.Name = "CTRL";
            this.CTRL.Size = new System.Drawing.Size(101, 23);
            this.CTRL.TabIndex = 9;
            this.CTRL.Text = "CONTROL";
            this.CTRL.UseVisualStyleBackColor = true;
            this.CTRL.Click += new System.EventHandler(this.CTRL_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button5.Location = new System.Drawing.Point(226, 373);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "FAIRY";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button6.Location = new System.Drawing.Point(226, 403);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "NOP";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // TV1
            // 
            this.TV1.Location = new System.Drawing.Point(357, 347);
            this.TV1.Name = "TV1";
            this.TV1.Size = new System.Drawing.Size(171, 20);
            this.TV1.TabIndex = 12;
            // 
            // TV2
            // 
            this.TV2.Location = new System.Drawing.Point(357, 376);
            this.TV2.Name = "TV2";
            this.TV2.Size = new System.Drawing.Size(171, 20);
            this.TV2.TabIndex = 13;
            // 
            // TV3
            // 
            this.TV3.Location = new System.Drawing.Point(357, 406);
            this.TV3.Name = "TV3";
            this.TV3.Size = new System.Drawing.Size(171, 20);
            this.TV3.TabIndex = 14;
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(540, 468);
            this.Controls.Add(this.TV3);
            this.Controls.Add(this.TV2);
            this.Controls.Add(this.TV1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.CTRL);
            this.Controls.Add(this.EH);
            this.Controls.Add(this.Loot);
            this.Controls.Add(this.NPC);
            this.Controls.Add(this.AllWin);
            this.Controls.Add(this.CurWin);
            this.Controls.Add(this.TEST);
            this.Controls.Add(this.INF);
            this.Controls.Add(this.LTB);
            this.KeyPreview = true;
            this.Name = "Debug";
            this.ShowIcon = false;
            this.Text = "Отладка и информация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Debug_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Debug_KeyDown);
            this.Move += new System.EventHandler(this.Debug_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LTB;
        private System.Windows.Forms.Button INF;
        private System.Windows.Forms.Button TEST;
        private System.Windows.Forms.Button CurWin;
        private System.Windows.Forms.Button AllWin;
        private System.Windows.Forms.Button NPC;
        private System.Windows.Forms.Button Loot;
        private System.Windows.Forms.Button EH;
        private System.Windows.Forms.Button CTRL;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox TV1;
        private System.Windows.Forms.TextBox TV2;
        private System.Windows.Forms.TextBox TV3;
    }
}