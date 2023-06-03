
namespace Assymetrical_Algoritms
{
    partial class Cripta_Lab9
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
            this.texForEncrypt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.superSequeceBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.binText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.decryptedText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.encryptedText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.publicKey = new System.Windows.Forms.RichTextBox();
            this.timeEncr = new System.Windows.Forms.Label();
            this.timeDecr = new System.Windows.Forms.Label();
            this.numA = new System.Windows.Forms.Label();
            this.numN = new System.Windows.Forms.Label();
            this.modA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // texForEncrypt
            // 
            this.texForEncrypt.Location = new System.Drawing.Point(19, 50);
            this.texForEncrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.texForEncrypt.Name = "texForEncrypt";
            this.texForEncrypt.Size = new System.Drawing.Size(1463, 31);
            this.texForEncrypt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите текст для шфрования";
            // 
            // superSequeceBox
            // 
            this.superSequeceBox.Location = new System.Drawing.Point(19, 125);
            this.superSequeceBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.superSequeceBox.Name = "superSequeceBox";
            this.superSequeceBox.Size = new System.Drawing.Size(244, 316);
            this.superSequeceBox.TabIndex = 2;
            this.superSequeceBox.Text = "";
            this.superSequeceBox.TextChanged += new System.EventHandler(this.superSequeceBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(19, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Закрытый ключ(сверхвозрастающий)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // binText
            // 
            this.binText.Location = new System.Drawing.Point(634, 123);
            this.binText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.binText.Name = "binText";
            this.binText.Size = new System.Drawing.Size(297, 316);
            this.binText.TabIndex = 4;
            this.binText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Текст в бинарном виде";
            // 
            // decryptedText
            // 
            this.decryptedText.Location = new System.Drawing.Point(13, 607);
            this.decryptedText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.decryptedText.Name = "decryptedText";
            this.decryptedText.Size = new System.Drawing.Size(1463, 31);
            this.decryptedText.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 562);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Расшифрованный текст";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(13, 661);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1463, 50);
            this.button1.TabIndex = 8;
            this.button1.Text = "Старт!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // encryptedText
            // 
            this.encryptedText.Location = new System.Drawing.Point(18, 505);
            this.encryptedText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.encryptedText.Name = "encryptedText";
            this.encryptedText.Size = new System.Drawing.Size(1461, 31);
            this.encryptedText.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 456);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Зашифрованный текст";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Открытый ключ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(348, 125);
            this.publicKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(267, 314);
            this.publicKey.TabIndex = 12;
            this.publicKey.Text = "";
            // 
            // timeEncr
            // 
            this.timeEncr.AutoSize = true;
            this.timeEncr.Location = new System.Drawing.Point(714, 475);
            this.timeEncr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeEncr.Name = "timeEncr";
            this.timeEncr.Size = new System.Drawing.Size(64, 25);
            this.timeEncr.TabIndex = 13;
            this.timeEncr.Text = "Время";
            // 
            // timeDecr
            // 
            this.timeDecr.AutoSize = true;
            this.timeDecr.Location = new System.Drawing.Point(714, 577);
            this.timeDecr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeDecr.Name = "timeDecr";
            this.timeDecr.Size = new System.Drawing.Size(64, 25);
            this.timeDecr.TabIndex = 14;
            this.timeDecr.Text = "Время";
            // 
            // numA
            // 
            this.numA.AutoSize = true;
            this.numA.Location = new System.Drawing.Point(1037, 215);
            this.numA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numA.Name = "numA";
            this.numA.Size = new System.Drawing.Size(0, 25);
            this.numA.TabIndex = 15;
            // 
            // numN
            // 
            this.numN.AutoSize = true;
            this.numN.Location = new System.Drawing.Point(1037, 268);
            this.numN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numN.Name = "numN";
            this.numN.Size = new System.Drawing.Size(0, 25);
            this.numN.TabIndex = 16;
            // 
            // modA
            // 
            this.modA.AutoSize = true;
            this.modA.Location = new System.Drawing.Point(1037, 325);
            this.modA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modA.Name = "modA";
            this.modA.Size = new System.Drawing.Size(0, 25);
            this.modA.TabIndex = 17;
            // 
            // Cripta_Lab9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1497, 734);
            this.Controls.Add(this.modA);
            this.Controls.Add(this.numN);
            this.Controls.Add(this.numA);
            this.Controls.Add(this.timeDecr);
            this.Controls.Add(this.timeEncr);
            this.Controls.Add(this.publicKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.encryptedText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.decryptedText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.binText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.superSequeceBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texForEncrypt);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Cripta_Lab9";
            this.Text = "Cripta_Lab9";
            this.Load += new System.EventHandler(this.Cripta_Lab9_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox texForEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox superSequeceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox binText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox decryptedText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox encryptedText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox publicKey;
        private System.Windows.Forms.Label timeEncr;
        private System.Windows.Forms.Label timeDecr;
        private System.Windows.Forms.Label numA;
        private System.Windows.Forms.Label numN;
        private System.Windows.Forms.Label modA;
    }
}

