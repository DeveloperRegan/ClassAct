CREATE PROCEDURE [dbo].[spAddCuisineRatingToResturant]
@CuisineID uniqueidentifier,
@resturantID uniqueidentifier,
@userid uniqueidentifier

AS
	insert into tblMeal (CuisineID,ResturantID,PersonID,Date,Rating) 
	values (@CuisineID, @resturantID, @userid, GETDATE(), 1)

RETURN 0
