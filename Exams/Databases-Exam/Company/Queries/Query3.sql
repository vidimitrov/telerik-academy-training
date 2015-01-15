USE Company 
GO

-- 3. Get each employee’s full name (first name + “ “ + last name), project’s name, department’s name, 
--    starting and ending date for each employee in project. 
--    Additionally get the number of all reports, which time of reporting is between the start and end date. 
--    Sort the results first by the employee id, then by the project id. (This query is slow, be patient!)

SELECT e.FirstName + ' ' + e.LastName AS [Full Name],
 p.Name AS [Project Name], d.Name AS [Department Name], 
 ep.StartingDate, ep.EndingDate, 
 (SELECT COUNT(*) FROM Reports r WHERE r.ReportingDate BETWEEN ep.StartingDate AND ep.EndingDate) AS [Reports in interval]
FROM Employees e
INNER JOIN EmployeesProjects ep
	ON e.Id = ep.EmployeeId
INNER JOIN Projects p
	ON p.Id = ep.ProjectId
INNER JOIN Departments d
	ON e.DepartmentId = d.Id
ORDER BY e.Id, p.Id


GO