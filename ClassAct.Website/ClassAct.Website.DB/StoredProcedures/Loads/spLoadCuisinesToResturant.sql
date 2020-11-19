CREATE PROCEDURE [dbo].[spLoadCuisinesToResturant]
	@ResturantID uniqueidentifier
AS
	SELECT 
	c.CuisineDescription, cr.Rating
	from tblCuisineResturant cr
	join tblCuisine c on cr.CuisineID = c.CuisineID
	where cr.ResturantID = ResturantID
RETURN 0

