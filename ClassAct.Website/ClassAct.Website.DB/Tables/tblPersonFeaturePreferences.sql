CREATE TABLE [dbo].[tblPersonFeaturePreferences] (
    [PersonID]  UNIQUEIDENTIFIER        NOT NULL,
    [FeatureID] UNIQUEIDENTIFIER        NOT NULL,
    [Rating]    FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([PersonID] ASC, [FeatureID] ASC),
    FOREIGN KEY ([PersonID]) REFERENCES [dbo].[tblPerson] ([PersonID]),
    FOREIGN KEY ([FeatureID]) REFERENCES [dbo].[tblFeatures] ([FeatureID])
);