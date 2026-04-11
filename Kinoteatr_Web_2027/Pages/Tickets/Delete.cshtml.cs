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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket? Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = _context.Tickets
                        .Where(c => c.Id == id)
                        .Include(b => b.Viewer)
                        .FirstOrDefault();

            if (Ticket == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var ticket = _context.Tickets.Find(Ticket.Id);

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
