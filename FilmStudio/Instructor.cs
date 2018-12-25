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
        public string Name, Email, Contact;

        public Instructor()
        {
            InstructorID = 0;
            Name = "NewInstructor";
            Email = "unknown";
            Contact = "NIL";
        }

        public Instructor(int instructorID, string name, string email, string contact)
        {
            InstructorID = instructorID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }
    }
}
