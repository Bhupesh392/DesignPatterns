using EmployeePortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Builder.ConcreteBuilder
{
    public class LaptopBuilder : ISystemBuilder
    {
        ComputerSystem laptop = new ComputerSystem();
        //public void AddDrive(string size)
        //{
        //    laptop.HDDSize = size;
        //}

        //public void AddKeyBoard(string type)
        //{
        //    return;
        //}

        //public void AddMemory(string memory)
        //{
        //    laptop.RAM = memory;
        //}

        //public void AddMouse(string type)
        //{
        //    return;
        //}

        //public void AddTouchScreen(string enabled)
        //{
        //    laptop.TouchScreen = enabled;
        //}

        //using fluent builder design pattern (method chaining)
        public ISystemBuilder AddDrive(string size)
        {
            laptop.HDDSize = size;
            return this;
        }

        public ISystemBuilder AddKeyBoard(string type)
        {
            return this;
        }

        public ISystemBuilder AddMemory(string memory)
        {
            laptop.RAM = memory;
            return this;
        }

        public ISystemBuilder AddMouse(string type)
        {
            return this;
        }

        public ISystemBuilder AddTouchScreen(string enabled)
        {
            laptop.TouchScreen = enabled;
            return this;
        }

        public ComputerSystem GetSystem()
        {
            return laptop;
        }
    }
}