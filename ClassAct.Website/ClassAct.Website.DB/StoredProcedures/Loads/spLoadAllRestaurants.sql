CREATE PROCEDURE [dbo].[spLoadAllRestaurants]

AS
	select r.ResturantName, r.ResturantID, r.ResturantPhoneNumber,r.ResturantImagePath,
	a.StreetAddress, a.City, a.State, a.ZipCode
	from tblResturant r 
	join tblAddress a on r.AddressID = a.AddressID
RETURN 0
