CREATE TABLE [dbo].[Movies]
(
	[MovieId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[MoviesName] NVARCHAR(100) NOT NULL,
	[YOR] INT NOT NULL,
	[Plot] NVARCHAR (1000) NULL,
	[Poster] NVARCHAR (1000) NULL,
	[ProducerId] INT NOT NULL, 
    CONSTRAINT [FK_Movies_Producers] FOREIGN KEY ([ProducerId]) REFERENCES [Producers]([ProducerId])
)
