CREATE TABLE [dbo].[tblCuisine] (
    [CuisineID]          UNIQUEIDENTIFIER           NOT NULL,
    [CuisineDescription] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([CuisineID] ASC)
);
