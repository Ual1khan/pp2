using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            string source = @"/Users/ualihan/desktop/pp2/Week2/Task4/original.txt";
            string destination = @"/Users/ualihan/desktop/pp2/Week1/Task4/copied.txt";

            if (Directory.Exiss(source))

            {

                Console.WriteLine("file has already created");
                return;
            }


            TextWriter tw = new StreamWriter(source, true);

            Console.WriteLine("Press Enter to Copy");



            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                File.Copy(source, destination, true);

                Console.WriteLine("Copied");
            }

            Console.WriteLine();

            Console.WriteLine("Press Enter to Delete old file");


            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                File.Delete(source);

                Console.WriteLine("Deleted");
            }

        }

    }
}
