CREATE TABLE [dbo].[RequestNotes] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]  NVARCHAR (50)  NULL,
    [CreatedOn]  DATETIME2 (7)  NOT NULL,
    [DeleteMark] BIT            NOT NULL,
    [ModifiedBy] NVARCHAR (50)  NULL,
    [ModifiedOn] DATETIME2 (7)  NULL,
    [Note]       NVARCHAR (MAX) NULL,
    [RequestId]  INT            NOT NULL,
    CONSTRAINT [PK_RequestNotes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RequestNotes_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Requests] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RequestNotes_RequestId]
    ON [dbo].[RequestNotes]([RequestId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);

