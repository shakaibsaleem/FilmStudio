insert into Users (Name, Passkey, isAdmin, Username)
values ('user','password',0,'username')

select * from Users

insert into Instructors (HabibID,Name,Email,Contact)
values ('fname.lname','Fname Lname','habibID@school.habib.edu.pk','+923210123456')

select HabibID,Name,Email,Contact from Instructors where InstructorID = 1

insert into Staff (HabibID,Name,Email,Contact)
values ('fname.lname','Fname Lname','habibID@habib.edu.pk','+923210123456')

select * from Staff

insert into Students (HabibID,Name,Email,Contact)
values ('xx01234','Fname Lname','habibID@st.habib.edu.pk','+923210123456')

select * from Students where HabibID = 'ms01036'

select HabibID from Students
order by HabibID

insert into Courses (CourseName,CourseCode)
values ('New Course','CRS103')

select * from Courses

select CourseName from Courses order by CourseName

select Name from Instructors order by Name

insert into Enrolments (CourseID,StudentID,InstructorID,Term)
values (3,2,2,'Spring2018')

select * from Enrolments

select * from Students

select * from Courses

select * from Instructors

select * from Staff

select * from Users
