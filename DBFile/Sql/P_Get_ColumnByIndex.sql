if (exists (select name from sysobjects where (name = N'P_Get_ColumnByIndex') and (type = 'P')))
  drop procedure dbo.P_Get_ColumnByIndex
go

create procedure [dbo].P_Get_ColumnByIndex
(
	@DBID int,
	@TableCode nvarchar(40),
	@IndexCode nvarchar(40)
)
as
begin
	select * from T_DMS_INDEX_COLUMN 
		where DBID = @DBID and TableCode = @TableCode and IndexCode = @IndexCode
end


GO