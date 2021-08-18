using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowAndDeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Shallow Copy: Creating a new object and then copying the value type fields of the current object to the new object. But when the data is reference type, then the only reference is copied but not the referred object itself. Therefore the original and clone refer to the same object. The concept will more clear when you will see the code and the diagram of the Shallow copy.
             */
            ShallowCopy();

            /*
             * Deep Copy: It is a process of creating a new object and then copying the fields of the current object to the newly created object to make a complete copy of the internal reference types. If the specified field is a value type, then a bit-by-bit copy of the field will be performed. If the specified field is a reference type, then a new copy of the referred object is performed.
             */
            DeepCopy();
        }

        private static void DeepCopy()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Deep Copy");
            Company c1 = new Company(548, "Intersoft",
                                                  "Rajit Passey");
            // Performing Deep copy                             
            Company c2 = (Company)c1.DeepCopy();

            Console.WriteLine("Before Changing: ");

            // Before changing the value of 
            // c2 ID and CompanyName
            Console.WriteLine("Source ID: {0}",c1.ID);
            Console.WriteLine("Copied ID: {0}",c2.ID);
            Console.WriteLine("Source Company Name: {0}",c2.desc.CompanyName);
            Console.WriteLine("Copied Company Name: {0}",c1.desc.CompanyName);

            Console.WriteLine("\nAfter Changing: ");

            // changing the value of c2 
            // ID and CompanyName
            c2.ID = 59;
            c2.desc.CompanyName = "GFG";

            // After changing the value of
            // c2 ID and CompanyName
            Console.WriteLine("Source ID: {0}", c1.ID);
            Console.WriteLine("Copied ID: {0}", c2.ID);
            Console.WriteLine("Source Company Name: {0}", c2.desc.CompanyName);
            Console.WriteLine("Copied Company Name: {0}", c1.desc.CompanyName);
            Console.WriteLine("---------------------------------------------------------------");
            Console.ReadKey();
        }

        private static void ShallowCopy()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Shallow Copy");
            Company c1 = new Company(548, "Intersoft", "Rajit Passey");

            // Performing Shallow copy                      
            Company c2 = (Company)c1.Shallowcopy();

            Console.WriteLine("Before Changing: ");

            // Before changing the value of
            // c2 ID and CompanyName
            Console.WriteLine("Source ID: {0}", c1.ID);
            Console.WriteLine("Copied ID: {0}", c2.ID);
            Console.WriteLine("Source Company Name: {0}", c2.desc.CompanyName);
            Console.WriteLine("Copied Company Name: {0}", c1.desc.CompanyName);

            // changing the value of c2 ID
            // and CompanyName
            c2.ID = 59;
            c2.desc.CompanyName = "Vserv";

            Console.WriteLine("\nAfter Changing: ");

            // After changing the value of 
            // c2 ID and CompanyName
            Console.WriteLine("Source ID: {0}", c1.ID);
            Console.WriteLine("Copied ID: {0}", c2.ID);
            Console.WriteLine("Source Company Name: {0}", c2.desc.CompanyName);
            Console.WriteLine("Copied Company Name: {0}", c1.desc.CompanyName);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
