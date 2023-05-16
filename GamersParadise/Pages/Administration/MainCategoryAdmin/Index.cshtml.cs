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
    public class IndexModel : PageModel
    {
        private readonly GamersParadise.Data.GamersParadiseContext _context;

        public IndexModel(GamersParadise.Data.GamersParadiseContext context)
        {
            _context = context;
        }

        public IList<MainCategory> MainCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MainCategories != null)
            {
                MainCategory = await _context.MainCategories.ToListAsync();
            }
        }
    }
}
