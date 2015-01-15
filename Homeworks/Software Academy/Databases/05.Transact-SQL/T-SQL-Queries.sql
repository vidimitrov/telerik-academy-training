USE master
GO

CREATE DATABASE PersonsDatabase
GO

USE PersonsDatabase
GO

-- ===================================================================

-- 1. Create a database with two tables: 
-- Persons(Id(PK), FirstName, LastName, SSN) and 
-- Accounts(Id(PK), PersonId(FK), Balance). 
-- Insert few records for testing. Write a stored procedure that selects 
-- the full names of all persons.

-- ===================================================================

CREATE TABLE Persons(
  Id int IDENTITY NOT NULL,
  FirstName nvarchar(50) NOT NULL,
  LastName nvarchar(50) NOT NULL,
  SSN nvarchar(50) NOT NULL,
  CONSTRAINT PK_Persons PRIMARY KEY CLUSTERED(Id ASC)
)
GO

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Pesho', 'Ivanov', '123-52-9867')

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Georgi', 'Petrov', '153-13-9811')

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Qncho', 'Todorov', '523-44-9877')

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Petq', 'Kuzmanova', '313-59-9447')

GO

CREATE TABLE Accounts(
  Id int IDENTITY NOT NULL,
  PersonId int NOT NULL,
  Balance float NOT NULL,
  CONSTRAINT PK_Accounts PRIMARY KEY CLUSTERED(Id ASC),
  CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId)
  REFERENCES Persons(Id)
)
GO

INSERT INTO Accounts (PersonId, Balance)
VALUES (1, 123.21)

INSERT INTO Accounts (PersonId, Balance)
VALUES (2, 12223.21)

INSERT INTO Accounts (PersonId, Balance)
VALUES (3, 421123.21)

INSERT INTO Accounts (PersonId, Balance)
VALUES (4, 6123.21)

GO

CREATE PROC dbo.usp_FullNamesOfAllPersons
AS 
	SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance
	FROM Persons p INNER JOIN Accounts a 
	  ON p.Id = a.PersonId
GO

EXEC dbo.usp_FullNamesOfAllPersons

GO

-- ===================================================================

-- 2. Create a stored procedure that accepts a number as a parameter 
-- and returns all persons who have more money in their accounts than 
-- the supplied number.

-- ===================================================================

CREATE PROC dbo.usp_GetAllPersonsWithMoneyCondition(
	@money float = 0
) 
AS
	SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance
	FROM Persons p INNER JOIN Accounts a 
	  ON p.Id = a.PersonId
	  WHERE a.Balance > @money
GO

EXEC dbo.usp_GetAllPersonsWithMoneyCondition 40000.00

GO

-- ===================================================================

-- 3. Create a function that accepts as parameters – sum, yearly interest 
-- rate and number of months. It should calculate and return the new sum. 
-- Write a SELECT to test whether the function works as expected.

-- ===================================================================

CREATE FUNCTION BalanceWithInterest (@sum money, @months int, @yearlyRate float)
	RETURNS money
AS
	BEGIN
		RETURN @sum * (1 + ((@yearlyRate / 100.0) / 12.0) * @months);
	END
GO

SELECT dbo.BalanceWithInterest(1000, 50, 101) AS Result
GO

-- ==========================================================================

-- 4. Create a stored procedure that uses the function from the previous example
-- to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.

-- ==========================================================================

CREATE PROC AddInterestForOneMonth(@accountID int, @yearlyRate float)
AS
    UPDATE Accounts
    SET Balance = dbo.BalanceWithInterest(Balance, @yearlyRate, 1)
    WHERE Id = @accountID;
GO

EXEC AddInterestForOneMonth 2, 123.90

GO

-- ==========================================================================

-- 5. Add two more stored procedures:
-- WithdrawMoney(AccountId, money) and DepositMoney (AccountId, money) 
-- that operate in transactions.

-- ==========================================================================

CREATE PROCEDURE WithdrawMoney(@accountID int, @money money)
AS
    DECLARE @currentBalance money;
    SELECT @currentBalance = Balance FROM Accounts
        WHERE Id = @accountID;

    BEGIN TRAN
        UPDATE Accounts
        SET Balance -= @money
        WHERE Id = @accountID

        IF (@money < 0)
            BEGIN
                RAISERROR('Cannot withdraw negative amount of money!', 15, 1);
                ROLLBACK TRAN;
                RETURN;
            END
        ELSE IF (@currentBalance < @money)
            BEGIN
                RAISERROR('Insufficient balance for withdrawal!', 15, 1);
                ROLLBACK TRAN;
                RETURN;
            END
        ELSE
            COMMIT TRAN
GO

CREATE PROCEDURE DepositMoney(@accountID int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance += @money
        WHERE Id = @accountID

        IF (@money < 0)
            BEGIN
                RAISERROR('Cannot deposit negative amount of money!', 15, 1);
                ROLLBACK TRAN;
                RETURN;
            END
        ELSE
            COMMIT TRAN
GO

EXEC DepositMoney 2, 150
SELECT * FROM Accounts WHERE Id = 2;

GO