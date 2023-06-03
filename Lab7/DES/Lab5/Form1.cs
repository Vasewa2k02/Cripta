using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public string key;
        public Form1()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 8)
            {
                key = textBox1.Text;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string source = openFileDialog1.FileName;
                    string fileText = File.ReadAllText(source);
                    richTextBox1.Text = fileText;
                    saveFileDialog1.Filter = "des files |*.des";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string destination = saveFileDialog1.FileName;
                        var startTime = System.Diagnostics.Stopwatch.StartNew();
                        EncryptFile(source, destination, key);
                        startTime.Stop();
                        var resultTime = startTime.Elapsed;

                        // elapsedTime - строка, которая будет содержать значение затраченного времени
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                            resultTime.Hours,
                            resultTime.Minutes,
                            resultTime.Seconds,
                            resultTime.Milliseconds);
                        label1.Text += elapsedTime.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ключ должен быть длиной 8!");
            }
           
        }



        private void EncryptFile(string source, string destination, string key)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length);

                cryptoStream.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            string fileText = File.ReadAllText(destination);
            richTextBox3.Text = fileText;
            fsInput.Close();
            fsEncrypted.Close();

        }

        private void DecryptFile(string source, string destination, string key)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsDecrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(fsDecrypted, desencrypt, CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptoStream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
                return;
            }
            string fileText = File.ReadAllText(destination);
            richTextBox2.Text = fileText;
            fsInput.Close();
            fsDecrypted.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            key = textBox1.Text;
            openFileDialog1.Filter = "des files |*.des";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "txt files | *.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string destination = saveFileDialog1.FileName;
                    var startTime = System.Diagnostics.Stopwatch.StartNew();
                    DecryptFile(source, destination, key);
                    startTime.Stop();
                    var resultTime = startTime.Elapsed;

                    // elapsedTime - строка, которая будет содержать значение затраченного времени
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                        resultTime.Hours,
                        resultTime.Minutes,
                        resultTime.Seconds,
                        resultTime.Milliseconds);
                    label2.Text += elapsedTime.ToString();
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
