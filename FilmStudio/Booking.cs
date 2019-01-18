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

        //public List<Equipment> Equipments;

        public DateTime IssuedOn, DueOn, BookedOn, ReturnedOn;
        public string ID, Notes, BookedBy, Project;
        public bool OffCampus, Returned;

        public Booking(User user)
        {
            User = user;
            Instructor = new Instructor();
            Staff = new Staff();
            Student = new Student();
            Enrolment = new Enrolment();
            Course = new Course();
            //Equipments = new List<Equipment>();

            DateTime d = DateTime.Now;

            ID = "0";
            IssuedOn = DateTime.Now;
            DueOn = new DateTime(d.Year, d.Month, d.AddDays(1).Day, 10, 0, 0);
            BookedOn = DateTime.Now;
            //ReturnedOn = DateTime.Now.AddDays(3);
            Notes = "";
            BookedBy = "";
            Project = "";
            OffCampus = false;
            Returned = false;
        }
        /*

        public Booking(User user, Instructor instructor, Staff staff, Enrolment enrolment, Student student, Course course, DateTime issuedOn, DateTime dueOn, DateTime bookedOn, DateTime returnedOn, string iD, string notes, string bookedBy, string project, bool offCampus, bool returned)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Instructor = instructor ?? throw new ArgumentNullException(nameof(instructor));
            Staff = staff ?? throw new ArgumentNullException(nameof(staff));
            Enrolment = enrolment ?? throw new ArgumentNullException(nameof(enrolment));
            Student = student ?? throw new ArgumentNullException(nameof(student));
            Course = course ?? throw new ArgumentNullException(nameof(course));
            IssuedOn = issuedOn;
            DueOn = dueOn;
            ReturnedOn = returnedOn;
            BookedOn = bookedOn;
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
            BookedBy = bookedBy ?? throw new ArgumentNullException(nameof(bookedBy));
            Project = project ?? throw new ArgumentNullException(nameof(project));
            OffCampus = offCampus;
            Returned = returned;
        }

        public Booking(User user, Instructor instructor, Staff staff, Enrolment enrolment, Student student, Course course, DateTime issuedOn, DateTime dueOn, DateTime bookedOn, string iD, string notes, string bookedBy, string project, bool offCampus, bool returned)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Instructor = instructor ?? throw new ArgumentNullException(nameof(instructor));
            Staff = staff ?? throw new ArgumentNullException(nameof(staff));
            Enrolment = enrolment ?? throw new ArgumentNullException(nameof(enrolment));
            Student = student ?? throw new ArgumentNullException(nameof(student));
            Course = course ?? throw new ArgumentNullException(nameof(course));
            IssuedOn = issuedOn;
            DueOn = dueOn;
            BookedOn = bookedOn;
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
            BookedBy = bookedBy ?? throw new ArgumentNullException(nameof(bookedBy));
            Project = project ?? throw new ArgumentNullException(nameof(project));
            OffCampus = offCampus;
            Returned = returned;
        }*/
    }
}
