CREATE TABLE [dbo].[ApplicationOwningSite]
(
	[AppId] INT NOT NULL , 
    [OwningSiteId] INT NOT NULL, 
    PRIMARY KEY ([AppId], [OwningSiteId]),
	CONSTRAINT [FK_ApplicationOwningSites_ToApplications] FOREIGN KEY (AppId) REFERENCES Applications(Id),
	CONSTRAINT [FK_ApplicationOwningSites_ToOwningSites] FOREIGN KEY (OwningSiteId) REFERENCES OwningSites(Id)

)
