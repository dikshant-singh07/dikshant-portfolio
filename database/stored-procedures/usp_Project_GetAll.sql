USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Project_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.ProjectId,
        p.Title,
        p.Description,
        p.GithubUrl,
        p.LiveUrl,
        STRING_AGG(t.Name, ', ') AS Technologies
    FROM dbo.Projects AS p
    LEFT JOIN dbo.ProjectTechnologies AS pt
        ON p.ProjectId = pt.ProjectId
    LEFT JOIN dbo.Technologies AS t
        ON pt.TechnologyId = t.TechnologyId
    GROUP BY
        p.ProjectId,
        p.Title,
        p.Description,
        p.GithubUrl,
        p.LiveUrl
    ORDER BY p.ProjectId;
END;
GO