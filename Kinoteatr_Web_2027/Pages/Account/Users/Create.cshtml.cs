using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models.AuthApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kinoteatr_Web_2027.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        [BindProperty]
        public AuthUser User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.AuthUsers.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
