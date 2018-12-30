using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Student
    {
        public string StudentID,HUID, FirstName, MiddleName, LastName, Contact, Email;

        public Student()
        {
            StudentID = "3";
            HUID = "ab01234";
            FirstName = "Shah";
            MiddleName = "Rukh";
            LastName = "Khan";
            Contact = "923001234567";
            Email = "ab01234@st.habib.edu.pk";
        }

        public Student(string studentID, string hUID, string firstName, string middleName, string lastName, string contact, string email)
        {
            StudentID = studentID ?? throw new ArgumentNullException(nameof(studentID));
            HUID = hUID ?? throw new ArgumentNullException(nameof(hUID));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
