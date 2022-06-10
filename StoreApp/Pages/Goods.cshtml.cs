using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Models;

namespace StoreApp.Pages
{
    public class GoodsModel : PageModel
    {
        List<Item> items;
        public List<Item> DisplayedGoods { get; set; }
        public string FromValueText { get; set; }
        public string ToValueText { get; set; }

        public GoodsModel()
        {
            items = new List<Item>()
            {
                new Item{Id=1, Title="test1title", Description="test1description", Price=10},
                new Item{Id=2, Title="test2title", Description="test2description", Price=120},
                new Item{Id=3, Title="test3title", Description="test3description", Price=45},
                new Item{Id=4, Title="test4title", Description="test4description", Price=200},
                new Item{Id=5, Title="test5title", Description="test5description", Price=15},
                new Item{Id=6, Title="test6title", Description="test6description", Price=130},
                new Item{Id=7, Title="test7title", Description="test7description", Price=50},
                new Item{Id=8, Title="test8title", Description="test8description", Price=220},
                new Item{Id=9, Title="test9title", Description="test9description", Price=20},
                new Item{Id=10, Title="test10title", Description="test10description", Price=140},
            };

            FromValueText = items.Min(p => p.Price).ToString();
            ToValueText = items.Max(p => p.Price).ToString();
        }
        public void OnGet()
        {
            Init();
        }

        public void Init()
        {
            DisplayedGoods = items;
        }

        public int GoodsQuantity()
        {
            return DisplayedGoods.Count;
        }

        public void OnPostReset()
        {
            Init();
        }

        public void OnPostFromCheapToExpansive()
        {
            DisplayedGoods = items.OrderBy(p => p.Price).ToList();
        }
        public void OnPostFromExpansiveToCheap()
        {
            DisplayedGoods = items.OrderByDescending(p => p.Price).ToList();
        }

        public void OnPostFilter(int from, int to)
        {
            if (to != 0)
            {
                DisplayedGoods = items.Where(p => p.Price >= from && p.Price <= to).ToList();
                FromValueText = from.ToString();
                ToValueText = to.ToString();
            }
            else
            {
                DisplayedGoods = items.Where(p => p.Price <= from).ToList();
                FromValueText = from.ToString();
                ToValueText = "";
            }
        }
    }
}
