CREATE PROCEDURE [dbo].[spLoadRecommendationsByUserIDAndLocationDescription]
	@LocationDescription varchar(255),
	@UserID uniqueidentifier
AS
	
	select r.ResturantName, r.ResturantPhoneNumber, 
	a.StreetAddress, a.City, a.State, a.Latitude, a.Longitude
	from tblRecommendation rec
	join tblResturant r on rec.ResturantID = r.ResturantID
	join tblAddress a on r.AddressID = a.AddressID
	join tblPersonAddress pa on a.AddressID = pa.AddressID
	where pa.AddressDescription = @LocationDescription and rec.UserID = @UserID

RETURN 0
