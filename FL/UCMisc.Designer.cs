namespace FL
{
    partial class UCMisc
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
            this.OpenStart = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.open_delay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.open_item = new System.Windows.Forms.TextBox();
            this.GB01 = new System.Windows.Forms.GroupBox();
            this.INV_SELECT = new System.Windows.Forms.Button();
            this.GB01.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenStart
            // 
            this.OpenStart.Location = new System.Drawing.Point(121, 52);
            this.OpenStart.Name = "OpenStart";
            this.OpenStart.Size = new System.Drawing.Size(90, 23);
            this.OpenStart.TabIndex = 107;
            this.OpenStart.Text = "Начать";
            this.OpenStart.UseVisualStyleBackColor = true;
            this.OpenStart.Click += new System.EventHandler(this.OpenStart_Click);
            this.OpenStart.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenStart_Paint);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 106;
            this.label14.Text = "Пауза";
            // 
            // open_delay
            // 
            this.open_delay.Location = new System.Drawing.Point(61, 54);
            this.open_delay.Name = "open_delay";
            this.open_delay.Size = new System.Drawing.Size(44, 20);
            this.open_delay.TabIndex = 105;
            this.open_delay.Text = "4";
            this.open_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 104;
            this.label13.Text = "ID";
            // 
            // open_item
            // 
            this.open_item.Location = new System.Drawing.Point(61, 28);
            this.open_item.Name = "open_item";
            this.open_item.Size = new System.Drawing.Size(44, 20);
            this.open_item.TabIndex = 103;
            this.open_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GB01
            // 
            this.GB01.Controls.Add(this.INV_SELECT);
            this.GB01.Controls.Add(this.OpenStart);
            this.GB01.Controls.Add(this.open_item);
            this.GB01.Controls.Add(this.label14);
            this.GB01.Controls.Add(this.label13);
            this.GB01.Controls.Add(this.open_delay);
            this.GB01.Location = new System.Drawing.Point(3, 3);
            this.GB01.Name = "GB01";
            this.GB01.Size = new System.Drawing.Size(237, 99);
            this.GB01.TabIndex = 108;
            this.GB01.TabStop = false;
            this.GB01.Text = "Открыть итем";
            // 
            // INV_SELECT
            // 
            this.INV_SELECT.Location = new System.Drawing.Point(121, 26);
            this.INV_SELECT.Name = "INV_SELECT";
            this.INV_SELECT.Size = new System.Drawing.Size(90, 23);
            this.INV_SELECT.TabIndex = 108;
            this.INV_SELECT.Text = "Из инвентаря";
            this.INV_SELECT.UseVisualStyleBackColor = true;
            this.INV_SELECT.Click += new System.EventHandler(this.INV_SELECT_Click);
            this.INV_SELECT.Paint += new System.Windows.Forms.PaintEventHandler(this.INV_SELECT_Paint);
            // 
            // UCMisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GB01);
            this.Name = "UCMisc";
            this.Size = new System.Drawing.Size(630, 450);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCMisc_Paint);
            this.GB01.ResumeLayout(false);
            this.GB01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenStart;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox open_delay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox open_item;
        private System.Windows.Forms.GroupBox GB01;
        private System.Windows.Forms.Button INV_SELECT;
    }
}
