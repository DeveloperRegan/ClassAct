CREATE TABLE [dbo].[tblPersonAddress] (
    [PersonID]           UNIQUEIDENTIFIER           NOT NULL,
    [AddressID]          UNIQUEIDENTIFIER           NOT NULL,
    [AddressDescription] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonID] ASC, [AddressID] ASC),
    FOREIGN KEY ([PersonID]) REFERENCES [dbo].[tblPerson] ([PersonID]),
    FOREIGN KEY ([AddressID]) REFERENCES [dbo].[tblAddress] ([AddressID])
);