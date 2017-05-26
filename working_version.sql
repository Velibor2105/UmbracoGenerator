USE [db.name]
GO
/****** Object:  StoredProcedure [dbo].[pr_AddFolderToDataTypes]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[pr_AddFolderToDataTypes]
(
 @trashed bit,
 @parentID int,
 @nodeUser int,
 @level int,
 @path nvarchar(150),
 @sortOrder int,
 @uniqueID uniqueidentifier,
 @text nvarchar(255),
 @createDate datetime,
 @id int output
)
as
begin
       insert into [dbo].[umbracoNode] (
       [trashed]
      ,[parentID]
      ,[nodeUser]
      ,[level]
      ,[path]
      ,[sortOrder]
      ,[uniqueID]
      ,[text]
      ,[nodeObjectType]
      ,[createDate])
	  values (@trashed,@parentID,@nodeUser,@level,@path,@sortOrder,@uniqueID,@text,'521231E3-8B37-469C-9F9D-51AFC91FEB7B',@createDate);

	  set @id = SCOPE_IDENTITY();

	  update [dbo].[umbracoNode] 
	  set [path] = '-1,' + CAST(@id as varchar(16)) 
	  where [id] = @id;
end
GO
/****** Object:  StoredProcedure [dbo].[pr_AddArchetypeToDataType]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_AddArchetypeToDataType]
(
 @text nvarchar(255),
 @createDate datetime,
 @id int output
)
as
begin
           declare @Count int;
	  declare @FolderId int;
	  declare @Guid varchar (500);
	  declare @Guid1 varchar (500);
      -- exec  [dbo].[pr_AddFolderToDataTypes] @trashed,@parentID,@nodeUser,@level,@path, @sortOrder,@uniqueID,@text, @createDate,@id

	   select  @Count = count(*) from [dbo].[umbracoNode] where [text] = 'AT'

	   if @Count > 0 
			begin
			   select @FolderId = [id] from [dbo].[umbracoNode] where [text] = 'AT'
			end
		else	
			begin
		       	SET @Guid = NEWID()
				exec [dbo].[pr_AddFolderToDataTypes] 0,-1,0,1,'-1',0,@Guid,'AT',@createDate, @FolderId output
			end
		set @Guid1 = NEWID();
       insert into [dbo].[umbracoNode] (
       [trashed]
      ,[parentID]
      ,[nodeUser]
      ,[level]
      ,[path]
      ,[sortOrder]
      ,[uniqueID]
      ,[text]
      ,[nodeObjectType]
      ,[createDate])
	  values (0,@FolderId,1,1,'-1',0,@Guid1,@text,'30A2A501-1978-4DDB-A57B-F7EFED43BA3C',@createDate);

	  set @id = SCOPE_IDENTITY();

	  update [dbo].[umbracoNode] 
	  set [path] = '-1,' + CAST(@FolderId as varchar(16)) + ',' + CAST(@id as varchar(16)) 
	  where [id] = @id;


	   insert into [Vega.Welibor].[dbo].[cmsDataType] (
	    [nodeId],
		[propertyEditorAlias],
        [dbType])
	   values  (@id,'Imulus.Archetype','Ntext')
end

GO
/****** Object:  StoredProcedure [dbo].[pr_AddFolderToDocumentTypes]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[pr_AddFolderToDocumentTypes]
(
 @trashed bit,
 @parentID int,
 @nodeUser int,
 @level int,
 @path nvarchar(150),
 @sortOrder int,
 @uniqueID uniqueidentifier,
 @text nvarchar(255),
 @createDate datetime,
 @id int output
)
as
begin
       insert into [dbo].[umbracoNode] (
       [trashed]
      ,[parentID]
      ,[nodeUser]
      ,[level]
      ,[path]
      ,[sortOrder]
      ,[uniqueID]
      ,[text]
      ,[nodeObjectType]
      ,[createDate])
	  values (@trashed,@parentID,@nodeUser,@level,@path,@sortOrder,@uniqueID,@text,'2F7A2769-6B0B-4468-90DD-AF42D64F7F16',@createDate);

	  set @id = SCOPE_IDENTITY();

	  update [dbo].[umbracoNode] 
	  set [path] = '-1,' + CAST(@id as varchar(16)) 
	  where [id] = @id;
end
GO
/****** Object:  StoredProcedure [dbo].[pr_AddMNTPToDataType]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_AddMNTPToDataType]
(
 @text nvarchar(255),
 @createDate datetime,
 @id int output
)
as
begin
    
      declare @Count int;
	  declare @FolderId int;
	  declare @Guid varchar (500);
	  declare @Guid1 varchar (500);
      -- exec  [dbo].[pr_AddFolderToDataTypes] @trashed,@parentID,@nodeUser,@level,@path, @sortOrder,@uniqueID,@text, @createDate,@id

	   select  @Count = count(*) from [dbo].[umbracoNode] where [text] = 'MNTP'

	   if @Count > 0 
			begin
			   select @FolderId = [id] from [dbo].[umbracoNode] where [text] = 'MNTP'
			end
		else	
			begin
		       	SET @Guid = NEWID()
				exec [dbo].[pr_AddFolderToDataTypes] 0,-1,0,1,'-1',0,@Guid,'MNTP',@createDate, @FolderId output
			end
		set @Guid1 = NEWID();
       insert into [dbo].[umbracoNode] (
       [trashed]
      ,[parentID]
      ,[nodeUser]
      ,[level]
      ,[path]
      ,[sortOrder]
      ,[uniqueID]
      ,[text]
      ,[nodeObjectType]
      ,[createDate])
	  values (0,@FolderId,1,1,'-1',0,@Guid1,@text,'30A2A501-1978-4DDB-A57B-F7EFED43BA3C',@createDate);

	  set @id = SCOPE_IDENTITY();

	  update [dbo].[umbracoNode] 
	  set [path] = '-1,' + CAST(@FolderId as varchar(16)) + ',' + CAST(@id as varchar(16)) 
	  where [id] = @id;


	   insert into [Vega.Welibor].[dbo].[cmsDataType] (
	    [nodeId],
		[propertyEditorAlias],
        [dbType])
	   values  (@id,'Umbraco.MultiNodeTreePicker','Nvarchar')
end
GO
/****** Object:  StoredProcedure [dbo].[pr_AddMUPToDataType]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_AddMUPToDataType]
(
 @text nvarchar(255),
 @createDate datetime,
 @id int output
)
as
begin
           declare @Count int;
	  declare @FolderId int;
	  declare @Guid varchar (500);
	  declare @Guid1 varchar (500);
      -- exec  [dbo].[pr_AddFolderToDataTypes] @trashed,@parentID,@nodeUser,@level,@path, @sortOrder,@uniqueID,@text, @createDate,@id

	   select  @Count = count(*) from [dbo].[umbracoNode] where [text] = 'MUP'

	   if @Count > 0 
			begin
			   select @FolderId = [id] from [dbo].[umbracoNode] where [text] = 'MUP'
			end
		else	
			begin
		       	SET @Guid = NEWID()
				exec [dbo].[pr_AddFolderToDataTypes] 0,-1,0,1,'-1',0,@Guid,'MUP',@createDate, @FolderId output
			end
		set @Guid1 = NEWID();
       insert into [dbo].[umbracoNode] (
       [trashed]
      ,[parentID]
      ,[nodeUser]
      ,[level]
      ,[path]
      ,[sortOrder]
      ,[uniqueID]
      ,[text]
      ,[nodeObjectType]
      ,[createDate])
	  values (0,@FolderId,1,1,'-1',0,@Guid1,@text,'30A2A501-1978-4DDB-A57B-F7EFED43BA3C',@createDate);

	  set @id = SCOPE_IDENTITY();

	  update [dbo].[umbracoNode] 
	  set [path] = '-1,' + CAST(@FolderId as varchar(16)) + ',' + CAST(@id as varchar(16)) 
	  where [id] = @id;


	   insert into [Vega.Welibor].[dbo].[cmsDataType] (
	    [nodeId],
		[propertyEditorAlias],
        [dbType])
	   values  (@id,'RJP.MultiUrlPicker','Ntext')
end
GO
/****** Object:  StoredProcedure [dbo].[pr_AddNestedContentToDataType]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_AddNestedContentToDataType]
(
 @text nvarchar(255),
 @createDate datetime,
 @id int output
)
as
begin
           declare @Count int;
	  declare @FolderId int;
	  declare @Guid varchar (500);
	  declare @Guid1 varchar (500);
      -- exec  [dbo].[pr_AddFolderToDataTypes] @trashed,@parentID,@nodeUser,@level,@path, @sortOrder,@uniqueID,@text, @createDate,@id

	   select  @Count = count(*) from [dbo].[umbracoNode] where [text] = 'NC'

	   if @Count > 0 
			begin
			   select @FolderId = [id] from [dbo].[umbracoNode] where [text] = 'NC'
			end
		else	
			begin
		       	SET @Guid = NEWID()
				exec [dbo].[pr_AddFolderToDataTypes] 0,-1,0,1,'-1',0,@Guid,'NC',@createDate, @FolderId output
			end
		set @Guid1 = NEWID();
       insert into [dbo].[umbracoNode] (
       [trashed]
      ,[parentID]
      ,[nodeUser]
      ,[level]
      ,[path]
      ,[sortOrder]
      ,[uniqueID]
      ,[text]
      ,[nodeObjectType]
      ,[createDate])
	  values (0,@FolderId,1,1,'-1',0,@Guid1,@text,'30A2A501-1978-4DDB-A57B-F7EFED43BA3C',@createDate);

	  set @id = SCOPE_IDENTITY();

	  update [dbo].[umbracoNode] 
	  set [path] = '-1,' + CAST(@FolderId as varchar(16)) + ',' + CAST(@id as varchar(16)) 
	  where [id] = @id;


	   insert into [Vega.Welibor].[dbo].[cmsDataType] (
	    [nodeId],
		[propertyEditorAlias],
        [dbType])
	   values  (@id,'Our.Umbraco.NestedContent','Ntext')
end
GO
/****** Object:  StoredProcedure [dbo].[pr_ExistDataType]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[pr_ExistDataType]
(
@Text varchar (50),
@Count int out
)
as
begin
    SELECT @Count = COUNT(*) from [dbo].[umbracoNode] where [text] =  @Text
end 

GO
/****** Object:  StoredProcedure [dbo].[pr_GetIdDataTypeByText]    Script Date: 5/26/2017 1:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_GetIdDataTypeByText]
(
@Text varchar (50),
@Id int output
)
as
begin
    SELECT @Id = id from [dbo].[umbracoNode] where [text] =  @Text
end 
GO
