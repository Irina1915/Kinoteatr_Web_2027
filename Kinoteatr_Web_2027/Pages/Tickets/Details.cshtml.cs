using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models;

namespace Kinoteatr_Web_2027.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Ticket? Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = _context.Tickets
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

            if (Ticket == null)
                return NotFound();

            return Page();
        }
    }
}
