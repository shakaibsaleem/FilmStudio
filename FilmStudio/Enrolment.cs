using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Enrolment
    {
        public int EnrolmentID;
        public Student MyStudent;
        public Course MyCourse;
        public Instructor MyInstructor;
        public string Term;

        public Enrolment()
        {
            EnrolmentID = 9;
            MyStudent = new Student();
            MyCourse = new Course();
            MyInstructor = new Instructor();
            Term = "Fall2018";
        }

        public Enrolment(int enrolmentID, Student myStudent, Course myCourse, Instructor myInstructor, string term)
        {
            EnrolmentID = enrolmentID;
            MyStudent = myStudent ?? throw new ArgumentNullException(nameof(myStudent));
            MyCourse = myCourse ?? throw new ArgumentNullException(nameof(myCourse));
            MyInstructor = myInstructor ?? throw new ArgumentNullException(nameof(myInstructor));
            Term = term ?? throw new ArgumentNullException(nameof(term));
        }
    }
}
