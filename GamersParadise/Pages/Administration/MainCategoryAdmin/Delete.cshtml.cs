using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamersParadise.Data;
using GamersParadise.Models;

namespace GamersParadise.Pages.Administration.MainCategoryAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly GamersParadise.Data.GamersParadiseContext _context;

        public DeleteModel(GamersParadise.Data.GamersParadiseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MainCategory MainCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MainCategories == null)
            {
                return NotFound();
            }

            var maincategory = await _context.MainCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (maincategory == null)
            {
                return NotFound();
            }
            else 
            {
                MainCategory = maincategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MainCategories == null)
            {
                return NotFound();
            }
            var maincategory = await _context.MainCategories.FindAsync(id);

            if (maincategory != null)
            {
                MainCategory = maincategory;
                _context.MainCategories.Remove(MainCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
