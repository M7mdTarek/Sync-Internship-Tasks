using System.Collections.Generic;
using System.Linq;

namespace Sync_Task1.Models.Repositories
{
    public class BugRepo : ITask1Repo<Bug>
    {
        List<Bug> bugs;
        public BugRepo()
        {
            bugs = new List<Bug>()
            {
                new Bug(){
                    id=1,
                    title="runtime error",
                    priority=2,
                    state="inprogress",
                    description="some description",
                    developer = new Developer(){Name = "mohamed"},
                    solution=new Solution(){id = 1}
                },
                new Bug(){
                    id=2,
                    title="compiletime error",
                    priority=5,
                    state="inprogress",
                    description="some description",
                    developer = new Developer(){Name = "ahmed"},
                    solution=new Solution(){id = 2}
                },
                new Bug(){
                    id=3,
                    title="syntax error",
                    priority=1,
                    state="done",
                    description="some description",
                    developer = new Developer(){Name = "omnya"},
                    solution=new Solution(){id = 3}
                },
            };
        }
        public void add(Bug temp)
        {
            if(bugs.Count == 0) temp.id = 1;
            else temp.id = bugs.Max(a => a.id) + 1;
            bugs.Add(temp);
        }

        public void delete(int id)
        {
            var bug = find(id);
            bugs.Remove(bug);
        }

        public Bug find(int id)
        {
            var bug = bugs.SingleOrDefault(x => x.id == id);
            return bug;
        }

        public List<Bug> list() => bugs.ToList();

        public List<Bug> search(string term)
        {
            var results = bugs.Where(a => a.title.Contains(term)
            || a.developer.Name.Contains(term)).ToList();
            return results;
        }

        public void update(Bug temp)
        {
            var bug = find(temp.id);
            bug.description = temp.description;
            bug.developer = temp.developer;
            bug.title = temp.title;
            bug.priority = temp.priority;
            bug.state = temp.state;
            bug.solution = temp.solution;
        }
    }
}
