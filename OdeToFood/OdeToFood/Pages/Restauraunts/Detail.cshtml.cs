using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restauraunts
{
    public class DetailModel : PageModel
    {
        public Restauraunt Restauraunt { get; set; }

        public void OnGet(int restaurauntId)
        {
            Restauraunt = new Restauraunt();
            Restauraunt.Id = restaurauntId;
        }
    }
}