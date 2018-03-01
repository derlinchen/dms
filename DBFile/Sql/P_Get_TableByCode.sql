if (exists (select name from sysobjects where (name = N'P_Get_TableByCode') and (type = 'P')))
  drop procedure dbo.P_Get_TableByCode
go

create procedure [dbo].P_Get_TableByCode
(
	@DBID int,
	@TableCode nvarchar(40)
)
as
begin
	select * from T_DMS_TABLE where DBID = @DBID and lower(TableCode) = lower(@TableCode)
end


GO