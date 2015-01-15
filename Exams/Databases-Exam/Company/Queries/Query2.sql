USE Company 
GO

-- 2. Get all departments and how many employees there are in each one. 
--    Sort the result by the number of employees in descending order.

SELECT d.Name, 
	(SELECT COUNT(*) 
	 FROM Employees e
	 WHERE e.DepartmentId = d.Id
	 ) AS [Employees count]
FROM Departments d
ORDER BY [Employees count] DESC

GO