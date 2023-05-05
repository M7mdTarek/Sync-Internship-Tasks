using Sync_Task3.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Sync_Task4.Models.Repository
{
    public class UserRepo : ITaskRepo<User>
    {
        List<User> Users { get; set; }

        public UserRepo() 
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "mohamed",
                    password = "123456",
                    Tickets = new List<Ticket>()
                    {
                        new Ticket(){Id = 1,Payment="222555463" ,Price = 150 ,Train = new Train(){Name = "Local"}}
                    }
                },
                new User()
                {
                    Id = 2,
                    Name = "tarek",
                    password = "123456",
                    Tickets = new List<Ticket>()
                },
                new User()
                {
                    Id = 3,
                    Name = "fathi",
                    password = "123456",
                    Tickets = new List<Ticket>()
                }
            };
        }
        public void add(User temp)
        {
            if (Users.Count == 0) temp.Id = 1;
            else temp.Id = Users.Max(x => x.Id) + 1;
            Users.Add(temp);
        }

        public void delete(int id)
        {
            var user = find(id);

            Users.Remove(user);
        }

        public User find(int id)
        {
            var user = Users.SingleOrDefault(d => d.Id == id);
            return user;
        }

        public List<User> list() => Users.ToList();

        public void update(User temp)
        {
            var user = find(temp.Id);
            user.Name = temp.Name;
            user.password = temp.password;
            user.Tickets = temp.Tickets;
        }
    }
}
