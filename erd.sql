CREATE TABLE Equipments (
  EquipmentID INTEGER  NOT NULL   IDENTITY ,
  Description VARCHAR(50)    ,
  QuantityAvailable INTEGER  NOT NULL  ,
  QuantityBooked INTEGER  NOT NULL  ,
  Make VARCHAR(20)    ,
  Model VARCHAR(20)    ,
  Remarks VARCHAR(50)      ,
PRIMARY KEY(EquipmentID));
GO




CREATE TABLE Instructors (
  InstructorID INTEGER  NOT NULL   IDENTITY ,
  Name VARCHAR(50)      ,
PRIMARY KEY(InstructorID));
GO




CREATE TABLE Students (
  StudentID INTEGER  NOT NULL   IDENTITY ,
  HUID VARCHAR(7)  NOT NULL  ,
  FirstName VARCHAR(15)  NOT NULL  ,
  MiddleName VARCHAR(15)    ,
  LastName VARCHAR(15)    ,
  Contact VARCHAR(12)  NOT NULL    ,
PRIMARY KEY(StudentID));
GO




CREATE TABLE Users (
  UserID INTEGER  NOT NULL   IDENTITY ,
  Name VARCHAR(20)    ,
  Username VARCHAR(20)  NOT NULL  ,
  Passkey VARCHAR(20)  NOT NULL  ,
  isAdmin BIT  NOT NULL    ,
PRIMARY KEY(UserID));
GO




CREATE TABLE Courses (
  CourseID INTEGER  NOT NULL   IDENTITY ,
  CourseName VARCHAR(50)    ,
  CourseCode VARCHAR(15)      ,
PRIMARY KEY(CourseID));
GO




CREATE TABLE Enrolments (
  EnrolmentID INTEGER  NOT NULL   IDENTITY ,
  CourseID INTEGER  NOT NULL  ,
  StudentID INTEGER  NOT NULL  ,
  InstructorID INTEGER  NOT NULL  ,
  Term VARCHAR(10)      ,
PRIMARY KEY(EnrolmentID)      ,
  FOREIGN KEY(CourseID)
    REFERENCES Courses(CourseID),
  FOREIGN KEY(StudentID)
    REFERENCES Students(StudentID),
  FOREIGN KEY(InstructorID)
    REFERENCES Instructors(InstructorID));
GO


CREATE INDEX Enrolments_FKIndex1 ON Enrolments (CourseID);
GO
CREATE INDEX Enrolments_FKIndex2 ON Enrolments (StudentID);
GO
CREATE INDEX Enrolments_FKIndex3 ON Enrolments (InstructorID);
GO


CREATE INDEX IFK_Rel_08 ON Enrolments (CourseID);
GO
CREATE INDEX IFK_Rel_09 ON Enrolments (StudentID);
GO
CREATE INDEX IFK_Rel_10 ON Enrolments (InstructorID);
GO


CREATE TABLE Bookings (
  BookingID INTEGER  NOT NULL   IDENTITY ,
  EnrolmentID INTEGER  NOT NULL  ,
  UserID INTEGER  NOT NULL  ,
  IssuedOn DATETIME    ,
  DueOn DATETIME  NOT NULL  ,
  ReturnedOn DATETIME    ,
  BookedOn DATETIME  NOT NULL  ,
  Notes VARCHAR(50)    ,
  Project VARCHAR(20)      ,
PRIMARY KEY(BookingID)    ,
  FOREIGN KEY(UserID)
    REFERENCES Users(UserID),
  FOREIGN KEY(EnrolmentID)
    REFERENCES Enrolments(EnrolmentID));
GO


CREATE INDEX Bookings_FKIndex1 ON Bookings (UserID);
GO
CREATE INDEX Bookings_FKIndex2 ON Bookings (EnrolmentID);
GO


CREATE INDEX IFK_Rel_11 ON Bookings (UserID);
GO
CREATE INDEX IFK_Rel_12 ON Bookings (EnrolmentID);
GO


CREATE TABLE BookedItems (
  BookingID INTEGER  NOT NULL  ,
  EquipmentID INTEGER  NOT NULL  ,
  Quantity INTEGER  NOT NULL    ,
PRIMARY KEY(BookingID, EquipmentID)    ,
  FOREIGN KEY(BookingID)
    REFERENCES Bookings(BookingID),
  FOREIGN KEY(EquipmentID)
    REFERENCES Equipments(EquipmentID));
GO


CREATE INDEX BookedItems_FKIndex1 ON BookedItems (BookingID);
GO
CREATE INDEX BookedItems_FKIndex2 ON BookedItems (EquipmentID);
GO


CREATE INDEX IFK_Rel_06 ON BookedItems (BookingID);
GO
CREATE INDEX IFK_Rel_07 ON BookedItems (EquipmentID);
GO



