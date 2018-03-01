if (exists (select name from sysobjects where (name = N'P_Get_PmtSetByDB') and (type = 'P')))
  drop procedure dbo.P_Get_PmtSetByDB
go

create procedure [dbo].P_Get_PmtSetByDB
(
	@DBID int
)
as
begin
	select * from T_DMS_PMTSET where DBID = @DBID order by TableSet
end


GO