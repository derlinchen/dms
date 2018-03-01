if (exists (select name from sysobjects where (name = N'P_Delete_Key') and (type = 'P')))
  drop procedure dbo.P_Delete_Key
go

create procedure [dbo].P_Delete_Key
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@IsLog bit = null
)
as
begin
	delete from T_DMS_KEY where DBID = @DBID and TableCode = @TableCode
	
	delete from T_DMS_KEY_COLUMN where DBID = @DBID and TableCode = @TableCode
end


GO