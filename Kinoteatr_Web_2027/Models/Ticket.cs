namespace Kinoteatr_Web_2027.Models
{
    public class Ticket : EFModel
    {
        public string Title { get; set; }
        public string Viewer { get; set; }
        public int Date { get; set; }

        public double Summa { get; set; }
    }
}
