using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Enrolment
    {
        public Student MyStudent;
        public Course MyCourse;
        public Instructor MyInstructor;
        public string ID, Term;

        public Enrolment()
        {
            ID = "1";
            MyStudent = new Student();
            MyCourse = new Course();
            MyInstructor = new Instructor();
            Term = "Spring2019";
        }

        public Enrolment(string iD, Student myStudent, Course myCourse, Instructor myInstructor, string term)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            MyStudent = myStudent ?? throw new ArgumentNullException(nameof(myStudent));
            MyCourse = myCourse ?? throw new ArgumentNullException(nameof(myCourse));
            MyInstructor = myInstructor ?? throw new ArgumentNullException(nameof(myInstructor));
            Term = term ?? throw new ArgumentNullException(nameof(term));
        }
    }
}
