CREATE PROCEDURE [dbo].[spLoadRatingsByUser]
	@userID uniqueidentifier
AS
	SELECT * from tblResturantRating rr
	where rr.UserID = @userID
RETURN 0
