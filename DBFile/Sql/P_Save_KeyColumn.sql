if (exists (select name from sysobjects where (name = N'P_Save_KeyColumn') and (type = 'P')))
  drop procedure dbo.P_Save_KeyColumn
go

create procedure [dbo].P_Save_KeyColumn
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@KeyCode nvarchar(40) = null,
	@ColumnCode nvarchar(40) = null
)
as
begin
	insert into T_DMS_KEY_COLUMN (DBID, TableCode, KeyCode, ColumnCode) 
			values (@DBID, @TableCode, @KeyCode, @ColumnCode)	
end


GO