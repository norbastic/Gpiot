using Npgsql;

namespace Gpiot.Helpers;

public class ConnectionStringHelper
{
    public static string GetConnectionString(WebApplicationBuilder builder)
    {
        var hostname = Environment.GetEnvironmentVariable("DB_HOST");
        var database = Environment.GetEnvironmentVariable("DB_DATABASE");
        var username = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        if ( string.IsNullOrEmpty(hostname) || string.IsNullOrEmpty(database) ||
             string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("You must set [DB_HOST], [DB_DATABASE] and "
                                            + "[DB_USER], [DB_PASSWORD] Environtment variables.");
        }
        var connectionStringTemplate = builder.Configuration.GetConnectionString("Default");
        if (string.IsNullOrEmpty(connectionStringTemplate))
        {
            throw new Exception("Could not get connection string template from appsettings.[ENV].json");
        }
        
        var npgsqlBuilder = new NpgsqlConnectionStringBuilder(connectionStringTemplate)
        {
            Host = hostname,
            Database = database,
            Username = username,
            Password = password
        };

        return npgsqlBuilder.ConnectionString;
    }
}