CREATE PROCEDURE [dbo].[spAddRecommendation]
	@UserID uniqueidentifier,
	@ResturantID uniqueidentifier,
	@BatchID uniqueidentifier,
	@LocationDescription varchar(255)
AS
	insert into tblRecommendation (Id, UserID, ResturantID, BatchID, LocationDescription) values
	(NEWID(), @UserID, @ResturantID, @BatchID,@LocationDescription)
RETURN 0
