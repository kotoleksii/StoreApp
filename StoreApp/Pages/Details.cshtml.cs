using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Models;

namespace StoreApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public int id { set; get; }
        public Item Item { get; set; }

        public DetailsModel(ApplicationContext db)
        {
            _context = db;
        }

        //public void OnGet()
        //{
        //    Item = _context.Items.Find(id);
        //}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Items.FindAsync(id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
