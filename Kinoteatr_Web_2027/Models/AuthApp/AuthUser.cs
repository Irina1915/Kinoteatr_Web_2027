namespace Kinoteatr_Web_2027.Models.AuthApp
{
    public class AuthUser : EFModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
