using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Builder.IBuilder
{
    //we could have created two interface just to follow SOLID principle
    public interface ISystemBuilder
    {
        //void AddMemory(string memory);
        //void AddDrive(string size);
        //void AddKeyBoard(string type);
        //void AddMouse(string type);
        //void AddTouchScreen(string enabled);
        //ComputerSystem GetSystem();

        //using Fluent Builder Design Pattern(Method chaining)

        ISystemBuilder AddMemory(string memory);
        ISystemBuilder AddDrive(string size);
        ISystemBuilder AddKeyBoard(string type);
        ISystemBuilder AddMouse(string type);
        ISystemBuilder AddTouchScreen(string enabled);
        ComputerSystem GetSystem();
    }
}
