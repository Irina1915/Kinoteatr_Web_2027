using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kinoteatr_Web_2027.Pages.Visitors
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Visitor Visitor { get; set; }

        public IActionResult OnGet(int id)
        {
            Visitor = _context.Visitors.FirstOrDefault(s => s.Id == id);

            if (Visitor == null)
                return NotFound();

            return Page();
        }
    }
}
