
insert into Instructors (Name, Email,Contact) values ('Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','03210321321')

select * from Instructors

insert into BookingsByStudents (BookingID,EnrolmentID,Project) values (2,2,'ProjectX')

delete from BookingsByStudents where BookingID = 55

select * from BookingsByStudents

insert into BookingsByInstructors (InstructorID,BookingID) values (1,11)

delete from BookingsByInstructors where BookingID = 55

update BookingsByInstructors set InstructorID = 2 where BookingID = 53

select * from BookingsByInstructors

select top 1 BookingID from Bookings order by BookingID desc

update Bookings set BookedBy = 'Instructor' where BookingID = 43

delete from Bookings where BookingID = 19

insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime)
values (1, 'note','Instructor','2018-12-30','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','18:00:00')

select * from Bookings

select * from BookingsByStudents

select * from BookingsByStaff

select * from BookingsByInstructors

