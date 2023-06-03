using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cripta_Lab2
{
    class Entropia_Shennon
    {
        public string data_file_str(string name_file)
        {
            FileStream fstream = File.OpenRead(name_file);
            byte[] array = new byte[fstream.Length];
            fstream.Read(array, 0, array.Length);
            string s = System.Text.Encoding.Default.GetString(array);

            char[] deaf = new char[] { '\n', ' ', '(', ')', '.', ',', '^', '?', '!', '—', '…', '\r', '-', ':', ';', '»', '«', '\'', '’' };
            foreach (char c in deaf)
            {
                s = s.Replace(c.ToString(), "");
            }
            return s;
        }

        public void result_file(string name_file,  Dictionary<char,int> collec)
        {
            var selectkey = from i in collec
                            orderby i.Key
                            select i;
            using (StreamWriter sw = new StreamWriter(name_file))
            {
                foreach (var el in selectkey)
                {
                    sw.WriteLine($"Element {el.Key} - {el.Value} \n");
                    using (StreamWriter sw_all = new StreamWriter("info.log", true, Encoding.Default))
                    { sw_all.Write($"{DateTime.Now} count {el.Key}  = {el.Value} \n"); }
                }
            }
        }
        public double entrop(string str, string name_out_file = "Result.log")
        {
            double result = 0.0;

            str = str.Replace(" ", "").ToUpper();

            int leng = str.Length;

            var collec = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (collec.ContainsKey(c))
                    collec[c] += 1;
                else
                    collec.Add(c, 1);
            }

            result_file(name_out_file, collec);

            foreach(var el in collec)
            {
                var i = (double)el.Value / leng;
                result += -(i * Math.Log(i, 2));
            }

            return result;
        }
        public double info(string str, double entropy)
        {
            //str = str.Replace(" ", "");
            return str.Length * entropy;
        }

        public double infoMistake(int len, double p)
        {
            double q = 1 - p;
            double result = -p * Math.Log(p) / Math.Log(2) - q * Math.Log(q) / Math.Log(2);
            return len * (1 - result);
        }
    }
}
