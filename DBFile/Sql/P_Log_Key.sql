if (exists (select name from sysobjects where (name = N'P_Log_Key') and (type = 'P')))
  drop procedure dbo.P_Log_Key
go


create procedure [dbo].P_Log_Key
(
	@DBID int,
	@TableCode nvarchar(40),
	@IsLog bit
)
as
begin	
	if @IsLog = 1
	begin
		declare @DBSerial int
	
		select @DBSerial = DBSerial from T_DMS_DB where DBID = @DBID
	
		insert into H_DMS_Key (DBID, TableCode, KeyID, KeyName, KeyCode, IsPrimary, NowSerial) 
			select DBID, TableCode, KeyID, KeyName, KeyCode, IsPrimary, @DBSerial from H_DMS_Key where DBID = @DBID and TableCode = @TableCode 
				
		insert into H_DMS_KEY_COLUMN (DBID, TableCode, KeyCode, ColumnCode, NowSerial) 
			select DBID, TableCode, KeyCode, ColumnCode, @DBSerial from T_DMS_KEY_COLUMN where DBID = @DBID and TableCode = @TableCode 
	end
end


GO