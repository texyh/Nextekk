CREATE TABLE [dbo].[Projects]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NULL, 
    [Description] VARCHAR(200) NULL, 
    [Status] INT NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    [ClientName] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Projects_Clients] FOREIGN KEY ([ClientName]) REFERENCES [Clients]([Name])
)
