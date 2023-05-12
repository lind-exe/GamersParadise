using GamersParadise.DAL;
using GamersParadise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamersParadise.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<SubCategory> SubCategories { get; set; }

        [BindProperty]
        public SubCategory SubCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int editid)
        {
            SubCategories = await AdminManager.GetAllSubCategories();
            if (editid != 0)
            {
                SubCategory = SubCategories.Where(x => x.Id == editid).FirstOrDefault();

            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}