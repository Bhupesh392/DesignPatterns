using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Manager
{
    public interface IEmployeeManager
    {
        decimal GetPay();
        decimal GetBonus();
    }
}
