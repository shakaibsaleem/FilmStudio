using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Course
    {
        public string CourseID, CourseName, CourseCode;

        public Course()
        {
            CourseID = "1";
            CourseName = "NewCourse";
            CourseCode = "CODE101";
        }

        public Course(string courseID, string courseName, string courseCode)
        {
            CourseID = courseID ?? throw new ArgumentNullException(nameof(courseID));
            CourseName = courseName ?? throw new ArgumentNullException(nameof(courseName));
            CourseCode = courseCode ?? throw new ArgumentNullException(nameof(courseCode));
        }
    }
}
