CREATE PROCEDURE [dbo].[spUpdateUserCuisineRating]
	@UserID uniqueidentifier,
	@CuisineID uniqueidentifier,
	@NewRating float
AS
	update tblPersonCuisine 
	set Rating = @NewRating
	where PersonID = @UserID
	and CuisineID = @CuisineID

RETURN 0
