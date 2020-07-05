using System;
using System.Collections.Generic;

namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext dbContext;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            dbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = shoppingCart.ShoppingCartItems;
            order.OrderTotal = shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            dbContext.Orders.Add(order);

            dbContext.SaveChanges();
        }
    }
}
