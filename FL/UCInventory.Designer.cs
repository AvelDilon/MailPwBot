namespace FL
{
    partial class UCInventory
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
            this.ISLB = new System.Windows.Forms.ListBox();
            this.InvCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ISLB
            // 
            this.ISLB.FormattingEnabled = true;
            this.ISLB.Location = new System.Drawing.Point(3, 3);
            this.ISLB.Name = "ISLB";
            this.ISLB.Size = new System.Drawing.Size(624, 394);
            this.ISLB.TabIndex = 0;
            this.ISLB.DoubleClick += new System.EventHandler(this.ISLB_DoubleClick);
            // 
            // InvCancel
            // 
            this.InvCancel.Location = new System.Drawing.Point(537, 424);
            this.InvCancel.Name = "InvCancel";
            this.InvCancel.Size = new System.Drawing.Size(90, 23);
            this.InvCancel.TabIndex = 108;
            this.InvCancel.Text = "Отмена";
            this.InvCancel.UseVisualStyleBackColor = true;
            this.InvCancel.Click += new System.EventHandler(this.InvCancel_Click);
            // 
            // UCInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InvCancel);
            this.Controls.Add(this.ISLB);
            this.Name = "UCInventory";
            this.Size = new System.Drawing.Size(630, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ISLB;
        private System.Windows.Forms.Button InvCancel;
    }
}
