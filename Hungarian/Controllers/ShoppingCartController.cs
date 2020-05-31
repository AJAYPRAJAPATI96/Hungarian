using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hungarian.Interfaces;
using Hungarian.Models.Dishes;
using Hungarian.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hungarian.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IMenuRepository menuRepository, ShoppingCart shoppingCart)
        {
            _menuRepository = menuRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int menuId)
        {
            var selectedMenu = _menuRepository.Menus.FirstOrDefault(p => p.MenuId == menuId);
            if (selectedMenu != null)
            {
                _shoppingCart.AddToCart(selectedMenu, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int menuId)
        {
            var selectedMenu = _menuRepository.Menus.FirstOrDefault(p => p.MenuId == menuId);
            if (selectedMenu != null)
            {
                _shoppingCart.RemoveFromCart(selectedMenu);
            }
            return RedirectToAction("Index");
        }

    }
}