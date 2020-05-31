using Hungarian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Interfaces
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> Menus { get; }
        IEnumerable<Menu> PreferredMenus { get; }
        Menu GetMenuById(int menuId);
    }
}
