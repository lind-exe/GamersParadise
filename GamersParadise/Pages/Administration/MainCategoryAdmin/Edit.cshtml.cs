using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamersParadise.Data;
using GamersParadise.Models;

namespace GamersParadise.Pages.Administration.MainCategoryAdmin
{
    public class EditModel : PageModel
    {
        private readonly GamersParadise.Data.GamersParadiseContext _context;

        public EditModel(GamersParadise.Data.GamersParadiseContext context)
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

            var maincategory =  await _context.MainCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (maincategory == null)
            {
                return NotFound();
            }
            MainCategory = maincategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MainCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainCategoryExists(MainCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MainCategoryExists(int id)
        {
          return (_context.MainCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
