using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Instructor
    {
        public int InstructorID;
        public string InstructorName;

        public Instructor()
        {
            InstructorID = 0;
            InstructorName = "NewInstructor";
        }

        public Instructor(int instructorID, string instructorName)
        {
            InstructorID = instructorID;
            InstructorName = instructorName ?? throw new ArgumentNullException(nameof(instructorName));
        }
    }
}
