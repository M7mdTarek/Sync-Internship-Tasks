using System.Collections.Generic;
using System.Linq;

namespace Sync_Task1.Models.Repositories
{
    public class DeveloperRepo : ITask1Repo<Developer>
    {
        List<Developer> developers;
        public DeveloperRepo()
        {
            developers = new List<Developer>()
            {
                new Developer() {id = 1,Name="mohamed",role="backend" ,imgUrl = "144565.jpg"},
                new Developer() {id = 2,Name="ahmed",role="datascience" ,imgUrl = "144565.jpg"},
                new Developer() {id = 3,Name="tarek",role="tester", imgUrl = "144565.jpg"},
                new Developer() {id = 4,Name="omnya",role="frontend", imgUrl = "144565.jpg"}
            };
        }
        public void add(Developer temp)
        {
            if(developers.Count == 0) temp.id = 1;
            else temp.id = developers.Max(x => x.id) + 1;
            developers.Add(temp);
        }

        public void delete(int id)
        {
            var developer = find(id);
          
            developers.Remove(developer);
        }

        public Developer find(int id)
        {
            var developer = developers.SingleOrDefault(d => d.id == id);
            return developer;
        }

        public List<Developer> list() => developers.ToList();

        public List<Developer> search(string term)
        {
            throw new System.NotImplementedException();
        }

        public void update(Developer temp)
        {
            Developer developer = find(temp.id);
            developer.Name = temp.Name;
            developer.role = temp.role;
            developer.imgUrl = temp.imgUrl;
        }
    }
}
