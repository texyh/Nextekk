CREATE TABLE [dbo].[Employee]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [LastName] VARCHAR(50) NULL, 
    [FirstName] VARCHAR(50) NULL, 
    [Gender] INT NULL, 
    [ProjectId] UNIQUEIDENTIFIER NULL, 
    [ApplicationUserId] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_Employee_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_Employee_UserTable] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers]([Id])
)
