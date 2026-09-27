using System.Data;
using Microsoft.Data.SqlClient;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public class SkillGroupRepository : ISkillGroupRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public SkillGroupRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<SkillGroupDto>> GetSkillGroupsAsync()
    {
        var groups = new Dictionary<int, SkillGroupDto>();

        await using SqlConnection connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using SqlCommand command = new(
            "dbo.usp_SkillGroup_GetAll",
            connection);

        command.CommandType = CommandType.StoredProcedure;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var groupId = reader.GetInt32(
                reader.GetOrdinal("SkillGroupId"));

            if (!groups.TryGetValue(groupId, out var group))
            {
                group = new SkillGroupDto
                {
                    SkillGroupId = groupId,
                    Name = reader.GetString(
                        reader.GetOrdinal("SkillGroupName")),
                    GroupType = reader.GetString(
                        reader.GetOrdinal("GroupType")),
                    DisplayOrder = reader.GetInt32(
                        reader.GetOrdinal("GroupDisplayOrder"))
                };

                groups.Add(groupId, group);
            }

            if (!reader.IsDBNull(reader.GetOrdinal("SkillId")))
            {
                var skillId = reader.GetInt32(
                    reader.GetOrdinal("SkillId"));

                if (!group.Skills.Any(skill => skill.SkillId == skillId))
                {
                    group.Skills.Add(new SkillItemDto
                    {
                        SkillId = skillId,
                        Name = reader.GetString(
                            reader.GetOrdinal("SkillName")),
                        Type = reader.GetString(
                            reader.GetOrdinal("SkillType")),
                        DisplayOrder = reader.GetInt32(
                            reader.GetOrdinal("SkillDisplayOrder"))
                    });
                }
            }

            if (!reader.IsDBNull(reader.GetOrdinal("TechnologyId")))
            {
                var technologyId = reader.GetInt32(
                    reader.GetOrdinal("TechnologyId"));

                if (!group.Technologies.Any(
                    technology => technology.TechnologyId == technologyId))
                {
                    group.Technologies.Add(new TechnologyItemDto
                    {
                        TechnologyId = technologyId,
                        Name = reader.GetString(
                            reader.GetOrdinal("TechnologyName")),
                        Type = reader.GetString(
                            reader.GetOrdinal("TechnologyType")),
                        DisplayOrder = reader.GetInt32(
                            reader.GetOrdinal("TechnologyDisplayOrder"))
                    });
                }
            }
        }

        return groups.Values
            .OrderBy(group => group.DisplayOrder)
            .ToList();
    }
}