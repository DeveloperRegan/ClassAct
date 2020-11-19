CREATE PROCEDURE [dbo].[spDoesCuisineExisitInResturantCuisine]
	@RestID uniqueidentifier,
	@CuisineID uniqueidentifier
AS
	SELECT * from tblCuisineResturant
	where ResturantID= @RestID and CuisineID = @CuisineID
RETURN 0
