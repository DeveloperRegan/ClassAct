CREATE TABLE [dbo].[tblMeal] (
    [PersonID]    UNIQUEIDENTIFIER        NOT NULL,
    [ResturantID] UNIQUEIDENTIFIER        NOT NULL,
    [CuisineID]   UNIQUEIDENTIFIER        NOT NULL,
    [Date]        DATE       NOT NULL,
    [Rating]      FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([CuisineID] ASC, [Date] ASC, [ResturantID] ASC, [PersonID] ASC),
    FOREIGN KEY ([PersonID]) REFERENCES [dbo].[tblPerson] ([PersonID]),
    FOREIGN KEY ([ResturantID]) REFERENCES [dbo].[tblResturant] ([ResturantID]),
    FOREIGN KEY ([CuisineID]) REFERENCES [dbo].[tblCuisine] ([CuisineID])
);

