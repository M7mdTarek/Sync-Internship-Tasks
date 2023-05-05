namespace Sync_Task4.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public Train Train { get; set; }

        public int Price { get; set; }

        public string Payment { get; set; }
    }
}
