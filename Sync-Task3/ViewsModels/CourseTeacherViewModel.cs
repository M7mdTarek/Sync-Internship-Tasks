using Sync_Task3.Models;
using System.Collections.Generic;

namespace Sync_Task3.ViewsModels
{
    public class CourseTeacherViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public int TeacherId { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}
