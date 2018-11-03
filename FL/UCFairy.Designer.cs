namespace FL
{
    partial class UCFairy
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FairyStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "из 100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Качать: ";
            // 
            // FG
            // 
            this.FG.Location = new System.Drawing.Point(267, 140);
            this.FG.Name = "FG";
            this.FG.Size = new System.Drawing.Size(35, 20);
            this.FG.TabIndex = 10;
            this.FG.Text = "80";
            this.FG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 78);
            this.label1.MaximumSize = new System.Drawing.Size(240, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 39);
            this.label1.TabIndex = 9;
            this.label1.Text = "1) Джины качаются за дух\r\n2) Положите джинов в интвентарь\r\n3) Оставьте немного ме" +
    "ста в инвентаре";
            // 
            // FairyStart
            // 
            this.FairyStart.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FairyStart.Location = new System.Drawing.Point(194, 332);
            this.FairyStart.Name = "FairyStart";
            this.FairyStart.Size = new System.Drawing.Size(246, 41);
            this.FairyStart.TabIndex = 8;
            this.FairyStart.Text = "Запустить";
            this.FairyStart.UseVisualStyleBackColor = true;
            this.FairyStart.Click += new System.EventHandler(this.FairyStart_Click);
            this.FairyStart.Paint += new System.Windows.Forms.PaintEventHandler(this.FairyStart_Paint);
            // 
            // UCFairy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FairyStart);
            this.Name = "UCFairy";
            this.Size = new System.Drawing.Size(630, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FG;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button FairyStart;
    }
}
