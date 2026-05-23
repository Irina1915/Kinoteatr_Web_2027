namespace Kinoteatr_Web_2027.Models.AuthApp
{
    public class AuthUser : EFModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public new string Name { get; set; } = "Name";
        public byte[]? Avatar { get; set; }
    }
}
