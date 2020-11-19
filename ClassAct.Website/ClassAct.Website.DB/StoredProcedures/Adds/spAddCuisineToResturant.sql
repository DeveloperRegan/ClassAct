CREATE PROCEDURE [dbo].[spAddCuisineToResturant]
	@ResturantID uniqueidentifier,
	@CuisineID uniqueidentifier,
	@rating float
AS
	insert into dbo.tblCuisineResturant (ResturantID, CuisineID, Rating)
	values (@ResturantID, @CuisineID, @rating)

RETURN 0
