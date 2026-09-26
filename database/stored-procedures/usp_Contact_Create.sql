USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Contact_Create
    @Name NVARCHAR(100),
    @Email NVARCHAR(254),
    @Subject NVARCHAR(200) = NULL,
    @Message NVARCHAR(2000)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.ContactMessages
    (
        Name,
        Email,
        Subject,
        Message
    )
    VALUES
    (
        @Name,
        @Email,
        @Subject,
        @Message
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS ContactMessageId;
END;
GO