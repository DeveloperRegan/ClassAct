CREATE PROCEDURE [dbo].[spLoadRestaurantsByCuisineLocation]
	@Cuisine varchar(255),
	@City varchar(100),
	@State varchar(2)
	
AS
	select r.ResturantName, r.ResturantID, r.ResturantPhoneNumber,r.ResturantImagePath, a.AddressID,
	a.StreetAddress, a.City, a.State, a.ZipCode, c.CuisineDescription
	from tblResturant r
		join tblAddress a on r.AddressID = a.AddressID
		join tblCuisineResturant cr on r.ResturantID = cr.ResturantID
		join tblCuisine c on cr.CuisineID = c.CuisineID
	where c.CuisineDescription = @Cuisine AND
		  (a.City = @City AND a.State = @State)
