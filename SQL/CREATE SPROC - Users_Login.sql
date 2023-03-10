USE [scottlampron]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetById]    Script Date: 3/3/2023 11:19:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Users_Login]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(20),
	@Password nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


select * from [dbo].[Users] u
join [dbo].[Roles] r 
on u.RoleId = r.RoleId
where username = @Username and password = @Password

END
