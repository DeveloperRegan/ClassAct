CREATE PROCEDURE [dbo].[spLoadResturantByFeatureLocation]
	@city varchar(255),
	@state varchar(255),
	@FeatureDescription  varchar(255) 
AS
	SELECT * from tblResturant r 
	join tblAddress a on r.AddressID = a.AddressID
	join tblResturantFeatures rf on rf.ResturantID = r.ResturantID
	join tblFeatures f on rf.FeatureID = f.FeatureID
	where a.City = @city and a.State = @state  and f.FeatureDescription = @FeatureDescription

RETURN 0
