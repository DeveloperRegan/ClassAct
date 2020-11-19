CREATE PROCEDURE [dbo].spDoesCuisineExistInPersonCuisineTable
	@CuisineID uniqueidentifier,
	@PersonID uniqueidentifier
AS
	SELECT * from tblPersonCuisine pc
	where pc.CuisineID = @CuisineID and pc.PersonID= @PersonID
RETURN 0
