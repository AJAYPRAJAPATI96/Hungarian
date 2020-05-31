using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hungarian.Models;
using Hungarian.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Hungarian.ViewModels;
using Hungarian.Interfaces;
using Hungarian.Repositories;

namespace Hungarian.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMenuRepository _menuRepository;
        private readonly ICategoryRepository _categoryRepository;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMenuRepository menuRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _context = context;
            _menuRepository = menuRepository;
            _categoryRepository = categoryRepository;
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredMenus = _menuRepository.PreferredMenus
            };
            return View(homeViewModel);
        }
       [Authorize(policy: "Private")]
        public async Task<IActionResult> Display()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> About([Bind("CId,CName,CEmail,CContact,Subject")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(About));
            }
            return View(contact);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
