using GamersParadise.DAL;
using GamersParadise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GamersParadise.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace GamersParadise.Pages
{
	public class IndexModel : PageModel
	{
		public GamersParadiseUser MyUser { get; set; }
		private UserManager<GamersParadiseUser> _userManager { get; set; } //TODO: Kolla igenom alla properties och Program
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