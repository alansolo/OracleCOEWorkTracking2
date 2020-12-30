CREATE TABLE [dbo].[RequestAttachments] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Attachment] VARBINARY (MAX) NULL,
    [RequestId]  INT             NOT NULL,
    [FileName]   NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_RequestAttachments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RequestAttachments_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Requests] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RequestAttachments_RequestId]
    ON [dbo].[RequestAttachments]([RequestId] ASC);

