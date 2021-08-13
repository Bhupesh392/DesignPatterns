using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Factory.AbstractFactory
{
    //Business Rule Abstract 
    public class EmployeeSystemFactory
    {
        public IComputerFactory Create(EmployeeDetail emp)
        {
            IComputerFactory returnValue = null;
            if(emp.EmployeeTypeID == 1)
            {
                if (emp.Description.Equals("Manager"))
                {
                    returnValue = new MACLaptopFactory();
                }
                else
                {
                    returnValue = new MACFactory();
                }
            }
            else if(emp.EmployeeTypeID == 2)
            {
                if (emp.Description.Equals("Manager"))
                {
                    returnValue = new DellLaptopFactory();
                }
                else
                {
                    returnValue = new DELLFactory();
                }
            }
            return returnValue;
        }
    }
}