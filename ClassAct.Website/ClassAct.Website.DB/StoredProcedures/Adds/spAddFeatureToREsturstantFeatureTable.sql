CREATE PROCEDURE [dbo].[spAddFeatureToREsturstantFeatureTable]
	@FeatureID uniqueidentifier,
	@ResturantID uniqueidentifier
AS
	insert into tblResturantFeatures (ResturantID, FeatureID,Rating) values (@ResturantID, @FeatureID,1)
RETURN 0
