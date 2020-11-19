CREATE TABLE [dbo].[tblPersonRelationship] (
    [MainPersonID]       UNIQUEIDENTIFIER NOT NULL,
    [SecondPersonID]     UNIQUEIDENTIFIER NOT NULL,
    [RelationshipTypeID] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([MainPersonID] ASC, [SecondPersonID] ASC, [RelationshipTypeID] ASC),
    FOREIGN KEY ([MainPersonID]) REFERENCES [dbo].[tblPerson] ([PersonID]),
    FOREIGN KEY ([SecondPersonID]) REFERENCES [dbo].[tblPerson] ([PersonID]),
    FOREIGN KEY ([RelationshipTypeID]) REFERENCES [dbo].[tblRelationshipsLookUp] ([RelationshipTypeID])
);

