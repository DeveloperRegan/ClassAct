CREATE TABLE [dbo].[tblPersonCuisine] (
    [PersonID]  UNIQUEIDENTIFIER        NOT NULL,
    [CuisineID] UNIQUEIDENTIFIER        NOT NULL,
    [Rating]    FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonID] ASC, [CuisineID] ASC),
    FOREIGN KEY ([PersonID]) REFERENCES [dbo].[tblPerson] ([PersonID]),
    FOREIGN KEY ([CuisineID]) REFERENCES [dbo].[tblCuisine] ([CuisineID])
);

