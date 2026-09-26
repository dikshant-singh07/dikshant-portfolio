USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Project_GetById
    @ProjectId INT
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
    WHERE ProjectId = @ProjectId;
END;
GO