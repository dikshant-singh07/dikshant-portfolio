using System.Data;
using Microsoft.Data.SqlClient;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public class ExperienceRepository : IExperienceRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ExperienceRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<ExperienceDto>> GetExperiencesAsync()
    {
        var experiences = new List<ExperienceDto>();

        await using SqlConnection connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using SqlCommand command = new(
            "dbo.usp_Experience_GetAll",
            connection);

        command.CommandType = CommandType.StoredProcedure;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            experiences.Add(new ExperienceDto
            {
                ExperienceId = reader.GetInt32(
                    reader.GetOrdinal("ExperienceId")),

                Company = reader.GetString(
                    reader.GetOrdinal("Company")),

                JobTitle = reader.GetString(
                    reader.GetOrdinal("JobTitle")),

                Location = reader.IsDBNull(
                    reader.GetOrdinal("Location"))
                    ? null
                    : reader.GetString(
                        reader.GetOrdinal("Location")),

                StartDate = reader.GetDateTime(
                    reader.GetOrdinal("StartDate")),

                EndDate = reader.IsDBNull(
                    reader.GetOrdinal("EndDate"))
                    ? null
                    : reader.GetDateTime(
                        reader.GetOrdinal("EndDate")),

                IsCurrent = reader.GetBoolean(
                    reader.GetOrdinal("IsCurrent")),

                Description = reader.GetString(
                    reader.GetOrdinal("Description"))
            });
        }

        return experiences;
    }
}