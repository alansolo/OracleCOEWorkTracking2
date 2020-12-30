ALTER ROLE [db_owner] ADD MEMBER [OracleWorkMgmtDBO];


GO
ALTER ROLE [db_datareader] ADD MEMBER [OracleWorkMgmtDBO];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [OracleWorkMgmtDBO];


GO
ALTER ROLE [db_securityadmin] ADD MEMBER [PPGNA\TFSService];


GO
ALTER ROLE [db_ddladmin] ADD MEMBER [PPGNA\TFSService];


GO
ALTER ROLE [db_datareader] ADD MEMBER [PPGNA\TFSService];



