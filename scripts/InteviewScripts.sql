/*Insertando datos en las tablas correspondientes */
USE InterviewDB
GO

-- Insertar 3 entrevistados en la tabla 'Interviewee'
INSERT INTO Interviewees
   ([FirstName], [LastName], [Email], [BirthDay])
VALUES
   (N'Alessandra', N'Quintero', N'alessandra@email.com', '2-7-1995'),
   (N'Miguel', N'Martinez', N'alessandra@email.com', '2-10-1998'),
   (N'Christian', N'Valencia', N'chritian@email.com', '9-12-1996')
GO

SELECT * FROM Interviewees
GO

-- Insertar 3 entrevistadores en la tabla 'Interviewers'
INSERT INTO Interviewers
   ([FirstName], [LastName], [Email], [BirthDay])
VALUES
   (N'Marcos', N'Gonzolez', N'marcos@empresa.com', '12-4-1990'),
   (N'Adriana', N'Villegas', N'adriana@empresa.com', '2-7-1992'),
   (N'Nestor', N'Bermudez', N'nestor@empresa.com', '9-12-1982')
GO

SELECT * FROM Interviewers
GO

-- Insertar 3 entrevistas en la tabla 'Interviews'
INSERT INTO Interviews
   ([Name], [Appointment], [IntervieweeId])
VALUES
   (N'Entrevista Fullstack', '8-20-2022', 1),
   (N'Entrevista Backend', '8-25-2022', 2),
   (N'Entrevista DevOps', '9-4-2022', 3)
GO

SELECT * FROM Interviews
GO

-- Insertar 4 registros en InterviewInterviewer para relacionar Interviews y Interviewers 
INSERT INTO InterviewInterviewer
   ([InterviewsId], [InterviewersId])
VALUES
   (1, 1),
   (1, 2),
   (2, 2),
   (2, 3),
   (3, 2),
   (3, 3)
GO

SELECT * FROM InterviewInterviewer
GO