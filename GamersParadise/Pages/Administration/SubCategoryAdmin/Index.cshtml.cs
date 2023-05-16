using GamersParadise.DAL;
using GamersParadise.Data;
using GamersParadise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamersParadise.Pages.Administration.SubCategoryAdmin
{
    public class IndexModel : PageModel
    {
        private GamersParadiseContext _context;

        public IndexModel(GamersParadiseContext context)
        {

            _context = context;

        }
        [BindProperty]
        public MainCategory MainCategory { get; set; }
        [BindProperty]
        public List<MainCategory> MainCategories { get; set; }
        [BindProperty]
        public SubCategory NewSubCategory { get; set; }
        [BindProperty]
        public List<SubCategory> SubCategories { get; set; }


        public async Task<IActionResult> OnGetAsync(int showid, int editid, int mainCategoryId)
        {
            MainCategories = await _context.MainCategories.ToListAsync();
            MainCategory = new();


            
            MainCategory.SubCategories = new();

            SubCategories = await AdminManager.GetAllSubCategories();




            if (mainCategoryId != null)
            {
                MainCategory = _context.MainCategories.Where(x => x.Id == mainCategoryId).FirstOrDefault();


            }
            


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

                if (MainCategory != null)
                {
                    
                    MainCategory.SubCategories.Add(NewSubCategory);
                    
                }
            }
            SubCategories = await AdminManager.GetAllSubCategories();
            return RedirectToPage("/Administration/SubCategoryAdmin/Index");
        }
    }
}
