if (exists (select name from sysobjects where (name = N'P_Get_DBByCode') and (type = 'P')))
  drop procedure dbo.P_Get_DBByCode
go

create procedure [dbo].P_Get_DBByCode
(
	@DBCode nvarchar(40)
)
as
begin
	select * from T_DMS_DB where DBCode = @DBCode
end


GO