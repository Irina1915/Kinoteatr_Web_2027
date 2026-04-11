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

        public IActionResult OnGet(string LastName)
        {
            Visitor = _context.Visitors.Find(LastName);

            if (Visitor == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var participant = _context.Visitors.Find(Visitor.LastName);

            if (participant != null)
            {
                _context.Visitors.Remove(participant);
                //_context.SaveChanges();
            }

            return RedirectToPage("Index");
        
        }
    }
}
