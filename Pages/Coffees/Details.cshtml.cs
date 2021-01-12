using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Petrina_Ioana_ProiectFinal.Data;
using Petrina_Ioana_ProiectFinal.Models;

namespace Petrina_Ioana_ProiectFinal.Pages.Coffees
{
    public class DetailsModel : PageModel
    {
        private readonly Petrina_Ioana_ProiectFinal.Data.Petrina_Ioana_ProiectFinalContext _context;

        public DetailsModel(Petrina_Ioana_ProiectFinal.Data.Petrina_Ioana_ProiectFinalContext context)
        {
            _context = context;
        }

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
    }
}
