using System.Collections.Generic;
using System.Linq;

namespace Sync_Task3.Models.Repository
{
    public class StudentRepo : ITaskRepo<Student>
    {
        List<Student> students;

        public StudentRepo()
        {
            students = new List<Student>()
            {
                new Student(){Id = 1 , Name = "mohamed",Department = "CS"},
                new Student(){Id = 2 , Name = "ahmed",Department = "IS"},
                new Student(){Id = 3 , Name = "tarek",Department = "IT"},
                new Student(){Id = 4 , Name = "fathi",Department = "AI"}
            };
        }
        public void add(Student temp)
        {
            if (students.Count == 0) temp.Id = 1;
            else temp.Id = students.Max(x => x.Id) + 1;
            students.Add(temp);
        }

        public void delete(int id)
        {
            var student = find(id);

            students.Remove(student);
        }

        public Student find(int id)
        {
            var student = students.SingleOrDefault(d => d.Id == id);
            return student;
        }

        public List<Student> list()=>students.ToList();

        public void update(Student temp)
        {
            var student = find(temp.Id);
            student.Name = temp.Name;
            student.Department = temp.Department;
        }
    }
}
