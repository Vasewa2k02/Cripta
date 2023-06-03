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

namespace mp5crypt
{
    public partial class Cripta_Lab11 : Form
    {
        public Cripta_Lab11()
        {
            InitializeComponent();
        }
        private void encrypt_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            encryptText.Text = GetHash(textToEncrypt.Text);
            stopwatch.Stop();
            TimeLabel.Text = "Затраченное время: " + stopwatch.ElapsedMilliseconds + " мс";
        }
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}