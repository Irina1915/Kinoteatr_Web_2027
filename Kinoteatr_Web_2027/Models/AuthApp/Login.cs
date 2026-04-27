using System.ComponentModel.DataAnnotations;

namespace Kinoteatr_Web_2027.Models.AuthApp
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
