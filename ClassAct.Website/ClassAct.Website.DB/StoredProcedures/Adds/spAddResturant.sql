CREATE PROCEDURE [dbo].[spAddResturant]
	@ResturantName varchar(255),
	@ResturantPhoneNumber varchar(20),
	@ResturantStreetAddress varchar(255),
	@ResturantCity varchar(255),
	@ResturantState varchar (255),
	@ResturantZip varChar (255),
	@AddressID Uniqueidentifier,
	@ResturantID Uniqueidentifier,
	@ResturantImagePath varchar (255),
	@Lat float,
	@long float,
	@website varchar(255),
	@hours varchar(255)

AS
	insert into dbo.tblAddress (AddressID,StreetAddress, City, State, ZipCode, Longitude, Latitude)
	values (@AddressID,
			@ResturantStreetAddress, 
			@ResturantCity, 
			@ResturantState,
			@ResturantZip,
			@long,
			@Lat)

insert into dbo.tblResturant (ResturantID, AddressID, ResturantName, ResturantImagePath, ResturantPhoneNumber,
ResturantHours, ResturantWebsite)
	values (@ResturantID,
	@AddressID,
	@ResturantName,
	@ResturantImagePath,
	@ResturantPhoneNumber,
	@hours,
	@website
	)

RETURN 0