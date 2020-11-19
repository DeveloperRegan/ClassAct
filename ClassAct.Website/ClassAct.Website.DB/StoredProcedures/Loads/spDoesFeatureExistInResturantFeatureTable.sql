CREATE PROCEDURE [dbo].[spDoesFeatureExistInResturantFeatureTable]
	@FeatureID uniqueidentifier,
	@ResturantID uniqueidentifier
AS
	select * from tblResturantFeatures
	where FeatureID = @FeatureID and ResturantID = @ResturantID
RETURN 0
