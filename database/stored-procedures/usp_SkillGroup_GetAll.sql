USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_SkillGroup_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        sg.SkillGroupId,
        sg.Name AS SkillGroupName,
        sg.GroupType,
        sg.DisplayOrder AS GroupDisplayOrder,

        s.SkillId,
        s.Name AS SkillName,
        sgs.SkillType,
        sgs.DisplayOrder AS SkillDisplayOrder,

        t.TechnologyId,
        t.Name AS TechnologyName,
        sgt.TechnologyType,
        sgt.DisplayOrder AS TechnologyDisplayOrder

    FROM dbo.SkillGroups AS sg

    LEFT JOIN dbo.SkillGroupSkills AS sgs
        ON sg.SkillGroupId = sgs.SkillGroupId

    LEFT JOIN dbo.Skills AS s
        ON sgs.SkillId = s.SkillId

    LEFT JOIN dbo.SkillGroupTechnologies AS sgt
        ON sg.SkillGroupId = sgt.SkillGroupId

    LEFT JOIN dbo.Technologies AS t
        ON sgt.TechnologyId = t.TechnologyId

    ORDER BY
        sg.DisplayOrder,
        sgs.DisplayOrder,
        sgt.DisplayOrder;
END;
GO