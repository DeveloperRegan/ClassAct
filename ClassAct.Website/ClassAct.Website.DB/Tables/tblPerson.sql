CREATE TABLE [dbo].[tblPerson] (
    [PersonID]        UNIQUEIDENTIFIER           NOT NULL,
    [PersonsEmail]    VARCHAR (255) NOT NULL unique,
    [PersonsUserName] VARCHAR (255) NOT NULL unique,
    [PersonsPassword] VARCHAR (255) NOT NULL,
    [PersonFirstName] VARCHAR (255) NULL,
    [PersonLastName]  VARCHAR (255) NULL,
    [PersonDOB]       DATE          NULL,
    [Role] VARCHAR(255) NULL, 
    [Image] IMAGE NULL, 
    [PersonsSelf] VARCHAR(255) NULL, 
    PRIMARY KEY CLUSTERED ([PersonID] ASC)
);