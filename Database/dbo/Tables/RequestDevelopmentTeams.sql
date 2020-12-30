CREATE TABLE [dbo].[RequestDevelopmentTeams] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [DevelopmentTeamId] INT NOT NULL,
    [RequestId]         INT NOT NULL,
    CONSTRAINT [PK_RequestDevelopmentTeams] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RequestDevelopmentTeams_DevelopmentTeams_DevelopmentTeamId] FOREIGN KEY ([DevelopmentTeamId]) REFERENCES [dbo].[DevelopmentTeams] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RequestDevelopmentTeams_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Requests] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RequestDevelopmentTeams_DevelopmentTeamId]
    ON [dbo].[RequestDevelopmentTeams]([DevelopmentTeamId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RequestDevelopmentTeams_RequestId]
    ON [dbo].[RequestDevelopmentTeams]([RequestId] ASC);

