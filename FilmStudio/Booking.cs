using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Booking
    {
        public User CurrentUser;
        public Instructor CurrentInstructor;
        public Staff CurrentStaff;
        public Enrolment CurrentEnrolment;
        public Student CurrentStudent;
        public Course CurrentCourse;

        public DateTime IssuedOn, DueOn, ReturnedOn, BookedOn;
        public string ID, Notes, BookedBy;

        public Booking()
        {
            CurrentUser = new User();
            CurrentInstructor = new Instructor();
            CurrentStaff = new Staff();
            CurrentStudent = new Student();
            CurrentEnrolment = new Enrolment();
            CurrentCourse = new Course();

            ID = "0";
            IssuedOn = new DateTime(2018,11,8,9,0,0,0);
            DueOn = new DateTime(2018, 11, 11, 9, 0, 0, 0);
            ReturnedOn = new DateTime(2018, 11, 10, 10, 0, 0, 0);
            BookedOn = new DateTime(2018, 11, 7, 9, 41, 15, 2);
            Notes = "";
            BookedBy = "";
        }

        public Booking(User currentUser,Course currentCourse, Instructor currentInstructor, Staff currentStaff, Student currentStudent, Enrolment currentEnrolment, DateTime issuedOn, DateTime dueOn, DateTime returnedOn, DateTime bookedOn, string iD, string notes, string bookedBy)
        {
            CurrentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            CurrentCourse = currentCourse ?? throw new ArgumentNullException(nameof(currentCourse));
            CurrentInstructor = currentInstructor ?? throw new ArgumentNullException(nameof(currentInstructor));
            CurrentStaff = currentStaff ?? throw new ArgumentNullException(nameof(currentStaff));
            CurrentEnrolment = currentEnrolment ?? throw new ArgumentNullException(nameof(currentEnrolment));
            CurrentStudent = currentStudent ?? throw new ArgumentNullException(nameof(currentStudent));
            IssuedOn = issuedOn;
            DueOn = dueOn;
            ReturnedOn = returnedOn;
            BookedOn = bookedOn;
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
            BookedBy = bookedBy ?? throw new ArgumentNullException(nameof(bookedBy));
        }
    }
}
