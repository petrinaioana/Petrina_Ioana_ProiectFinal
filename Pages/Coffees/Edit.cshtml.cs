using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Petrina_Ioana_ProiectFinal.Data;
using Petrina_Ioana_ProiectFinal.Models;

namespace Petrina_Ioana_ProiectFinal.Pages.Coffees
{
    public class EditModel : PageModel
    {
        private readonly Petrina_Ioana_ProiectFinal.Data.Petrina_Ioana_ProiectFinalContext _context;

        public EditModel(Petrina_Ioana_ProiectFinal.Data.Petrina_Ioana_ProiectFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coffee Coffee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coffee = await _context.Coffee.FirstOrDefaultAsync(m => m.ID == id);

            if (Coffee == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coffee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeExists(Coffee.ID))
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

        private bool CoffeeExists(int id)
        {
            return _context.Coffee.Any(e => e.ID == id);
        }
    }
}
