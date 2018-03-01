if (exists (select name from sysobjects where (name = N'P_Get_ColumnTable') and (type = 'P')))
  drop procedure dbo.P_Get_ColumnTable
go

create procedure [dbo].P_Get_ColumnTable
(
	@DBID int,
	@TableCode nvarchar(40)
)
as
begin
	select a.*, b.DataType, b.ColumnName, b.ColumnLength, b.ColumnNotNull from T_DMS_COLUMNTABLE a, T_DMS_COLUMN b where a.DBID = b.DBID and a.RelaTable = b.TableCode and a.DisplayColumn = b.ColumnCode 
		and a.DBID = @DBID and a.TableCode = @TableCode order by a.ColumnSerial 
end


GO