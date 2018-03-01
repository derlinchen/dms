if (exists (select name from sysobjects where (name = N'P_Get_DBForCombox') and (type = 'P')))
  drop procedure dbo.P_Get_DBForCombox
go

create procedure [dbo].[P_Get_DBForCombox]
(
	@DBType varchar(2) = null
)
as
begin
	select DBID, DBName + '(' + DBCode + ')' DBName from T_DMS_DB where DBType = @DBType order by DBID
end




GO