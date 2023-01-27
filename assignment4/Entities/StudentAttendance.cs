using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4.Entities
{
    public class StudentAttendance
    {
        public int ID { get; set; }
        public string Attendance { get; set; }
        public int StudentID { get; set; }
        public List<CourseAttendance> AttendCourses { get; set; }
    }
}
