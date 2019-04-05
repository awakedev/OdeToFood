using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restauraunts
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurauntData _restaurauntData;
        public string Message { get; set; }
        public IEnumerable<Restauraunt> Restauraunts { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurauntData restaurauntData)
        {
            this._config = config;
            this._restaurauntData = restaurauntData;
        }

        public void OnGet()
        {
            Restauraunts = _restaurauntData.GetRestaurauntsByName(SearchTerm);
        }
    }
}