if (exists (select name from sysobjects where (name = N'P_Get_ColumnByKey') and (type = 'P')))
  drop procedure dbo.P_Get_ColumnByKey
go

create procedure [dbo].P_Get_ColumnByKey
(
	@DBID int,
	@TableCode nvarchar(40),
	@KeyCode nvarchar(40)
)
as
begin
	select * from T_DMS_KEY_COLUMN 
		where DBID = @DBID and TableCode = @TableCode and KeyCode = @KeyCode
end


GO