CREATE PROCEDURE [dbo].[spAddCuisineToCuisineTable]
	@CuisineDescription varchar(255)
AS
	insert into tblCuisine(CuisineID, CuisineDescription) 
	values (NEWID(), @CuisineDescription)
RETURN 0
