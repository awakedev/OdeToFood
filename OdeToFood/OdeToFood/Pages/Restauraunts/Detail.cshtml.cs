using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restauraunts
{
    public class DetailModel : PageModel
    {
        public Restauraunt Restauraunt { get; set; }

        public void OnGet()
        {
        }
    }
}