insert into Users (Name, Passkey, isAdmin, Username)
values ('user','password',0,'username')
insert into Users (Name, Passkey, isAdmin, Username)
values ('Shakaib Saleem','admin',0,'shakaib')
insert into Users (Name, Passkey, isAdmin, Username)
values ('Talha Muneer','admin',1,'talha')

insert into Instructors (HabibID,Name,Email,Contact)
values ('waqar.saleem','Waqar Saleem','waqar.saleem@sse.habib.edu.pk','+9221111042242')
insert into Instructors (HabibID,Name,Email,Contact)
values ('muqeem.khan','Muqeem Khan','muqeem.khan@ahss.habib.edu.pk','+9221111042242')
insert into Instructors (HabibID,Name,Email,Contact)
values ('aaron.mulvany','Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','+9221111042242')

insert into Staff (HabibID,Name,Email,Contact)
values ('fname.lname','Fname Lname','habibID@habib.edu.pk','+9221111042242')
insert into Staff (HabibID,Name,Email,Contact)
values ('talha.muneer','Talha Muneer','talha.muneer@ahss.habib.edu.pk','+9221111042242')

insert into Students (HabibID,Name,Email,Contact)
values ('xx01234','Fname Lname','habibID@st.habib.edu.pk','+9221111042242')
insert into Students (HabibID,Name,Email,Contact)
values ('ms01036','Shakaib Saleem','ms01036@st.habib.edu.pk','+9221111042242')
insert into Students (HabibID,Name,Email,Contact)
values ('hr01295','Haya Danish','hr01295@st.habib.edu.pk','+9221111042242')

insert into Courses (CourseName,CourseCode)
values ('Intro to Film','FILM101')
insert into Courses (CourseName,CourseCode)
values ('Film Making','FILM102')
insert into Courses (CourseName,CourseCode)
values ('Advance Film','FILM301')
insert into Courses (CourseName,CourseCode)
values ('Intro to Photography','CND121')
insert into Courses (CourseName,CourseCode)
values ('Photography Techniques','CND122')

insert into Enrolments (StudentID,CourseID,InstructorID,Term)
values (2,4,3,'Spring2019')
insert into Enrolments (StudentID,CourseID,InstructorID,Term)
values (2,1,2,'Spring2018')
insert into Enrolments (StudentID,CourseID,InstructorID,Term)
values (2,1,1,'Fall2018')
insert into Enrolments (StudentID,CourseID,InstructorID,Term)
values (2,3,3,'Spring2019')
insert into Enrolments (StudentID,CourseID,InstructorID,Term)
values (3,1,2,'Spring2018')
insert into Enrolments (StudentID,CourseID,InstructorID,Term)
values (3,4,3,'Spring2018')
insert into Enrolments (StudentID,CourseID,InstructorID,Term)
values (3,5,3,'Fall2018')
insert into Enrolments (StudentID,CourseID,InstructorID)
values (1,1,1)

insert into EmailAccount (Username,Passkey) values ('ms01036@st.habib.edu.pk','haya123,./')

select * from Enrolments

select * from Students

select * from Courses

select * from Instructors

select * from Staff

select * from Users
