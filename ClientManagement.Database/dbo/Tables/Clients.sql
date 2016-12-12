CREATE TABLE [dbo].[Clients]
(
	[Id] UNIQUEIDENTIFIER NOT NULL , 
    [Name] VARCHAR(50) NULL, 
    [Address] VARCHAR(200) NOT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_Clients_Clientname] UNIQUE ([Name])
)
