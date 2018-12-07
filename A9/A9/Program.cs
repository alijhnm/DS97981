using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] list = new long[] { 1, 5, 3, 90, 32, 5, 0};
            Console.WriteLine(list.Max().ToString());
            Console.ReadKey();
        }
    }
}
