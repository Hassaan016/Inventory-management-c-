CREATE TABLE [dbo].[purchase_master] (
    [id]                 INT          NOT NULL IDENTITY,
    [product_name]       VARCHAR (50) NULL,
    [product_quantity]   VARCHAR (50) NULL,
    [product_unit]       VARCHAR (50) NULL,
    [product_price]      VARCHAR (50) NULL,
    [product_total]      VARCHAR (50) NULL,
    [product_date]       VARCHAR (50) NULL,
    [product_party_name] VARCHAR (50) NULL,
    [purchase_type]      VARCHAR (50) NULL,
    [expiry_date]        VARCHAR (50) NULL,
    [profit]             VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

