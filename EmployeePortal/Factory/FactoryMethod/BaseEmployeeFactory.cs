using EmployeePortal.Manager;
using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Factory.FactoryMethod
{
    public abstract class BaseEmployeeFactory
    {
        protected EmployeeDetail _emp;

        public BaseEmployeeFactory(EmployeeDetail emp)
        {
            this._emp = emp;
        }
        public abstract IEmployeeManager Create();

        public EmployeeDetail ApplySalary()
        {
            IEmployeeManager manager = this.Create();
            _emp.Bonus = manager.GetBonus();
            _emp.HourlyPay = manager.GetPay();
            return _emp;
        }
    }
}