CREATE DATABASE ExampleDB;

USE ExampleDb;

CREATE TABLE Student (
	StudentID int NOT NULL AUTO_INCREMENT,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	PRIMARY KEY (StudentID)
);

CREATE TABLE Lecturer (
	LecturerID int NOT NULL AUTO_INCREMENT,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	PRIMARY KEY (LecturerID)
);

CREATE TABLE Course (
	CourseID int NOT NULL AUTO_INCREMENT,
	Name varchar(50) NOT NULL,
	PRIMARY KEY (CourseID)
);

CREATE TABLE Teaching (
	TeachingID int NOT NULL AUTO_INCREMENT,
	LecturerID int NOT NULL,
	CourseID int NOT NULL,
	PRIMARY KEY (TeachingID),
	FOREIGN KEY (LecturerID) REFERENCES Lecturer(LecturerID),
	FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

CREATE TABLE Enrolment (
	EnrolmentID int NOT NULL AUTO_INCREMENT,
	StudentID int NOT NULL,
	CourseID int NOT NULL,
	PRIMARY KEY (EnrolmentID),
	FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

INSERT INTO Course (Name) VALUES
('Access to HE Diploma in Computing'),
('BSc (Hons) Applied Computer Science'),
('Computing - Level 1 Diploma'),
('Computing - Level 2 Diploma'),
('Computing - Level 3 Extended Diploma'),
('Computing - Digital Support Services - T Level - Level 3'),
('Games Design - Level 3 Extended Diploma'),
('Microsoft Office Specialist - Excel'),
('Microsoft Office Specialist - Powerpoint'), 
('Microsoft Office Specialist - Word');

INSERT INTO Student (FirstName, LastName) VALUES
('Enid', 'Ward'),
('Donna', 'Amos'),
('Amar', 'Whiting'),
('Jay', 'Rudd'),
('William', 'Rogers'),
('Nichola', 'Richmond'),
('Abigail', 'Worrall'),
('Joan', 'Ridley'),
('Lydia', 'Forster'),
('Loretta', 'Alcock'),
('Laura', 'Carroll'),
('Suresh', 'Bishop'),
('Nathan', 'Lawton'),
('Gerard', 'Sullivan'),
('Ron', 'Beckett'),
('Nikki', 'Hubbard'),
('Bernice', 'Evans'),
('Cecil', 'Patel'),
('Doris', 'Brien'),
('Elsie', 'Neale'),
('Clair', 'Oldham'),
('Shamim', 'Butterfield'),
('Nana', 'Hayward'),
('Tessa', 'Newton'),
('Jacqui', 'Prior');

INSERT INTO Lecturer (FirstName, LastName) VALUES
('Christopher', 'Sherwood'),
('Bethany', 'Hampton'),
('Pauline', 'Hopkins'),
('Vivian', 'Shaw'),
('Clifford', 'Bannister'),
('Rowena', 'Thornton'),
('Shona', 'Rudd'),
('Jemma', 'Marks'),
('Reginald', 'McKenzie'),
('Mario', 'Bassett');

INSERT INTO Enrolment(StudentID, CourseID) VALUES
('1', '8'),
('2', '4'),
('3', '4'),
('4', '6'), ('4', '9'),
('5', '6'), ('5', '10'),
('6', '8'),
('7', '8'),
('8', '9'), ('8', '10'),
('9', '7'), ('9', '10'),
('10', '5'),
('11', '3'), ('11', '9'),
('12', '4'), ('12', '9'),
('13', '1'), ('13', '8'),
('14', '5'), ('14', '9'),
('15', '1'), ('15', '9'),
('16', '8'),
('17', '8'), ('17', '10'),
('18', '3'),
('19', '8'),
('20', '9'),
('21', '6'),
('22', '7'),
('23', '2'), ('23', '10'),
('24', '9'),
('25', '2');

INSERT INTO Teaching (LecturerID, CourseID) VALUES
('1', '10'), ('1', '4'),
('2', '7'), ('2', '4'),
('3', '3'), ('3', '10'),
('4', '9'), ('4', '3'), ('4', '8'),
('5', '8'), ('5', '5'), ('5', '1'),
('6', '3'),
('7', '2'), ('7', '10'),
('8', '6'), ('8', '8'),
('9', '1'),
('10', '6'), ('10', '1'), ('10', '10');
