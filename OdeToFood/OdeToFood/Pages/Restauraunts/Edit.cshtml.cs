using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restauraunts
{
    public class EditModel : PageModel
    {
        private readonly IRestaurauntData restaurauntData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restauraunt Restauraunt { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurauntData restaurauntData,
                         IHtmlHelper htmlHelper)
        {
            this.restaurauntData = restaurauntData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurauntId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            Restauraunt = restaurauntData.GetById(restaurauntId);
            if (Restauraunt == null)
            {
                return RedirectToPage("/.NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            Restauraunt = restaurauntData.Update(Restauraunt);
            restaurauntData.Commit();
            return Page();
        }
    }
}