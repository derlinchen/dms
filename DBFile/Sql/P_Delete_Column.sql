if (exists (select name from sysobjects where (name = N'P_Delete_Column') and (type = 'P')))
  drop procedure dbo.P_Delete_Column
go

create procedure [dbo].P_Delete_Column
(
	@DBID int,
	@TableCode nvarchar(40),
	@IsLog bit = null
)
as
begin
	delete from T_DMS_Column where DBID = @DBID and TableCode = @TableCode 
end


GO