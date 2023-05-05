using System.Collections.Generic;

namespace Sync_Task3.Models.Repository
{
    public interface ITaskRepo<Temp>
    {
        List<Temp> list();
        Temp find(int id);
        void delete(int id);
        void update(Temp temp);
        void add(Temp temp);
    }
}
