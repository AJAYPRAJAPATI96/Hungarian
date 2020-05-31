using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Models.Dishes
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Menu Menu { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
