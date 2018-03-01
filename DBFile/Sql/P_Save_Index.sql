if (exists (select name from sysobjects where (name = N'P_Save_Index') and (type = 'P')))
  drop procedure dbo.P_Save_Index
go

create procedure [dbo].P_Save_Index
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@IndexID int = null,
	@IndexName nvarchar(40) = null,
	@IndexCode nvarchar(40) = null,
	@IsUnique bit = null
)
as
begin
	insert into T_DMS_INDEX (DBID, TableCode, IndexID, IndexName, IndexCode, IsUnique) 
			values (@DBID, @TableCode, @IndexID, @IndexName, @IndexCode, @IsUnique)	
end


GO