USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Project_Create
    @Title NVARCHAR(150),
    @Description NVARCHAR(1000),
    @GithubUrl NVARCHAR(500) = NULL,
    @LiveUrl NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Projects
    (
        Title,
        Description,
        GithubUrl,
        LiveUrl
    )
    VALUES
    (
        @Title,
        @Description,
        @GithubUrl,
        @LiveUrl
    );

    SELECT
        ProjectId,
        Title,
        Description,
        GithubUrl,
        LiveUrl
    FROM dbo.Projects
    WHERE ProjectId = SCOPE_IDENTITY();
END;
GO