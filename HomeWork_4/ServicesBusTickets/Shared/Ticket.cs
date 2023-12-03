using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesBusTickets.Shared
{
    public class Ticket
    {
        public int Id { get; set; }
        public string FromStation  { get; set; } = string.Empty;
        public string ToStation  { get; set; } = string.Empty;
        public DateTime DatePurchase {  get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
