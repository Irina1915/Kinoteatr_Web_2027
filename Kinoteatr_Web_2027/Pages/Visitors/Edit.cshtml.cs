using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kinoteatr_Web_2027.Pages.Visitors
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visitor Visitor { get; set; }

        public IActionResult OnGet(int id)
        {
            Visitor = _context.Visitors.Find(id);

            if (Visitor == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Visitors.Update(Visitor);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
