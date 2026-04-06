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
        public Ticket Ticket { get; set; }

        public IActionResult OnGet(string Title)
        {
            Ticket = _context.Tickets.Find(Title);

            if (Ticket == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var participant = _context.Tickets.Find(Ticket.Title);

            if (participant != null)
            {
                _context.Tickets.Remove(participant);
                //_context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
