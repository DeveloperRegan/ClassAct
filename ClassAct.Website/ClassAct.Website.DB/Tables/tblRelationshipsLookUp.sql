CREATE TABLE [dbo].[tblRelationshipsLookUp] (
    [RelationshipTypeID] UNIQUEIDENTIFIER           NOT NULL,
    [Description]        VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([RelationshipTypeID] ASC)
);

