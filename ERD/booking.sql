
insert into Instructors (Name, Email,Contact) values ('Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','03210321321')

select * from Instructors

insert into BookingsByStudents (BookingID,EnrolmentID,Project) values (1,2,'ProjectX')

delete from BookingsByStudents where EnrolmentID = 2

delete from BookingsByStudents where BookingID = 2

select * from BookingsByStudents

insert into BookingsByInstructors (InstructorID,BookingID) values (1,11)

delete from BookingsByInstructors where BookingID = 55

update BookingsByInstructors set InstructorID = 2 where BookingID = 53

select * from BookingsByInstructors

select top 1 BookingID from Bookings order by BookingID desc

update Bookings set BookedBy = 'Instructor' where BookingID = 43

update Bookings set
UserID = 2,
Notes = 'none',
BookedBy = 'Instructor',
BookingDate = '2019-01-01',
BookingTime = '22:32:00',
IssueDate = '2019-01-01',
IssueTime = '22:32:00',
DueDate = '2019-01-01',
DueTime = '22:32:00',
ReturnDate = '2019-01-01',
ReturnTime = '22:32:00'
where BookingID = 1

delete from Bookings where BookingID = 19

insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime)
values (1, 'Note','Instructor','2018-12-30','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','18:00:00')

select * from Bookings

select * from BookingsByStudents

select * from BookingsByStaff

select * from BookingsByInstructors

delete from BookedItems where BookingID = 1

insert into BookedItems (BookingID,EquipmentID,Quantity)
values (1,1,1)

select EquipmentID from BookedItems where BookingID = 6

select Quantity,QuantityAvailable,QuantityBooked from BookedItems,Equipments
where BookingID = 2 and BookedItems.EquipmentID = 3
and BookedItems.EquipmentID = Equipments.EquipmentID

update BookedItems set Quantity = 1 where BookingID = 1 and EquipmentID = 2

select * from BookedItems

select * from Equipments

update Equipments set
QuantityBooked = 0,
QuantityAvailable = 3
where EquipmentID = 1

insert into Equipments (Description,QuantityAvailable,QuantityBooked)
values ('c',3,0)

select EquipmentID,QuantityAvailable,QuantityBooked from Equipments where Description = 'Camera'

select * from Equipments

select HabibID from Students

select StudentID,HabibID,Name,Email,Contact from Students where HabibID = 'ms01036'

select Courses.CourseID as id, Courses.CourseName as name, Courses.CourseCode as code, EnrolmentID, Enrolments.CourseID,StudentID,InstructorID,Term
from Courses, Enrolments where Courses.CourseID=Enrolments.CourseID and StudentID = 2

select distinct CourseName from Courses, Enrolments where Courses.CourseID=Enrolments.CourseID and StudentID = 2

select Instructors.Name from Courses, Enrolments, Instructors
where Courses.CourseID=Enrolments.CourseID and Instructors.InstructorID=Enrolments.InstructorID
and StudentID = 2 and Enrolments.CourseID=3

select InstructorID,HabibID,Name,Email,Contact from Instructors where Name = 'Fname Lname'

select EnrolmentID,Term from Enrolments
where CourseID=3 and StudentID=2 and InstructorID=2