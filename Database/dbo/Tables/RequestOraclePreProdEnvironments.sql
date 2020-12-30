CREATE TABLE [dbo].[RequestOraclePreProdEnvironments] (
    [Id]                         INT IDENTITY (1, 1) NOT NULL,
    [OraclePreProdEnvironmentId] INT NOT NULL,
    [RequestId]                  INT NOT NULL,
    CONSTRAINT [PK_RequestOraclePreProdEnvironments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RequestOraclePreProdEnvironments_OraclePreProdEnvironments_OraclePreProdEnvironmentId] FOREIGN KEY ([OraclePreProdEnvironmentId]) REFERENCES [dbo].[OraclePreProdEnvironments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RequestOraclePreProdEnvironments_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Requests] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RequestOraclePreProdEnvironments_OraclePreProdEnvironmentId]
    ON [dbo].[RequestOraclePreProdEnvironments]([OraclePreProdEnvironmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RequestOraclePreProdEnvironments_RequestId]
    ON [dbo].[RequestOraclePreProdEnvironments]([RequestId] ASC);

