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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            var visitor = _context.Visitors.Find(Visitor.Id);

            if (visitor != null)
            {
                _context.Visitors.Remove(visitor);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
