if (exists (select name from sysobjects where (name = N'P_Save_TableSet') and (type = 'P')))
  drop procedure dbo.P_Save_TableSet
go

create procedure [dbo].P_Save_TableSet
(
	@DBID int,
	@TableCode nvarchar(40),
	@TableSet nvarchar(1000)
)
as
begin
	delete from T_DMS_TABLESET where DBID = @DBID and TableCode = @TableCode
	
	insert into T_DMS_TABLESET(DBID, TableCode, TableSet) values (@DBID, @TableCode, @TableSet)
end


GO