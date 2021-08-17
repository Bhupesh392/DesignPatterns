using EmployeePortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Builder.ConcreteBuilder
{
    public class DesktopBuilder : ISystemBuilder
    {
        ComputerSystem desktop = new ComputerSystem();
        //public void AddDrive(string size)
        //{
        //    desktop.HDDSize = size;
        //}

        //public void AddKeyBoard(string type)
        //{
        //    desktop.KeyBoard = type;
        //}

        //public void AddMemory(string memory)
        //{
        //    desktop.RAM = memory;
        //}

        //public void AddMouse(string type)
        //{
        //    desktop.Mouse = type;
        //}

        //public void AddTouchScreen(string enabled)
        //{
        //    return;
        //}

        public ComputerSystem GetSystem()
        {
            return desktop;
        }

        //using fluent builder design pattern(method chaining)
        public ISystemBuilder AddDrive(string size)
        {
            desktop.HDDSize = size;
            return this;
        }

        public ISystemBuilder AddKeyBoard(string type)
        {
            desktop.KeyBoard = type;
            return this;
        }

        public ISystemBuilder AddMemory(string memory)
        {
            desktop.RAM = memory;
            return this;
        }

        public ISystemBuilder AddMouse(string type)
        {
            desktop.Mouse = type;
            return this;
        }

        public ISystemBuilder AddTouchScreen(string enabled)
        {
            return this;
        }
    }
}