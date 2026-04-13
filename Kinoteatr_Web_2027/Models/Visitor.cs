namespace Kinoteatr_Web_2027.Models
{
    public class Visitor : EFModel
    {
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
       

    }
}
