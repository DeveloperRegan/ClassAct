CREATE PROCEDURE [dbo].[spLoadRestutrantByLongLat]
	@RestName varchar(255),
	@Latitude float,
	@long float
AS
	SELECT * from tblAddress a 
	join tblResturant r on a.AddressID= r.AddressID
	where a.Longitude =@long and a.Latitude=@Latitude and r.ResturantName = @RestName
RETURN 0
