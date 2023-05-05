using Sync_Task3.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Sync_Task4.Models.Repository
{
    public class TicketRepo : ITaskRepo<Ticket>
    {
        List<Ticket> Tickets = new List<Ticket>();
        public void add(Ticket temp)
        {
            if (Tickets.Count == 0) temp.Id = 1;
            else temp.Id = Tickets.Max(x => x.Id) + 1;
            Tickets.Add(temp);
        }

        public void delete(int id)
        {
            var ticket = find(id);

            Tickets.Remove(ticket);
        }

        public Ticket find(int id)
        {
            var ticket = Tickets.SingleOrDefault(d => d.Id == id);
            return ticket;
        }

        public List<Ticket> list() => Tickets.ToList();

        public void update(Ticket temp)
        {
            var ticket = find(temp.Id);
            ticket.Payment = temp.Payment;
            ticket.Price = temp.Price;
            ticket.Train = temp.Train;

        }
    }
}
