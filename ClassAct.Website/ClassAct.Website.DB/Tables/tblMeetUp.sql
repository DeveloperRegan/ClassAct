CREATE TABLE [dbo].[tblMeetUp]
(
	MeetUpID uniqueidentifier not null Primary Key,
   [CreatorID] UNIQUEIDENTIFIER NOT NULL,
	ResturantID uniqueidentifier,
	startTime Datetime,
	endtime datetime, 
    [Description] VARCHAR(255) NOT NULL, 
 
  
)
