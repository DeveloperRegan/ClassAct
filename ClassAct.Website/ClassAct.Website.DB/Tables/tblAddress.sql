CREATE TABLE [dbo].[tblAddress] (
    [AddressID]     UNIQUEIDENTIFIER           NOT NULL,
    [StreetAddress] VARCHAR (255) NOT NULL,
    [City]          VARCHAR (100) NOT NULL,
    [State]         VARCHAR (2)   NOT NULL,
    [ZipCode]       VARCHAR (10)  NOT NULL,
    [Latitude] FLOAT NULL, 
    [Longitude] FLOAT NULL, 
    [GooglePlaceID] VARCHAR(255) NULL, 
    PRIMARY KEY CLUSTERED ([AddressID] ASC)
);