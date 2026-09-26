using Microsoft.Data.SqlClient;

namespace Portfolio.Api.Data;

public interface IDbConnectionFactory
{
    SqlConnection CreateConnection();
}