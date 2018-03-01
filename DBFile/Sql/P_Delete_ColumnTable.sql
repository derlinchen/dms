if (exists (select name from sysobjects where (name = N'P_Delete_ColumnTable') and (type = 'P')))
  drop procedure dbo.P_Delete_ColumnTable
go

create procedure [dbo].P_Delete_ColumnTable
(
	@DBID int,
	@TableCode nvarchar(40)
)
as
begin
	delete from T_DMS_COLUMNTABLE where DBID = @DBID and TableCode = @TableCode
end


GO