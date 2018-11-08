﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Student
    {
        public int StudentID;
        public string HUID, FirstName, MiddleName, LastName, Contact;
        public Course StdCourse;
        public Instructor StdInstructor;

        public Student()
        {
            StudentID = 420;
            HUID = "ab01234";
            FirstName = "Shah";
            MiddleName = "Rukh";
            LastName = "Khan";
            Contact = "923001234567";
            StdCourse = new Course();
            StdInstructor = new Instructor();
        }

        public Student(int studentID, string hUID, string firstName, string middleName, string lastName, string contact, Course stdCourse, Instructor stdInstructor)
        {
            StudentID = studentID;
            HUID = hUID ?? throw new ArgumentNullException(nameof(hUID));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
            StdCourse = stdCourse;
            StdInstructor = stdInstructor;
        }
    }
}
