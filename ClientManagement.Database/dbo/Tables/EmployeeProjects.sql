CREATE TABLE [dbo].[EmployeeProjects]
(
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL, 
    [ProjectId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_EmployeeProjects_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]), 
    CONSTRAINT [FK_EmployeeProjects_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]), 
    CONSTRAINT [PK_EmployeeProjects] PRIMARY KEY ([EmployeeId], [ProjectId])
)
