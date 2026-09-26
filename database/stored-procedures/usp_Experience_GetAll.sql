USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Experience_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ExperienceId,
        Company,
        JobTitle,
        Location,
        StartDate,
        EndDate,
        IsCurrent,
        Description
    FROM dbo.Experience
    ORDER BY StartDate DESC;
END;
GO