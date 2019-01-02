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
        public string ID, Notes, BookedBy, Project;

        public Booking()
        {
            CurrentUser = new User();
            CurrentInstructor = new Instructor();
            CurrentStaff = new Staff();
            CurrentStudent = new Student();
            CurrentEnrolment = new Enrolment();
            CurrentCourse = new Course();

            ID = "0";
            IssuedOn = DateTime.Now.AddDays(1);
            DueOn = DateTime.Now.AddDays(3);
            ReturnedOn = DateTime.Now.AddDays(2);
            BookedOn = DateTime.Now;
            Notes = "";
            BookedBy = "";
            Project = "";
        }

        public Booking(User currentUser,Course currentCourse, Instructor currentInstructor, Staff currentStaff, Student currentStudent, Enrolment currentEnrolment, DateTime issuedOn, DateTime dueOn, DateTime returnedOn, DateTime bookedOn, string iD, string notes, string bookedBy, string project)
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
            Project = project ?? throw new ArgumentNullException(nameof(project));
        }
    }
}
