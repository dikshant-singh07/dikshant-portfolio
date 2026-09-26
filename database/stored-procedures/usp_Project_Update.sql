USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Project_Update
    @ProjectId INT,
    @Title NVARCHAR(150),
    @Description NVARCHAR(1000),
    @GithubUrl NVARCHAR(500) = NULL,
    @LiveUrl NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Projects
    SET
        Title = @Title,
        Description = @Description,
        GithubUrl = @GithubUrl,
        LiveUrl = @LiveUrl
    WHERE ProjectId = @ProjectId;

    IF @@ROWCOUNT = 0
    BEGIN
        RETURN;
    END;

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