CREATE TABLE [dbo].[tblResturant] (
    [ResturantID]        UNIQUEIDENTIFIER           NOT NULL,
    [AddressID]          UNIQUEIDENTIFIER           NOT NULL,
    [ResturantName]      VARCHAR (255) NOT NULL,
    [ResturantImagePath] VARCHAR (255) NULL,
    [ResturantPhoneNumber] VARCHAR(20) NULL, 
    [ResturantHours] VARCHAR(255) NULL, 
    [ResturantWebsite] VARCHAR(255) NULL, 
    PRIMARY KEY CLUSTERED ([ResturantID] ASC)
);