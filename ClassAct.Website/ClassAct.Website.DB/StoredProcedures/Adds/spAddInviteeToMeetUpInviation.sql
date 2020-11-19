CREATE PROCEDURE [dbo].[spAddInviteeToMeetUpInviation]
@ReciverID uniqueidentifier, @MeetUpCode varchar(255)
AS
	update tblMeetUpInvitation 
	set ReciverUserID =@ReciverID
	where MeetUpCode = @MeetUpCode
	
RETURN 0
