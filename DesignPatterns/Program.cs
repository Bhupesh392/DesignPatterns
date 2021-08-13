using DesignPatterns.SingletonDesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => PrintStudentDetails(),
                () => PrintEmployeeDetails()
                );

            Console.ReadKey();
        }

        private static void PrintEmployeeDetails()
        {
            /*
            * Assuming Singleton is created from employee class
            * we refer to the GetInstance property from the Singleton class
            **/
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("from student");
        }

        private static void PrintStudentDetails()
        {
            /*
             * Assuming Singleton is created from student class
             * we refer to the GetInstance property from the Singleton class
             **/
            Singleton fromEmp = Singleton.GetInstance;
            fromEmp.PrintDetails("From employee");
        }
    }
}
