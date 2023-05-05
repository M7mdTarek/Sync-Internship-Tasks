using System.Collections.Generic;

namespace Sync_Task4.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Ticket> Tickets { get; set; }

        public string password { get; set; }

        public int NumofTickets { get; set; } = 0;
    }
}
