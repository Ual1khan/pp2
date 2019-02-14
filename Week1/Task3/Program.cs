using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // variable integer, inputs string and converts to integer 
            int[] array = new int[n]; // array is created 
            int[] array2 = new int[n * 2]; // another array is created with doubled quantity of array 
            string[] s = Console.ReadLine().Split();
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(s[i]); // the array inputs elements through loop  


                array2[j] = array[i]; // the first array's elements moved to the second array 
                array2[j + 1] = array[i];  // every next element automatically repeated 

                j = j + 2;


            }
            for (int f = 0; f < (n * 2); f++)
            {

                Console.Write(array2[f] + " "); // outputs array's elements 


            }

        }
    }
}