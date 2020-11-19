CREATE PROCEDURE [dbo].[spDoesFeatureByNameExistInResturantFeature]
	@FeatureName varchar(255),
	@resturantID uniqueidentifier
AS
	SELECT * from  tblResturantFeatures cr
	join tblFeatures f on cr.FeatureID = f.FeatureID
	where f.FeatureDescription = @FeatureName and cr.ResturantID=@resturantID
RETURN 0
