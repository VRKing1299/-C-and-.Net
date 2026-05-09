-- 1) Users
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE NOT NULL,
    UserPassword VARCHAR(255) NOT NULL,
    UserRole VARCHAR(20) NOT NULL, -- student / instructor / admin
    CreatedAt DATETIME DEFAULT GETDATE()
);

--2)categpries
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100)
);

--3)Coursers
CREATE TABLE Courses (
    Id INT PRIMARY KEY IDENTITY(1,1),
	ImgLink VARCHAR(200),
    Title VARCHAR(200),
    Description VARCHAR(MAX),
    Price DECIMAL(10,2),
    CategoryId INT,
    InstructorId INT,
    
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (InstructorId) REFERENCES Users(Id)
);

--ALTER TABLE Courses
--ADD ImgLink VARCHAR(200);

--4)cart
CREATE TABLE Cart (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    CourseId INT,

    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

--5)Enrollment
-- 5) Enrollment
CREATE TABLE Enrollment (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    CourseId INT,
	Price DECIMAL(10,2),
	Status VARCHAR(20) DEFAULT 'Pending',
    EnrolledDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

-- 6) Invoice
CREATE TABLE Invoice (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    TotalAmount DECIMAL(10,2),
    InvoiceDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- 7) InvoiceItems
CREATE TABLE InvoiceItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    InvoiceId INT,
    CourseId INT,
    Price DECIMAL(10,2),
    FOREIGN KEY (InvoiceId) REFERENCES Invoice(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

--6)payment
--CREATE TABLE Payment (
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    UserId INT,
--    Amount DECIMAL(10,2),
--    Method VARCHAR(20), -- Debit / Credit
--    PaymentDate DATETIME DEFAULT GETDATE(),
--    FOREIGN KEY (UserId) REFERENCES Users(Id)
--);

--DROP TABLE Payment

--7)Invoice

--drop table Invoice

--CREATE TABLE InvoiceItems (
--	UserId INT,
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    InvoiceId INT NOT NULL,
--    CourseId  INT NOT NULL,
--    Price     DECIMAL(10,2) NOT NULL,
--    FOREIGN KEY (InvoiceId) REFERENCES Invoice(Id),
--    FOREIGN KEY (CourseId)  REFERENCES Courses(Id),
--	FOREIGN KEY (UserId) REFERENCES Users(Id)
--);







-- inset data in users
INSERT INTO Users (UserName, Email, UserPassword, UserRole)
VALUES 
('John Instructor', 'john@gmail.com', '123456', 'instructor'),
('Alice Student', 'alice@gmail.com', '123456', 'student'),
('admin', 'admin@a.com','123','admin');

--inser data in categories
INSERT INTO Categories (Name)
VALUES 
('Web Development'),
('Backend');

--insert data into courses
INSERT INTO Courses (Title, Description, Price, CategoryId, InstructorId)
VALUES
('HTML Basics', 'Learn structure of web pages using HTML', 999, 1, 1),
('CSS Fundamentals', 'Learn styling using CSS', 1999, 1, 1),
('JavaScript Essentials', 'Learn JS for interactivity', 1499, 1, 1);

INSERT INTO Courses (Title, Description, Price, CategoryId, InstructorId)
VALUES
('Java Backend Development', 'Learn backend using Java', 1999, 2, 1),
('Python Backend Development', 'Learn backend using Python', 1999, 2, 1);

--cart
INSERT INTO Cart (UserId, CourseId)
VALUES 
(2, 1),
(2, 4);

--Enrollment
INSERT INTO Enrollment (UserId, CourseId)
VALUES
(2, 1),
(2, 4);

--invoice
INSERT INTO Invoice (UserId, TotalAmount)
VALUES
(2, 2998);

--payment
INSERT INTO Payment (UserId, Amount, Method)
VALUES
(2, 2998, 'Debit Card');