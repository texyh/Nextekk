/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO AspNetRoles(Id, [Name])
VALUES
(1,'Manager'),
(2, 'Employee')

/*
INSERT INTO AspNetUserRoles(UserId,[RoleId])
VALUES
('4bb0afc7-8629-4813-9bff-4609b15e0992',1)
*/