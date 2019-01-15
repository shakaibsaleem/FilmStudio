using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Student
    {
        public string ID, HabibID, Name, Email, Contact;

        public Student()
        {
            ID = "1";
            HabibID = "ms01036";
            Name = "Mohammad Shakaib Saleem";
            Email = "ms01036@st.habib.edu.pk";
            Contact = "+923210123456";
        }

        public Student(string iD, string habibID, string name, string email, string contact)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            HabibID = habibID ?? throw new ArgumentNullException(nameof(habibID));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        public override string ToString()
        {
            return HabibID;
        }
    }
}
