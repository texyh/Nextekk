CREATE TABLE [dbo].[Employees]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [LastName] VARCHAR(50) NULL, 
    [FirstName] VARCHAR(50) NULL, 
    [Gender] INT NULL, 
    [ApplicationUserId] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_Employees_Aspnetusers] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers]([Id])
)
