namespace FL
{
    partial class UCSettings
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
            this.LOFSF = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LOFSF
            // 
            this.LOFSF.AutoSize = true;
            this.LOFSF.Location = new System.Drawing.Point(14, 17);
            this.LOFSF.Name = "LOFSF";
            this.LOFSF.Size = new System.Drawing.Size(233, 17);
            this.LOFSF.TabIndex = 3;
            this.LOFSF.Text = "Использовать локальный файл офсетов";
            this.LOFSF.UseVisualStyleBackColor = true;
            this.LOFSF.CheckedChanged += new System.EventHandler(this.LOFSF_CheckedChanged);
            // 
            // UCSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LOFSF);
            this.Name = "UCSettings";
            this.Size = new System.Drawing.Size(630, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox LOFSF;
    }
}
