﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.R2
{
    public class DetailsModel : PageModel
    {
        private readonly OdeToFood.Data.OdeToFoodDbContext _context;

        public DetailsModel(OdeToFood.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Restauraunt Restauraunt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restauraunt = await _context.Restauraunts.FirstOrDefaultAsync(m => m.Id == id);

            if (Restauraunt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
