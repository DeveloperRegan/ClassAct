CREATE PROCEDURE [dbo].[spAddCuisineToUser]
	@UserID uniqueidentifier,
	@CuisineID uniqueidentifier,
	@rating float
AS
	insert into dbo.tblPersonCuisine
	values (@UserID, @CuisineID, @rating)

RETURN 0
