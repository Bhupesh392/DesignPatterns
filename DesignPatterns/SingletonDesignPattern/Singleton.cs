using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SingletonDesignPattern
{
    //Sealed restrics inheritance.
    //you can argu that we have private counstuctor then why we need sealed. we need sealed so we make sure even the nested 
    //classes can't make the object of this class because that will voilates the singleton single object rule.
    public sealed class Singleton
    {
        private static object _obj = new object(); 
        private static int _count = 0;
        private Singleton()
        {
            _count++;
            Console.WriteLine(_count);
        }
        private static Singleton _instance = null;
        public static Singleton GetInstance
        {
            get
            {
                //Lazy Initialization for single thread enviornment
                if (_instance == null)
                    _instance = new Singleton();

                //for multi-threading
                //lock (_obj)
                //{
                //    if (_instance == null)
                //        _instance = new Singleton();
                //}
                return _instance;
            }
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
