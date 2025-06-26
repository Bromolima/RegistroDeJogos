namespace RegistroDeJogos
{
    partial class CreditsForm
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
            this.Credits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Credits
            // 
            this.Credits.AutoSize = true;
            this.Credits.Location = new System.Drawing.Point(-3, 80);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(532, 264);
            this.Credits.TabIndex = 0;
            this.Credits.Text = "Trabalho de tópicos de linguagem de\r\nProgramação III\r\n\r\nAluno\r\nMarcelo Lima Bromo" +
    "nschenkel\r\n\r\nProfessor\r\nCarlos Augusto Sicsú A. do Nascimento\r\n";
            this.Credits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreditsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(524, 501);
            this.Controls.Add(this.Credits);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 540);
            this.MinimumSize = new System.Drawing.Size(540, 540);
            this.Name = "CreditsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Créditos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Credits;
    }
}