namespace FL
{
    partial class UCClients
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
            this.ClientsScan = new System.Windows.Forms.Button();
            this.ClientsList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ClientsScan
            // 
            this.ClientsScan.Location = new System.Drawing.Point(522, 8);
            this.ClientsScan.Name = "ClientsScan";
            this.ClientsScan.Size = new System.Drawing.Size(105, 23);
            this.ClientsScan.TabIndex = 6;
            this.ClientsScan.Text = "Найти клиенты";
            this.ClientsScan.UseVisualStyleBackColor = true;
            this.ClientsScan.Click += new System.EventHandler(this.ClientsScan_Click);
            // 
            // ClientsList
            // 
            this.ClientsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientsList.FormattingEnabled = true;
            this.ClientsList.Items.AddRange(new object[] {
            "<.. поиск ..>"});
            this.ClientsList.Location = new System.Drawing.Point(266, 9);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.Size = new System.Drawing.Size(250, 21);
            this.ClientsList.TabIndex = 5;
            this.ClientsList.SelectedIndexChanged += new System.EventHandler(this.ClientsList_SelectedIndexChanged);
            // 
            // UCClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.ClientsScan);
            this.Controls.Add(this.ClientsList);
            this.Name = "UCClients";
            this.Size = new System.Drawing.Size(640, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClientsScan;
        private System.Windows.Forms.ComboBox ClientsList;
    }
}
