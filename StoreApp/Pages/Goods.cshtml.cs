using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.Services;

namespace StoreApp.Pages
{
    public class GoodsModel : PageModel
    {

        private readonly ApplicationContext _context;
        public List<Item> Items { get; set; }

        public string FromValueText { get; set; }
        public string ToValueText { get; set; }

        public GoodsModel(ApplicationContext db)
        {
            _context = db;

            if (_context.Items.FirstOrDefault() != null)
            {
                FromValueText = _context.Items.Min(p => p.Price).ToString();
                ToValueText = _context.Items.Max(p => p.Price).ToString();
            }
        }

        public void OnGet()
        {
            Items = _context.Items.AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Items = GoodsService.GetItems();

                foreach (Item item in Items)
                {
                    _context.Items.Add(item);
                }
                await _context.SaveChangesAsync();
                Items = _context.Items.AsNoTracking().ToList();
                return RedirectToPage("Goods");
            }
            return Page();
        }

        public void OnPostFilter(int from, int to)
        {
            if (to != 0)
            {
                Items = _context.Items.Where(p => p.Price >= from && p.Price <= to).ToList();
                FromValueText = from.ToString();
                ToValueText = to.ToString();
            }
            else
            {
                Items = _context.Items.Where(p => p.Price <= from).ToList();
                FromValueText = from.ToString();
                ToValueText = "";
            }
        }

        public void OnPostReset()
        {
            Items = _context.Items.ToList();
        }

        public void OnPostFromCheapToExpansive()
        {
            Items = _context.Items.OrderBy(p => p.Price).ToList();
        }

        public void OnPostFromExpansiveToCheap()
        {
            Items = _context.Items.OrderByDescending(p => p.Price).ToList();
        }

        public int GoodsQuantity()
        {
            return Items.Count;
        }
    }
}
