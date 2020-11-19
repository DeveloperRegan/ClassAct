CREATE PROCEDURE [dbo].[spLoadResturantsbyFeatureID]
	@FeatureID uniqueidentifier
AS
	SELECT * from tblResturant r join tblResturantFeatures rf on r.ResturantID = rf.ResturantID
	where rf.FeatureID = @FeatureID
RETURN 0
