CREATE PROCEDURE [dbo].[spLoadResturantsbyCuisineID]
	@CuisineID uniqueidentifier
	
AS
	SELECT * from tblResturant r 
	join tblCuisineResturant cr
	on cr.ResturantID = r.ResturantID
	where cr.CuisineID = @CuisineID

RETURN 0
