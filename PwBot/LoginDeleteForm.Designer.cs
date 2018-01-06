namespace PwBot
{
    partial class LoginDeleteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DAL = new System.Windows.Forms.Label();
            this.DAB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DAL
            // 
            this.DAL.AutoSize = true;
            this.DAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DAL.Location = new System.Drawing.Point(13, 13);
            this.DAL.Name = "DAL";
            this.DAL.Size = new System.Drawing.Size(115, 13);
            this.DAL.TabIndex = 0;
            this.DAL.Text = "Удалить аккаунт?";
            // 
            // DAB
            // 
            this.DAB.Location = new System.Drawing.Point(104, 50);
            this.DAB.Name = "DAB";
            this.DAB.Size = new System.Drawing.Size(75, 23);
            this.DAB.TabIndex = 1;
            this.DAB.Text = "Удалить";
            this.DAB.UseVisualStyleBackColor = true;
            this.DAB.Click += new System.EventHandler(this.DAB_Click);
            // 
            // LoginDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 85);
            this.Controls.Add(this.DAB);
            this.Controls.Add(this.DAL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDeleteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Удаление аккаунта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DAL;
        private System.Windows.Forms.Button DAB;
    }
}