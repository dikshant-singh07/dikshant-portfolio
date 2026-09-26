USE PortfolioDb;
GO

/* =========================================
   Technologies
   ========================================= */

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'SQL'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'SQL', N'Language');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'C#'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'C#', N'Language');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'Python'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'Python', N'Language');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'SQL Server'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'SQL Server', N'Database');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'MySQL'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'MySQL', N'Database');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'.NET'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'.NET', N'Framework');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'Angular'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'Angular', N'Framework');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Technologies
    WHERE Name = N'Power BI'
)
BEGIN
    INSERT INTO dbo.Technologies (Name, Category)
    VALUES (N'Power BI', N'BI Tool');
END;
GO


/* =========================================
   Skills
   ========================================= */

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Skills
    WHERE Name = N'Database Design'
)
BEGIN
    INSERT INTO dbo.Skills (Name)
    VALUES (N'Database Design');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Skills
    WHERE Name = N'SQL Querying'
)
BEGIN
    INSERT INTO dbo.Skills (Name)
    VALUES (N'SQL Querying');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Skills
    WHERE Name = N'Data Analysis'
)
BEGIN
    INSERT INTO dbo.Skills (Name)
    VALUES (N'Data Analysis');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Skills
    WHERE Name = N'REST API Development'
)
BEGIN
    INSERT INTO dbo.Skills (Name)
    VALUES (N'REST API Development');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Skills
    WHERE Name = N'Backend Development'
)
BEGIN
    INSERT INTO dbo.Skills (Name)
    VALUES (N'Backend Development');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Skills
    WHERE Name = N'Frontend Development'
)
BEGIN
    INSERT INTO dbo.Skills (Name)
    VALUES (N'Frontend Development');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Skills
    WHERE Name = N'Problem Solving'
)
BEGIN
    INSERT INTO dbo.Skills (Name)
    VALUES (N'Problem Solving');
END;
GO


/* =========================================
   Project
   ========================================= */

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Projects
    WHERE Title = N'Online Retail Sales Database'
)
BEGIN
    INSERT INTO dbo.Projects
    (
        Title,
        Description,
        GithubUrl,
        LiveUrl
    )
    VALUES
    (
        N'Online Retail Sales Database',
        N'A normalized SQL database designed for managing online retail sales, products, customers, orders, and related business data.',
        N'https://github.com/dikshant-singh07/Online-Retail-Sales-Database-Design',
        NULL
    );
END;
GO


/* =========================================
   Project → Technologies
   ========================================= */

INSERT INTO dbo.ProjectTechnologies
(
    ProjectId,
    TechnologyId
)
SELECT
    p.ProjectId,
    t.TechnologyId
FROM dbo.Projects p
CROSS JOIN dbo.Technologies t
WHERE p.Title = N'Online Retail Sales Database'
  AND t.Name IN
  (
      N'SQL',
      N'MySQL'
  )
  AND NOT EXISTS
  (
      SELECT 1
      FROM dbo.ProjectTechnologies pt
      WHERE pt.ProjectId = p.ProjectId
        AND pt.TechnologyId = t.TechnologyId
  );
GO


/* =========================================
   Project → Skills
   ========================================= */

INSERT INTO dbo.ProjectSkills
(
    ProjectId,
    SkillId
)
SELECT
    p.ProjectId,
    s.SkillId
FROM dbo.Projects p
CROSS JOIN dbo.Skills s
WHERE p.Title = N'Online Retail Sales Database'
  AND s.Name IN
  (
      N'Database Design',
      N'SQL Querying',
      N'Data Analysis'
  )
  AND NOT EXISTS
  (
      SELECT 1
      FROM dbo.ProjectSkills ps
      WHERE ps.ProjectId = p.ProjectId
        AND ps.SkillId = s.SkillId
  );
GO