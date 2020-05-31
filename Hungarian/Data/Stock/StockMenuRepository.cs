using Hungarian.Interfaces;
using Hungarian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Data.Stock
{
    public class StockMenuRepository : IMenuRepository
    {
        private readonly ICategoryRepository _categoryRepository = new StockCategoryRepository();

        public IEnumerable<Menu> Menus
        {
            get
            {
                return new List<Menu>
                {
                    new Menu {
                        Name = "Chilly Potato",
                        Price = 160, ShortDescription = "Indo-Chinese Snack",
                        LongDescription ="Chilly Potato is a Indo-Chinese starter made with fried potatoes tossed in spicy, slightly sweet and sour chilly sauce.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "C:/Users/Jagpreet Kaur/Desktop/demo-master/demo-master/Hungarian/wwwroot/Images/ChillyPotato.jpg",
                        InStock = true,
                        IsPreferredMenu = true,
                        ImageThumbnailUrl = ""
                    },
                    new Menu {
                        Name = "Spring Roll",
                        Price = 150, ShortDescription = "Chinese Snack",
                        LongDescription = "Spring Roll is a Chinese snack consisting of a pancake filled with vegetables and sometimes meat, rolled into a cylinder and deep-fried.",
                        Category =  _categoryRepository.Categories.First(),
                        ImageUrl = "C:/Users/Jagpreet Kaur/Desktop/demo-master/demo-master/Hungarian/wwwroot/Images/SpringRoll.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = ""
                    },
                    new Menu {
                        Name = "Noodles",
                        Price = 180, ShortDescription = "Chinese Snack",
                        LongDescription = "Noodles is a Chinese dish consisting of vegetables and sometimes meat or tofu",
                        Category =  _categoryRepository.Categories.First(),
                        ImageUrl = "C:/Users/Jagpreet Kaur/Desktop/demo-master/demo-master/Hungarian/wwwroot/Images/Noodles.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = ""
                    },
                    new Menu
                    {
                        Name = "Momos",
                        Price = 12.95M,
                        ShortDescription = "Tibet and Nepal Snack",
                        LongDescription = "Momos are a tantalizing, traditional food of Tibet and Nepal. Momo is a small bite sized savory snack or steamed dumpling with a filling which vary from mixed vegetables, greens, mushrooms, tofu, meat, chicken and shrimp",
                        Category = _categoryRepository.Categories.Last(),
                        ImageUrl = "~/Images/35b2c2cb-9912-49d9-af38-05954c4bfdc5_foodieCor.jpeg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = ""
                    }
                };
            }
        }

        public IEnumerable<Menu> PreferredMenus => throw new NotImplementedException();

        public Menu GetMenuById(int menuId)
        {
            throw new NotImplementedException();
        }
    }
}