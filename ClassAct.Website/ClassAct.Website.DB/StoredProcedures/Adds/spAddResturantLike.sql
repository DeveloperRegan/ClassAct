CREATE PROCEDURE [dbo].[spAddResturantLike]
	@UserID Uniqueidentifier,
	@resturantID Uniqueidentifier
AS
	insert into tblResturantRating (ResturantID, UserID, Rating, Date) values 
	(@resturantID, @UserID, 1, GETDATE())
RETURN 0
