SELECT c.CourseId, c.Name, f.FacultyName FROM courses c JOIN Faculties f ON c.FacultyId = f.FacultyId;
SELECT * FROM courses;
SELECT * FROM Faculties;
SELECT c.*, f.FacultyName AS facultyName FROM courses c JOIN Faculties f ON c.FacultyId = f.FacultyId