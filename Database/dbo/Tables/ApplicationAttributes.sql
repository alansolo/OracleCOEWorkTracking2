CREATE TABLE [dbo].[ApplicationAttributes] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [CreatedBy]     NVARCHAR (50) NULL,
    [CreatedOn]     DATETIME2 (7) NOT NULL,
    [DeleteMark]    BIT           NOT NULL,
    [ModifiedBy]    NVARCHAR (50) NULL,
    [ModifiedOn]    DATETIME2 (7) NULL,
    [ApplicationId] INT           NULL,
    [Attribute1]    NVARCHAR (50) NULL,
    [Attribute2]    NVARCHAR (50) NULL,
    [Attribute3]    NVARCHAR (50) NULL,
    [Attribute4]    NVARCHAR (50) NULL,
    [Attribute5]    NVARCHAR (50) NULL,
    [Attribute6]    NVARCHAR (50) NULL,
    [Attribute7]    NVARCHAR (50) NULL,
    [Attribute8]    NVARCHAR (50) NULL,
    [Attribute9]    NVARCHAR (50) NULL,
    [Attribute10]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_ApplicationAttribute] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApplicationAttribute_Applications] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[Applications] ([Id])
);

