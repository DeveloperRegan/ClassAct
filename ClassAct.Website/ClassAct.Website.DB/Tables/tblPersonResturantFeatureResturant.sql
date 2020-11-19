CREATE TABLE [dbo].[tblPersonResturantFeatureResturant] (
    [PersonID]    UNIQUEIDENTIFIER        NOT NULL,
    [ResturantID] UNIQUEIDENTIFIER        NOT NULL,
    [FeatureID]   UNIQUEIDENTIFIER        NOT NULL,
    [Date]        DATE       NOT NULL,
    [RATING]      FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonID] ASC, [ResturantID] ASC, [FeatureID] ASC, [Date] ASC),
    FOREIGN KEY ([PersonID]) REFERENCES [dbo].[tblPerson] ([PersonID]),
    FOREIGN KEY ([ResturantID]) REFERENCES [dbo].[tblResturant] ([ResturantID]),
    FOREIGN KEY ([FeatureID]) REFERENCES [dbo].[tblFeatures] ([FeatureID])
);