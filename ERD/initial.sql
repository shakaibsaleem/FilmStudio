insert into Users (Name, Passkey, isAdmin, Username)
values ('Shakaib Saleem','admin',1,'shakaib')

select * from Users

insert into Instructors (HabibID,Name,Email,Contact)
values ('aaron.mulvany','Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','+923210123456')

select * from Instructors

insert into Staff (HabibID,Name,Email,Contact)
values ('talha.muneer','Talha Muneer','talha.muneer@ahss.habib.edu.pk','+923210123456')

select * from Staff

insert into Students (HabibID,Name,Email,Contact)
values ('ms01036','Mohammad Shakaib Saleem','ms01036@st.habib.edu.pk','+923210123456')

select * from Students

insert into Courses (CourseName,CourseCode)
values ('Course','CRS101')

select * from Courses

insert into Enrolments (CourseID,StudentID,InstructorID,Term)
values (1,1,1,'Spring2019')

select * from Enrolments
