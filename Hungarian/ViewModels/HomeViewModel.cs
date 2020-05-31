using Hungarian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Menu> PreferredMenus { get; set; }
    }
}
