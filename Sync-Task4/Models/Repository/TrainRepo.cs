using Sync_Task3.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Sync_Task4.Models.Repository
{
    public class TrainRepo : ITaskRepo<Train>
    {
        List<Train> Trains;

        public TrainRepo()
        {
            Trains = new List<Train>()
            {
                new Train()
                {
                    Id = 1,
                    Name = "Local",
                    Source = "Cairo",
                    Destination = "Alex",
                    AvailableSeats = 5,
                    Price = 100
                }
                ,new Train()
                {
                    Id = 2,
                    Name = "Express",
                    Source = "Cairo",
                    Destination = "New Capital",
                    AvailableSeats = 50,
                    Price = 150
                }
                ,new Train()
                {
                    Id = 3,
                    Name = "Fast Train",
                    Source = "Cairo",
                    Destination = "Aswan",
                    AvailableSeats = 100,
                    Price = 200
                }
            };
        }
        public void add(Train temp)
        {
            if (Trains.Count == 0) temp.Id = 1;
            else temp.Id = Trains.Max(x => x.Id) + 1;
            Trains.Add(temp);
        }

        public void delete(int id)
        {
            var train = find(id);

            Trains.Remove(train);
        }

        public Train find(int id)
        {
            var train = Trains.SingleOrDefault(d => d.Id == id);
            return train;
        }

        public List<Train> list() => Trains.ToList();

        public void update(Train temp)
        {
            var train = find(temp.Id);
            train.Name = temp.Name;
            train.Source = temp.Source;
            train.Destination = temp.Destination;
            train.Price = temp.Price;
            train.AvailableSeats = temp.AvailableSeats;
            
        }
    }
}
