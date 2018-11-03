CREATE TABLE Instructors (
  InstructorsID INTEGER  NOT NULL   IDENTITY ,
  Name VARCHAR(50)      ,
PRIMARY KEY(InstructorsID));
GO




CREATE TABLE Items (
  ItemsID INTEGER  NOT NULL   IDENTITY ,
  Description VARCHAR(50)  NOT NULL  ,
  QuantityAvailable INTEGER  NOT NULL  ,
  QuantityBooked INTEGER  NOT NULL  ,
  Make VARCHAR(20)    ,
  Model VARCHAR(20)    ,
  Remarks VARCHAR(50)      ,
PRIMARY KEY(ItemsID));
GO




CREATE TABLE Students (
  StudentsID INTEGER  NOT NULL   IDENTITY ,
  HUID VARCHAR(7)  NOT NULL  ,
  FirstName VARCHAR(15)  NOT NULL  ,
  MiddleName VARCHAR(15)    ,
  LastName VARCHAR(15)    ,
  Contact VARCHAR(11)  NOT NULL    ,
PRIMARY KEY(StudentsID));
GO




CREATE TABLE Users (
  UserID INTEGER  NOT NULL   IDENTITY ,
  Name VARCHAR(20)    ,
  Passkey VARCHAR(20)  NOT NULL  ,
  isAdmin BIT  NOT NULL  ,
  Username INTEGER  NOT NULL    ,
PRIMARY KEY(UserID));
GO




CREATE TABLE Courses (
  CourseID INTEGER  NOT NULL   IDENTITY ,
  CourseName VARCHAR(50)    ,
  CourseCode VARCHAR(10)      ,
PRIMARY KEY(CourseID));
GO




CREATE TABLE Bookings (
  BookingsID INTEGER  NOT NULL   IDENTITY ,
  Studentss_StudentsID INTEGER  NOT NULL  ,
  UserID INTEGER  NOT NULL  ,
  IssueOn DATETIME  NOT NULL  ,
  DueOn DATETIME  NOT NULL  ,
  ReturnedOn DATETIME    ,
  BookedOn DATETIME  NOT NULL  ,
  OtherDetails VARCHAR(20)    ,
  Project VARCHAR(20)      ,
PRIMARY KEY(BookingsID)    ,
  FOREIGN KEY(Studentss_StudentsID)
    REFERENCES Students(StudentsID),
  FOREIGN KEY(UserID)
    REFERENCES Users(UserID));
GO


CREATE INDEX Booking_FKIndex1 ON Bookings (Studentss_StudentsID);
GO
CREATE INDEX Booking_FKIndex2 ON Bookings (UserID);
GO


CREATE INDEX IFK_Rel_04 ON Bookings (Studentss_StudentsID);
GO
CREATE INDEX IFK_Rel_05 ON Bookings (UserID);
GO


CREATE TABLE Enrolments (
  CourseID INTEGER  NOT NULL  ,
  Instructorss_InstructorsID INTEGER  NOT NULL  ,
  Studentss_StudentsID INTEGER  NOT NULL    ,
PRIMARY KEY(CourseID, Instructorss_InstructorsID, Studentss_StudentsID)      ,
  FOREIGN KEY(Studentss_StudentsID)
    REFERENCES Students(StudentsID),
  FOREIGN KEY(CourseID)
    REFERENCES Courses(CourseID),
  FOREIGN KEY(Instructorss_InstructorsID)
    REFERENCES Instructors(InstructorsID));
GO


CREATE INDEX Table_05_FKIndex1 ON Enrolments (Studentss_StudentsID);
GO
CREATE INDEX Table_05_FKIndex2 ON Enrolments (CourseID);
GO
CREATE INDEX Table_05_FKIndex3 ON Enrolments (Instructorss_InstructorsID);
GO


CREATE INDEX IFK_Rel_01 ON Enrolments (Studentss_StudentsID);
GO
CREATE INDEX IFK_Rel_02 ON Enrolments (CourseID);
GO
CREATE INDEX IFK_Rel_03 ON Enrolments (Instructorss_InstructorsID);
GO


CREATE TABLE BookedItems (
  Bookingss_BookingsID INTEGER  NOT NULL  ,
  Itemss_ItemsID INTEGER  NOT NULL    ,
PRIMARY KEY(Bookingss_BookingsID, Itemss_ItemsID)    ,
  FOREIGN KEY(Bookingss_BookingsID)
    REFERENCES Bookings(BookingsID),
  FOREIGN KEY(Itemss_ItemsID)
    REFERENCES Items(ItemsID));
GO


CREATE INDEX BookedItems_FKIndex1 ON BookedItems (Bookingss_BookingsID);
GO
CREATE INDEX BookedItems_FKIndex2 ON BookedItems (Itemss_ItemsID);
GO


CREATE INDEX IFK_Rel_06 ON BookedItems (Bookingss_BookingsID);
GO
CREATE INDEX IFK_Rel_07 ON BookedItems (Itemss_ItemsID);
GO



