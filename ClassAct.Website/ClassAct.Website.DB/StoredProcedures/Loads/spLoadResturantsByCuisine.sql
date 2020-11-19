CREATE PROCEDURE [dbo].[spLoadResturantsByCuisine]
	@CuisineID uniqueidentifier
	
AS
	select r.ResturantName, r.ResturantID, r.ResturantPhoneNumber,r.ResturantImagePath,
	a.StreetAddress, a.City, a.State, a.ZipCode, cr.Rating
	from tblCuisineResturant cr
	join tblResturant r on r.ResturantID = cr.ResturantID
	join tblAddress a on r.AddressID = a.AddressID
	where cr.CuisineID = @CuisineID
	order  by cr.Rating desc

RETURN 0
