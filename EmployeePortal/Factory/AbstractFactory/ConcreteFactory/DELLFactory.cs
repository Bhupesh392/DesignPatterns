using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Factory.AbstractFactory
{
    //Concrete Factories which implements IComputerFactory interface to create concrete products 
    public class DELLFactory : IComputerFactory
    {
        public IBrand Brand()
        {
            return new DELL();
        }

        public IProcessor Processor()
        {
            return new I5();
        }
        //Reason why we made it to virtual because that's the only different thing in both of the factory
        public virtual ISystemType SystemType()
        {
            return new Desktop();
        }
    }

    public class DellLaptopFactory : DELLFactory
    {
        public override ISystemType SystemType()
        {
            return new Laptop();
        }
    }
}