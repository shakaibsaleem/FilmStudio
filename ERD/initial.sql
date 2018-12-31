insert into Users (Name, Passkey, isAdmin, Username)
values ('user','password',0,'username')

select * from Users

insert into Instructors (HabibID,Name,Email,Contact)
values ('fname.lname','Fname Lname','habibID@school.habib.edu.pk','+923210123456')

select * from Instructors

insert into Staff (HabibID,Name,Email,Contact)
values ('fname.lname','Fname Lname','habibID@habib.edu.pk','+923210123456')

select * from Staff

insert into Students (HabibID,Name,Email,Contact)
values ('xx01234','Fname Lname','habibID@st.habib.edu.pk','+923210123456')

select * from Students

insert into Courses (CourseName,CourseCode)
values ('Course Name','CRS102')

select * from Courses

insert into Enrolments (CourseID,StudentID,InstructorID,Term)
values (2,2,2,'Fall2018')

select * from Enrolments

select * from Users

select * from Instructors

select * from Staff

select * from Students

select * from Courses

select * from Enrolments
