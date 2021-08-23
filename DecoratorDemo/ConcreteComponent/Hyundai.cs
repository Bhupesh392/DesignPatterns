using DecoratorDemo.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDemo.ConcreteComponent
{
    public sealed class Hyundai : ICar
    {
        public string Make
        {
            get { return "HatchBack"; }
        }

        public double GetPrice()
        {
            return 800000;
        }
    }
}
