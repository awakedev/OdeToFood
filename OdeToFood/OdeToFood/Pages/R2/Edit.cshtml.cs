using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.R2
{
    public class EditModel : PageModel
    {
        private readonly OdeToFood.Data.OdeToFoodDbContext _context;

        public EditModel(OdeToFood.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Restauraunt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurauntExists(Restauraunt.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RestaurauntExists(int id)
        {
            return _context.Restauraunts.Any(e => e.Id == id);
        }
    }
}
