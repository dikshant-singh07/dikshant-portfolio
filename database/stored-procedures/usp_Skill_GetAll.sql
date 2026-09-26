USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Skill_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SkillId,
        Name
    FROM dbo.Skills
    ORDER BY SkillId;
END;
GO