CREATE PROCEDURE [dbo].[spAddFeaturetoFeatureTable]
	@Feature varchar(255)
AS
	insert into tblFeatures(FeatureID,FeatureDescription)
	values (NEWID(),@Feature)
RETURN 0
