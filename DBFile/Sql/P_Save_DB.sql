if (exists (select name from sysobjects where (name = N'P_Save_DB') and (type = 'P')))
  drop procedure dbo.P_Save_DB
go

create procedure [dbo].P_Save_DB
(
	@DBID int out,
	@DBName nvarchar(40) = null,
	@DBCode nvarchar(40) = null,
	@IsLog bit = null,
	@ACTION int
)
as
begin
	if @ACTION = 2
	begin
		if (@DBID is null) or (@DBID = 0)
		begin
			set @DBID = (select isnull(max(DBID), 0) + 1 from T_DMS_DB)
			
			insert into T_DMS_DB (DBID, DBName, DBCode, DBSerial) values (@DBID, @DBName, @DBCode, 1)
			
			insert into H_DMS_DB (DBID, DBName, DBCode, DBSerial, CrtDate) select DBID, DBName, DBCode, DBSerial, getdate() from T_DMS_DB where DBID = @DBID
		end
	end
	else if @ACTION = 3
	begin
		if @IsLog = 1
		begin
			update T_DMS_DB set DBName = @DBName, DBCode = @DBCode, DBSerial = DBSerial + 1 where DBID = @DBID
		
			insert into H_DMS_DB (DBID, DBName, DBCode, DBSerial, CrtDate) select DBID, DBName, DBCode, DBSerial, getdate() from T_DMS_DB where DBID = @DBID
		end
		else
		begin
			update T_DMS_DB set DBName = @DBName, DBCode = @DBCode where DBID = @DBID
		end
	end
	
	
end


GO