using System.Collections.Generic;
using System.Linq;

namespace Sync_Task1.Models.Repositories
{
    public class DeveloperDbRepo : ITask1Repo<Developer>
    {
        Task1DbContext db;
        public DeveloperDbRepo(Task1DbContext db)
        {
            this.db = db;
        }
        public void add(Developer temp)
        {
            db.developer.Add(temp);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            var developer = find(id);

            db.developer.Remove(developer);
            db.SaveChanges();
        }

        public Developer find(int id)
        {
            var developer = db.developer.SingleOrDefault(d => d.id == id);
            return developer;
        }

        public List<Developer> list() => db.developer.ToList();

        public List<Developer> search(string term)
        {
            throw new System.NotImplementedException();
        }

        public void update(Developer temp)
        {
            db.developer.Update(temp);
            db.SaveChanges();
        }
    }
}
