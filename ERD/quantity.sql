
--select EquipmentID,Quantity,IssueDate,DueDate from BookedItems, Bookings where Bookings.BookingID = BookedItems.BookingID and BookedItems.EquipmentID = 14

--select EquipmentID,sum(Quantity) from
--(select EquipmentID,Quantity,IssueDate,DueDate,ReturnDate from BookedItems, Bookings where Bookings.BookingID = BookedItems.BookingID) as Quantities
--where (IssueDate < '2019-01-10' and (IssueDate > '2019-01-09' or (ReturnDate is NULL or ReturnDate > '2019-01-09')))
--group by EquipmentID

--select sum(Quantity) from
--(select EquipmentID,Quantity,IssueDate,DueDate,ReturnDate from BookedItems, Bookings where Bookings.BookingID = BookedItems.BookingID) as Quantities
--where EquipmentID = 14
--and (IssueDate < '2019-01-10' and (IssueDate > '2019-01-09' or (ReturnDate is NULL or ReturnDate > '2019-01-09')))


select * from Equipments

select * from BookedItems

select * from Bookings

--where ReturnDate is not NULL

--update Bookings set ReturnDate = NULL where BookingID = 4

--update Equipments set QuantityAvailable = 4
--update Equipments set QuantityBooked = 0

--select * from Bookings, BookedItems where (IssueDate < '2019-01-10' and (IssueDate > '2019-01-09' or (ReturnDate is NULL or ReturnDate > '2019-01-09')))

select Bookings.BookingID,EquipmentID,Quantity,IssueDate,IssueTime,DueDate,Duetime
from BookedItems, Bookings 
where Bookings.BookingID = BookedItems.BookingID 
and IssueDate <= '2019-01-16' and DueDate >= '2019-01-10'
and EquipmentID = 3
