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
        
        
        public static string[] A(string[] s, int charCounter, int breakpoint, int[] phone)
        {
            if (s[0].Length == breakpoint)
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
                return A(result.ToArray(), charCounter + 1, breakpoint, phone); 
            }
        }

        public static string[] GetNames(int[] phone)
        {
            return new string[] { "ali" };  
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
