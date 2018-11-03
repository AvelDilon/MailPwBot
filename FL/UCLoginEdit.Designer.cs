namespace FL
{
    partial class UCLoginEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCLoginEdit));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DES = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PNU = new System.Windows.Forms.TextBox();
            this.PSW = new System.Windows.Forms.TextBox();
            this.LGN = new System.Windows.Forms.TextBox();
            this.ac_edit_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(181, 252);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(378, 252);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 18;
            this.AddButton.Text = "Сохранить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Название";
            // 
            // DES
            // 
            this.DES.Location = new System.Drawing.Point(287, 213);
            this.DES.Name = "DES";
            this.DES.Size = new System.Drawing.Size(166, 20);
            this.DES.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Номер персонажа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Логин / почта";
            // 
            // PNU
            // 
            this.PNU.Location = new System.Drawing.Point(287, 187);
            this.PNU.Name = "PNU";
            this.PNU.Size = new System.Drawing.Size(166, 20);
            this.PNU.TabIndex = 12;
            // 
            // PSW
            // 
            this.PSW.Location = new System.Drawing.Point(287, 161);
            this.PSW.Name = "PSW";
            this.PSW.Size = new System.Drawing.Size(166, 20);
            this.PSW.TabIndex = 11;
            // 
            // LGN
            // 
            this.LGN.Location = new System.Drawing.Point(287, 135);
            this.LGN.Name = "LGN";
            this.LGN.Size = new System.Drawing.Size(166, 20);
            this.LGN.TabIndex = 10;
            // 
            // ac_edit_cancel
            // 
            this.ac_edit_cancel.Location = new System.Drawing.Point(378, 293);
            this.ac_edit_cancel.Name = "ac_edit_cancel";
            this.ac_edit_cancel.Size = new System.Drawing.Size(75, 23);
            this.ac_edit_cancel.TabIndex = 20;
            this.ac_edit_cancel.Text = "Отмена";
            this.ac_edit_cancel.UseVisualStyleBackColor = true;
            this.ac_edit_cancel.Click += new System.EventHandler(this.ac_edit_cancel_Click);
            // 
            // UCLoginEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ac_edit_cancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DES);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PNU);
            this.Controls.Add(this.PSW);
            this.Controls.Add(this.LGN);
            this.Name = "UCLoginEdit";
            this.Size = new System.Drawing.Size(630, 450);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DES;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PNU;
        private System.Windows.Forms.TextBox PSW;
        private System.Windows.Forms.TextBox LGN;
        private System.Windows.Forms.Button ac_edit_cancel;
    }
}
