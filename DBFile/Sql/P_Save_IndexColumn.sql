if (exists (select name from sysobjects where (name = N'P_Save_IndexColumn') and (type = 'P')))
  drop procedure dbo.P_Save_IndexColumn
go

create procedure [dbo].P_Save_IndexColumn
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@IndexCode nvarchar(40) = null,
	@ColumnCode nvarchar(40) = null
)
as
begin
	insert into T_DMS_INDEX_COLUMN (DBID, TableCode, IndexCode, ColumnCode) 
			values (@DBID, @TableCode, @IndexCode, @ColumnCode)	
end


GO