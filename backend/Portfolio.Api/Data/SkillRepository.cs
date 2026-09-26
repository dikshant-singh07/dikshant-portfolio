using System.Data;
using Microsoft.Data.SqlClient;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public class SkillRepository : ISkillRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public SkillRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<SkillDto>> GetSkillsAsync()
    {
        var skills = new List<SkillDto>();

        await using SqlConnection connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using SqlCommand command = new(
            "dbo.usp_Skill_GetAll",
            connection);

        command.CommandType = CommandType.StoredProcedure;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            skills.Add(new SkillDto
            {
                SkillId = reader.GetInt32(reader.GetOrdinal("SkillId")),
                Name = reader.GetString(reader.GetOrdinal("Name"))
            });
        }

        return skills;
    }
}