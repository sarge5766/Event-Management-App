USE [scottlampron]
GO
/****** Object:  StoredProcedure [dbo].[Contacts_GetById]    Script Date: 3/7/2023 10:44:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE [dbo].[Contacts_GetContactEvents]
	-- Add the parameters for the stored procedure here
	@ContactId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
select e.name, e.eventdate, e.eventid from [dbo].[EventMapper] em
join [dbo].[Events] e on e.eventid = em.EventId
where contactid = @ContactId


END
