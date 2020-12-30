CREATE TABLE [dbo].[RequestRegions] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [RegionId]  INT NOT NULL,
    [RequestId] INT NOT NULL,
    CONSTRAINT [PK_RequestRegions] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON),
    CONSTRAINT [FK_RequestRegions_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Regions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RequestRegions_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Requests] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RequestRegions_RegionId]
    ON [dbo].[RequestRegions]([RegionId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_RequestRegions_RequestId]
    ON [dbo].[RequestRegions]([RequestId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);

