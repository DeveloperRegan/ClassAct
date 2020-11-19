CREATE TABLE [dbo].[tblResturantFeatures] (
    [ResturantID] UNIQUEIDENTIFIER        NOT NULL,
    [FeatureID]   UNIQUEIDENTIFIER        NOT NULL,
    [Rating]      FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([ResturantID] ASC, [FeatureID] ASC),
    FOREIGN KEY ([ResturantID]) REFERENCES [dbo].[tblResturant] ([ResturantID]),
    FOREIGN KEY ([FeatureID]) REFERENCES [dbo].[tblFeatures] ([FeatureID])
);

