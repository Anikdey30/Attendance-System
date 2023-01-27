using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using assignment4.Entities;
using assignment4.Migrations;

AttendanceDBContext context = new AttendanceDBContext();

Console.Write("Username: ");
string user = Console.ReadLine();
Console.Write("Password: ");
string pass = Console.ReadLine();

Admin admin1 = context.Admins.Where(x => x.UserName == user).FirstOrDefault();
Admin admin2 = context.Admins.Where(y => y.Password == pass).FirstOrDefault();
Teacher teacher1 = context.Teachers.Where(z => z.Username == user).FirstOrDefault();
Teacher teacher2 = context.Teachers.Where(w => w.Password == pass).FirstOrDefault();
Student student1 = context.Students.Where(a => a.Username == user).FirstOrDefault();
Student student2 = context.Students.Where(b => b.Password == pass).FirstOrDefault();


if (admin1 != null && admin2 != null)
{
    Console.WriteLine
        ($"Welcome {user}\n" +
        "1. Create Teacher\n" +
        "2. Create Course\n" +
        "3. Create Student\n" +
        "4. Assign a teacher in a course\n" +
        "5. Assign students in a course\n" +
        "6. Set class schedule for a course"
        );
    Console.Write("Enter the serial no.: ");
    int? a = int.Parse(Console.ReadLine());

    if (a == 1)
    {
        Console.WriteLine("Add Teacher:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Username: ");
        string uname = Console.ReadLine();
        Console.Write("Password: ");
        string passcode = Console.ReadLine();

        if (name != null && uname != null && passcode != null)
        {
            Teacher t1 = new Teacher { Name = $"{name}", Username = $"{uname}", Password = $"{passcode}" };
            context.Add(t1);
            context.SaveChanges();
        }
        else
            Console.WriteLine("Any Index Cannot be null");
    }
    else if (a == 2)
    {
        Console.WriteLine("Add course");
        Console.Write("Course Name: ");
        string cname = Console.ReadLine();
        Console.Write("Fees: ");
        double fees = double.Parse(Console.ReadLine());

        if (cname != null && fees != null)
        {
            Course cour = new Course { CourseName = $"{cname}", Fees = fees };
            context.Add(cour);
            context.SaveChanges();
        }
        else
            Console.WriteLine("Any Index Cannot be null");
    }
    else if (a == 3)
    {
        Console.WriteLine("Add student");
        Console.Write("Name: ");
        string sname = Console.ReadLine();
        Console.Write("Username: ");
        string suname = Console.ReadLine();
        Console.Write("Password: ");
        string spasscode = Console.ReadLine();

        if (sname != null && suname != null && spasscode != null)
        {
            Student st1 = new Student { Name = $"{sname}", Username = $"{suname}", Password = $"{spasscode}" };
            context.Add(st1);
            context.SaveChanges();
        }
        else
            Console.WriteLine("Any Index Cannot be null");

    }
    else if (a == 4)
    {
        Console.WriteLine("Assigning Teacher to Course");
        Console.Write("Teacher's Name: ");
        string tname= Console.ReadLine(); 
        Console.Write("Course Name: ");
        string cname = Console.ReadLine();
        Teacher teacher = context.Teachers.Where(x => x.Name == $"{tname}").FirstOrDefault();
        Course courses = context.Courses.Where(x => x.CourseName == $"{cname}").FirstOrDefault();
        courses.TeacherId = teacher.Id;
        context.SaveChanges();
    }
    else if (a == 5)
    {
        Console.WriteLine("Assigning students in a course");
        Console.Write("Student Name: ");
        string stname = Console.ReadLine();
        Console.Write("Course Name: ");
        string cname = Console.ReadLine();
        Course courses = context.Courses.Where(x => x.CourseName == $"{cname}").FirstOrDefault();
        Student student = context.Students.Where(y => y.Name == $"{stname}").FirstOrDefault();
        if (courses.CourseStudents == null)
        {
            courses.CourseStudents = new List<CourseRegestration>();
            courses.CourseStudents.Add(new CourseRegestration { Student = student });
            context.SaveChanges();
        }
    }
    else if (a == 6)
    {
        Console.WriteLine("Schedule to courses");
        Console.Write("Course Name: ");
        string coname = Console.ReadLine();
        Console.Write("Day and Time (like Sunday 8-10pm)(,): ");
        string dt = Console.ReadLine();
        Console.Write("Total Number of Classes: ");
        int tc = int.Parse(Console.ReadLine());
        

        ClassSchedule CourseWithSchedules = new ClassSchedule { DayAndTime = $"{dt}", TotalNumberOfClasses = tc };
        CourseWithSchedules.CourseSchedules = new List<Course>();
        CourseWithSchedules.CourseSchedules.Where(x => x.CourseName == $"{coname}");
        context.ClassSchedules.Add(CourseWithSchedules);
        context.SaveChanges();

        Course n = context.Courses.Where(x => x.CourseName == $"{coname}").FirstOrDefault();
        n.ScheduleClassesID = CourseWithSchedules.ID;
        context.SaveChanges();



    }

    else
        Console.WriteLine("!!!!!!!!!Invalid Number please enter 1-6!!!!!!!!!");
}





else if (teacher1 != null && teacher2 != null)
{
    Console.WriteLine($"Welcome {teacher1.Name}");
    /*Console.WriteLine("Check Attendance:");
    Console.Write("Course Name:");
    string CourseName = Console.ReadLine();

    Course course = context.Courses.Where(x => x.CourseName == $"{CourseName}")
        .Include(x => x.CourseAttends)
        .FirstOrDefault();*/
}







else if (student1 != null && student2 != null)
{
    Console.WriteLine($"Welcome {student1.Name}\n Attendance--");
    Console.Write("Course Name: ");
    string cname = Console.ReadLine();
    Console.Write("Give Attendance(Sunday 11-2): ");
    string att = Console.ReadLine();

    
    Course courses = context.Courses.Where(x => x.CourseName == $"{cname}").FirstOrDefault();
    StudentAttendance sa = new StudentAttendance();
    sa.StudentID = student1.Id;
    sa.Attendance = att;
  
    if (courses.CourseAttends == null)
    {
        courses.CourseAttends = new List<CourseAttendance>();
        courses.CourseAttends.Add(new CourseAttendance { StudentAttendance = sa });
        context.SaveChanges();
    }
    else
        Console.WriteLine("index is not null");
}

else
    Console.WriteLine("You arenot registered!!\n OR, INVALID DETAILS!!");



