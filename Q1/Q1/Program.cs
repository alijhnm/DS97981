using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Program
    {
        private static Dictionary<int, char[]> D =
            new Dictionary<int, char[]>
            {
                [0] = new char[] { '+' },
                [1] = new char[] { '_', ',', '@' },
                [2] = new char[] { 'A', 'B', 'C' },
                [3] = new char[] { 'D', 'E', 'F' },
                [4] = new char[] { 'G', 'H', 'I' },
                [5] = new char[] { 'J', 'K', 'L' },
                [6] = new char[] { 'M', 'N', 'O' },
                [7] = new char[] { 'P', 'Q', 'R', 'S' },
                [8] = new char[] { 'T', 'U', 'V' },
                [9] = new char[] { 'W', 'X', 'Y', 'Z' },
            };
        
        
        public static List<string> A(List<string> s, int charCounter, int[] phone)
        {
            if (s.Count() == 0)
            {
                char[] chars = D[phone[charCounter]];
                List<string> result = new List<string>();
                foreach(char ch in chars)
                {
                    result.Add(ch.ToString());
                }
                return A(result, charCounter + 1, phone);
            }
            else if (s[0].Length == phone.Length)
            {
                return s;
            }
            else
            {
                char[] chars = D[phone[charCounter]];
                List<string> result = new List<string>();
                foreach(string str in s)
                {
                    foreach(char ch in chars)
                    {
                        result.Add(str + ch.ToString());
                    }
                }
                return A(result, charCounter + 1, phone); 
            }
        }

        public static string[] GetNames(int[] phone)
        {
            List<string> result = A(new List<string>() { }, 0, phone);
            return result.ToArray();

        }

        static void Main(string[] args)
        {
            int[] phoneNumber = new int[] { 0, 9, 1, 2, 2, 2, 4, 2, 5, 2, 5 };

            // چاپ یک رشته حرفی برای شماره تلفن
            for (int i = 0; i < phoneNumber.Length; i++)
                Console.Write(D[phoneNumber[i]][0]);
            Console.WriteLine();
        }


    }
}
