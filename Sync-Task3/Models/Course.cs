using System.Collections.Generic;

namespace Sync_Task3.Models
{
    public class Course
    {
        public int Id { get; set; }

        public int Size { get; set; }

        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
            Size = 0;
        }
    }
}
