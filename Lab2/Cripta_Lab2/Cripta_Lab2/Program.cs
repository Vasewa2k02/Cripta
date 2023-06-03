using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cripta_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string f;
            string name_fran = "Kirill Sergeevich Bulavsky";
            name_fran = name_fran.Replace(" ", "").ToLower();

            string name_Rus = "Булавский Кирил Сергеевич";
            name_Rus = name_Rus.Replace(" ", "").ToLower();

            Entropia_Shennon shan = new Entropia_Shennon();

            Console.WriteLine("-------------1-2---------------\n");

            //Russian
            f = shan.data_file_str("Rus.txt");
            double ent_Rus_str = shan.entrop(f, "RusResult.log");
            Console.WriteLine("Энтропия текста на русском языке: \n" + ent_Rus_str + "\n");

            StringBuilder f_byte = new StringBuilder();
            foreach (char a in f)
                f_byte.Append(Convert.ToString(a, 2));
            double ent_Rus_byte = shan.entrop(f_byte.ToString(), "RusByteResult.log");
            Console.WriteLine("Энтропия бинарного текста на русском языке: \n" + ent_Rus_byte + "\n");

            //Franch
            f = shan.data_file_str("fran.txt");
            double ent_fran_str = shan.entrop(f, "franResult.log");
            Console.WriteLine("Энтропия текста на французском языке: \n" + ent_fran_str + "\n");

            foreach (char a in f)
                f_byte.Append(Convert.ToString(a, 2));
            double ent_fran_byte = shan.entrop(f_byte.ToString(), "franByteResult.log");
            Console.WriteLine("Энтропия бинарного текста на французском языке: \n" + ent_fran_byte + "\n");

            Console.WriteLine("-------------3---------------\n");
            //FIO
            Console.WriteLine("Количество информации в моём ФИО: \n\t на русском: " + shan.info(name_Rus, ent_Rus_str)
                                                            + "\n\t на французском: " + shan.info(name_fran, ent_fran_str) + "\n");

            byte[] bytes = Encoding.ASCII.GetBytes(name_Rus);
            String ASCII_Rus = "";
            foreach (var b in bytes)
                ASCII_Rus += b;

            bytes = Encoding.ASCII.GetBytes(name_fran);
            String ASCII_fran = "";
            foreach (var b in bytes)
                ASCII_fran += b;

            Console.WriteLine("Количество информации в моём ФИО(ASCII): \n\t на русском: " + shan.info(ASCII_Rus, ent_Rus_byte)
                                                            + "\n\t на французском: " + shan.info(ASCII_fran, ent_fran_byte) + "\n");

            Console.WriteLine("-------------4----------------\n");

            Console.WriteLine("Количество информации в моём ФИО с вероятностью ошибочной передачи единичного бита 0.1:"
                + "\n\t на русском: " + shan.infoMistake(name_Rus.Length, 0.1)
                + "\n\t на французском: " + shan.infoMistake(name_fran.Length, 0.1) + "\n");

            Console.WriteLine("Количество информации в моём ФИО с вероятностью ошибочной передачи единичного бита 0.5:"
                + "\n\t на русском: " + shan.infoMistake(name_Rus.Length, 0.5)
                + "\n\t на французском: " + shan.infoMistake(name_fran.Length, 0.5) + "\n");

            Console.WriteLine("Количество информации в моём ФИО с вероятностью ошибочной передачи единичного бита 1.0:"
                + "\n\t на русском: " + shan.infoMistake(name_Rus.Length, 1.0)
                + "\n\t на французском: " + shan.infoMistake(name_fran.Length, 1.0) + "\n");




        }
    }
}
