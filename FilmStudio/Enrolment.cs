using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Enrolment
    {
        public Student Student;
        public Course Course;
        public Instructor Instructor;
        public string ID, Term;

        public Enrolment()
        {
            ID = "1";
            Student = new Student();
            Course = new Course();
            Instructor = new Instructor();
            Term = "Spring2019";
        }

        public Enrolment(string iD, Student myStudent, Course myCourse, Instructor myInstructor, string term)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            Student = myStudent ?? throw new ArgumentNullException(nameof(myStudent));
            Course = myCourse ?? throw new ArgumentNullException(nameof(myCourse));
            Instructor = myInstructor ?? throw new ArgumentNullException(nameof(myInstructor));
            Term = term ?? throw new ArgumentNullException(nameof(term));
        }
    }
}
