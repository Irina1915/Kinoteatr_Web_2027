using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models;

namespace Kinoteatr_Web_2027.Pages.Visitors
{
    public class DetailsModel : PageModel
    {
        private readonly Kinoteatr_Web_2027.Data.ApplicationDbContext _context;

        public DetailsModel(Kinoteatr_Web_2027.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Visitor Visitor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors.FirstOrDefaultAsync(m => m.Id == id);

            if (visitor is not null)
            {
                Visitor = visitor;

                return Page();
            }

            return NotFound();
        }
    }
}
