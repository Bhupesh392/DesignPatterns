using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeePortal.Manager;
using EmployeePortal.Models;

namespace EmployeePortal.Factory.FactoryMethod
{
    public class PermanentEmployeeFactory : BaseEmployeeFactory
    {
        public PermanentEmployeeFactory(EmployeeDetail emp) : base(emp)
        {
        }

        public override IEmployeeManager Create()
        {
            PermanentEmployeeManager manager = new PermanentEmployeeManager();
            _emp.HouseAllowance = manager.GetHouseAllowance();
            return manager;
        }
    }
}