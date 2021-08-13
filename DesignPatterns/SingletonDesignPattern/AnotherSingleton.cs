using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SingletonDesignPattern
{
    public sealed class AnotherSingleton
    {
        private static readonly object _obj = new object();
        private static AnotherSingleton _getInstance = null;

        public static AnotherSingleton GetInstance
        {
            get
            {
                //Double Checked Locking
                if (_getInstance == null)
                {
                    lock (_obj)
                    {
                        if (_getInstance == null)
                        {
                            _getInstance = new AnotherSingleton();
                        }
                    }
                }
                return _getInstance;
            }
        }

        //Lazy or Eager loading. It's thread safe because CLR takes care of variable initialization  

        private static readonly AnotherSingleton _eagerInstance = new AnotherSingleton();

        public static AnotherSingleton GetEagerInstance
        {
            get
            {
                return _eagerInstance;
            }
        }

        //using Lazy keyword which is there in the .net framework above 4.0. by default Lazy is thread safe.
        private static readonly Lazy<AnotherSingleton> anotherSingleton = new Lazy<AnotherSingleton>(() => new AnotherSingleton());

        public static AnotherSingleton AnotherSingletonInstance
        {
            get
            {
                return anotherSingleton.Value;
            }
        }
    }
}
