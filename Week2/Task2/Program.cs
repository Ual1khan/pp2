using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static bool prime(int num)// method to identify prime numbers
        {
            if (num == 1)
                return false;// 1 isn't prime
            if (num == 2)
                return true;// 2 is prime
            for (int i = 2; i < num / 2; i++)
                if (num % i == 0)
                    return false;// not prime if it will divide to number without remainder 
            return true;// prime number after passing loop
        }
        static void Main(string[] args)
        {
            string[] s = System.IO.File.ReadAllText(@"/Users/ualihan/desktop/pp2/Week2/Task2/input.txt").Split();//Read numbers from file and split spaces
            string r = "";// creating empty string to store all numbers
            for (int i = 0; i < s.Length; i++)
            {
                if (prime(int.Parse(s[i])))// checking number after converting it to integer
                {
                    r += s[i] + " ";// adding to string each prime number as a char
                }
            }

            System.IO.File.WriteAllText(@"Users/ualihan/desktop/pp2/Week2/Task2/output.txt", r);// storing output in another file
        }
    }
}