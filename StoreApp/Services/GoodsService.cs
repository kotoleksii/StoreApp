﻿using StoreApp.Models;
using System.Collections.Generic;

namespace StoreApp.Services
{
    public class GoodsService
    {
        public static List<Item> GetItems()
        {
            List<Item> items = new List<Item>()
                {
                    new Item{Title="test1title", Description="test1description", Price=10},
                    new Item{Title="test2title", Description="test2description", Price=120},
                    new Item{Title="test3title", Description="test3description", Price=45},
                    new Item{Title="test4title", Description="test4description", Price=200},
                    new Item{Title="test5title", Description="test5description", Price=15},
                    new Item{Title="test6title", Description="test6description", Price=130},
                    new Item{Title="test7title", Description="test7description", Price=50},
                    new Item{Title="test8title", Description="test8description", Price=220},
                    new Item{Title="test9title", Description="test9description", Price=20},
                    new Item{Title="test10title", Description="test10description", Price=140},
                };
            return items;
        }
    }
}
