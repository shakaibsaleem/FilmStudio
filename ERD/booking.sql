
select * from BookingsByInstructors where BookingID = 2

insert into Instructors (Name, Email,Contact)
values ('Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','03210321321')

select * from Instructors

insert into BookingsByStudents (BookingID,EnrolmentID,Project)
values (2,2,'ProjectX')

insert into BookingsByInstructors (InstructorID,BookingID)
values (1,11)

delete from Bookings where BookingID = 19

select * from BookingsByInstructors

select * from Bookings

insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime)
values (1, 'note','Instructor','2018-12-30','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','18:00:00')

select * from Bookings

select top 1 BookingID from Bookings order by BookingID desc

select * from Bookings where BookingDate = '2018-12-29'

select BookingTime from Bookings where BookingTime = '11:1:2'

delete from Bookings where BookingDate = '2018-12-30'

select * from Bookings

select * from BookingsByStaff

select * from BookingsByInstructors

select * from BookingsByStudents

