using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Instructor
    {
        public string InstructorID, Name, Email, Contact;

        public Instructor()
        {
            InstructorID = "1";
            Name = "NewInstructor";
            Email = "unknown";
            Contact = "NIL";
        }

        public Instructor(string instructorID, string name, string email, string contact)
        {
            InstructorID = instructorID ?? throw new ArgumentNullException(nameof(instructorID));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }
    }
}
