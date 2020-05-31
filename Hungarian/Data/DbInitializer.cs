using Hungarian.Models;
using Hungarian.Models.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Menus.Any())
            {
                context.AddRange
                (
                       new Menu
                       {
                           Name = "Manchurian",
                           Price = 160,
                           ShortDescription = "Chinese Snack",
                           LongDescription = "Manchurian is a NorthEast Chinese snack consist of vegetable, paneer ,mashroom as well as chicken. It is also known as Manchu.",
                           Category = Categories["Snacks"],
                           ImageUrl = "/Images/Manchurian.jpg",
                           InStock = true,
                           IsPreferredMenu = true,
                           ImageThumbnailUrl = "/Images/Manchurian.jpg"
                       },
                    new Menu
                    {
                        Name = "White Sauce Pasta",
                        Price = 140,
                        ShortDescription = "Italian Dish",
                        LongDescription = "White Sauce Pasta is very much inspired from the italian white-coloured pasta but it is tweaked and adjusted to the Indian taste buds.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/WhiteSaucePasta.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/WhiteSaucePasta.jpg"
                    },
                    new Menu
                    {
                        Name = "Red Sauce Pasta",
                        Price = 140,
                        ShortDescription = "Italian Dish",
                        LongDescription = "Red Sauce Pasta is a dish made with pasta, tomatoes, bell peppers, onions, garlic and herbs.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/RedSaucePasta.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/RedSaucePasta.jpg"
                    },
                    new Menu
                    {
                        Name = "Pizza",
                        Price = 560,
                        ShortDescription = "Italian Dish",
                        LongDescription = "It is a dish consisting of a flat round base of dough baked with a topping of tomatoes and cheese, typically with added meat, fish, or vegetables.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/Pizza.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/Pizza.jpg"
                    },
                    new Menu
                    {
                        Name = "Garlic Bread",
                        Price = 170,
                        ShortDescription = "European Dish",
                        Category = Categories["Snacks"],
                        LongDescription = "Garlic bread or garlic toast is consists of bread , topped with garlic and olive oil or butter and may include additional herbs, such as oregano or chives. It is then either grilled or broiled until toasted or baked in a conventional or bread oven.",
                        ImageUrl = "/Images/GarlicBread.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/GarlicBread.jpg"
                    },
                    new Menu
                    {
                        Name = "Lemonade",
                        Price = 120,
                        ShortDescription = "Drink",
                        LongDescription = "It is a drink made from lemon juice and water sweetened with sugar",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/Lemonade.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/Lemonade.jpg"
                    },
                    new Menu
                    {
                        Name = "Orange Juice",
                        Price = 80,
                        ShortDescription = "Juice",
                        LongDescription = "Orange juice is a liquid extract of the orange tree fruit, produced by squeezing or reaming oranges. It comes in several different varieties, including blood orange, navel oranges, valencia orange, clementine, and tangerine.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/OrangeJuice.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/OrangeJuice.jpg"
                    },
                    new Menu
                    {
                        Name = "Mojito",
                        Price = 130,
                        ShortDescription = "Drink",
                        LongDescription = "A mojito is a cocktail that consists of lime juice, soda water, and mint leaves and lime wedges are used to garnish the glass.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/Mojito.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/Mojito.jpg"
                    },
                    new Menu
                    {
                        Name = "Oreo Shake",
                        Price = 130,
                        ShortDescription = "Shake",
                        LongDescription = "Oreo milk shake is the ideal sweet treat. With a bit of cookie crunch, rich chocolate sauce, and creamy body.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/OreoShake.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/OreoShake.jpg"
                    },
                    new Menu
                    {
                        Name = "Strawberry Shake",
                        Price = 130,
                        ShortDescription = "Shake",
                        LongDescription = "Strawberry Shake is a drink blend with milk, strawberries alongwith creamy body.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/StrawberryShake.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/StrawberryShake.jpg"
                    },
                    new Menu
                    {
                        Name = "Idli Sambar",
                        Price = 100,
                        ShortDescription = "South Indian dish",
                        LongDescription = "Idli Sambar is a traditional South Indian breakfast. Idli is made of fermented rice and black gram batter and steamed in molds. Sambar is a vegateable curry with lentil base.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/IdliSamber.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/IdliSamber.jpg"
                    },
                    new Menu
                    {
                        Name = "Masala Dosa",
                        Price = 160,
                        ShortDescription = "South Indian Dish",
                        LongDescription = "A dosa is a cooked rice pancake, originating from South India, made from a fermented batter. It is somewhat similar to a crepe in appearance.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/Dosa.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/Dosa.jpg"
                    },
                    new Menu
                    {
                        Name = "Uttapam",
                        Price = 140,
                        ShortDescription = "South Indian Dish",
                        LongDescription = "Uthappam is a type of dosa. Unlike a typical dosa, which is crisp and crepe-like, uttapam is thicker, with toppings.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/Uttapam.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/Uttapam.jpg"
                    },
                    new Menu
                    {
                        Name = "Medu Vada",
                        Price = 100,
                        ShortDescription = "South Indian Dish",
                        LongDescription = "Medu vada is a South Indian dish usually made in a doughnut shape, with a crispy exterior and soft interior.",
                        Category = Categories["Snacks"],
                        ImageUrl = "/Images/SambarVada.jpg",
                        InStock = false,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/SambarVada.jpg"
                    },

                    new Menu
                    {
                        Name = "Water ",
                        Price = 20,
                        ShortDescription = "Bisleri Water",
                        LongDescription = "Bisleri was originally an Italian company created by Felice Bisleri, who first brought the idea of selling bottled water in India. It is purified water.",
                        Category = Categories["Main Course"],
                        ImageUrl = "/Images/Water.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/Water.jpg"
                    },
                    new Menu
                    {
                        Name = "Coffee ",
                        Price = 65,
                        ShortDescription = "Beverage from coffee beans",
                        LongDescription = "Coffee is a brewed drink prepared from roasted coffee beans, the seeds of berries from certain coffea species.",
                        Category = Categories["Main Course"],
                        ImageUrl = "/Images/Coffee.jpg",
                        InStock = true,
                        IsPreferredMenu = true,
                        ImageThumbnailUrl = "/Images/Coffee.jpg"
                    },
                    new Menu
                    {
                        Name = "Tea",
                        Price = 30,
                        ShortDescription = "Beverage from Tea Leaves",
                        LongDescription = "Tea is an aromatic beverage commonly prepared by pouring hot or boiling water over cured leaves of the Camellia sinensis, an evergreen shrub (bush) native to East Asia.",
                        Category = Categories["Main Course"],
                        ImageUrl = "/Images/Tea.jpeg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/Tea.jpeg"
                    },
                    new Menu
                    {
                        Name = "South Indian Platter",
                        Price = 450,
                        ShortDescription = "Consist of Famous South Indian Dish",
                        LongDescription = "Platter is consist of variety of South Indian Dish including masala dosa, uttapam, idli, medu vada, rice alongwith sambar.",
                        Category = Categories["Main Course"],
                        ImageUrl = "/Images/SouthInndianPlatter.jpg",
                        InStock = true,
                        IsPreferredMenu = false,
                        ImageThumbnailUrl = "/Images/SouthInndianPlatter.jpg"
                    },

                     new Menu
                     {
                         Name = "Paratha",
                         Price = 30,
                         ShortDescription = "Indian Morning Breakfast",
                         LongDescription = "A Paratha is a flatbread native to the Indian subcontinent, prevalent throughout the modern-day nations of India, Sri Lanka, Pakistan, Nepal, Bangladesh, Maldives, and Myanmar, where wheat is the traditional staple.",
                         Category = Categories["Main Course"],
                         ImageUrl = "/Images/Parantha.jpg",
                         InStock = true,
                         IsPreferredMenu = false,
                         ImageThumbnailUrl = "/Images/Parantha.jpg"
                     },

                     new Menu
                     {
                         Name = "Aloo Puri",
                         Price = 90,
                         ShortDescription = "India Festive Dish",
                         LongDescription = "Aloo poori is prepared with wheat flour mixed with desi masalas and boiled potatoes stuffing can be served with any sabzi.",
                         Category = Categories["Main Course"],
                         ImageUrl = "/Images/AlooPuri.jpg",
                         InStock = true,
                         IsPreferredMenu = false,
                         ImageThumbnailUrl = "/Images/AlooPuri.jpg"
                     },

                     new Menu
                     {
                         Name = "Chole Bhature",
                         Price = 80,
                         ShortDescription = "North Indian Dish",
                         LongDescription = "Chole Bhature is a Punjabi concoction of spicy curried chickpeas (chole) and puffy fried white-flour bread (bhature), most often eaten together for breakfast (it's also known as chana bhatura).",
                         Category = Categories["Main Course"],
                         ImageUrl = "/Images/CholeBhature.jpg",
                         InStock = true,
                         IsPreferredMenu = false,
                         ImageThumbnailUrl = "/Images/CholeBhature.jpg"
                     },

                     new Menu
                     {
                         Name = "Kulche Chole",
                         Price = 60,
                         ShortDescription = "North Indian Dish",
                         LongDescription = "Kulche Chole are served as main course where kulcha is a flat bread made without using yeast and chole is made using boiled white chana.",
                         Category = Categories["Main Course"],
                         ImageUrl = "/Images/CholeKulche.jpg",
                         InStock = true,
                         IsPreferredMenu = false,
                         ImageThumbnailUrl = "/Images/CholeKulche.jpg"
                     },

                     new Menu
                     {
                         Name = "Dalmakhni Naan",
                         Price = 150,
                         ShortDescription = "North Indian Dish",
                         LongDescription = "Dal Makhani is creamy. Dal Makhani is one of India's most loved dal! This dal has whole black lentils cooked with butter and cream and simmered on low heat for that unique flavor. It tastes best with garlic naan which is a sort of bread.",
                         Category = Categories["Main Course"],
                         ImageUrl = "/Images/DaalMakhni.jpg",
                         InStock = true,
                         IsPreferredMenu = false,
                         ImageThumbnailUrl = "/Images/DaalMakhni.jpg"
                     },

                     new Menu
                     {
                         Name = "ShahiPaneer Naan",
                         Price = 170,
                         ShortDescription = "North Indian Dish",
                         LongDescription = "Shahi paneer is a preparation of paneer, native to the Indian subcontinent, consisting of a thick gravy of cream, tomatoes and Indian spices. It is served with butter naan which is a kind of a bread served with it.",
                         Category = Categories["Main Course"],
                         ImageUrl = "/Images/ShahiPaneer.jpg",
                         InStock = true,
                         IsPreferredMenu = false,
                         ImageThumbnailUrl = "/Images/ShahiPaneer.jpg"
                     },

                      new Menu
                      {
                          Name = "North Indian Platter",
                          Price = 750,
                          ShortDescription = "Consist of Famous North Indian Dish",
                          LongDescription = "Platter is consist of variety of North Indian Dish including daalmakhni, shahipaneer, aloo sbji, gobi, raita, rice, salad, pickals alongwith naan(flatbread).",
                          Category = Categories["Main Course"],
                          ImageUrl = "/Images/NorthIndianPlatter.jpg",
                          InStock = true,
                          IsPreferredMenu = false,
                          ImageThumbnailUrl = "/Images/NorthIndianPlatter.jpg"
                      }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                            new Category { CategoryName = "Snacks", Description="All Snacks" },
                            new Category { CategoryName = "Main Course", Description="All Main Course" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}