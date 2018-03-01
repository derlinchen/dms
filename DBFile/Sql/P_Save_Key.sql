if (exists (select name from sysobjects where (name = N'P_Save_Key') and (type = 'P')))
  drop procedure dbo.P_Save_Key
go

create procedure [dbo].P_Save_Key
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@KeyID int = null,
	@KeyName nvarchar(40) = null,
	@KeyCode nvarchar(40) = null,
	@IsPrimary bit = null
)
as
begin
	insert into T_DMS_Key (DBID, TableCode, KeyID, KeyName, KeyCode, IsPrimary) 
			values (@DBID, @TableCode, @KeyID, @KeyName, @KeyCode, @IsPrimary)	
end


GO