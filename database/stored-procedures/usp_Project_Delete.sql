USE PortfolioDb;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Project_Delete
    @ProjectId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Projects
    WHERE ProjectId = @ProjectId;

    SELECT @@ROWCOUNT AS RowsAffected;
END;
GO