using ShoppingCart.Implementation;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFacade
{
    public class UserOrder : IUserOrder
    {
        public int AddToCart(int itemID, int qty)
        {
            Console.WriteLine("Start AddToCart");
            ICart userCart = new ShoppingCartDetails();
            int cartID = 0;

            //Step 1 : GetItem
            Product product = userCart.GetItemDetails(itemID);

            //step 2 : Check Availability
            if (userCart.CheckItemAvailability(product))
            {
                //step 3: Lock item in the stock
                userCart.LockItemInStock(itemID, qty);
                //step 4: Add Item to the Cart
                cartID = userCart.AddItemToCart(itemID, qty);
            }

            Console.WriteLine("End AddtoCart");
            return cartID;
        }

        public int PlaceOrder(int cartID, int userID)
        {
            Console.WriteLine("Start PlaceOrderDetails");
            int orderID = -1;
            IWallet wallet = new Wallet();
            ITax tax = new Tax();
            ICart userCart = new ShoppingCartDetails();
            IAddress address = new AddressDetails();
            IOrder order = new Order();
            //step 1: Get Tax Percentage by state 
            double stateTax = tax.GetTaxByState("ABC");
            //step 2: Apply Tax on the cart items 
            tax.ApplyTax(cartID, stateTax);
            //step 3: Get User Wallet Balance
            double userWalletbalance = wallet.GetUserBalance(userID);
            //step 4: Get the cart item price
            double cartPrice = userCart.GetCartPrice(cartID);
            //step 5: Compare the balance and price 
            if(userWalletbalance > cartPrice)
            {
                //step 6: Get user Address and set to cart
                Address userAddress = address.GetAddressDetails(userID);
                //step 7: Place the order 
                orderID = order.PlaceOrderDetails(cartID, userAddress.AddressID);
            }

            Console.WriteLine("End PlaceOrderDetails");
            return orderID;
        }
    }
}
