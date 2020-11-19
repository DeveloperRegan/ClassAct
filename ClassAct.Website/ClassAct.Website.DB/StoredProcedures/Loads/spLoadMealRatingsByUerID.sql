CREATE PROCEDURE [dbo].[spLoadMealRatingsByUerID]
	@UserID uniqueidentifier
AS
	SELECT Count(m.CuisineID) as counts, m.Rating as rating, m.CuisineID, c.CuisineDescription
	from tblMeal m 
	join tblCuisine c on m.CuisineID = c.CuisineID
	where m.PersonID = @UserID
	group by m.CuisineID, m.Rating, c.CuisineDescription

	
RETURN 0
