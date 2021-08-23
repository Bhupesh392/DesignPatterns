using DecoratorDemo.Component;
using DecoratorDemo.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDemo.ConcreteDecorator
{
    public class OfferPrice : CarDecorator
    {
        public OfferPrice(ICar car): base(car)
        {
        }
        public override double GetDiscountedPrice()
        {
            return .8 * base.GetPrice();
        }
    }
}
