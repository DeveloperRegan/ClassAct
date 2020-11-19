CREATE PROCEDURE [dbo].[spDoesCuisineExist]
	@cuisineName varchar(255)
AS
	SELECT * from tblCuisine c
	where c.CuisineDescription = @cuisineName
RETURN 0
