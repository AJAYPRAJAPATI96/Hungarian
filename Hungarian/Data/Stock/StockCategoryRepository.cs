using Hungarian.Interfaces;
using Hungarian.Models.Dishes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Data.Stock
{
    public class StockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { CategoryName = "Snacks", Description = "All Snacks" },
                         new Category { CategoryName = "Main Course", Description = "All Main Course" }
                     };
            }
        }

        IEnumerable<Category> ICategoryRepository.Categories => throw new NotImplementedException();
    }   
}
