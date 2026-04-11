using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kinoteatr_Web_2027.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        //private readonly IHubContext<BookHub> _hubContext;

        //public EditModel(ApplicationDbContext context, IHubContext<BookHub> hubContext)
        //{
        //    _context = context;
        //    _hubContext = hubContext;
        //}

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
            if (!ModelState.IsValid)
                return Page();

            _context.Tickets.Update(Ticket);
            _context.SaveChanges();

            // Отправляем обновление всем клиентам
            //_hubContext.Clients.All.SendAsync("BookUpdated", Ticket);

            return RedirectToPage("Index");
        }
    }
}
