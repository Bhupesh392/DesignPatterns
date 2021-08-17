using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EmployeePortal
{
    public class ComputerSystem
    {
        public string RAM { get; set; }
        public string HDDSize { get; set; }
        public string KeyBoard { get; set; }
        public string Mouse { get; set; }
        public string TouchScreen { get; set; }
        public ComputerSystem()
        {

        }

        //public ComputerSystem(string RAM, string HDD)
        //{
        //    this._RAM = RAM;
        //    this._HDDSize = HDD;
        //}

        //public string Build()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(string.Format("RAM : {0} ", RAM));
        //    sb.Append(string.Format(" HDD Size : {0}", HDDSize));
        //    return sb.ToString();
        //}
    }
}