using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPattern
{
    /// <summary>
    /// Concrete Implementor 
    /// </summary>
    public class IDBIPaymentSystem : IPaymentSystem
    {
        public void ProcessPayment(string paymentsystem)
        {
            Console.WriteLine("Using IDBI Bank Gateway For " + paymentsystem);
        }
    }
}
