using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Instructor
    {
        public string ID, HabibID, Name, Email, Contact;

        public Instructor()
        {
            ID = "1";
            HabibID = "aaron.mulvany";
            Name = "Aaron Mulvany";
            Email = "aaron.mulvany@ahss.habib.edu.pk";
            Contact = "+923210123456";
        }

        public Instructor(string iD, string habibID, string name, string email, string contact)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            HabibID = habibID ?? throw new ArgumentNullException(nameof(habibID));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
