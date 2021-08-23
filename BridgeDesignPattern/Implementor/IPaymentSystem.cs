using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPattern
{
    /// <summary>
    /// Implementor Interface
    /// </summary>
    public interface IPaymentSystem
    {
        void ProcessPayment(string paymentsystem);
    }
}
