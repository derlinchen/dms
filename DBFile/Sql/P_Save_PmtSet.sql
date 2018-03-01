if (exists (select name from sysobjects where (name = N'P_Save_PmtSet') and (type = 'P')))
  drop procedure dbo.P_Save_PmtSet
go

create procedure [dbo].P_Save_PmtSet
(
	@DBID int,
	@TableSet nvarchar(400)
)
as
begin
	delete from T_DMS_PMTSET where DBID = @DBID and TableSet = @TableSet
	
	insert into T_DMS_PMTSET(DBID, TableSet) values (@DBID, @TableSet)
end


GO