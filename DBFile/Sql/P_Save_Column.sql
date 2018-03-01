if (exists (select name from sysobjects where (name = N'P_Save_Column') and (type = 'P')))
  drop procedure dbo.P_Save_Column
go

create procedure [dbo].P_Save_Column
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@ColumnID int = null,
	@ColumnName nvarchar(40) = null,
	@ColumnCode nvarchar(40) = null,
	@DataType nvarchar(40) = null,
	@ColumnLength int = null,
	@ColumnPrecision int = null,
	@ColumnIdentity bit = null,
	@ColumnNotNull bit = null,
	@PreSerial int = null
)
as
begin
	insert into T_DMS_Column (DBID, TableCode, ColumnID, ColumnName, ColumnCode, DataType, ColumnLength, ColumnPrecision, ColumnIdentity, ColumnNotNull, PreSerial, NowSerial) 
			select @DBID, @TableCode, @ColumnID, @ColumnName, @ColumnCode, @DataType, @ColumnLength, @ColumnPrecision, @ColumnIdentity, @ColumnNotNull, DBSerial, DBSerial from T_DMS_DB where DBID = @DBID
end


GO