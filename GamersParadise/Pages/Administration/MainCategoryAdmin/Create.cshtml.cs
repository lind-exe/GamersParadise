using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamersParadise.Data;
using GamersParadise.Models;

namespace GamersParadise.Pages.Administration.MainCategoryAdmin
{
    public class CreateModel : PageModel
    {
        private readonly GamersParadise.Data.GamersParadiseContext _context;

        public CreateModel(GamersParadise.Data.GamersParadiseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MainCategory MainCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MainCategories == null || MainCategory == null)
            {
                return Page();
            }

            _context.MainCategories.Add(MainCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
