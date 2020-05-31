using Hungarian.Data;
using Hungarian.Interfaces;
using Hungarian.Models.Dishes;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                { 
                    Amount = shoppingCartItem.Amount,
                    MenuId = shoppingCartItem.Menu.MenuId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Menu.Price
               
            };
                

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
