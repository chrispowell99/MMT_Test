USE [MMTShop]
GO

/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 01/04/2021 20:49:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetCategories] 
	@categoryId int null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	if (@categoryId is null) 
		begin
			select * from Category
		end
	else	
		begin
			select * from Category where Id = @categoryId
		end
END
GO


