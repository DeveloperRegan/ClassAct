CREATE PROCEDURE [dbo].[spLoadMeetUpInvitationsByUser]
	@UserID Uniqueidentifier
AS
	SELECT m.Description, i.MeetUpCode, i.StartTime, i.Endtime, m.CreatorID from tblMeetUpInvitation i
join tblMeetUp m on m.MeetUpID = i.MeetUpID
	where ReciverUserID =@UserID or m.CreatorID= @UserID
RETURN 0
