using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
    class EllipticCurves
    {
        private static Random random = new Random(); 
        private static string alphabeth = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
        private static int[,] points = 
            { { 189, 297 }, { 189, 454 }, { 192, 32 }, { 192, 719 }, { 194, 205 }, { 194, 546 }, { 197, 145 }, { 197, 606 },
            { 198, 224 }, { 198, 527 }, { 200, 30 }, { 200, 721 }, { 203, 324 }, { 203, 427 }, { 205, 372 }, { 205, 379 }, 
            { 206, 106 }, { 206, 645 }, { 209, 82 }, { 209, 669 }, { 210, 31 }, { 210, 720 }, { 215, 247 }, { 215, 504 },
            { 218, 150 }, { 218, 601 }, { 221, 138 }, { 221, 613 }, { 226, 9 }, { 226, 742 }, { 227, 299 }, { 227, 542 } };

        public static int[] InversePoint(int[] P)
        {
            return new int[2] { P[0], (-1) * P[1] };
        }

        private static int CalculateLambda(int[] P, int a, int p)
        {
            return GCD.Mod(GCD.Mod(3 * (P[0] * P[0]) + a, p) * GCD.ModInverse(2 * P[1], p), p);
        }

        private static int CalculateLambda(int[] P, int[] Q, int p)
        {
            var a = GCD.Mod(GCD.Mod(Q[1] - P[1], p) * GCD.Mod(GCD.ModInverse(Q[0] + GCD.Mod(-P[0], p), p), p), p);
            //Console.WriteLine(a);
            return a;
        }

        public static int[] CalculateSum(int[] P, int[] Q, int p)
        {
            int lambda = CalculateLambda(P, Q, p);
            int x = GCD.Mod(lambda * lambda - P[0] - Q[0], p);
            int y = GCD.Mod(lambda * (P[0] - x) - P[1], p);
            return new int[] { x, y };
        }

        public static int[] CalculateSum(int[] P, int a, int p)
        {
            int lambda = CalculateLambda(P, a, p);
            int x = GCD.Mod(lambda * lambda - P[0] - P[0], p);
            int y = GCD.Mod(lambda * (P[0] - x) - P[1], p);
            return new int[] { x, y };
        }

        public static int[] kP(int k , int[] P, int a, int p)
        {
            int[] kP = P;
            for (int i = 0; i < (int)Math.Log(k, 2); i++)
                kP = CalculateSum(kP, a, p);
            k = k - (int)Math.Pow(2, (int)Math.Log(k, 2));
            while (k > 1)
            {
                for (int i = 0; i < (int)Math.Log(k, 2); i++)
                    kP = CalculateSum(kP, CalculateSum(P, a, p), p);
                k = k - (int)Math.Pow(2, (int)Math.Log(k, 2));
            }
            if (k == 1) kP = CalculateSum(kP, P, p);
            return kP;
        }

        public static int[,] Encrypt(string text, int[] G, int a, int p, int d)
        {
            int[] Q = kP(d, G, a, p), P;
            int[,] encryptedText = new int[text.Length, 4];
            int k;
            Console.WriteLine($"G = ({G[0]}, {G[1]}), d = {d}, Q = ({Q[0]}, {Q[1]})");
            for (int i = 0; i < text.Length; i++)
            {
                k = random.Next(2, d);
                P = Enumerable.Range(0, points.GetLength(1)).Select(x => points[alphabeth.IndexOf(text[i]), x]).ToArray();
                int[] C1 = kP(k, G, a, p), kQ = kP(k, Q, a, p), C2;
                C2 = CalculateSum(P, kQ, p);
                encryptedText[i, 0] = C1[0]; encryptedText[i, 1] = C1[1];
                encryptedText[i, 2] = C2[0]; encryptedText[i, 3] = C2[1];
            }
            return encryptedText;
        }

        public static string Decrypt(int[,] encryptedText, int a, int p, int d)
        {
            string decryptedText = "";
            for (int i = 0; i < encryptedText.GetUpperBound(0) + 1; i++)
            {
                int[] C1 = kP(d, new int[] { encryptedText[i, 0], encryptedText[i, 1] }, a, p), C2 = { encryptedText[i, 2], encryptedText[i, 3] };
                int[] P = CalculateSum(C2, InversePoint(C1), p);
                for (int k = 0; k < points.GetUpperBound(0) + 1; k++)
                {
                    if (points[k, 0] == P[0] && points[k, 1] == P[1])
                    {
                        decryptedText += alphabeth[k];
                        break;
                    }
                }
            }
            return decryptedText;
        }

        public static int[] CreateDigitalSign(int[] G, int q, int d, int a, int p)
        {
            Console.WriteLine($"G = ({G[0]}, {G[1]}), d = {d}, q = {q}");
            int[] digitalSign = new int[2];
            int[] kG;
            int k, t;
            do
            {
                do
                {
                    k = random.Next(2, q);
                    kG = kP(k, G, a, p);
                    digitalSign[0] = kG[0] % q;
                } while (digitalSign[0] <= 1);
                t = GCD.ModInverse(k, q);
                int H = points[alphabeth.IndexOf("т"), 0] % 13; 
                digitalSign[1] = (t * (H + d * digitalSign[0])) % q;
            } while (digitalSign[1] <= 0);
            return digitalSign;
        }

        public static bool VerifyDigitalSign(int[] digitalSign, int[] G, int q, int d, int a, int p)
        {
            if (digitalSign[0] <= 1 || digitalSign[1] >= q)
                return false;

            int H = points[alphabeth.IndexOf("т"), 0] % 13;

            int w = GCD.ModInverse(digitalSign[1], q);
            int u1 = (w * H) % q;
            int u2 = (w * digitalSign[0]) % q;
            int[] Q = kP(d, G, a, p), u1G = kP(u1, G, a, p), u2Q = kP(u2, Q, a, p);
            int v = CalculateSum(u1G, u2Q, p)[0] % q;
            return digitalSign[0] == v;
        }
    }
}
