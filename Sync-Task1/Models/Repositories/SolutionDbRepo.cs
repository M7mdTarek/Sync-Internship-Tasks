using System.Collections.Generic;
using System.Linq;

namespace Sync_Task1.Models.Repositories
{
    public class SolutionDbRepo : ITask1Repo<Solution>
    {
        Task1DbContext db;

        public SolutionDbRepo(Task1DbContext db)
        {
            this.db = db;
        }
        public void add(Solution temp)
        {
            db.solution.Add(temp);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            var soluton = find(id);
            db.solution.Remove(soluton);
            db.SaveChanges();
        }

        public Solution find(int id)
        {
            var solution = db.solution.SingleOrDefault(x => x.id == id);
            return solution;
        }

        public List<Solution> list() => db.solution.ToList();

        public List<Solution> search(string term)
        {
            throw new System.NotImplementedException();
        }

        public void update(Solution temp)
        {
            db.solution.Update(temp);
            db.SaveChanges();
        }
    }
}
