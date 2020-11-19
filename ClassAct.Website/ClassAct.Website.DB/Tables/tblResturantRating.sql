CREATE TABLE [dbo].[tblResturantRating]
(    [ResturantID] UNIQUEIDENTIFIER NOT NULL, 
    [UserID] UNIQUEIDENTIFIER NOT NULL, 
     [Date] DATETIME NOT NULL,
	 [Rating] BIT NOT NULl, 
    CONSTRAINT PrimaryKeys UNIQUE (ResturantID, UserID, [Date])
)
