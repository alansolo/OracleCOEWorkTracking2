CREATE TABLE [dbo].[Requests] (
    [Id]                        INT            IDENTITY (10000, 1) NOT NULL,
    [BIContact]                 NVARCHAR (MAX) NULL,
    [BIGateQuestionnaireUrl]    NVARCHAR (MAX) NULL,
    [BIGateStatusId]            INT            NULL,
    [BenefitCase]               NVARCHAR (MAX) NULL,
    [COEPriority]               INT            NULL,
    [CRNo]                      INT            NULL,
    [CreatedBy]                 NVARCHAR (50)  NULL,
    [CreatedOn]                 DATETIME2 (7)  NOT NULL,
    [DCOEDevelopmentLead]       NVARCHAR (MAX) NULL,
    [DCOEEstimate]              FLOAT (53)     NULL,
    [DeleteMark]                BIT            NOT NULL,
    [EBSGateQuestionnaireUrl]   NVARCHAR (MAX) NULL,
    [EBSGateStatusId]           INT            NULL,
    [EstimateInfra]             INT            NULL,
    [FrontLineContact]          NVARCHAR (MAX) NULL,
    [FunctionalContact]         NVARCHAR (MAX) NULL,
    [GBSPriority]               INT            NULL,
    [MD_50]                     NVARCHAR (MAX) NULL,
    [MD_50_DueDate]             DATETIME2 (7)  NULL,
    [MD_70]                     NVARCHAR (MAX) NULL,
    [MD_70_DueDate]             DATETIME2 (7)  NULL,
    [ModifiedBy]                NVARCHAR (50)  NULL,
    [ModifiedOn]                DATETIME2 (7)  NULL,
    [NextBIGateId]              INT            NULL,
    [NextEBSGateId]             INT            NULL,
    [OTMEBSGateId]              INT            NULL,
    [Next_NETGateId]            INT            NULL,
    [OTMGateQuestionnaireUrl]   NVARCHAR (MAX) NULL,
    [OTMGateStatusId]           INT            NULL,
    [OracleDevEstimateOffShore] FLOAT (53)     NULL,
    [OracleDevEstimateOnShore]  FLOAT (53)     NULL,
    [OracleDevelopmentLead]     NVARCHAR (MAX) NULL,
    [OriginalSystemReference]   NVARCHAR (MAX) NULL,
    [OwningSiteId]              INT            NULL,
    [OwningStreamId]            INT            NOT NULL,
    [Problem]                   NVARCHAR (MAX) NULL,
    [ProductionDate]            DATETIME2 (7)  NULL,
    [ProjectName]               NVARCHAR (MAX) NULL,
    [ReadyForBIGateId]          INT            NULL,
    [ReadyForEBSGateId]         INT            NULL,
    [ReadyForOTMGateId]         INT            NULL,
    [ReadyFor_NETGateId]        INT            NULL,
    [Requestor]                 NVARCHAR (MAX) NULL,
    [StatusId]                  INT            NOT NULL,
    [TIPUrl]                    NVARCHAR (MAX) NULL,
    [TestingDate]               DATETIME2 (7)  NULL,
    [TotalEstimate]             FLOAT (53)     NULL,
    [_NETGateQuestionnaireUrl]  NVARCHAR (MAX) NULL,
    [_NETGateStatusId]          INT            NULL,
    [BIRequestId]               INT            NULL,
    [Attribute1]                NVARCHAR (MAX) NULL,
    [Attribute10]               DATETIME2 (7)  NULL,
    [Attribute2]                NVARCHAR (MAX) NULL,
    [Attribute3]                NVARCHAR (MAX) NULL,
    [Attribute4]                NVARCHAR (MAX) NULL,
    [Attribute5]                NVARCHAR (MAX) NULL,
    [Attribute6]                NVARCHAR (MAX) NULL,
    [Attribute7]                NVARCHAR (MAX) NULL,
    [Attribute8]                NVARCHAR (MAX) NULL,
    [Attribute9]                NVARCHAR (MAX) NULL,
    [BIImpactedStream]          BIT            DEFAULT ((0)) NOT NULL,
    [OTMImpactedStream]         BIT            DEFAULT ((0)) NOT NULL,
    [ApplicationId] INT NULL, 
    CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Requests_BooleanDropDownValues_BIRequestId] FOREIGN KEY ([BIRequestId]) REFERENCES [dbo].[BooleanDropDownValues] ([Id]),
    CONSTRAINT [FK_Requests_BooleanDropDownValues_ReadyFor_NETGateId] FOREIGN KEY ([ReadyFor_NETGateId]) REFERENCES [dbo].[BooleanDropDownValues] ([Id]),
    CONSTRAINT [FK_Requests_BooleanDropDownValues_ReadyForBIGateId] FOREIGN KEY ([ReadyForBIGateId]) REFERENCES [dbo].[BooleanDropDownValues] ([Id]),
    CONSTRAINT [FK_Requests_BooleanDropDownValues_ReadyForEBSGateId] FOREIGN KEY ([ReadyForEBSGateId]) REFERENCES [dbo].[BooleanDropDownValues] ([Id]),
    CONSTRAINT [FK_Requests_BooleanDropDownValues_ReadyForOTMGateId] FOREIGN KEY ([ReadyForOTMGateId]) REFERENCES [dbo].[BooleanDropDownValues] ([Id]),
    CONSTRAINT [FK_Requests_Gates_Next_NETGateId] FOREIGN KEY ([Next_NETGateId]) REFERENCES [dbo].[Gates] ([Id]),
    CONSTRAINT [FK_Requests_Gates_NextBIGateId] FOREIGN KEY ([NextBIGateId]) REFERENCES [dbo].[Gates] ([Id]),
    CONSTRAINT [FK_Requests_Gates_NextEBSGateId] FOREIGN KEY ([NextEBSGateId]) REFERENCES [dbo].[Gates] ([Id]),
    CONSTRAINT [FK_Requests_Gates_OTMEBSGateId] FOREIGN KEY ([OTMEBSGateId]) REFERENCES [dbo].[Gates] ([Id]),
    CONSTRAINT [FK_Requests_GateStatuses__NETGateStatusId] FOREIGN KEY ([_NETGateStatusId]) REFERENCES [dbo].[GateStatuses] ([Id]),
    CONSTRAINT [FK_Requests_GateStatuses_BIGateStatusId] FOREIGN KEY ([BIGateStatusId]) REFERENCES [dbo].[GateStatuses] ([Id]),
    CONSTRAINT [FK_Requests_GateStatuses_EBSGateStatusId] FOREIGN KEY ([EBSGateStatusId]) REFERENCES [dbo].[GateStatuses] ([Id]),
    CONSTRAINT [FK_Requests_GateStatuses_OTMGateStatusId] FOREIGN KEY ([OTMGateStatusId]) REFERENCES [dbo].[GateStatuses] ([Id]),
    CONSTRAINT [FK_Requests_OwningSites_OwningSiteId] FOREIGN KEY ([OwningSiteId]) REFERENCES [dbo].[OwningSites] ([Id]),
    CONSTRAINT [FK_Requests_OwningStreams_OwningStreamId] FOREIGN KEY ([OwningStreamId]) REFERENCES [dbo].[OwningStreams] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Requests_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Statuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Requests_Applications] FOREIGN KEY (ApplicationId) REFERENCES [dbo].[Applications] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_BIGateStatusId]
    ON [dbo].[Requests]([BIGateStatusId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_EBSGateStatusId]
    ON [dbo].[Requests]([EBSGateStatusId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_NextBIGateId]
    ON [dbo].[Requests]([NextBIGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_NextEBSGateId]
    ON [dbo].[Requests]([NextEBSGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_OTMEBSGateId]
    ON [dbo].[Requests]([OTMEBSGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_Next_NETGateId]
    ON [dbo].[Requests]([Next_NETGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_OTMGateStatusId]
    ON [dbo].[Requests]([OTMGateStatusId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_OwningSiteId]
    ON [dbo].[Requests]([OwningSiteId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_OwningStreamId]
    ON [dbo].[Requests]([OwningStreamId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_ReadyForBIGateId]
    ON [dbo].[Requests]([ReadyForBIGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_ReadyForEBSGateId]
    ON [dbo].[Requests]([ReadyForEBSGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_ReadyForOTMGateId]
    ON [dbo].[Requests]([ReadyForOTMGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_ReadyFor_NETGateId]
    ON [dbo].[Requests]([ReadyFor_NETGateId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_StatusId]
    ON [dbo].[Requests]([StatusId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests__NETGateStatusId]
    ON [dbo].[Requests]([_NETGateStatusId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);


GO
CREATE NONCLUSTERED INDEX [IX_Requests_BIRequestId]
    ON [dbo].[Requests]([BIRequestId] ASC) WITH (FILLFACTOR = 90, PAD_INDEX = ON);

