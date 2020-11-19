CREATE PROCEDURE [dbo].[spLoadResturantsByLocationFeatureID]
	@city varchar(255),
	@state varchar(255),
	@FeatureID  uniqueidentifier
AS
	SELECT * from tblResturant r 
	join tblAddress a on r.AddressID = a.AddressID
	join tblResturantFeatures rf on rf.ResturantID = r.ResturantID
	join tblFeatures f on rf.FeatureID = f.FeatureID
	where a.City = @city and a.State = @state  and f.FeatureID = @FeatureID

RETURN 0
