USE [MMTShop]
GO

/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 01/04/2021 20:50:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetProducts] 
	@categoryId int null,
	@featured bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	if (@categoryId is null and @featured = null) 
		begin
			select * from Product
		end
	else if(@categoryId is not null and @featured is null) 	
		begin
			select * from Product where CategoryId = @categoryId
		end
	else if(@categoryId is null and @featured is not null) 	
		begin
			select * from Product where Featured = @featured
		end
	else	
		begin
			select * from Product where CategoryId = @categoryId and Featured = @featured
		end
END
GO


