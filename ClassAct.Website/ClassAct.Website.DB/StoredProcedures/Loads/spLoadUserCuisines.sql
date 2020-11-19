CREATE PROCEDURE [dbo].[spLoadUserCuisines]
	@UserID uniqueidentifier
AS
	select pc.CuisineID, pc.Rating, c.CuisineDescription 
	from tblPersonCuisine pc
	join tblPerson p on p.PersonID = pc.PersonID
	join tblCuisine c on pc.CuisineID = c.CuisineID
	where p.PersonID = @UserID
	order by pc.Rating

RETURN 0
