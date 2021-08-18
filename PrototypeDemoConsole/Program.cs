using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDemoConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ShallowCopy();
            ShallowCopyRef();
        }
        public static void ShallowCopy()
        {
            Employee empJohn = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "John",
                DepartmentID = 150,
            };

            Console.WriteLine(empJohn.ToString());

            Employee empSam = (Employee)empJohn.Clone();
            empSam.Name = "Sam Paul";
            Console.WriteLine(empSam.ToString());

            Console.WriteLine("Changed Johns DepartmentID to 161");
            empJohn.DepartmentID = 161;
            Console.WriteLine(empJohn.ToString());
            Console.WriteLine(empSam.ToString());

            Console.ReadLine();
        }
        public static void ShallowCopyRef()
        {
            Employee empJohn = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "John",
                DepartmentID = 150,
                AddressDetails = new Address()
                {
                    DoorNumber = 10,
                    StreetNumber = 20,
                    Zipcode = 90025,
                    Country = "US"
                }
            };

            Console.WriteLine(empJohn.ToString());

            Employee empSam = (Employee)empJohn.Clone();
            empSam.Name = "Sam Paul";
            empSam.DepartmentID = 151;
            empSam.AddressDetails.StreetNumber = 21;
            empSam.AddressDetails.DoorNumber = 11;

            Console.WriteLine(empSam.ToString());

            Console.WriteLine("Modified Details of John");
            empJohn.AddressDetails.DoorNumber = 30;
            empJohn.AddressDetails.StreetNumber = 40;

            empJohn.DepartmentID = 160;
            Console.WriteLine(empJohn.ToString());
            Console.WriteLine(empSam.ToString());

            Console.ReadLine();
        }
    }
    public partial class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public override string ToString()
        {
            return string.Format(" Name : {0}  " + "DepartmentID : {1}  {2}",
                this.Name, this.DepartmentID.ToString(), AddressDetails.ToString());
        }
    }
    public partial class Employee : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public partial class Employee
    {
        public Address AddressDetails { get; set; }
    }

    public class Address
    {
        public Address() { }

        public int DoorNumber { get; set; }
        public int StreetNumber { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public override string ToString()
        {
            return string.Format("AddressDetails : Door : {0}, Street: {1}, ZipCode : {2}," +
                " Country : {3}", this.DoorNumber, this.StreetNumber, this.Zipcode.ToString(),
                this.Country);
        }
    }
}
