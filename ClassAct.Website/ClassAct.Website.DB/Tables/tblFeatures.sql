CREATE TABLE [dbo].[tblFeatures] (
    [FeatureID]          UNIQUEIDENTIFIER           NOT NULL,
    [FeatureDescription] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([FeatureID] ASC)
);