using System.Collections.Generic;
using System.Linq;

namespace Sync_Task3.Models.Repository
{
    public class TeacherRepo : ITaskRepo<Teacher>
    {
        List<Teacher> teachers;

        public TeacherRepo()
        {
            teachers = new List<Teacher>()
            {
                new Teacher{Id=1 , Name="disoki",Age=25,Salary=10000},
                new Teacher{Id=2 , Name="amin allam",Age=30,Salary=20000},
                new Teacher{Id=3 , Name="sabah",Age=27,Salary=15000}
            };
        }
        public void add(Teacher temp)
        {
            if (teachers.Count == 0) temp.Id = 1;
            else temp.Id = teachers.Max(x => x.Id) + 1;
            teachers.Add(temp);
        }

        public void delete(int id)
        {
            var teacher = find(id);

            teachers.Remove(teacher);
        }

        public Teacher find(int id)
        {
            var teacher = teachers.SingleOrDefault(d => d.Id == id);
            return teacher;
        }

        public List<Teacher> list() => teachers.ToList();

        public void update(Teacher temp)
        {
            var teacher = find(temp.Id);
            teacher.Name = temp.Name;
            teacher.Salary = temp.Salary;
            teacher.Age = temp.Age;
        }
    }
}
