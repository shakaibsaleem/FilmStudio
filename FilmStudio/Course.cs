using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Course
    {
        public string ID, CourseName, CourseCode;

        public Course()
        {
            ID = "1";
            CourseName = "Course";
            CourseCode = "CRS101";
        }

        public Course(string iD, string courseName, string courseCode)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            CourseName = courseName ?? throw new ArgumentNullException(nameof(courseName));
            CourseCode = courseCode ?? throw new ArgumentNullException(nameof(courseCode));
        }

        public override string ToString()
        {
            return CourseName;
        }
    }
}
