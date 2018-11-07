using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Booking
    {
        //Student student;
        //User user;
        public int ID;
        public DateTime IssuedOn, DueOn, ReturnedOn, BookedOn;
        public string Notes, Project;

        public Booking()
        {
            ID = 0;
            IssuedOn = new DateTime(2018,11,8,9,0,0,0);
            DueOn = new DateTime(2018, 11, 11, 9, 0, 0, 0);
            ReturnedOn = new DateTime(2018, 11, 10, 10, 0, 0, 0);
            BookedOn = new DateTime(2018, 11, 7, 9, 41, 15, 2);
            Notes = "";
            Project = "";
        }

        public Booking(int iD, DateTime issuedOn, DateTime dueOn, DateTime returnedOn, DateTime bookedOn, string notes, string project)
        {
            ID = iD;
            IssuedOn = issuedOn;
            DueOn = dueOn;
            ReturnedOn = returnedOn;
            BookedOn = bookedOn;
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
            Project = project ?? throw new ArgumentNullException(nameof(project));
        }
    }
}
