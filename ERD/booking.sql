
select * from BookingsByInstructors where BookingID = 2

insert into Instructors (Name, Email,Contact)
values ('Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','03210321321')

select * from Instructors

insert into BookingsByInstructors (InstructorID,BookingID)
values (1,11)

delete from BookingsByInstructors where BookingID = 11

select * from BookingsByInstructors

select * from Bookings

insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime)
values (1, 'note','Instructor','2018-12-30','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','08:00:00')

select * from Bookings

select top 1 BookingID from Bookings order by BookingID desc

select * from Bookings where BookingDate = '2018-12-29'

select BookingTime from Bookings where BookingTime = '11:1:2'

delete from Bookings where BookingDate = '2018-12-30'
