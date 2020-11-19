CREATE PROCEDURE [dbo].[spLoadUserAddresses]
	@UserID uniqueidentifier
AS
	SELECT pa.AddressID, pa.AddressDescription, 
	a.City, a.[State], a.StreetAddress, a.ZipCode
	from tblPersonAddress pa
	join tblAddress a on a.AddressID = pa.AddressID
	where pa.PersonID = @UserID
	order by pa.AddressDescription
RETURN 0
