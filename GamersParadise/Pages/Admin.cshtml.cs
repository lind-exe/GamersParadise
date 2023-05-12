using GamersParadise.DAL;
using GamersParadise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamersParadise.Pages
{
    public class AdminModel : PageModel
    {

        [BindProperty]
        public SubCategory NewSubCategory { get; set; }
        [BindProperty]
        public List<SubCategory> SubCategories { get; set; }


        public async Task<IActionResult> OnGetAsync(int showid, int editid)
        {
            SubCategories = await AdminManager.GetAllSubCategories();

            if (showid != 0)
            {
                NewSubCategory = await AdminManager.GetOneSubCategory(showid);
            }
            else if (editid != 0)
            {
                NewSubCategory = await AdminManager.GetOneSubCategory(editid);
            }
            else
            {
                NewSubCategory = new SubCategory();
                NewSubCategory.Id = 9999;
            }


            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await AdminManager.SaveSubCategory(NewSubCategory);
            }
            SubCategories = await AdminManager.GetAllSubCategories();
            return Page();
        }
    }
}
