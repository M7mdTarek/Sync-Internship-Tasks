namespace Sync_Task4.Models
{
    public class Train
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Destination { get; set; }

        public string Source { get; set; }

        public int Price { get; set; }

        public int AvailableSeats { get; set;}
    }
}
