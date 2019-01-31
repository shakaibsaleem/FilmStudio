CREATE TABLE Instructors (
  InstructorID INTEGER  NOT NULL   IDENTITY ,
  HabibID VARCHAR(50)  NOT NULL  ,
  Name VARCHAR(50)    ,
  Email VARCHAR(100)  NOT NULL  ,
  Contact VARCHAR(20)      ,
PRIMARY KEY(InstructorID));
GO




CREATE TABLE Equipments (
  EquipmentID INTEGER  NOT NULL   IDENTITY ,
  Description VARCHAR(100)  NOT NULL  ,
  QuantityTotal INTEGER  NOT NULL  ,
  Remarks VARCHAR(50)      ,
PRIMARY KEY(EquipmentID));
GO




CREATE TABLE EmailAccount (
  EmailAccountID INTEGER  NOT NULL   IDENTITY ,
  Username VARCHAR(100)  NOT NULL  ,
  Passkey VARCHAR(50)  NOT NULL    ,
PRIMARY KEY(EmailAccountID));
GO




CREATE TABLE Users (
  UserID INTEGER  NOT NULL   IDENTITY ,
  Name VARCHAR(20)    ,
  Username VARCHAR(20)  NOT NULL  ,
  Passkey VARCHAR(20)  NOT NULL  ,
  isAdmin BIT  NOT NULL    ,
PRIMARY KEY(UserID));
GO




CREATE TABLE Students (
  StudentID INTEGER  NOT NULL   IDENTITY ,
  HabibID VARCHAR(7)  NOT NULL  ,
  Name VARCHAR(50)    ,
  Email VARCHAR(23)  NOT NULL  ,
  Contact VARCHAR(20)      ,
PRIMARY KEY(StudentID));
GO




CREATE TABLE Staff (
  StaffID INTEGER  NOT NULL   IDENTITY ,
  HabibID VARCHAR(50)  NOT NULL  ,
  Name VARCHAR(50)    ,
  Email VARCHAR(100)  NOT NULL  ,
  Contact VARCHAR(20)      ,
PRIMARY KEY(StaffID));
GO




CREATE TABLE Courses (
  CourseID INTEGER  NOT NULL   IDENTITY ,
  CourseName VARCHAR(50)    ,
  CourseCode VARCHAR(15)      ,
PRIMARY KEY(CourseID));
GO




CREATE TABLE Bookings (
  BookingID INTEGER  NOT NULL   IDENTITY ,
  UserID INTEGER  NOT NULL  ,
  Notes VARCHAR(50)    ,
  BookedBy VARCHAR(10)  NOT NULL  ,
  OffCampus BIT    ,
  BookingDate DATE  NOT NULL  ,
  BookingTime TIME  NOT NULL  ,
  IssueDate DATE    ,
  IssueTime TIME    ,
  DueDate DATE  NOT NULL  ,
  DueTime TIME  NOT NULL  ,
  ReturnDate DATE    ,
  ReturnTime TIME      ,
PRIMARY KEY(BookingID)  ,
  FOREIGN KEY(UserID)
    REFERENCES Users(UserID));
GO


CREATE INDEX Bookings_FKIndex1 ON Bookings (UserID);
GO


CREATE INDEX IFK_Rel_11 ON Bookings (UserID);
GO


CREATE TABLE BookingsByInstructors (
  BookingID INTEGER  NOT NULL  ,
  InstructorID INTEGER  NOT NULL    ,
PRIMARY KEY(BookingID, InstructorID)    ,
  FOREIGN KEY(BookingID)
    REFERENCES Bookings(BookingID),
  FOREIGN KEY(InstructorID)
    REFERENCES Instructors(InstructorID));
GO


CREATE INDEX Table_11_FKIndex1 ON BookingsByInstructors (BookingID);
GO
CREATE INDEX Table_11_FKIndex2 ON BookingsByInstructors (InstructorID);
GO


CREATE INDEX IFK_Rel_13 ON BookingsByInstructors (BookingID);
GO
CREATE INDEX IFK_Rel_14 ON BookingsByInstructors (InstructorID);
GO


CREATE TABLE BookedItems (
  BookingID INTEGER  NOT NULL  ,
  EquipmentID INTEGER  NOT NULL  ,
  QuantityBooked INTEGER  NOT NULL    ,
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


CREATE TABLE BookingsByStaff (
  BookingID INTEGER  NOT NULL  ,
  StaffID INTEGER  NOT NULL    ,
PRIMARY KEY(BookingID, StaffID)    ,
  FOREIGN KEY(StaffID)
    REFERENCES Staff(StaffID),
  FOREIGN KEY(BookingID)
    REFERENCES Bookings(BookingID));
GO


CREATE INDEX Table_12_FKIndex1 ON BookingsByStaff (StaffID);
GO
CREATE INDEX Table_12_FKIndex2 ON BookingsByStaff (BookingID);
GO


CREATE INDEX IFK_Rel_15 ON BookingsByStaff (StaffID);
GO
CREATE INDEX IFK_Rel_16 ON BookingsByStaff (BookingID);
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


CREATE TABLE BookingsByStudents (
  BookingID INTEGER  NOT NULL  ,
  EnrolmentID INTEGER  NOT NULL  ,
  Project VARCHAR(200)      ,
PRIMARY KEY(BookingID, EnrolmentID)    ,
  FOREIGN KEY(EnrolmentID)
    REFERENCES Enrolments(EnrolmentID),
  FOREIGN KEY(BookingID)
    REFERENCES Bookings(BookingID));
GO


CREATE INDEX Table_10_FKIndex1 ON BookingsByStudents (EnrolmentID);
GO
CREATE INDEX Table_10_FKIndex2 ON BookingsByStudents (BookingID);
GO


CREATE INDEX IFK_Rel_11 ON BookingsByStudents (EnrolmentID);
GO
CREATE INDEX IFK_Rel_12 ON BookingsByStudents (BookingID);
GO



