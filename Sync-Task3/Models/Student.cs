namespace Sync_Task3.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public int NumofAbsence { get; set; } = 0;

        public int Attendance { get; set; }
    }
}
