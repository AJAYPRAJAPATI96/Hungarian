using Hungarian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.ViewModels
{
    public class MenuListViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
        public string CurrentCategory { get; set; }
    }
}
