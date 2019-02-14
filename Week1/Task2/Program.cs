using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class student
    {
        public string name;
        public int id;
        public int year;

        public student()
        {
            name = Console.ReadLine();
            id = int.Parse(Console.ReadLine());
            y();
        }

        public student(string name, int id)
        {
            this.name = name;
            this.id = id;
            y();
        }

        public void y()
        {
            year = int.Parse(Console.ReadLine()) + 1;
            Console.Write(year + " ");
        }
        public override string ToString()
        {
            return name + " " + id;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            student s = new student();
            Console.WriteLine(s);
            student k = new student("Uali",1);
            Console.WriteLine(k);
        }

    }
}

