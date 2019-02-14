using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool pl(string s)
        {

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
                    }
            return true;
        }
        static void Main(string[] args)
        {
            string s = System.IO.File.ReadAllText("/Users/ualihan/Desktop/pp2/Week2/Task1/test.txt");
            if (pl(s))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}