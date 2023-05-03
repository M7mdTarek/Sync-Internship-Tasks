using Sync_Task3.Models;
using System.Collections.Generic;

namespace Sync_Task3.ViewsModels
{
    public class CourseStudentViewModel
    {
        public int CoursesId { get; set; }

        public int StudentId { get; set; }
        public List<Student> Students { get; set; }

        public List<Student> AllStudents { get; set; }

        public List<Course> AllCourses { get; set; }


    }
}
