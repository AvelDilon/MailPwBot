namespace FL
{
    partial class UCLoginAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCLoginAdd));
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
            this.label5 = new System.Windows.Forms.Label();
            this.la_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(295, 247);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(386, 247);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 18;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Название";
            // 
            // DES
            // 
            this.DES.Location = new System.Drawing.Point(295, 208);
            this.DES.Name = "DES";
            this.DES.Size = new System.Drawing.Size(166, 20);
            this.DES.TabIndex = 16;
            this.DES.Enter += new System.EventHandler(this.DES_Enter);
            this.DES.Leave += new System.EventHandler(this.DES_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Номер персонажа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Логин / почта";
            // 
            // PNU
            // 
            this.PNU.Location = new System.Drawing.Point(295, 182);
            this.PNU.Name = "PNU";
            this.PNU.Size = new System.Drawing.Size(166, 20);
            this.PNU.TabIndex = 12;
            this.PNU.Enter += new System.EventHandler(this.PNU_Enter);
            this.PNU.Leave += new System.EventHandler(this.PNU_Leave);
            // 
            // PSW
            // 
            this.PSW.Location = new System.Drawing.Point(295, 156);
            this.PSW.Name = "PSW";
            this.PSW.Size = new System.Drawing.Size(166, 20);
            this.PSW.TabIndex = 11;
            this.PSW.Enter += new System.EventHandler(this.PSW_Enter);
            this.PSW.Leave += new System.EventHandler(this.PSW_Leave);
            // 
            // LGN
            // 
            this.LGN.Location = new System.Drawing.Point(295, 130);
            this.LGN.Name = "LGN";
            this.LGN.Size = new System.Drawing.Size(166, 20);
            this.LGN.TabIndex = 10;
            this.LGN.Enter += new System.EventHandler(this.LGN_Enter);
            this.LGN.Leave += new System.EventHandler(this.LGN_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Иконка";
            // 
            // la_cancel
            // 
            this.la_cancel.Location = new System.Drawing.Point(386, 288);
            this.la_cancel.Name = "la_cancel";
            this.la_cancel.Size = new System.Drawing.Size(75, 23);
            this.la_cancel.TabIndex = 21;
            this.la_cancel.Text = "Отмена";
            this.la_cancel.UseVisualStyleBackColor = true;
            this.la_cancel.Click += new System.EventHandler(this.la_cancel_Click);
            // 
            // UCLoginAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.la_cancel);
            this.Controls.Add(this.label5);
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
            this.Name = "UCLoginAdd";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button la_cancel;
    }
}
