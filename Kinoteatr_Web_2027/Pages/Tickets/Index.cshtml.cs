using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Kinoteatr_Web_2027.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ticket> Tickets { get; set; }

        public void OnGet()
        {
            Tickets = _context.Tickets
                .ToList();
        }
    }
}
