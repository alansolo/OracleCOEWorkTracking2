CREATE TABLE [dbo].[RequestImpactedStreams] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [ImpactedStreamId] INT NOT NULL,
    [RequestId]        INT NOT NULL,
    CONSTRAINT [PK_RequestImpactedStreams] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RequestImpactedStreams_ImpactedStreams_ImpactedStreamId] FOREIGN KEY ([ImpactedStreamId]) REFERENCES [dbo].[ImpactedStreams] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RequestImpactedStreams_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Requests] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RequestImpactedStreams_ImpactedStreamId]
    ON [dbo].[RequestImpactedStreams]([ImpactedStreamId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RequestImpactedStreams_RequestId]
    ON [dbo].[RequestImpactedStreams]([RequestId] ASC);

