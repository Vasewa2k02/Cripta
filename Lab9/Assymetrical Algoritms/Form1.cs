using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace Assymetrical_Algoritms
{
    public partial class Cripta_Lab9 : Form
    {
        public Cripta_Lab9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //сверхвозрастающая последовательность (закрытый ключ)
            BigInteger[] mass = SuperSequence(); 

            superSequeceBox.Text = "";
            for (int i = 0; i < mass.Length; i++)
            {
                superSequeceBox.Text += mass[i] + "\n";
            }

            BigInteger W = 0; //Сумма элементов массива

            for (int i = 0; i < mass.Length; i++)
            {
                W += mass[i];
            }

            //Для получения открытого ключa все значения закрытого ключа умножаются на некоторое число a по модулю n

            string n = "265252859812191058636308479999999";
            //string n = "40";

            BigInteger N = BigInteger.Parse(n);
            numN.Text = "n = " + N.ToString();

            string a = "75838465738475849374657348573930";
            //string a = "13";

            BigInteger A = BigInteger.Parse(a);
            numA.Text = "a = " + A.ToString();

            BigInteger[] S = new BigInteger[8];

            publicKey.Text = "";


            for (int i = 0; i < 8; i++)
            {
                S[i] = (mass[i] * A) % N;
                publicKey.Text += S[i] + "\n";
            }

            string[] set = toBin(texForEncrypt.Text);

            binText.Text = "";
            for (int i = 0; i < set.Length; i++)
            {
                binText.Text += set[i] + "\n";
            }

            BigInteger[] crypt = new BigInteger[set.Length];

            long ellapledTicks = DateTime.Now.Ticks;
            
            encryptedText.Text = "";
            for (int i = 0; i < set.Length; i++)
            {
                char[] b = set[i].ToCharArray();
                for (int j = 0; j < b.Length; j++)
                {
                    crypt[i] += BigInteger.Parse(b[j].ToString()) * S[j];
                }
                encryptedText.Text += crypt[i];
                encryptedText.Text += " ";
            }

            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;

            timeEncr.Text = "Время зашифрования: " + ellapledTicks / 1000 + " мс";

            string modAs = "198053286779263733527432885858298";
            //string modAs = "37";
            BigInteger mod_A = BigInteger.Parse(modAs);
            modA.Text = "a^-1 = " + mod_A.ToString();

            BigInteger[] startEncrypt = new BigInteger[crypt.Length];
            long ellapledTicks2 = DateTime.Now.Ticks;
            //s = c * (а ^ –1) mod n
            for (int i = 0; i < crypt.Length; i++)
            {
                startEncrypt[i] = (crypt[i] * mod_A) % N;
            }

            string[] encrypt = new string[startEncrypt.Length];
            for (int i = 0; i < startEncrypt.Length; i++)
            {
                string currentWord = "";
                BigInteger toNull = startEncrypt[i];

                for (int j = mass.Length - 1; j >= 0; j--)
                {

                    if (toNull >= mass[j])
                    {
                        toNull -= mass[j];
                        currentWord += "1";
                    }
                    else
                    {
                        currentWord += "0";
                    }
                }
                encrypt[i] = new string(currentWord.ToCharArray().Reverse().ToArray());

            }
            ellapledTicks2 = DateTime.Now.Ticks - ellapledTicks2;
            string bicaryEncrypt = "";
            for (int i = 0; i < encrypt.Length; i++)
            {
                bicaryEncrypt += encrypt[i];
            }
            var stringArray = Enumerable.Range(0, bicaryEncrypt.Length / 8).Select(i => Convert.ToByte(bicaryEncrypt.Substring(i * 8, 8), 2)).ToArray();
            var result = Encoding.Unicode.GetString(stringArray);
            result = result.Remove(result.Length - 1);
            decryptedText.Text = result;
            timeDecr.Text = "Время расшифрования: " + ellapledTicks2 / 1000 + " мс";
        }

        static BigInteger[] SuperSequence()
        {
            Random rnd = new Random();
            BigInteger[] mass = new BigInteger[8];

            mass[0] = rnd.Next(1, 10);
            for (int i = 1; i < mass.Length; i++)
            {
                for (int j = 0; j < mass.Length; j++)
                {
                    if (i != j)
                        mass[i] += mass[j];
                }
                mass[i] += 1;

                Console.WriteLine(mass[i]);
            }
            return mass;
        }

        static string[] toBin(string text)
        {
            string str = text;

            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.Unicode.GetBytes(str))
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0')).Append(' ');
            string binaryStr = sb.ToString();
            string[] set = binaryStr.Split(' ');
            return set;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Cripta_Lab9_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void superSequeceBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
