USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Technology_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        TechnologyId,
        Name,
        Category
    FROM dbo.Technologies
    ORDER BY TechnologyId;
END;
GO