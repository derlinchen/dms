if (exists (select name from sysobjects where (name = N'P_Log_Column') and (type = 'P')))
  drop procedure dbo.P_Log_Column
go

create procedure [dbo].P_Log_Column
(
	@DBID int,
	@TableCode nvarchar(40),
	@IsLog bit
)
as
begin
	
	if @IsLog = 1
	begin
		insert into H_DMS_Column (DBID, TableCode, ColumnID, ColumnName, ColumnCode, DataType, ColumnLength, ColumnPrecision, ColumnIdentity, ColumnNotNull, PreSerial, NowSerial, RecoDate) 
				select DBID, TableCode, ColumnID, ColumnName, ColumnCode, DataType, ColumnLength, ColumnPrecision, ColumnIdentity, ColumnNotNull, PreSerial, NowSerial, getdate() 
				from T_DMS_COLUMN where DBID = @DBID and TableCode = @TableCode 
	end
end


GO