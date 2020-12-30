CREATE TABLE [dbo].[EnvironmentSettings] (
    [Id]                    INT            NOT NULL,
    [EnvironmentName]       NVARCHAR (MAX) NULL,
    [ManageRequestsADGroup] NVARCHAR (MAX) NULL,
    [AddRequestsADGroup]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_EnvironmentSettings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

