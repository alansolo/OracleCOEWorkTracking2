CREATE TABLE [dbo].[ApplicationRegion]
(
	[AppId] INT NOT NULL , 
    [RegionId] INT NOT NULL, 
    PRIMARY KEY ([AppId], [RegionId]), 
    CONSTRAINT [FK_ApplicationRegions_ToApplications] FOREIGN KEY (AppId) REFERENCES Applications(Id),
	CONSTRAINT [FK_ApplicationRegions_ToRegions] FOREIGN KEY (RegionId) REFERENCES Regions(Id)
)
