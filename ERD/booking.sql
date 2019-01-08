
DBCC CHECKIDENT (Bookings, RESEED, 0);

select * from Students where HabibID = 'ms01036'

select HabibID,Name,Email,Contact from Instructors where InstructorID = 1

select Name from Instructors order by Name

select HabibID from Students order by HabibID

select CourseName from Courses order by CourseName

delete from Students where StudentID >2

delete from Equipments where EquipmentID > 0

insert into Instructors (Name, Email,Contact) values ('Aaron Mulvany','aaron.mulvany@ahss.habib.edu.pk','03210321321')

select * from Instructors

insert into BookingsByStudents (BookingID,EnrolmentID,Project) values (1,2,'ProjectX')

delete from Bookings where BookingID = 0

delete from BookingsByStudents where BookingID = 2

select * from BookingsByStudents

insert into BookingsByInstructors (InstructorID,BookingID) values (1,11)

delete from BookingsByInstructors where BookingID = 55

update BookingsByInstructors set InstructorID = 2 where BookingID = 53

select * from BookingsByInstructors

select InstructorID from BookingsByInstructors where BookingID = 9

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

delete from Bookings where BookingID = 21

insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime)
values (1, 'Note','Instructor','2018-12-30','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','18:00:00')

select UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime
from Bookings
where BookingID = 1

select * from (SELECT LAG(BookingID) OVER (ORDER BY BookingID) PreviousValue, BookingID FROM Bookings) as newtable
where newtable.BookingID = 1

select * from (SELECT LEAD(BookingID) OVER (ORDER BY BookingID) NextValue, BookingID FROM Bookings) as newtable
WHERE newtable.BookingID = 25

insert into Bookings (UserID,Notes,BookedBy,BookingDate,BookingTime,IssueDate,IssueTime,DueDate,DueTime,ReturnDate,ReturnTime,OffCampus)
values (1, 'Note','Instructor','2018-12-30','11:1:2','2018-12-29','12:00:00','2018-12-30','09:00:00','2018-12-30','09:00:00',1)

update Bookings set ReturnDate = NULL where BookingID = 2

select * from Bookings

select Bookings.BookingID,Description,Quantity as QuantityIssued,IssueDate,ReturnDate,DueDate,QuantityAvailable,BookedBy,Notes
from Equipments, BookedItems, Bookings
where Equipments.EquipmentID=BookedItems.EquipmentID
and BookedItems.BookingID = Bookings.BookingID
and Equipments.EquipmentID = 17

select Bookings.BookingID,CourseName,IssueDate,ReturnDate,DueDate,Project
from Courses,Enrolments,BookingsByStudents,Bookings
where Courses.CourseID=Enrolments.CourseID
and Enrolments.EnrolmentID=BookingsByStudents.EnrolmentID
and BookingsByStudents.BookingID=Bookings.BookingID
and CourseName = 'Course'

select BookingID,IssueDate,ReturnDate,DueDate,BookedBy,Notes  from Bookings 
where IssueDate >= '2019-01-03' and IssueDate <= '2019-01-03'
or ReturnDate = '2019-01-04'
or DueDate = '2019-01-05'

select Description from Equipments order by Description

select UserID,Name,Username,Passkey,isAdmin from Users where UserID = 2

select * from Equipments

select * from BookedItems

select * from Bookings

select * from BookingsByStudents

select * from BookingsByInstructors

select * from BookingsByStaff

select Bookings.BookingID,HabibID,IssueDate,ReturnDate,DueDate
from Bookings, BookingsByStudents, Enrolments, Students
where Bookings.BookingID=BookingsByStudents.BookingID
and BookingsByStudents.EnrolmentID=Enrolments.EnrolmentID
and Enrolments.StudentID=Students.StudentID
and HabibID = 'ms01036'

select Bookings.BookingID,Name,IssueDate,ReturnDate,DueDate,HabibID  from Bookings, BookingsByStudents, Enrolments, Students where Bookings.BookingID = BookingsByStudents.BookingID and BookingsByStudents.EnrolmentID = Enrolments.EnrolmentID and Enrolments.StudentID = Students.StudentID and Students.StudentID = 1
order by Bookings.BookingID desc

delete from Bookings where BookingID = 84

delete from BookedItems where BookingID = 84

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
values ('ab',10,0)

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

select * from Bookings

select * from BookingsByStudents

select * from Enrolments

select * from Students

select * from Courses

select * from Instructors

select Enrolments.EnrolmentID,Project,Term,Students.StudentID,Students.HabibID,Students.Name,Students.Email,Students.Contact,Courses.CourseID,Courses.CourseName,Courses.CourseCode,Instructors.InstructorID,Instructors.HabibID,Instructors.Name,Instructors.Email,Instructors.Contact from BookingsByStudents, Enrolments, Students, Courses, Instructors where BookingsByStudents.BookingID = 74 and BookingsByStudents.EnrolmentID = Enrolments.EnrolmentID and Enrolments.StudentID = Students.StudentID and Enrolments.CourseID = Courses.CourseID and Enrolments.InstructorID = Instructors.InstructorID

select Description,Quantity from BookedItems,Equipments where BookedItems.EquipmentID = Equipments.EquipmentID and BookingID = 14

ALTER TABLE Bookings
ADD OffCampus Bit