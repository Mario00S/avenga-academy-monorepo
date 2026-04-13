using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Models;

    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public MenuCategory Category { get; set; }

        public MenuItem(string name, double price, MenuCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }

