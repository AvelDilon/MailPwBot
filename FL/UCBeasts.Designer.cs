namespace FL
{
    partial class UCBeasts
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
            this.SBCB = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PointLimit = new System.Windows.Forms.TextBox();
            this.OBCB = new System.Windows.Forms.CheckBox();
            this.BB_RUN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SBCB
            // 
            this.SBCB.AutoSize = true;
            this.SBCB.Checked = true;
            this.SBCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SBCB.Location = new System.Drawing.Point(217, 156);
            this.SBCB.Name = "SBCB";
            this.SBCB.Size = new System.Drawing.Size(229, 17);
            this.SBCB.TabIndex = 9;
            this.SBCB.Text = "Пропускать бои (иногда вылетает окно)";
            this.SBCB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Набить не более";
            // 
            // PointLimit
            // 
            this.PointLimit.Location = new System.Drawing.Point(312, 194);
            this.PointLimit.Name = "PointLimit";
            this.PointLimit.Size = new System.Drawing.Size(45, 20);
            this.PointLimit.TabIndex = 7;
            this.PointLimit.Text = "3000";
            // 
            // OBCB
            // 
            this.OBCB.AutoSize = true;
            this.OBCB.Checked = true;
            this.OBCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OBCB.Location = new System.Drawing.Point(217, 133);
            this.OBCB.Name = "OBCB";
            this.OBCB.Size = new System.Drawing.Size(119, 17);
            this.OBCB.TabIndex = 6;
            this.OBCB.Text = "Открывать мешки";
            this.OBCB.UseVisualStyleBackColor = true;
            // 
            // BB_RUN
            // 
            this.BB_RUN.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BB_RUN.Location = new System.Drawing.Point(194, 333);
            this.BB_RUN.Name = "BB_RUN";
            this.BB_RUN.Size = new System.Drawing.Size(246, 41);
            this.BB_RUN.TabIndex = 5;
            this.BB_RUN.Text = "Запустить";
            this.BB_RUN.UseVisualStyleBackColor = true;
            this.BB_RUN.Click += new System.EventHandler(this.BB_RUN_Click);
            this.BB_RUN.Paint += new System.Windows.Forms.PaintEventHandler(this.BB_RUN_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 61);
            this.label1.MaximumSize = new System.Drawing.Size(240, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "1) Дождитесь окончания \"замка\"\r\n2) Зайдите в дом\r\n3) Дом должен быть чистым";
            // 
            // UCBeasts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SBCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PointLimit);
            this.Controls.Add(this.OBCB);
            this.Controls.Add(this.BB_RUN);
            this.Name = "UCBeasts";
            this.Size = new System.Drawing.Size(630, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox SBCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PointLimit;
        private System.Windows.Forms.CheckBox OBCB;
        public System.Windows.Forms.Button BB_RUN;
        private System.Windows.Forms.Label label1;
    }
}
