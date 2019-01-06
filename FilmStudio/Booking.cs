using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Booking
    {
        public User User;
        public Instructor Instructor;
        public Staff Staff;
        public Enrolment Enrolment;
        public Student Student;
        public Course Course;

        public DateTime IssuedOn, DueOn, ReturnedOn, BookedOn;
        public string ID, Notes, BookedBy, Project;

        public Booking(User currentUser)
        {
            User = currentUser;
            Instructor = new Instructor();
            Staff = new Staff();
            Student = new Student();
            Enrolment = new Enrolment();
            Course = new Course();

            ID = "0";
            IssuedOn = DateTime.Now.AddDays(1);
            DueOn = DateTime.Now.AddDays(4);
            ReturnedOn = DateTime.Now.AddDays(3);
            BookedOn = DateTime.Now;
            Notes = "";
            BookedBy = "";
            Project = "";
        }

        public Booking(User currentUser,Course currentCourse, Instructor currentInstructor, Staff currentStaff, Student currentStudent, Enrolment currentEnrolment, DateTime issuedOn, DateTime dueOn, DateTime returnedOn, DateTime bookedOn, string iD, string notes, string bookedBy, string project)
        {
            User = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            Course = currentCourse ?? throw new ArgumentNullException(nameof(currentCourse));
            Instructor = currentInstructor ?? throw new ArgumentNullException(nameof(currentInstructor));
            Staff = currentStaff ?? throw new ArgumentNullException(nameof(currentStaff));
            Enrolment = currentEnrolment ?? throw new ArgumentNullException(nameof(currentEnrolment));
            Student = currentStudent ?? throw new ArgumentNullException(nameof(currentStudent));
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
