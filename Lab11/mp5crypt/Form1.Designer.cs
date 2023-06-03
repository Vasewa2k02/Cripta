
namespace mp5crypt
{
    partial class Cripta_Lab11
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textToEncrypt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.encryptText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.encrypt = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textToEncrypt
            // 
            this.textToEncrypt.Location = new System.Drawing.Point(13, 51);
            this.textToEncrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textToEncrypt.Name = "textToEncrypt";
            this.textToEncrypt.Size = new System.Drawing.Size(664, 31);
            this.textToEncrypt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текст для хеширования";
            // 
            // encryptText
            // 
            this.encryptText.Location = new System.Drawing.Point(13, 132);
            this.encryptText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.encryptText.Name = "encryptText";
            this.encryptText.Size = new System.Drawing.Size(664, 31);
            this.encryptText.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Хеш";
            // 
            // encrypt
            // 
            this.encrypt.Location = new System.Drawing.Point(71, 237);
            this.encrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.encrypt.Name = "encrypt";
            this.encrypt.Size = new System.Drawing.Size(532, 33);
            this.encrypt.TabIndex = 6;
            this.encrypt.Text = "Получить хеш";
            this.encrypt.UseVisualStyleBackColor = true;
            this.encrypt.Click += new System.EventHandler(this.encrypt_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(13, 189);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(189, 25);
            this.TimeLabel.TabIndex = 7;
            this.TimeLabel.Text = "Время выполнения:   ";
            // 
            // Cripta_Lab11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(688, 320);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.encrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.encryptText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textToEncrypt);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Cripta_Lab11";
            this.Text = "Cripta_Lab11";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textToEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox encryptText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button encrypt;
        private System.Windows.Forms.Label TimeLabel;
    }
}

