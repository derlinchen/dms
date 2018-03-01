if (exists (select name from sysobjects where (name = N'P_Delete_Index') and (type = 'P')))
  drop procedure dbo.P_Delete_Index
go

create procedure [dbo].P_Delete_Index
(
	@DBID int = null,
	@TableCode nvarchar(40) = null
)
as
begin
	delete from T_DMS_INDEX where DBID = @DBID and TableCode = @TableCode
	
	delete from T_DMS_INDEX_COLUMN where DBID = @DBID and TableCode = @TableCode
end


GO