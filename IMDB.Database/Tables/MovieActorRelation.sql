CREATE TABLE [dbo].[MovieActorRelationship]
(
	[MovieId] INT NOT NULL,
	[ActorId] INT NOT NULL, 
    CONSTRAINT [FK_MovieActorRelationship_Movies] FOREIGN KEY ([MovieId]) REFERENCES [Movies]([MovieId]), 
    CONSTRAINT [FK_MovieActorRelationship_Actors] FOREIGN KEY ([ActorId]) REFERENCES [Actors]([ActorId]),
	PRIMARY KEY(MovieId,ActorId)
)
