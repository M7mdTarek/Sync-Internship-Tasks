using System.Collections.Generic;

namespace Sync_Task1.Models.Repositories
{
    public interface ITask1Repo<Temp>
    {
        List<Temp> list();
        Temp find(int id);
        void delete(int id);
        void update(Temp temp);
        void add(Temp temp);
        List<Temp> search(string term);
    }
}
