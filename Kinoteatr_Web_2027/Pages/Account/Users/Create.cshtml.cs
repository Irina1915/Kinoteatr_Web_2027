using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kinoteatr_Web_2027.Data;
using Kinoteatr_Web_2027.Models.AuthApp;

namespace Kinoteatr_Web_2027.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }
        [BindProperty]
        public IFormFile? AvatarFile { get; set; }
        public void OnGet()
        {
            User = new AuthUser();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // ????????? ????? (????????? ??? ????)
            if (AvatarFile != null)
            {
                if (AvatarFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "File too large");
                    return Page();
                }

                using (var ms = new MemoryStream())
                {
                    await AvatarFile.CopyToAsync(ms);
                    User.Avatar = ms.ToArray();
                }
            }
            if (User.Id > 0) // ???? ???????? ??? ?????????? (?????? ?????? ??? Create)
            {
                _context.Attach(User).State = EntityState.Modified;
            }
            else
            {
                // ??????????? ??????, ???? ?? ??????????? ? ??????
                // User.Password = PasswordHasher.Hash(User.Password);

                await _context.AuthUsers.AddAsync(User);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
