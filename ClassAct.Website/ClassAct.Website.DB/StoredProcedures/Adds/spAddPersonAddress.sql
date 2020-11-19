CREATE PROCEDURE [dbo].[spAddPersonAddress]
	@UserID uniqueidentifier,
	@AddressID uniqueidentifier,
	@StreetAddress varchar(255),
	@City varchar(255),
	@State varchar (255),
	@Zip varchar (255),
	@Description varchar(255)

AS
insert into tblAddress 
	values (@AddressID,  @StreetAddress, @City, @State, @zip)


	insert into tblPersonAddress
	values (@UserID, @AddressID, @Description)

RETURN 0
