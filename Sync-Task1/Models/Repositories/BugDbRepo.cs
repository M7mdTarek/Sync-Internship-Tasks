using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Sync_Task1.Models.Repositories
{
    public class BugDbRepo:ITask1Repo<Bug>
    {
        Task1DbContext db;
        public BugDbRepo(Task1DbContext db)
        {
            this.db = db;
        }
        public void add(Bug temp)
        {
            db.bug.Add(temp);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            var bug = find(id);
            db.bug.Remove(bug);
            db.SaveChanges();
        }

        public Bug find(int id)
        {
            var bug = db.bug.Include(add => add.developer).Include(add => add.solution).SingleOrDefault(x => x.id == id);
            return bug;
        }

        public List<Bug> list() => db.bug.Include(add => add.developer).Include(add => add.solution).ToList();

        public List<Bug> search(string term)
        {
            var results = db.bug.Include(add => add.developer).Include(add => add.solution)
                .Where(r => r.title.Contains(term)
                || r.developer.Name.Contains(term)).ToList();
            return results;
        }

        public void update(Bug temp)
        {
            db.bug.Update(temp);
            db.SaveChanges();
        }
        
    }
}
