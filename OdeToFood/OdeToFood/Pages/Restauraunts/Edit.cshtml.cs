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

        public IActionResult OnGet(int? restaurauntId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurauntId.HasValue)
            {
                Restauraunt = restaurauntData.GetById(restaurauntId.Value);
            }
            else
            {
                Restauraunt = new Restauraunt();
            }
            if (Restauraunt == null)
            {
                return RedirectToPage("/.NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restauraunt.Id > 0)
            {
                restaurauntData.Update(Restauraunt);
            }
            else
            {
                restaurauntData.Add(Restauraunt);
            }
            restaurauntData.Commit();
            TempData["Message"] = "Restauraunt saved!";
            return RedirectToPage("./Detail", new { restaurauntId = Restauraunt.Id });
        }
    }
}