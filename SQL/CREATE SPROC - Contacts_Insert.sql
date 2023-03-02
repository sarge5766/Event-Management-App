-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.Contacts_Insert
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(25)
	,@LastName nvarchar(25)
	,@Email nvarchar(35)
	,@MobileNumber nvarchar(20)
	,@Address nvarchar(35)
	,@City nvarchar(25)
	,@Zipcode nvarchar(10)
	,@BloodType int
	,@ReferredBy int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
INSERT INTO [dbo].[Contacts]
values
           (@FirstName,
		   @LastName
           ,@Email
           ,@MobileNumber
           ,@Address
           ,@City
           ,@Zipcode
           ,@BloodType
           ,@ReferredBy)
    
END
GO
