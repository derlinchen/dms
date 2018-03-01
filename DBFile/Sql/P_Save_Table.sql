if (exists (select name from sysobjects where (name = N'P_Save_Table') and (type = 'P')))
  drop procedure dbo.P_Save_Table
go

create procedure [dbo].P_Save_Table
(
	@DBID int = null,
	@TableCode nvarchar(40) = null,
	@TableName nvarchar(40) = null,
	@Comment nvarchar(400) = null,
	@IsPmt bit = null,
	@IsLog bit = null,
	@ACTION int
)
as
begin
	declare @DBSerial int
	
	select @DBSerial = DBSerial from T_DMS_DB where DBID = @DBID
	
	if @ACTION = 2
	begin
		insert into T_DMS_Table (DBID, TableName, TableCode, IsPmt, Comment, PreSerial, NowSerial) values (@DBID, @TableName, @TableCode, @IsPmt, @Comment, @DBSerial, @DBSerial)
		
		insert into H_DMS_Table (DBID, TableName, TableCode, IsPmt, Comment, PreSerial, NowSerial, RecoDate) select DBID, TableName, TableCode, IsPmt, Comment, PreSerial, NowSerial, getdate() 
			from T_DMS_Table where DBID = @DBID and TableCode = @TableCode 
	end
	else if @ACTION = 3
	begin
		if @IsLog = 1
		begin
			update T_DMS_Table set TableName = @TableName, IsPmt = @IsPmt, Comment = @Comment, PreSerial = @DBSerial, NowSerial = @DBSerial where DBID = @DBID and TableCode = @TableCode
			
			insert into H_DMS_Table (DBID, TableName, TableCode, IsPmt, Comment, PreSerial, NowSerial, RecoDate) select DBID, TableName, TableCode, IsPmt, Comment, PreSerial, NowSerial, getdate() 
				from T_DMS_Table where DBID = @DBID and TableCode = @TableCode 
		end
		else
		begin
			update T_DMS_Table set TableName = @TableName, IsPmt = @IsPmt, Comment = @Comment where DBID = @DBID and TableCode = @TableCode
		end
	end
		
end


GO