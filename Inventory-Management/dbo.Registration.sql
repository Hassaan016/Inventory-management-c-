CREATE TABLE [dbo].[registration] (
    [id]        INT            NOT NULL IDENTITY,
    [firstname] VARCHAR (50)   NULL,
    [lastname]  VARCHAR(50) NULL,
    [username]  VARCHAR (50)   NULL,
    [password]  VARCHAR (50)   NULL,
    [contact]   VARCHAR (50)   NULL,
    [email]     VARCHAR (50)   NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

