using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Course
    {
        public int CourseID;
        public string CourseName, CourseCode;

        public Course()
        {
            CourseID = 0;
            CourseName = "NewCourse";
            CourseCode = "CODE101";
        }

        public Course(int courseID, string courseName, string courseCode)
        {
            CourseID = courseID;
            CourseName = courseName ?? throw new ArgumentNullException(nameof(courseName));
            CourseCode = courseCode ?? throw new ArgumentNullException(nameof(courseCode));
        }
    }
}
