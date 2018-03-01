if (exists (select name from sysobjects where (name = N'P_Get_SetByCode') and (type = 'P')))
  drop procedure dbo.P_Get_SetByCode
go

create procedure [dbo].P_Get_SetByCode
(
	@DBID int,
	@TableCode nvarchar(40)
)
as
begin
	select * from T_DMS_TABLESET where DBID = @DBID and TableCode = @TableCode
end


GO