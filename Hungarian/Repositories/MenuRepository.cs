using Hungarian.Data;
using Hungarian.Interfaces;
using Hungarian.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Repositories
{
    public class MenuRepository:IMenuRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public MenuRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Menu> Menus => _appDbContext.Menus.Include(c => c.Category);

        public IEnumerable<Menu> PreferredMenus => _appDbContext.Menus.Where(p => p.IsPreferredMenu).Include(c => c.Category);

        public Menu GetMenuById(int menuId) => _appDbContext.Menus.FirstOrDefault(p => p.MenuId == menuId);
    }
}
