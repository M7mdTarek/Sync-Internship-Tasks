using System.Collections.Generic;
using System.Linq;

namespace Sync_Task1.Models.Repositories
{
    public class SolutionRepo : ITask1Repo<Solution>
    {
        public List<Solution> List { get; set; }

        public SolutionRepo()
        {
            List = new List<Solution>
            {
                new Solution {id=1,Title="change database",Description="change DB from oracle to my sql",timeInHours=1 },
                new Solution {id=2,Title="refactor the code",Description="add mvc design pattern",timeInHours=5 },
                new Solution {id=3,Title="devide and conquer",Description="divide the code into 5 functions",timeInHours=7 },
                new Solution {id=4,Title="make interface",Description="make interface for all repositories",timeInHours=13 },
            };
        }
        public void add(Solution temp)
        {
            if(List.Count == 0) temp.id = 1;
            else temp.id = List.Max(x => x.id) + 1;
            List.Add(temp);

        }

        public void delete(int id)
        {
            var soluton = find(id);
            List.Remove(soluton);

        }

        public Solution find(int id)
        {
            var solution = List.SingleOrDefault(x => x.id == id);
            return solution;
        }

        public List<Solution> list()=> List.ToList();

        public void update(Solution temp)
        {
            var solution = find(temp.id);
            solution.id = temp.id;
            solution.timeInHours = temp.timeInHours;
            solution.Title = temp.Title;
            solution.Description = temp.Description;

        }

        public List<Solution> search(string term)
        {
            throw new System.NotImplementedException();
        }
    }
}
