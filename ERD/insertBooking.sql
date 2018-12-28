
insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime)
values (1, 'note','Student','2018-12-29','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','08:00:00')

select * from Bookings

select * from Bookings where BookingDate = '2018-12-29'

select BookingTime from Bookings where BookingTime = '11:1:2'

delete from Bookings where BookingDate = '2018-12-29'