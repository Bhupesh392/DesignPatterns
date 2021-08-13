using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeePortal.Manager;
using EmployeePortal.Models;

namespace EmployeePortal.Factory.FactoryMethod
{
    public class ContractEmployeeFactory : BaseEmployeeFactory
    {
        public ContractEmployeeFactory(EmployeeDetail emp) : base(emp)
        {
        }

        public override IEmployeeManager Create()
        {
            ContractEmployeeManager manager = new ContractEmployeeManager();
            _emp.MedicalAllowance = manager.GetMedicalAllowance();
            return manager;
        }
    }
}