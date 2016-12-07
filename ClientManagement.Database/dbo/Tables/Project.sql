CREATE TABLE [dbo].[Project]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NULL, 
    [Description] VARCHAR(200) NULL, 
    [Status] INT NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    [EmployeeId] UNIQUEIDENTIFIER NULL, 
    [ClientId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_Project_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_Project_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
)
