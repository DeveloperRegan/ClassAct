CREATE PROCEDURE [dbo].[spDoesCuisineExistInCuisineResturantbyNAme]
	@CuisineName varchar(255),
	@resturantID uniqueidentifier
AS
	SELECT * from tblCuisineResturant cr
	join tblCuisine c on cr.CuisineID = c.CuisineID
	where c.CuisineDescription = @CuisineName and cr.ResturantID = @resturantID
RETURN 0
