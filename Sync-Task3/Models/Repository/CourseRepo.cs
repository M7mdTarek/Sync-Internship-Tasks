using System.Collections.Generic;
using System.Linq;

namespace Sync_Task3.Models.Repository
{
    public class CourseRepo : ITaskRepo<Course>
    {
        List<Course> courses;

        public CourseRepo()
        {
            courses = new List<Course>()
            {
                new Course()
                {
                    Id = 1,Name="operating system",
                    Teacher = new Teacher{Id=1 , Name="disoki",Age=25,Salary=10000},
                    //Students = new List<Student>()
                },
                new Course()
                {
                    Id = 2,Name="concept of programming",
                    Teacher = new Teacher{Id=2 , Name="amin allam",Age=30,Salary=20000},
                    //Students= new List<Student>()
                },
                new Course()
                {
                    Id = 3,Name="high preformance computing",
                    Teacher = new Teacher{Id=3 , Name="sabah",Age=27,Salary=15000},
                    //Students= new List<Student>()
                }
            };

        }
        public void add(Course temp)
        {
            if (courses.Count == 0) temp.Id = 1;
            else temp.Id = courses.Max(x => x.Id) + 1;
            courses.Add(temp);
        }

        public void delete(int id)
        {
            var course = find(id);

            courses.Remove(course);
        }

        public Course find(int id)
        {
            var course = courses.SingleOrDefault(d => d.Id == id);
            return course;
        }

        public List<Course> list() => courses.ToList();

        public void update(Course temp)
        {
            var course = find(temp.Id);
            course.Name = temp.Name;
            course.Teacher = temp.Teacher;
            course.Students = temp.Students;
        }
        
    }
}
