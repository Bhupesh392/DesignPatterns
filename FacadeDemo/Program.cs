﻿using ShoppingFacade;
using System;

namespace FacadeDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUserOrder userOrder = new UserOrder();
            Console.WriteLine("Facade : Start");
            Console.WriteLine("*********************************************");

            int cartID = userOrder.AddToCart(10, 1);

            int userID = 1234;
            Console.WriteLine("**********************************************");
            int orderID = userOrder.PlaceOrder(cartID, userID);
            Console.WriteLine("**********************************************");
            Console.WriteLine("Facade : End CartId = {0}, OrderID = {1}", cartID, orderID);
            Console.ReadLine();
        }
    }
}