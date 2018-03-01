if (exists (select name from sysobjects where (name = N'P_Log_Index') and (type = 'P')))
  drop procedure dbo.P_Log_Index
go

create procedure [dbo].P_Log_Index
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
	
		insert into H_DMS_INDEX (DBID, TableCode, IndexID, IndexName, IndexCode, IsUnique, NowSerial) 
			select DBID, TableCode, IndexID, IndexName, IndexCode, IsUnique, @DBSerial from T_DMS_INDEX where DBID = @DBID and TableCode = @TableCode 
				
		insert into H_DMS_INDEX_COLUMN (DBID, TableCode, IndexCode, ColumnCode, NowSerial) 
			select DBID, TableCode, IndexCode, ColumnCode, @DBSerial from T_DMS_INDEX_COLUMN where DBID = @DBID and TableCode = @TableCode 
	end
end


GO