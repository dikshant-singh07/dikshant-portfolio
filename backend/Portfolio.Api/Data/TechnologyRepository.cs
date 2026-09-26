using System.Data;
using Microsoft.Data.SqlClient;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public class TechnologyRepository : ITechnologyRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TechnologyRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<TechnologyDto>> GetTechnologiesAsync()
    {
        var technologies = new List<TechnologyDto>();

        await using SqlConnection connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using SqlCommand command = new(
            "dbo.usp_Technology_GetAll",
            connection);

        command.CommandType = CommandType.StoredProcedure;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            technologies.Add(new TechnologyDto
            {
                TechnologyId = reader.GetInt32(
                    reader.GetOrdinal("TechnologyId")),
                Name = reader.GetString(
                    reader.GetOrdinal("Name")),
                Category = reader.GetString(
                    reader.GetOrdinal("Category"))
            });
        }

        return technologies;
    }
}