insert into Users (Name,Username,Passkey,isAdmin)
values ('new user','newuser','new',0)

select * from Users

update Users set Name = '',Username = '',Passkey = '',isAdmin = 1 where UserID = 5

select UserID,Name,Username,Passkey,isAdmin from Users where Username = 'adssada'

select * from Users

update Bookings set UserID = 2 where UserID = 1

select * from Bookings
select * from Users

delete from Users where UserID >4