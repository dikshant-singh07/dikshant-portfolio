using Microsoft.Data.SqlClient;
using Portfolio.Api.DTOs;
using System.Data;

namespace Portfolio.Api.Data;

public class ProjectRepository : IProjectRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ProjectRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

public async Task<List<ProjectDto>> GetProjectsAsync()
{
    var projects = new List<ProjectDto>();

    await using SqlConnection connection = _connectionFactory.CreateConnection();
    await connection.OpenAsync();

    await using SqlCommand command = new(
        "dbo.usp_Project_GetAll",
        connection);

    command.CommandType = CommandType.StoredProcedure;

    await using SqlDataReader reader = await command.ExecuteReaderAsync();

    while (await reader.ReadAsync())
    {
        projects.Add(new ProjectDto
        {
            Id = reader.GetInt32(reader.GetOrdinal("ProjectId")),
            Title = reader.GetString(reader.GetOrdinal("Title")),
            Description = reader.GetString(reader.GetOrdinal("Description")),
            GithubUrl = reader.IsDBNull(reader.GetOrdinal("GithubUrl"))
                ? null
                : reader.GetString(reader.GetOrdinal("GithubUrl")),
            LiveUrl = reader.IsDBNull(reader.GetOrdinal("LiveUrl"))
                ? null
                : reader.GetString(reader.GetOrdinal("LiveUrl"))
        });
    }

    return projects;
}

public async Task<ProjectDto?> GetProjectByIdAsync(int projectId)
{
    await using SqlConnection connection = _connectionFactory.CreateConnection();
    await connection.OpenAsync();

    await using SqlCommand command = new(
        "dbo.usp_Project_GetById",
        connection);

    command.CommandType = CommandType.StoredProcedure;

    command.Parameters.Add(
        new SqlParameter("@ProjectId", projectId));

    await using SqlDataReader reader = await command.ExecuteReaderAsync();

    if (!await reader.ReadAsync())
    {
        return null;
    }

    return new ProjectDto
    {
        Id = reader.GetInt32(reader.GetOrdinal("ProjectId")),
        Title = reader.GetString(reader.GetOrdinal("Title")),
        Description = reader.GetString(reader.GetOrdinal("Description")),
        GithubUrl = reader.IsDBNull(reader.GetOrdinal("GithubUrl"))
            ? null
            : reader.GetString(reader.GetOrdinal("GithubUrl")),
        LiveUrl = reader.IsDBNull(reader.GetOrdinal("LiveUrl"))
            ? null
            : reader.GetString(reader.GetOrdinal("LiveUrl"))
    };
}

public async Task<ProjectDto> CreateProjectAsync(CreateProjectRequest request)
{
    await using SqlConnection connection = _connectionFactory.CreateConnection();
    await connection.OpenAsync();

    await using SqlCommand command = new(
        "dbo.usp_Project_Create",
        connection);

    command.CommandType = CommandType.StoredProcedure;

    command.Parameters.Add(
        new SqlParameter("@Title", request.Title));

    command.Parameters.Add(
        new SqlParameter("@Description", request.Description));

    command.Parameters.Add(
        new SqlParameter("@GithubUrl", (object?)request.GithubUrl ?? DBNull.Value));

    command.Parameters.Add(
        new SqlParameter("@LiveUrl", (object?)request.LiveUrl ?? DBNull.Value));

    await using SqlDataReader reader = await command.ExecuteReaderAsync();

    if (!await reader.ReadAsync())
    {
        throw new InvalidOperationException(
            "The project was not created.");
    }

    return new ProjectDto
    {
        Id = reader.GetInt32(reader.GetOrdinal("ProjectId")),
        Title = reader.GetString(reader.GetOrdinal("Title")),
        Description = reader.GetString(reader.GetOrdinal("Description")),
        GithubUrl = reader.IsDBNull(reader.GetOrdinal("GithubUrl"))
            ? null
            : reader.GetString(reader.GetOrdinal("GithubUrl")),
        LiveUrl = reader.IsDBNull(reader.GetOrdinal("LiveUrl"))
            ? null
            : reader.GetString(reader.GetOrdinal("LiveUrl"))
    };
}

public async Task<ProjectDto?> UpdateProjectAsync(
    int projectId,
    UpdateProjectRequest request)
{
    await using SqlConnection connection = _connectionFactory.CreateConnection();
    await connection.OpenAsync();

    await using SqlCommand command = new(
        "dbo.usp_Project_Update",
        connection);

    command.CommandType = CommandType.StoredProcedure;

    command.Parameters.Add(
        new SqlParameter("@ProjectId", projectId));

    command.Parameters.Add(
        new SqlParameter("@Title", request.Title));

    command.Parameters.Add(
        new SqlParameter("@Description", request.Description));

    command.Parameters.Add(
        new SqlParameter(
            "@GithubUrl",
            (object?)request.GithubUrl ?? DBNull.Value));

    command.Parameters.Add(
        new SqlParameter(
            "@LiveUrl",
            (object?)request.LiveUrl ?? DBNull.Value));

    await using SqlDataReader reader = await command.ExecuteReaderAsync();

    if (!await reader.ReadAsync())
    {
        return null;
    }

    return new ProjectDto
    {
        Id = reader.GetInt32(reader.GetOrdinal("ProjectId")),
        Title = reader.GetString(reader.GetOrdinal("Title")),
        Description = reader.GetString(reader.GetOrdinal("Description")),
        GithubUrl = reader.IsDBNull(reader.GetOrdinal("GithubUrl"))
            ? null
            : reader.GetString(reader.GetOrdinal("GithubUrl")),
        LiveUrl = reader.IsDBNull(reader.GetOrdinal("LiveUrl"))
            ? null
            : reader.GetString(reader.GetOrdinal("LiveUrl"))
    };
}

}