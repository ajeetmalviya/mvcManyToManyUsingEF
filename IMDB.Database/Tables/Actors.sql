﻿CREATE TABLE [dbo].[Actors]
(
	[ActorId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ActorName] NVARCHAR(50) NOT NULL,
	[Gender] NVARCHAR(10) NOT NULL,
	[DOB] DATE ,
	[Bio] NVARCHAR(1000), 
)
