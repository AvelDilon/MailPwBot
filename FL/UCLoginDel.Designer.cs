namespace FL
{
    partial class UCLoginDel
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
            this.DAB = new System.Windows.Forms.Button();
            this.DAL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DAB
            // 
            this.DAB.Location = new System.Drawing.Point(279, 228);
            this.DAB.Name = "DAB";
            this.DAB.Size = new System.Drawing.Size(75, 23);
            this.DAB.TabIndex = 3;
            this.DAB.Text = "Удалить";
            this.DAB.UseVisualStyleBackColor = true;
            this.DAB.Click += new System.EventHandler(this.DAB_Click);
            // 
            // DAL
            // 
            this.DAL.AutoSize = true;
            this.DAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DAL.Location = new System.Drawing.Point(258, 200);
            this.DAL.Name = "DAL";
            this.DAL.Size = new System.Drawing.Size(115, 13);
            this.DAL.TabIndex = 2;
            this.DAL.Text = "Удалить аккаунт?";
            // 
            // UCLoginDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DAB);
            this.Controls.Add(this.DAL);
            this.Name = "UCLoginDel";
            this.Size = new System.Drawing.Size(630, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DAB;
        private System.Windows.Forms.Label DAL;
    }
}
