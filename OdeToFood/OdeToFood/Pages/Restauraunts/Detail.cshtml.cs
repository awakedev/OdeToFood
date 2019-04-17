using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restauraunts
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurauntData restaurauntData;

        [TempData]
        public string Message { get; set; }

        public Restauraunt Restauraunt { get; set; }
        public IRestaurauntData RestaurauntData { get; }

        public DetailModel(IRestaurauntData restaurauntData)
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
    }
}