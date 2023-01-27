using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4.Entities
{
    public class CourseAttendance
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int StudentAttendanceID { get; set; }
        public StudentAttendance StudentAttendance { get; set; }
    }
}
