using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4.Entities
{
    public class ClassSchedule
    {
        public int ID { get; set; }
        public string DayAndTime { get; set; }
        public int TotalNumberOfClasses { get; set; }
        public List<Course> CourseSchedules { get; set; }

    }
}
