USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Project_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ProjectId,
        Title,
        Description,
        GithubUrl,
        LiveUrl
    FROM dbo.Projects
    ORDER BY ProjectId;
END;
GO