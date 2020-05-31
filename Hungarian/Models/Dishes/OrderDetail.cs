using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Models.Dishes
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }
    }
}
