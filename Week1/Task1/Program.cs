using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {

        public static bool Isprime(int n) //created function which identifies prime
        {
            if (n == 1)
            {
                return false; // integer "1" is not prime

            }
            if (n == 2)
            {
                return true; // integer "2" is not prime
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false; // loop that identifies if integer is prime

                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            {
                int n; // created variable that is integer

                int cnt = 0; // created variable that counts

                n = int.Parse(Console.ReadLine()); // input string and it is converted to integer

                int[] array = new int[n]; // created array

                string s = Console.ReadLine();

                string[] ar = s.Split(); // elements of array are splited bt space

                for (int i = 0; i < n; i++) // input elements by using loop into array
                {
                    array[i] = int.Parse(ar[i]);
                }


                for (int i = 0; i < array.Length; i++)
                {

                    if (Isprime(array[i])) // counter increments if this statement is true
                    {
                        cnt++;
                    }
                }

                Console.WriteLine(cnt);

                for (int i = 0; i < array.Length; i++) // this loop outputs elements from the array
                {

                    if (Isprime(array[i]))
                    {
                        Console.Write(array[i] + " ");
                    }
                }
                Console.ReadKey();

            }


        }
    }
}