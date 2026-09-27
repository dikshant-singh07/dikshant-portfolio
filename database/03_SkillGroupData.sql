USE PortfolioDb;
GO

-- Skill groups
INSERT INTO dbo.SkillGroups
(
    Name,
    GroupType,
    DisplayOrder
)
VALUES
    ('DATABASE', 'TABLE', 1),
    ('DATA ENGINEERING', 'PIPELINE', 2),
    ('BACKEND', 'SERVICE', 3),
    ('ANALYTICS', 'VISUAL', 4),
    ('FRONTEND', 'CLIENT', 5);
GO

-- Skills mapped to groups
INSERT INTO dbo.SkillGroupSkills
(
    SkillGroupId,
    SkillId,
    SkillType,
    DisplayOrder
)
VALUES
    (1, 1, 'DESIGN', 1),
    (1, 2, 'QUERY', 2),
    (4, 3, 'ANALYTICS', 1),
    (3, 4, 'API', 1),
    (3, 5, 'DEVELOPMENT', 2),
    (5, 6, 'DEVELOPMENT', 1);
GO

-- Technologies mapped to groups
INSERT INTO dbo.SkillGroupTechnologies
(
    SkillGroupId,
    TechnologyId,
    TechnologyType,
    DisplayOrder
)
VALUES
    (1, 1, 'LANGUAGE', 1),
    (1, 4, 'RDBMS', 2),
    (1, 5, 'RDBMS', 3),
    (2, 3, 'LANGUAGE', 1),
    (3, 2, 'LANGUAGE', 1),
    (3, 6, 'FRAMEWORK', 2),
    (4, 8, 'BI', 1),
    (5, 7, 'FRAMEWORK', 1);
GO