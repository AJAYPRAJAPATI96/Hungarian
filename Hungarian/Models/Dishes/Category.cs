using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Models.Dishes
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
