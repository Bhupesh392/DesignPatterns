using EmployeePortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace EmployeePortal.Builder.Director
{
    public class ConfigurationBuilder
    {
        public void BuildSystem(ISystemBuilder systemBuilder, NameValueCollection collection)
        {
            //systemBuilder.AddDrive(collection["Drive"]);
            //systemBuilder.AddMemory(collection["RAM"]);
            //systemBuilder.AddMouse(collection["Mouse"]);
            //systemBuilder.AddKeyBoard(collection["Keyboard"]);
            //systemBuilder.AddTouchScreen(collection["TouchScreen"]);

            //using fluent builder design pattern (method chaining)
            systemBuilder.AddDrive(collection["Drive"])
            .AddMemory(collection["RAM"])
            .AddMouse(collection["Mouse"])
            .AddKeyBoard(collection["Keyboard"])
            .AddTouchScreen(collection["TouchScreen"]);
        }
    }
}