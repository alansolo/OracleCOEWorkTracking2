CREATE ROLE [db_spexec]
    AUTHORIZATION [dbo];




GO
ALTER ROLE [db_spexec] ADD MEMBER [PPGNA\TFSService];

