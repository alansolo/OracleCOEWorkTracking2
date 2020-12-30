CREATE TABLE [dbo].[ApplicationModule]
(
	[AppId] INT NOT NULL , 
    [ModuleId] INT NOT NULL, 
    PRIMARY KEY ([AppId], [ModuleId]),
	CONSTRAINT [FK_ApplicationModule_ToApplications] FOREIGN KEY (AppId) REFERENCES Applications(Id),
	CONSTRAINT [FK_ApplicationModule_ToModules] FOREIGN KEY (ModuleId) REFERENCES Modules(Id)

)

