if (exists (select name from sysobjects where (name = N'P_Get_TableNoPmtByDB') and (type = 'P')))
  drop procedure dbo.P_Get_TableNoPmtByDB
go

create procedure [dbo].P_Get_TableNoPmtByDB
(
	@DBID int
)
as
begin
	select TableCode, TableName + '(' + TableCode + ')' TableName from T_DMS_TABLE where DBID = @DBID and IsPmt = 0 order by tablename
end


GO