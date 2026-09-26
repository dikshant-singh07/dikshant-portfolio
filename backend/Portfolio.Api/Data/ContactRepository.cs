using Microsoft.Data.SqlClient;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public class ContactRepository : IContactRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ContactRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> CreateContactMessageAsync(
        CreateContactMessageRequest request)
    {
        await using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        await using var command = new SqlCommand(
            "dbo.usp_Contact_Create",
            connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;

        command.Parameters.Add(
            new SqlParameter("@Name", request.Name));

        command.Parameters.Add(
            new SqlParameter("@Email", request.Email));

        command.Parameters.Add(
            new SqlParameter("@Subject", (object?)request.Subject ?? DBNull.Value));

        command.Parameters.Add(
            new SqlParameter("@Message", request.Message));

        var result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result);
    }
}