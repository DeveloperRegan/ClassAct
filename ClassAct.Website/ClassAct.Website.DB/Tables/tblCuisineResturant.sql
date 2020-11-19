CREATE TABLE [dbo].[tblCuisineResturant] (
    [ResturantID] UNIQUEIDENTIFIER        NOT NULL,
    [CuisineID]   UNIQUEIDENTIFIER        NOT NULL,
    [Rating]      FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([ResturantID] ASC, [CuisineID] ASC),
    FOREIGN KEY ([ResturantID]) REFERENCES [dbo].[tblResturant] ([ResturantID]),
    FOREIGN KEY ([CuisineID]) REFERENCES [dbo].[tblCuisine] ([CuisineID])
);