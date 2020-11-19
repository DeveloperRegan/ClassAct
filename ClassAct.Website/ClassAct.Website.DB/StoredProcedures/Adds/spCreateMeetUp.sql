CREATE PROCEDURE [dbo].[spCreateMeetUp]
	@UserID uniqueidentifier, @MeetUpID uniqueidentifier, @meetupCode varchar(255)
AS
	insert into tblMeetUp (CreatorID, MeetUpID) values (@UserID, @MeetUpID);

	insert into tblMeetUpInvitation (MeetUpID, MeetUpCode) values (@MeetUpID, @meetupCode)
RETURN 0
