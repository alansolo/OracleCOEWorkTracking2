CREATE TABLE [dbo].[RequestModules] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ModuleId]  INT NOT NULL,
    [RequestId] INT NOT NULL,
    CONSTRAINT [PK_RequestModules] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON),
    CONSTRAINT [FK_RequestModules_Modules_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RequestModules_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Requests] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RequestModules_ModuleId]
    ON [dbo].[RequestModules]([ModuleId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_RequestModules_RequestId]
    ON [dbo].[RequestModules]([RequestId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);

