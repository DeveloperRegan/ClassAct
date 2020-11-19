CREATE TABLE [dbo].[tblRecommendation] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [ResturantID] UNIQUEIDENTIFIER NOT NULL,
    [UserID]      UNIQUEIDENTIFIER NOT NULL,
    [BatchID]     UNIQUEIDENTIFIER NOT NULL,
    [LocationDescription] VARCHAR(255) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

