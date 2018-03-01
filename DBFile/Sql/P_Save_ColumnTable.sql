if (exists (select name from sysobjects where (name = N'P_Save_ColumnTable') and (type = 'P')))
  drop procedure dbo.P_Save_ColumnTable
go

create procedure [dbo].P_Save_ColumnTable
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@ColumnSerial int = null,
	@ColumnCode nvarchar(40) = null,
	@RelaTable nvarchar(40) = null,
	@RelaColumn nvarchar(40) = null,
	@DisplayColumn nvarchar(40) = null,
	@Prefix nvarchar(2) = null
)
as
begin
	insert into T_DMS_COLUMNTABLE (DBID, TableCode, ColumnSerial, ColumnCode, RelaTable, RelaColumn, DisplayColumn, Prefix) 
		values (@DBID, @TableCode, @ColumnSerial, @ColumnCode, @RelaTable, @RelaColumn, @DisplayColumn, @Prefix)
end


GO