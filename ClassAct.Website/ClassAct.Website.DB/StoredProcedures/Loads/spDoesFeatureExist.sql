CREATE PROCEDURE [dbo].[spDoesFeatureExist]
	@FeatureDescription varchar(255)
AS
	SELECT * from tblFeatures f
	where f.FeatureDescription = @FeatureDescription
RETURN 0
