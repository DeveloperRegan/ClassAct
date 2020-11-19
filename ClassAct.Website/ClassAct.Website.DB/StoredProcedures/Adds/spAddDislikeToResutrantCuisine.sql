CREATE PROCEDURE [dbo].[spAddDislikeToResutrantCuisine]
	@ResturantID uniqueidentifier,
	@UserID uniqueidentifier,
	@cuisineID uniqueidentifier
AS
	insert into tblMeal (ResturantID, CuisineID, PersonID, Date, Rating)
	values (@ResturantID, @cuisineID, @UserID, GETDATE(), -1)
RETURN 0
