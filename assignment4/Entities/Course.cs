using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public double Fees { get; set; }
        public List<CourseRegestration> CourseStudents { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? ScheduleClassesID { get; set; }
        public ClassSchedule ScheduleClasses { get; set; }


        public List<CourseAttendance> CourseAttends { get; set; }

    }
}
