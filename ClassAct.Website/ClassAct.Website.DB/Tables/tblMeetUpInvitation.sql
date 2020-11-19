CREATE TABLE [dbo].[tblMeetUpInvitation]
(
	[InviationID] UNIQUEIDENTIFIER not NULL Primary Key,
	[MeetUpID] UNIQUEIDENTIFIER NOT NULL , 
    [ReciverUserID] UNIQUEIDENTIFIER NULL, 
    [StartTime] DATETIME NULL, 
    [Endtime] DATETIME NULL, 
    [LikelinessOfAttending] FLOAT NULL, 
    [MeetUpCode] VARCHAR(55) NOT NULL, 
	[IsAttending] bit
)
