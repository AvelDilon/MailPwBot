namespace FL
{
    partial class UCAL
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
            this.components = new System.ComponentModel.Container();
            this.PIL = new System.Windows.Forms.ListView();
            this.ALCM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AccAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.AccEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.AccDel = new System.Windows.Forms.ToolStripMenuItem();
            this.SetClient = new System.Windows.Forms.Button();
            this.AddAcc = new System.Windows.Forms.Button();
            this.ALCM.SuspendLayout();
            this.SuspendLayout();
            // 
            // PIL
            // 
            this.PIL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PIL.ContextMenuStrip = this.ALCM;
            this.PIL.LabelWrap = false;
            this.PIL.Location = new System.Drawing.Point(30, 30);
            this.PIL.Margin = new System.Windows.Forms.Padding(0);
            this.PIL.MultiSelect = false;
            this.PIL.Name = "PIL";
            this.PIL.ShowGroups = false;
            this.PIL.Size = new System.Drawing.Size(570, 320);
            this.PIL.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.PIL.TabIndex = 11;
            this.PIL.UseCompatibleStateImageBehavior = false;
            this.PIL.DoubleClick += new System.EventHandler(this.PIL_DoubleClick);
            // 
            // ALCM
            // 
            this.ALCM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccAdd,
            this.AccEdit,
            this.AccDel});
            this.ALCM.Name = "ALCM";
            this.ALCM.Size = new System.Drawing.Size(129, 70);
            // 
            // AccAdd
            // 
            this.AccAdd.Name = "AccAdd";
            this.AccAdd.Size = new System.Drawing.Size(128, 22);
            this.AccAdd.Text = "Добавить";
            this.AccAdd.Click += new System.EventHandler(this.AccAdd_Click);
            // 
            // AccEdit
            // 
            this.AccEdit.Name = "AccEdit";
            this.AccEdit.Size = new System.Drawing.Size(128, 22);
            this.AccEdit.Text = "Изменить";
            this.AccEdit.Click += new System.EventHandler(this.AccEdit_Click);
            // 
            // AccDel
            // 
            this.AccDel.Name = "AccDel";
            this.AccDel.Size = new System.Drawing.Size(128, 22);
            this.AccDel.Text = "Удалить";
            this.AccDel.Click += new System.EventHandler(this.AccDel_Click);
            // 
            // SetClient
            // 
            this.SetClient.Location = new System.Drawing.Point(20, 410);
            this.SetClient.Name = "SetClient";
            this.SetClient.Size = new System.Drawing.Size(134, 23);
            this.SetClient.TabIndex = 13;
            this.SetClient.Text = "Указать клиент";
            this.SetClient.UseVisualStyleBackColor = true;
            this.SetClient.Click += new System.EventHandler(this.SetClient_Click);
            // 
            // AddAcc
            // 
            this.AddAcc.Location = new System.Drawing.Point(476, 410);
            this.AddAcc.Name = "AddAcc";
            this.AddAcc.Size = new System.Drawing.Size(134, 23);
            this.AddAcc.TabIndex = 12;
            this.AddAcc.Text = "Добавить аккаунт";
            this.AddAcc.UseVisualStyleBackColor = true;
            this.AddAcc.Click += new System.EventHandler(this.AddAcc_Click);
            // 
            // UCAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PIL);
            this.Controls.Add(this.SetClient);
            this.Controls.Add(this.AddAcc);
            this.Name = "UCAL";
            this.Size = new System.Drawing.Size(630, 450);
            this.ALCM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PIL;
        private System.Windows.Forms.Button SetClient;
        private System.Windows.Forms.Button AddAcc;
        private System.Windows.Forms.ContextMenuStrip ALCM;
        private System.Windows.Forms.ToolStripMenuItem AccAdd;
        private System.Windows.Forms.ToolStripMenuItem AccEdit;
        private System.Windows.Forms.ToolStripMenuItem AccDel;
    }
}
