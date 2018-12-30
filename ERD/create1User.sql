insert into Users (Name, Passkey, isAdmin, Username)
values ('Shakaib Saleem','admin',1,'shakaib')

select * from Users

insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime)
values (1, 'note','Instructor','2018-12-30','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','18:00:00')

select * from Bookings

insert into Instructors (Name, Email,Contact)
values ('Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','03210321321')

select * from Instructors

insert into Staff (Name, Email,Contact)
values ('Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','03210321321')

select * from Staff

insert into Students (HUID,FirstName,MiddleName,LastName,Contact,Email)
values ('xx01234','FN','MN','LN','0','email')

select * from Students

insert into Courses (CourseName,CourseCode)
values ('course','crs101')

select * from Courses

insert into Enrolments (CourseID,StudentID,InstructorID,Term)
values (1,3,1,'Spring2019')

select * from Enrolments
