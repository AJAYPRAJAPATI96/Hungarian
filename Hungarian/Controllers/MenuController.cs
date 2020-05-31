using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hungarian.Data;
using Hungarian.Models;
using Hungarian.Interfaces;
using Hungarian.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Hungarian.Controllers
{

    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMenuRepository _menuRepository;
        private readonly ICategoryRepository _categoryRepository;
        public MenuController(ApplicationDbContext context, IMenuRepository menuRepository, ICategoryRepository categoryRepository)
        {
            _menuRepository = menuRepository;
            _categoryRepository = categoryRepository;
            _context = context;
        }
        [Authorize(Policy= "Private")]
        // GET: Menu
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Menus.Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        public ViewResult Details(int menuId)
        {
            var menu = _menuRepository.Menus.FirstOrDefault(d => d.MenuId == menuId);
            if (menu == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(menu);
        }
        //// GET: Menu/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var menu = await _context.Menus
        //        .Include(m => m.Category)
        //        .FirstOrDefaultAsync(m => m.MenuId == id);
        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(menu);
        //}
        [Authorize(Policy = "Admin")]
        // GET: Menu/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,Name,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsPreferredMenu,InStock,CategoryId")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", menu.CategoryId);
            return View(menu);
        }
        //
        [Authorize(Policy = "Admin")]
        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int? menuId)
        {
            if (menuId == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(menuId);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", menu.CategoryId);
            return View(menu);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int menuId, [Bind("MenuId,Name,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsPreferredMenu,InStock,CategoryId")] Menu menu)
        {
            if (menuId != menu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.MenuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", menu.CategoryId);
            return View(menu);
        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Menu> menus;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                menus = _menuRepository.Menus.OrderBy(p => p.MenuId);
            }
            else
            {
                menus = _menuRepository.Menus.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Menu/List.cshtml", new MenuListViewModel { Menus = menus, CurrentCategory = "All dishes" });
        }
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Menu> menus;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                menus = _menuRepository.Menus.OrderBy(p => p.MenuId);
                currentCategory = "All dishes";
            }
            else
            {
                if (string.Equals("Snacks", _category, StringComparison.OrdinalIgnoreCase))
                    menus = _menuRepository.Menus.Where(p => p.Category.CategoryName.Equals("Snacks")).OrderBy(p => p.Name);
                else
                    menus = _menuRepository.Menus.Where(p => p.Category.CategoryName.Equals("Main Course")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new MenuListViewModel
            {
                Menus = menus,
                CurrentCategory = currentCategory
            });
        }
        [Authorize(Policy = "Private")]
        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int? menuId)
        {
            if (menuId == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.MenuId == menuId);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int menuId)
        {
            var menu = await _context.Menus.FindAsync(menuId);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int menuId)
        {
            return _context.Menus.Any(e => e.MenuId == menuId);
        }
    }
}
