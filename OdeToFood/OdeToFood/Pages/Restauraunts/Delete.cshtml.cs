using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restauraunts
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurauntData restaurauntData;

        public Restauraunt Restauraunt { get; set; }

        public DeleteModel(IRestaurauntData restaurauntData)
        {
            this.restaurauntData = restaurauntData;
        }

        public IActionResult OnGet(int restaurauntId)
        {
            Restauraunt = restaurauntData.GetById(restaurauntId);
            if (Restauraunt == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurauntId)
        {
            var restauraunt = restaurauntData.Delete(restaurauntId);
            restaurauntData.Commit();

            if (restauraunt == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restauraunt.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}